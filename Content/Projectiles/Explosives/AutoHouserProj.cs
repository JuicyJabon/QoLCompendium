using QoLCompendium.Core;

namespace QoLCompendium.Content.Projectiles.Explosives
{
    public class AutoHouserProj : ModProjectile
    {
        public override string Texture => "QoLCompendium/Assets/Projectiles/Invisible";

        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.timeLeft = 1;
        }

#pragma warning disable IDE0060
        public static void PlaceHouse(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)(side * -1 + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);
            Tile tile = Main.tile[xPosition, yPosition];

            // Testing for blocks that should not be destroyed
            if (!CheckDestruction.OkayToDestroyTileAt(xPosition, yPosition))
                return;

            int wallID = WallID.Wood;
            int tileID = TileID.WoodBlock;
            int platformID = (int)Common.PlacedPlatformStyles.Wood;
            GetHouseStyle(player, ref wallID, ref tileID, ref platformID);

            int modWallID = WallID.None;
            int modTileID = -1;
            int modPlatformID = -1;
            bool inModdedBiome = false;
            GetModdedHouseStyle(player, ref modWallID, ref modTileID, ref modPlatformID, ref inModdedBiome);

            if (x == 10 * side || x == 1 * side)
            {
                //dont act if the right tile already above (but DO replace a corner platform)
                if (y == -5 && tile.TileType == tileID)
                    return;

                //dont act on correct block above/below door, destroying them will break it
                if ((y == -4 || y == 0) && tile.TileType == tileID)
                    return;

                if ((y == -1 || y == -2 || y == -3) && (tile.TileType == TileID.ClosedDoor || tile.TileType == TileID.OpenDoor))
                    return;
            }
            else //for blocks besides those on the left/right edges where doors are placed, its okay to have platform as floor
            {
                //dont act if the right blocks already above
                if (y == -5 && (tile.TileType == TileID.Platforms || tile.TileType == tileID || tile.TileType == modPlatformID))
                    return;

                if (y == 0 && (tile.TileType == TileID.Platforms || tile.TileType == tileID || tile.TileType == modPlatformID))
                    return;
            }

            //doing it this way so the code still runs to place bg walls behind open door
            if (!((x == 9 * side || x == 2 * side) && (y == -1 || y == -2 || y == -3) && tile.TileType == TileID.OpenDoor))
                Destruction.ClearEverything(xPosition, yPosition);

