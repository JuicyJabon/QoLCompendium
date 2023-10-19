using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class DontBreakHive : ModSystem
    {
        private static bool oldBreak;

        public override void Load()
        {
            oldBreak = Main.tileCut[231];
            if (QoLCompendium.mainConfig.NoLarvaBreak)
            {
                Main.tileCut[231] = false;
            }
        }

        public override void Unload()
        {
            Main.tileCut[231] = oldBreak;
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
}
