using Terraria.DataStructures;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core
{
    public class Common
    {
        public static readonly List<int> TownSlimeIDs = new(Enumerable.Range(678, 688 - 678)) { 670 };

        public static readonly List<int> PermanentUpgrades = new()
        {
            ItemID.AegisCrystal,
            ItemID.ArcaneCrystal,
            ItemID.AegisFruit,
            ItemID.Ambrosia,
            ItemID.GummyWorm,
            ItemID.GalaxyPearl,
            ItemID.PeddlersSatchel,
            ItemID.ArtisanLoaf,
            ItemID.CombatBook,
            ItemID.CombatBookVolumeTwo,
            ItemID.TorchGodsFavor,
            ItemID.MinecartPowerup
        };

        public static readonly List<int> VanillaBossAndEventSummons = new()
        {
            ItemID.SlimeCrown,
            ItemID.SuspiciousLookingEye,
            ItemID.WormFood,
            ItemID.BloodySpine,
            ItemID.Abeemination,
            ItemID.DeerThing,
            ItemID.QueenSlimeCrystal,
            ItemID.MechanicalWorm,
            ItemID.MechanicalEye,
            ItemID.MechanicalSkull,
            ItemID.MechdusaSummon,
            ItemID.CelestialSigil,
            ItemID.BloodMoonStarter,
            ItemID.GoblinBattleStandard,
            ItemID.PirateMap,
            ItemID.SolarTablet,
            ItemID.SnowGlobe,
            ItemID.PumpkinMoonMedallion,
            ItemID.NaughtyPresent
        };

        public static readonly ushort[] EvilWallIDs = new ushort[47]
        {
            WallID.CorruptGrassEcho,
            WallID.CorruptGrassUnsafe,
            WallID.CrimsonGrassEcho,
            WallID.CrimsonGrassUnsafe,
            WallID.HallowedGrassEcho,
            WallID.HallowedGrassUnsafe,
            WallID.EbonstoneEcho, 
            WallID.EbonstoneUnsafe,
            WallID.CrimstoneEcho,
            WallID.CrimstoneUnsafe,
            WallID.PearlstoneEcho,
            WallID.CorruptHardenedSandEcho,
            WallID.CorruptHardenedSand,
            WallID.CrimsonHardenedSandEcho,
            WallID.CrimsonHardenedSand,
            WallID.HallowHardenedSandEcho,
            WallID.HallowHardenedSand,
            WallID.CorruptSandstoneEcho,
            WallID.CorruptSandstone,
            WallID.CrimsonSandstoneEcho,
            WallID.CrimsonSandstone,
            WallID.HallowSandstoneEcho,
            WallID.HallowSandstone,
            WallID.Corruption1Echo,
            WallID.CorruptionUnsafe1,
            WallID.Corruption2Echo,
            WallID.CorruptionUnsafe2,
            WallID.Corruption3Echo,
            WallID.CorruptionUnsafe3,
            WallID.Corruption4Echo,
            WallID.CorruptionUnsafe4,
            WallID.Crimson1Echo,
            WallID.CrimsonUnsafe1,
            WallID.Crimson2Echo,
            WallID.CrimsonUnsafe2,
            WallID.Crimson3Echo,
            WallID.CrimsonUnsafe3,
            WallID.Crimson4Echo,
            WallID.CrimsonUnsafe4,
            WallID.Hallow1Echo,
            WallID.HallowUnsafe1,
            WallID.Hallow2Echo,
            WallID.HallowUnsafe2,
            WallID.Hallow3Echo,
            WallID.HallowUnsafe3,
            WallID.Hallow4Echo,
            WallID.HallowUnsafe4
        };

        public static readonly ushort[] PureWallIDs = new ushort[47]
        {
            WallID.Grass, 
            WallID.GrassUnsafe, 
            WallID.Grass, 
            WallID.GrassUnsafe, 
            WallID.Grass, 
            WallID.GrassUnsafe, 
            WallID.Stone, 
            WallID.Stone, 
            WallID.Stone, 
            WallID.Stone,
            WallID.Stone, 
            WallID.HardenedSandEcho, 
            WallID.HardenedSand, 
            WallID.HardenedSandEcho, 
            WallID.HardenedSand, 
            WallID.HardenedSandEcho, 
            WallID.HardenedSand, 
            WallID.SandstoneEcho, 
            WallID.Sandstone, 
            WallID.SandstoneEcho,
            WallID.Sandstone, 
            WallID.SandstoneEcho, 
            WallID.Sandstone, 
            WallID.Dirt1Echo, 
            WallID.DirtUnsafe1, 
            WallID.Dirt2Echo, 
            WallID.DirtUnsafe2, 
            WallID.Dirt3Echo, 
            WallID.DirtUnsafe3, 
            WallID.Dirt4Echo, 
            WallID.DirtUnsafe4, 
            WallID.Dirt1Echo, 
            WallID.DirtUnsafe1, 
            WallID.Dirt2Echo, 
            WallID.DirtUnsafe2, 
            WallID.Dirt3Echo, 
            WallID.DirtUnsafe3, 
            WallID.Dirt4Echo, 
            WallID.DirtUnsafe4, 
            WallID.Dirt1Echo, 
            WallID.DirtUnsafe1, 
            WallID.Dirt2Echo, 
            WallID.DirtUnsafe2, 
            WallID.Dirt3Echo, 
            WallID.DirtUnsafe3, 
            WallID.Dirt4Echo, 
            WallID.DirtUnsafe4
        };

        public static readonly HashSet<TileDefinition> DefaultVeinMinerWhitelist = new()
        {
            new TileDefinition(TileID.Copper),
            new TileDefinition(TileID.Tin),
            new TileDefinition(TileID.Iron),
            new TileDefinition(TileID.Lead),
            new TileDefinition(TileID.Silver),
            new TileDefinition(TileID.Tungsten),
            new TileDefinition(TileID.Gold),
            new TileDefinition(TileID.Platinum),
            new TileDefinition(TileID.Meteorite),
            new TileDefinition(TileID.Demonite),
            new TileDefinition(TileID.Crimtane),
            new TileDefinition(TileID.Obsidian),
            new TileDefinition(TileID.Hellstone),
            new TileDefinition(TileID.Cobalt),
            new TileDefinition(TileID.Palladium),
            new TileDefinition(TileID.Mythril),
            new TileDefinition(TileID.Orichalcum),
            new TileDefinition(TileID.Adamantite),
            new TileDefinition(TileID.Titanium),
            new TileDefinition(TileID.Chlorophyte),
            new TileDefinition(TileID.LunarOre),
            new TileDefinition(TileID.Amethyst),
            new TileDefinition(TileID.Topaz),
            new TileDefinition(TileID.Sapphire),
            new TileDefinition(TileID.Emerald),
            new TileDefinition(TileID.Ruby),
            new TileDefinition(TileID.Diamond),
            new TileDefinition(TileID.Silt),
            new TileDefinition(TileID.Slush),
            new TileDefinition(TileID.DesertFossil)
        };

        public static readonly List<int> PowerUpItems = new()
        {
            ItemID.Heart,
            ItemID.CandyApple,
            ItemID.CandyCane,
            ItemID.Star,
            ItemID.SoulCake,
            ItemID.SugarPlum,
            ItemID.NebulaPickup1,
            ItemID.NebulaPickup2,
            ItemID.NebulaPickup3,
        };

        #region Boss Drops
        public static readonly int[] kingSlimeDrops = { 
            ItemID.SlimySaddle,
            ItemID.NinjaHood,
            ItemID.NinjaShirt,
            ItemID.NinjaPants,
            ItemID.SlimeHook,
            ItemID.SlimeGun
        };

        public static readonly int[] eyeOfCthulhuDrops = { ItemID.Binoculars };

        public static readonly int[] eaterOfWorldsDrops = { ItemID.EatersBone };

        public static readonly int[] brainOfCthulhuDrops = { ItemID.BoneRattle };

        public static readonly int[] queenBeeDrops = {
            ItemID.BeeGun,
            ItemID.BeeKeeper,
            ItemID.BeesKnees,
            ItemID.HiveWand,
            ItemID.BeeHat,
            ItemID.BeeShirt,
            ItemID.BeePants,
            ItemID.HoneyComb,
            ItemID.Nectar,
            ItemID.HoneyedGoggles
        };

        public static readonly int[] deerclopsDrops = {
            ItemID.ChesterPetItem,
            ItemID.Eyebrella,
            ItemID.DontStarveShaderItem,
            ItemID.DizzyHat,
            ItemID.PewMaticHorn,
            ItemID.WeatherPain,
            ItemID.HoundiusShootius,
            ItemID.LucyTheAxe
        };

        public static readonly int[] skeletronDrops = {
            ItemID.SkeletronHand,
            ItemID.BookofSkulls,
            ItemID.ChippysCouch
        };

        public static readonly int[] wallOfFleshDrops = {
            ItemID.BreakerBlade,
            ItemID.ClockworkAssaultRifle,
            ItemID.LaserRifle,
            ItemID.FireWhip,
            ItemID.WarriorEmblem,
            ItemID.RangerEmblem,
            ItemID.SorcererEmblem,
            ItemID.SummonerEmblem
        };

        public static readonly int[] queenSlimeDrops = {
            ItemID.CrystalNinjaHelmet,
            ItemID.CrystalNinjaChestplate,
            ItemID.CrystalNinjaLeggings,
            ItemID.Smolstar,
            ItemID.QueenSlimeMountSaddle,
            ItemID.QueenSlimeHook
        };

        public static readonly int[] planteraDrops = {
            ItemID.GrenadeLauncher,
            ItemID.VenusMagnum,
            ItemID.NettleBurst,
            ItemID.LeafBlower,
            ItemID.FlowerPow,
            ItemID.WaspGun,
            ItemID.Seedler,
            ItemID.PygmyStaff,
            ItemID.ThornHook,
            ItemID.TheAxe,
            ItemID.Seedling
        };

        public static readonly int[] golemDrops = {
            ItemID.Picksaw,
            ItemID.Stynger,
            ItemID.PossessedHatchet,
            ItemID.SunStone,
            ItemID.EyeoftheGolem,
            ItemID.HeatRay,
            ItemID.StaffofEarth,
            ItemID.GolemFist
        };

        public static readonly int[] betsyDrops = {
            ItemID.BetsyWings,
            ItemID.DD2BetsyBow,
            ItemID.MonkStaffT3,
            ItemID.ApprenticeStaffT3,
            ItemID.DD2SquireBetsySword
        };

        public static readonly int[] dukeFishronDrops = {
            ItemID.FishronWings,
            ItemID.BubbleGun,
            ItemID.Flairon,
            ItemID.RazorbladeTyphoon,
            ItemID.TempestStaff,
            ItemID.Tsunami
        };

        public static readonly int[] empressOfLightDrops = {
            ItemID.FairyQueenMagicItem,
            ItemID.PiercingStarlight,
            ItemID.RainbowWhip,
            ItemID.FairyQueenRangedItem,
            ItemID.RainbowWings,
            ItemID.SparkleGuitar,
            ItemID.RainbowCursor
        };

        public static readonly int[] moonLordDrops = {
            ItemID.Meowmere,
            ItemID.Terrarian,
            ItemID.StarWrath,
            ItemID.SDMG,
            ItemID.Celeb2,
            ItemID.LastPrism,
            ItemID.LunarFlareBook,
            ItemID.RainbowCrystalStaff,
            ItemID.MoonlordTurretStaff,
            ItemID.MeowmereMinecart,
        };
        #endregion

        public static Color ColorSwap(Color firstColor, Color secondColor, float seconds)
        {
            float num = (float)((Math.Sin(Math.PI * 2.0 / (double)seconds * Main.GlobalTimeWrappedHourly) + 1.0) * 0.5);
            return Color.Lerp(firstColor, secondColor, num);
        }

        public interface IRightClickOverrideWhenHeld
        {
            bool RightClickOverrideWhileHeld(ref Item heldItem, Item[] inv, int context, int slot, Player player, QoLCPlayer qPlayer);
        }

        public static int GetModItem(Mod mod, string itemName)
        {
            if (mod != null)
            {
                if (mod.TryFind(itemName, out ModItem currItem) && currItem != null)
                {
                    return currItem.Type;
                }
            }
            return ItemID.None;
        }

        public static int GetModProjectile(Mod mod, string projName)
        {
            if (mod != null)
            {
                if (mod.TryFind(projName, out ModProjectile currProj) && currProj != null)
                {
                    return currProj.Type;
                }
            }
            return ProjectileID.None;
        }

        public static int GetModNPC(Mod mod, string npcName)
        {
            if (mod != null)
            {
                if (mod.TryFind(npcName, out ModNPC currNPC) && currNPC != null)
                {
                    return currNPC.Type;
                }
            }
            return NPCID.None;
        }

        public static int GetModTile(Mod mod, string tileName)
        {
            if (mod != null)
            {
                if (mod.TryFind(tileName, out ModTile currTile) && currTile != null)
                {
                    return currTile.Type;
                }
            }
            return -1;
        }

        public static int GetModBuff(Mod mod, string buffName)
        {
            if (mod != null)
            {
                if (mod.TryFind(buffName, out ModBuff currBuff) && currBuff != null)
                {
                    return currBuff.Type;
                }
            }
            return -1;
        }

        public static int GetModPrefix(Mod mod, string prefixName)
        {
            if (mod != null)
            {
                if (mod.TryFind(prefixName, out ModPrefix currPrefix) && currPrefix != null)
                {
                    return currPrefix.Type;
                }
            }
            return -1;
        }

        public static void CreateBagRecipe(int[] items, int bagID)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.BossBagRecipes, items[i]);
                recipe.AddIngredient(bagID);
                recipe.AddTile(TileID.Solidifier);
                recipe.Register();
            }
        }

        public static void CreateCrateRecipe(int item, int crateID, int crateHardmodeID, int crateCount)
        {
            Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.CrateRecipes, item);
            recipe.AddIngredient(crateID, crateCount);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.CrateRecipes, item);
            recipe.AddIngredient(crateHardmodeID, crateCount);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }

        public static void CreateCrateHardmodeRecipe(int item, int crateHardmodeID, int crateCount)
        {
            Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.CrateRecipes, item);
            recipe.AddIngredient(crateHardmodeID, crateCount);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }

        public static void CreateCrateWithKeyRecipe(int item, int crateID, int crateHardmodeID, int crateCount, int keyID)
        {
            Recipe recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.CrateRecipes, item);
            recipe.AddIngredient(crateID, crateCount);
            recipe.AddIngredient(keyID);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();

            recipe = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.CrateRecipes, item);
            recipe.AddIngredient(crateHardmodeID, crateCount);
            recipe.AddIngredient(keyID);
            recipe.AddTile(TileID.Solidifier);
            recipe.Register();
        }

        public static void ConversionRecipe(int item1, int item2, int station)
        {
            //Item 1 -> Item 2
            Recipe convertTo = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.ItemConversions, item1);
            convertTo.AddIngredient(item2);
            convertTo.AddTile(station);
            convertTo.Register();
            //Item 2 -> Item 1
            convertTo = ModConditions.GetItemRecipe(() => QoLCompendium.mainServerConfig.ItemConversions, item2);
            convertTo.AddIngredient(item1);
            convertTo.AddTile(station);
            convertTo.Register();
        }

        public static Point16 PlayerCenterTile(Player player)
        {
            return new Point16((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f));
        }

        public static int PlayerCenterTileX(Player player)
        {
            return (int)(player.Center.X / 16f);
        }

        public static int PlayerCenterTileY(Player player)
        {
            return (int)(player.Center.Y / 16f);
        }

        public static bool InGameWorldLeft(int x)
        {
            return x > 39;
        }

        public static bool InGameWorldRight(int x)
        {
            return x < Main.maxTilesX - 39;
        }

        public static bool InGameWorldTop(int y)
        {
            return y > 39;
        }

        public static bool InGameWorldBottom(int y)
        {
            return y < Main.maxTilesY - 39;
        }

        public static bool InGameWorld(int x, int y)
        {
            return x > 39 && x < Main.maxTilesX - 39 && y > 39 && y < Main.maxTilesY - 39;
        }

        public static bool InWorldLeft(int x)
        {
            return x >= 0;
        }

        public static bool InWorldRight(int x)
        {
            return x < Main.maxTilesX;
        }

        public static bool InWorldTop(int y)
        {
            return y >= 0;
        }

        public static bool InWorldBottom(int y)
        {
            return y < Main.maxTilesY;
        }

        public static bool InWorld(int x, int y)
        {
            return x >= 0 && x < Main.maxTilesX && y >= 0 && y < Main.maxTilesY;
        }

        public static int CoordsX(int x)
        {
            return x * 2 - Main.maxTilesX;
        }

        public static int CoordsY(int y)
        {
            return y * 2 - (int)Main.worldSurface * 2;
        }

        public static string CoordsString(int x, int y)
        {
            x = x * 2 - Main.maxTilesX;
            y = y * 2 - (int)Main.worldSurface * 2;
            string text = x < 0 ? " west, " : " east, ";
            string text2 = y < 0 ? " surface." : " underground.";
            x = x < 0 ? x * -1 : x;
            y = y < 0 ? y * -1 : y;
            return x.ToString() + text + y.ToString() + text2;
        }

        public static void TileSafe(int x, int y)
        {
            if (x < 0 || y < 0 || x > Main.ActiveWorldFileData.WorldSizeX || y > Main.ActiveWorldFileData.WorldSizeY)
            {
                return;
            }
            if (Main.tile[x, y] == null)
            {
                Main.tile[x, y].ResetToType(0);
            }
        }

        public static bool TileNull(int x, int y)
        {
            return Main.tile[x, y] == null;
        }

        public static bool SolidTile(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            return !TileNull(x, y) && tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType] && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid && !tile.IsActuated;
        }

        public static bool SearchBelow(Player player, Func<int, int, bool> toSearch, int gap)
        {
            int num = PlayerCenterTileX(player);
            int num2 = PlayerCenterTileY(player);
            int num3 = 0;
            while (InGameWorldLeft(num - num3) || InGameWorldRight(num + num3))
            {
                int num4 = num2;
                while (InGameWorldBottom(num4))
                {
                    int num5 = num - num3;
                    int num6 = num + num3;
                    if (InGameWorldLeft(num5))
                    {
                        TileSafe(num5, num4);
                        if (toSearch.Invoke(num5, num4))
                        {
                            return true;
                        }
                    }
                    if (InGameWorldRight(num6))
                    {
                        TileSafe(num6, num4);
                        if (toSearch.Invoke(num6, num4))
                        {
                            return true;
                        }
                    }
                    num4 += gap;
                }
                num3 += gap;
            }
            return false;
        }
    }
}
