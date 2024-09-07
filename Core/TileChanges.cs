using Mono.Cecil.Cil;
using MonoMod.Cil;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Drawing;
using Terraria.Utilities;

namespace QoLCompendium.Core
{
    public class DontBreakHive : ModSystem
    {
        private static bool oldBreak;

        public override void Load()
        {
            oldBreak = Main.tileCut[TileID.Larva];
            if (QoLCompendium.mainConfig.NoLarvaBreak)
            {
                Main.tileCut[TileID.Larva] = false;
            }
        }

        public override void Unload()
        {
            Main.tileCut[TileID.Larva] = oldBreak;
        }
    }

    public class FastTreeGrowth : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            if (!QoLCompendium.mainConfig.FastTrees || !Main.tile[i, j].HasTile)
            {
                return;
            }
            for (int time = 0; time < 4; time++)
            {
                switch (type)
                {
                    case TileID.Saplings:
                        if ((Main.tile[i, j].TileFrameX < 324 || Main.tile[i, j].TileFrameX >= 540) ? WorldGen.GrowTree(i, j) : WorldGen.GrowPalmTree(i, j) && WorldGen.PlayerLOS(i, j))
                            WorldGen.TreeGrowFXCheck(i, j);
                        return;
                    case TileID.VanityTreeSakuraSaplings:
                    case TileID.VanityTreeWillowSaplings:
                        if (WorldGen.genRand.NextBool(5) && WorldGen.TryGrowingTreeByType(type + 1, i, j) && WorldGen.PlayerLOS(i, j))
                            WorldGen.TreeGrowFXCheck(i, j);
                        return;
                    case TileID.GemSaplings:
                        if (WorldGen.genRand.NextBool(5))
                        {
                            int style = Main.tile[i, j].TileFrameX / 54;
                            int treeTileType = TileID.TreeTopaz + style;

                            if (WorldGen.TryGrowingTreeByType(treeTileType, i, j) && WorldGen.PlayerLOS(i, j))
                                WorldGen.TreeGrowFXCheck(i, j);
                        }
                        return;
                }
                if (TileID.Sets.TreeSapling[type])
                {
                    TileLoader.GetTile(type)?.RandomUpdate(i, j);
                }
            }
        }
    }

    public class FastHerbGrowth : ModSystem
    {
        private static int _herbStyle;
        private static int _herbType;

        public override void Load()
        {
            if (QoLCompendium.mainConfig.FastHerbs)
            {
                IL_WorldGen.GrowAlch += WorldGen_GrowAlch;
                On_TileDrawing.IsAlchemyPlantHarvestable += TileDrawing_IsAlchemyPlantHarvestable;
                IL_Player.PlaceThing_Tiles_BlockPlacementForAssortedThings += Player_PlaceThing_Tiles_BlockPlacementForAssortedThings;
                On_WorldGen.IsHarvestableHerbWithSeed += WorldGen_IsHarvestableHerbWithSeed;
            }
        }

        public override void Unload()
        {
            IL_WorldGen.GrowAlch -= WorldGen_GrowAlch;
            On_TileDrawing.IsAlchemyPlantHarvestable -= TileDrawing_IsAlchemyPlantHarvestable;
            IL_Player.PlaceThing_Tiles_BlockPlacementForAssortedThings -= Player_PlaceThing_Tiles_BlockPlacementForAssortedThings;
            On_WorldGen.IsHarvestableHerbWithSeed -= WorldGen_IsHarvestableHerbWithSeed;
        }

        private void WorldGen_GrowAlch(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Call),
                    i => i.Match(OpCodes.Ldc_I4_S)))
                return;
            c.EmitDelegate<Func<int, int>>(num => QoLCompendium.mainConfig.FastHerbs ? 1 : num);
        }


        private bool TileDrawing_IsAlchemyPlantHarvestable(On_TileDrawing.orig_IsAlchemyPlantHarvestable orig,
            TileDrawing self, int style)
        {
            return QoLCompendium.mainConfig.FastHerbs || orig.Invoke(self, style);
        }

        private bool WorldGen_IsHarvestableHerbWithSeed(On_WorldGen.orig_IsHarvestableHerbWithSeed orig, int type,
            int style)
        {
            return QoLCompendium.mainConfig.FastHerbs || orig.Invoke(type, style);
        }

        private static void Player_PlaceThing_Tiles_BlockPlacementForAssortedThings(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Ldc_I4_S, (sbyte)84),
                    i => i.Match(OpCodes.Bne_Un_S)))
                return;
            c.EmitDelegate(() =>
            {
                if (QoLCompendium.mainConfig.RegrowthAutoReplant)
                {
                    var tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                    _herbStyle = tile.TileFrameX / 18;
                    _herbType = tile.TileType;
                }
            });

            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Ldc_I4_0),
                    i => i.Match(OpCodes.Ldc_I4_0),
                    i => i.Match(OpCodes.Ldc_I4_0),
                    i => i.Match(OpCodes.Call)))
                return;
            c.EmitDelegate(() =>
            {
                if (!QoLCompendium.mainConfig.RegrowthAutoReplant ||
                    _herbType is not TileID.BloomingHerbs and not TileID.MatureHerbs)
                    return;

                WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.ImmatureHerbs, true, false, -1,
                    _herbStyle);
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY,
                    TileID.ImmatureHerbs, _herbStyle);
            });

            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Ldc_R8, 40500d),
                    i => i.Match(OpCodes.Ble_Un_S),
                    i => i.Match(OpCodes.Ldc_I4_1),
                    i => i.Match(OpCodes.Stloc_S),
                    i => i.Match(OpCodes.Ldloc_S)))
                return;
            c.EmitDelegate<Func<bool, bool>>(flag =>
            {
                if (QoLCompendium.mainConfig.RegrowthAutoReplant)
                {
                    var tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
                    _herbStyle = tile.TileFrameX / 18;
                    _herbType = tile.TileType;
                }

                return QoLCompendium.mainConfig.FastHerbs || flag;
            });

            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Ldc_R4),
                    i => i.Match(OpCodes.Ldc_I4_0),
                    i => i.Match(OpCodes.Ldc_I4_0),
                    i => i.Match(OpCodes.Ldc_I4_0),
                    i => i.Match(OpCodes.Call)))
                return;
            c.EmitDelegate(() =>
            {
                if (!QoLCompendium.mainConfig.RegrowthAutoReplant ||
                    _herbType is not TileID.BloomingHerbs and not TileID.MatureHerbs)
                    return;

                WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, TileID.ImmatureHerbs, true, false, -1,
                    _herbStyle);
                NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY,
                    TileID.ImmatureHerbs, _herbStyle);
            });
        }
    }

    public class TreeDrops : ModSystem
    {
        public override void Load()
        {
            On_WorldGen.SetGemTreeDrops += GemAlways;
            ShakeTreeTweak.Load();
        }

        public override void Unload()
        {
            On_WorldGen.SetGemTreeDrops -= GemAlways;
        }

        private void GemAlways(On_WorldGen.orig_SetGemTreeDrops orig, int gemType, int seedType, Tile tileCache, ref int dropItem, ref int secondaryItem)
        {
            if (QoLCompendium.mainConfig.TreesDropMore)
            {
                dropItem = gemType;
                secondaryItem = seedType;
            }
            else
            {
                orig.Invoke(gemType, seedType, tileCache, ref dropItem, ref secondaryItem);
            }
        }

        private class ShakeTreeTweak
        {
            private class ShakeTreeItem : GlobalItem
            {
                public override void OnSpawn(Item item, IEntitySource source)
                {
                    if (_isShakingTree && source is EntitySource_ShakeTree)
                        _hasItemDropped = true;
                }
            }

            private static bool _isShakingTree;
            private static bool _hasItemDropped; // 检测是否在摇树过程中有物品掉落

            public static void Load()
            {
                FieldInfo numShakes = typeof(WorldGen).GetField("numTreeShakes", BindingFlags.NonPublic | BindingFlags.Static);
                FieldInfo maxShakes = typeof(WorldGen).GetField("maxTreeShakes", BindingFlags.NonPublic | BindingFlags.Static);

                FieldInfo shakeX = typeof(WorldGen).GetField("treeShakeX", BindingFlags.NonPublic | BindingFlags.Static);
                FieldInfo shakeY = typeof(WorldGen).GetField("treeShakeY", BindingFlags.NonPublic | BindingFlags.Static);

                On_WorldGen.ShakeTree += (orig, i, j) =>
                {
                    if (!QoLCompendium.mainConfig.TreesDropMore)
                    {
                        orig(i, j);
                        return;
                    }

                    _isShakingTree = true;
                    _hasItemDropped = false;

                    bool treeShaken = false;

                    WorldGen.GetTreeBottom(i, j, out var x, out var y);
                    for (int k = 0; k < (int)numShakes.GetValue(null); k++)
                    {
                        if (shakeX.GetValue(null).Equals(k) && shakeY.GetValue(null).Equals(k))
                        {
                            treeShaken = true;
                            break;
                        }
                    }

                    orig(i, j);

                    _isShakingTree = false;

                    if ((int)numShakes.GetValue(null) == (int)maxShakes.GetValue(null) || _hasItemDropped || treeShaken)
                        return;

                    TreeTypes treeType = WorldGen.GetTreeType(Main.tile[x, y].TileType);
                    if (treeType == TreeTypes.None)
                        return;

                    y--;
                    while (y > 10 && Main.tile[x, y].HasTile && TileID.Sets.IsShakeable[Main.tile[x, y].TileType])
                    {
                        y--;
                    }

                    y++;
                    if (!WorldGen.IsTileALeafyTreeTop(x, y) || Collision.SolidTiles(x - 2, x + 2, y - 2, y + 2))
                        return;

                    int fruit = GetShakeTreeFruit(treeType);
                    if (fruit > -1)
                        Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, fruit);
                };
            }
        }

        public static int GetShakeTreeFruit(TreeTypes treeType)
        {
            switch (treeType)
            {
                case TreeTypes.Forest:
                    WeightedRandom<short> weightedRandom = new();
                    weightedRandom.Add(ItemID.Apple);
                    weightedRandom.Add(ItemID.Apricot);
                    weightedRandom.Add(ItemID.Peach);
                    weightedRandom.Add(ItemID.Grapefruit);
                    weightedRandom.Add(ItemID.Lemon);
                    return weightedRandom.Get();
                case TreeTypes.Snow:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.Plum : ItemID.Cherry;
                case TreeTypes.Jungle:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.Mango : ItemID.Pineapple;
                case TreeTypes.Palm or TreeTypes.PalmCorrupt or TreeTypes.PalmCrimson or TreeTypes.PalmHallowed:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.Coconut : ItemID.Banana;
                case TreeTypes.Corrupt or TreeTypes.PalmCorrupt:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.Elderberry : ItemID.BlackCurrant;
                case TreeTypes.Crimson or TreeTypes.PalmCrimson:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.BloodOrange : ItemID.Rambutan;
                case TreeTypes.Hallowed or TreeTypes.PalmHallowed:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.Dragonfruit : ItemID.Starfruit;
                case TreeTypes.Ash:
                    return (!WorldGen.genRand.NextBool(2)) ? ItemID.SpicyPepper : ItemID.Pomegranate;
                default:
                    return -1;
            }
        }
    }

    public class NoPylonRestrictions : GlobalPylon
    {
        public override bool? ValidTeleportCheck_PreAnyDanger(TeleportPylonInfo pylonInfo)
        {
            if (QoLCompendium.mainConfig.NoPylonRestriction)
                return true;
            return null;
        }
        public override bool? ValidTeleportCheck_PreNPCCount(TeleportPylonInfo pylonInfo, ref int defaultNecessaryNPCCount)
        {
            if (QoLCompendium.mainConfig.NoPylonRestriction)
                return true;
            return null;
        }
    }
}