            // Spawn walls
            if (y != -5 && y != 0 && x != 10 * side && x != 1 * side)
            {
                if (inModdedBiome)
                {
                    WorldGen.PlaceWall(xPosition, yPosition, modWallID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
                else
                {
                    WorldGen.PlaceWall(xPosition, yPosition, wallID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
            }

            //platforms on top
            if (y == -5 && Math.Abs(x) >= 3 && Math.Abs(x) <= 5)
            {
                if (inModdedBiome)
                {
                    WorldGen.PlaceTile(xPosition, yPosition, modPlatformID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, modPlatformID);
                }
                else
                {
                    WorldGen.PlaceTile(xPosition, yPosition, TileID.Platforms, style: platformID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Platforms, platformID);
                }
            }
            // Spawn border
            else if (y == -5 || y == 0 || x == 10 * side || x == 1 * side && y == -4)
            {
                if (inModdedBiome)
                {
                    WorldGen.PlaceTile(xPosition, yPosition, modTileID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
                else
                {
                    WorldGen.PlaceTile(xPosition, yPosition, tileID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
                }
                
            }
        }

        public static void PlaceFurniture(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)(side * -1 + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);

            Tile tile = Main.tile[xPosition, yPosition];
            // Testing for blocks that should not be destroyed
            if (!CheckDestruction.OkayToDestroyTile(tile))
                return;

            int tableTileType = 1;
            int tableStyle = (int)Common.PlacedTableStyles1.Wooden;
            int chairStyle = (int)Common.PlacedChairStyles.Wooden;
            int doorStyle = (int)Common.PlacedDoorStyles.Wooden;
            int torchStyle = (int)Common.PlacedTorchStyles.Torch;
            GetFurnitureStyle(player, ref tableStyle, ref chairStyle, ref doorStyle, ref torchStyle, ref tableTileType);

            int modTableID = -1;
            int modChairID = -1;
            int modDoorID = -1;
            int modTorchID = -1;
            bool inModdedBiome = false;
            GetModdedFurnitureStyle(player, ref modTableID, ref modChairID, ref modDoorID, ref modTorchID, ref inModdedBiome);

            if (y == -1)
            {
                if (Math.Abs(x) == 1)
                {
                    if (inModdedBiome)
                    {
                        WorldGen.PlaceTile(xPosition, yPosition, modDoorID);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, xPosition, yPosition - 2, 1, 3);
                    }
                    else
                    {
                        WorldGen.PlaceTile(xPosition, yPosition, TileID.ClosedDoor, style: doorStyle);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, xPosition, yPosition - 2, 1, 3);
                    }
                }

                if (x == 5 * side)
                {
                    if (inModdedBiome)
                    {
                        if (side == -1 && modChairID == Common.GetModTile(ModConditions.calamityMod, "AcidwoodChairTile"))
                            xPosition += 1;
                        WorldGen.PlaceObject(xPosition, yPosition, modChairID, direction: side);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, modChairID);
                    }
                    else
                    {
                        WorldGen.PlaceObject(xPosition, yPosition, TileID.Chairs, direction: side, style: chairStyle);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Chairs, chairStyle);
                    }
                }

                if (x == 7 * side)
                {
                    if (inModdedBiome)
                    {
                        WorldGen.PlaceTile(xPosition, yPosition, modTableID);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, modTableID);
                    }
                    else
                    {
                        if (tableTileType == 1)
                        {
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables, style: tableStyle);
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Tables, tableStyle);
                        }
                        if (tableTileType == 2)
                        {
                            WorldGen.PlaceTile(xPosition, yPosition, TileID.Tables2, style: tableStyle);
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Tables2, tableStyle);
                        }
                    }
                }
            }

            if (x == 7 * side && y == -4)
            {
                if (inModdedBiome)
                {
                    WorldGen.PlaceTile(xPosition, yPosition, modTorchID);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, modTorchID);
                }
                else
                {
                    WorldGen.PlaceTile(xPosition, yPosition, TileID.Torches, style: torchStyle);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, xPosition, yPosition, TileID.Torches);
                }
            }
        }

        public static void UpdateWall(int x, int y, Vector2 position, int side, Player player)
        {
            int xPosition = (int)(side * -1 + x + position.X / 16.0f);
            int yPosition = (int)(y + position.Y / 16.0f);

            WorldGen.SquareWallFrame(xPosition, yPosition);
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendTileSquare(-1, xPosition, yPosition, 1);
        }

        public override void OnKill(int timeLeft)
        {
            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, position);
            Player player = Main.player[Projectile.owner];

            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            if (player.Center.X < position.X)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int x = 11; x > -1; x--)
                    {
                        if (i != 2 && (x == 11 || x == 0))
                            continue;

                        for (int y = -6; y <= 1; y++)
                        {
                            if (i != 2 && (y == -6 || y == 1))
                                continue;

                            if (i == 0)
                            {
                                PlaceHouse(x, y, position, 1, player);
                            }
                            else if (i == 1)
                            {
                                PlaceFurniture(x, y, position, 1, player);
                            }
                            else
                            {
                                UpdateWall(x, y, position, 1, player);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int x = -11; x < 1; x++)
                    {
                        if (i != 2 && (x == -11 || x == 0))
                            continue;

                        for (int y = -6; y <= 1; y++)
                        {
                            if (i != 2 && (y == -6 || y == 1))
                                continue;

                            if (i == 0)
                            {
                                PlaceHouse(x, y, position, -1, player);
                            }
                            else if (i == 1)
                            {
                                PlaceFurniture(x, y, position, -1, player);
                            }
                        }
                    }
                }
            }
        }

        public static void GetHouseStyle(Player player, ref int wallID, ref int tileID, ref int platformID)
        {
            if (player.ZoneDesert && !player.ZoneBeach)
            {
                wallID = WallID.SmoothSandstone;
                tileID = TileID.SmoothSandstone;
                platformID = (int)Common.PlacedPlatformStyles.Sandstone;
            }
            if (player.ZoneSnow)
            {
                wallID = WallID.BorealWood;
                tileID = TileID.BorealWood;
                platformID = (int)Common.PlacedPlatformStyles.BorealWood;
            }
            if (player.ZoneJungle)
            {
                wallID = WallID.RichMaogany;
                tileID = TileID.RichMahogany;
                platformID = (int)Common.PlacedPlatformStyles.RichMahogany;
            }
            if (player.ZoneCorrupt)
            {
                wallID = WallID.Ebonwood;
                tileID = TileID.Ebonwood;
                platformID = (int)Common.PlacedPlatformStyles.Ebonwood;
            }
            if (player.ZoneCrimson)
            {
                wallID = WallID.Shadewood;
                tileID = TileID.Shadewood;
                platformID = (int)Common.PlacedPlatformStyles.Shadewood;
            }
            if (player.ZoneBeach)
            {
                wallID = WallID.PalmWood;
                tileID = TileID.PalmWood;
                platformID = (int)Common.PlacedPlatformStyles.PalmWood;
            }
            if (player.ZoneHallow)
            {
                wallID = WallID.Pearlwood;
                tileID = TileID.Pearlwood;
                platformID = (int)Common.PlacedPlatformStyles.Pearlwood;
            }
            if (player.ZoneGlowshroom)
            {
                wallID = WallID.Mushroom;
                tileID = TileID.MushroomBlock;
                platformID = (int)Common.PlacedPlatformStyles.Mushroom;
            }
            if (player.ZoneSkyHeight)
            {
                wallID = WallID.DiscWall;
                tileID = TileID.Sunplate;
                platformID = (int)Common.PlacedPlatformStyles.Skyware;
            }
            if (player.ZoneUnderworldHeight)
            {
                wallID = WallID.ObsidianBrick;
                tileID = TileID.ObsidianBrick;
                platformID = (int)Common.PlacedPlatformStyles.Obsidian;
            }
        }

        public static void GetFurnitureStyle(Player player, ref int tableID, ref int chairID, ref int doorID, ref int torchID, ref int tableTile)
        {
            if (player.ZoneDesert && !player.ZoneBeach)
            {
                tableTile = 2;
                tableID = (int)Common.PlacedTableStyles2.Sandstone;
                chairID = (int)Common.PlacedChairStyles.Sandstone;
                doorID = (int)Common.PlacedDoorStyles.Sandstone;
                torchID = (int)Common.PlacedTorchStyles.DesertTorch;
            }
            if (player.ZoneSnow)
            {
                tableID = (int)Common.PlacedTableStyles1.BorealWood;
                chairID = (int)Common.PlacedChairStyles.BorealWood;
                doorID = (int)Common.PlacedDoorStyles.BorealWood;
                torchID = (int)Common.PlacedTorchStyles.IceTorch;
            }
            if (player.ZoneJungle)
            {
                tableID = (int)Common.PlacedTableStyles1.RichMahogany;
                chairID = (int)Common.PlacedChairStyles.RichMahogany;
                doorID = (int)Common.PlacedDoorStyles.RichMahogany;
                torchID = (int)Common.PlacedTorchStyles.JungleTorch;
            }
            if (player.ZoneCorrupt)
            {
                tableID = (int)Common.PlacedTableStyles1.Ebonwood;
                chairID = (int)Common.PlacedChairStyles.Ebonwood;
                doorID = (int)Common.PlacedDoorStyles.Ebonwood;
                torchID = (int)Common.PlacedTorchStyles.CorruptTorch;
            }
            if (player.ZoneCrimson)
            {
                tableID = (int)Common.PlacedTableStyles1.Shadewood;
                chairID = (int)Common.PlacedChairStyles.Shadewood;
                doorID = (int)Common.PlacedDoorStyles.Shadewood;
                torchID = (int)Common.PlacedTorchStyles.CrimsonTorch;
            }
            if (player.ZoneBeach)
            {
                tableID = (int)Common.PlacedTableStyles1.PalmWood;
                chairID = (int)Common.PlacedChairStyles.PalmWood;
                doorID = (int)Common.PlacedDoorStyles.PalmWood;
                torchID = (int)Common.PlacedTorchStyles.CoralTorch;
            }
            if (player.ZoneHallow)
            {
                tableID = (int)Common.PlacedTableStyles1.Pearlwood;
                chairID = (int)Common.PlacedChairStyles.Pearlwood;
                doorID = (int)Common.PlacedDoorStyles.Pearlwood;
                torchID = (int)Common.PlacedTorchStyles.HallowedTorch;
            }
            if (player.ZoneGlowshroom)
            {
                tableID = (int)Common.PlacedTableStyles1.Mushroom;
                chairID = (int)Common.PlacedChairStyles.Mushroom;
                doorID = (int)Common.PlacedDoorStyles.Mushroom;
                torchID = (int)Common.PlacedTorchStyles.MushroomTorch;
            }
            if (player.ZoneSkyHeight)
            {
                tableID = (int)Common.PlacedTableStyles1.Skyware;
                chairID = (int)Common.PlacedChairStyles.Skyware;
                doorID = (int)Common.PlacedDoorStyles.Skyware;
                torchID = (int)Common.PlacedTorchStyles.YellowTorch;
            }
            if (player.ZoneUnderworldHeight)
            {
                tableID = (int)Common.PlacedTableStyles1.Obsidian;
                chairID = (int)Common.PlacedChairStyles.Obsidian;
                doorID = (int)Common.PlacedDoorStyles.Obsidian;
                torchID = (int)Common.PlacedTorchStyles.DemonTorch;
            }
        }

        public static void GetModdedHouseStyle(Player player, ref int wallID, ref int tileID, ref int platformID, ref bool inModdedBiome)
        {
            if (ModConditions.calamityLoaded)
            {
                if (ModConditions.calamityMod.TryFind("AstralInfectionBiome", out ModBiome AstralInfectionBiome) && Main.LocalPlayer.InModBiome(AstralInfectionBiome))
                {
                    wallID = Common.GetModWall(ModConditions.calamityMod, "AstralMonolithWall");
                    tileID = Common.GetModTile(ModConditions.calamityMod, "AstralMonolith");
                    platformID = Common.GetModTile(ModConditions.calamityMod, "MonolithPlatform");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("AbyssLayer1Biome", out ModBiome AbyssLayer1Biome) && Main.LocalPlayer.InModBiome(AbyssLayer1Biome)
                    || ModConditions.calamityMod.TryFind("AbyssLayer2Biome", out ModBiome AbyssLayer2Biome) && Main.LocalPlayer.InModBiome(AbyssLayer2Biome)
                    || ModConditions.calamityMod.TryFind("AbyssLayer3Biome", out ModBiome AbyssLayer3Biome) && Main.LocalPlayer.InModBiome(AbyssLayer3Biome)
                    || ModConditions.calamityMod.TryFind("AbyssLayer4Biome", out ModBiome AbyssLayer4Biome) && Main.LocalPlayer.InModBiome(AbyssLayer4Biome))
                {
                    wallID = Common.GetModWall(ModConditions.calamityMod, "SmoothAbyssGravelWall");
                    tileID = Common.GetModTile(ModConditions.calamityMod, "SmoothAbyssGravel");
                    platformID = Common.GetModTile(ModConditions.calamityMod, "SmoothAbyssGravelPlatform");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("BrimstoneCragsBiome", out ModBiome BrimstoneCragsBiome) && Main.LocalPlayer.InModBiome(BrimstoneCragsBiome))
                {
                    wallID = Common.GetModWall(ModConditions.calamityMod, "SmoothBrimstoneSlagWall");
                    tileID = Common.GetModTile(ModConditions.calamityMod, "SmoothBrimstoneSlag");
                    platformID = Common.GetModTile(ModConditions.calamityMod, "AshenPlatform");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                {
                    wallID = Common.GetModWall(ModConditions.calamityMod, "AcidwoodWall");
                    tileID = Common.GetModTile(ModConditions.calamityMod, "AcidwoodTile");
                    platformID = Common.GetModTile(ModConditions.calamityMod, "AcidwoodPlatformTile");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                {
                    wallID = Common.GetModWall(ModConditions.calamityMod, "SmoothNavystoneWall");
                    tileID = Common.GetModTile(ModConditions.calamityMod, "SmoothNavystone");
                    platformID = Common.GetModTile(ModConditions.calamityMod, "EutrophicPlatform");
                    inModdedBiome = true;
                }
            }
        }

        public static void GetModdedFurnitureStyle(Player player, ref int tableID, ref int chairID, ref int doorID, ref int torchID, ref bool inModdedBiome)
        {
            if (ModConditions.calamityLoaded)
            {
                if (ModConditions.calamityMod.TryFind("AstralInfectionBiome", out ModBiome AstralInfectionBiome) && Main.LocalPlayer.InModBiome(AstralInfectionBiome))
                {
                    tableID = Common.GetModTile(ModConditions.calamityMod, "MonolithTable");
                    chairID = Common.GetModTile(ModConditions.calamityMod, "MonolithChair");
                    doorID = Common.GetModTile(ModConditions.calamityMod, "MonolithDoorClosed");
                    torchID = Common.GetModTile(ModConditions.calamityMod, "AstralTorch");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("AbyssLayer1Biome", out ModBiome AbyssLayer1Biome) && Main.LocalPlayer.InModBiome(AbyssLayer1Biome)
                    || ModConditions.calamityMod.TryFind("AbyssLayer2Biome", out ModBiome AbyssLayer2Biome) && Main.LocalPlayer.InModBiome(AbyssLayer2Biome)
                    || ModConditions.calamityMod.TryFind("AbyssLayer3Biome", out ModBiome AbyssLayer3Biome) && Main.LocalPlayer.InModBiome(AbyssLayer3Biome)
                    || ModConditions.calamityMod.TryFind("AbyssLayer4Biome", out ModBiome AbyssLayer4Biome) && Main.LocalPlayer.InModBiome(AbyssLayer4Biome))
                {
                    tableID = Common.GetModTile(ModConditions.calamityMod, "AbyssTable");
                    chairID = Common.GetModTile(ModConditions.calamityMod, "AbyssChair");
                    doorID = Common.GetModTile(ModConditions.calamityMod, "AbyssDoorClosed");
                    torchID = Common.GetModTile(ModConditions.calamityMod, "AbyssTorch");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("BrimstoneCragsBiome", out ModBiome BrimstoneCragsBiome) && Main.LocalPlayer.InModBiome(BrimstoneCragsBiome))
                {
                    tableID = Common.GetModTile(ModConditions.calamityMod, "AshenTable");
                    chairID = Common.GetModTile(ModConditions.calamityMod, "AshenChair");
                    doorID = Common.GetModTile(ModConditions.calamityMod, "AshenDoorClosed");
                    torchID = Common.GetModTile(ModConditions.calamityMod, "GloomTorch");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("SulphurousSeaBiome", out ModBiome SulphurousSeaBiome) && Main.LocalPlayer.InModBiome(SulphurousSeaBiome))
                {
                    tableID = Common.GetModTile(ModConditions.calamityMod, "AcidwoodTableTile");
                    chairID = Common.GetModTile(ModConditions.calamityMod, "AcidwoodChairTile");
                    doorID = Common.GetModTile(ModConditions.calamityMod, "AcidwoodDoorClosed");
                    torchID = Common.GetModTile(ModConditions.calamityMod, "SulphurousTorch");
                    inModdedBiome = true;
                }

                if (ModConditions.calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                {
                    tableID = Common.GetModTile(ModConditions.calamityMod, "EutrophicTable");
                    chairID = Common.GetModTile(ModConditions.calamityMod, "EutrophicChair");
                    doorID = Common.GetModTile(ModConditions.calamityMod, "EutrophicDoorClosed");
                    torchID = Common.GetModTile(ModConditions.calamityMod, "NavyPrismTorch");
                    inModdedBiome = true;
                }
            }
        }
    }
}
