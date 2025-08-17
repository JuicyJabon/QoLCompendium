using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.GameContent.Drawing;

namespace QoLCompendium.Core.Changes.TileChanges
{
    public class FastHerbGrowth : ModSystem
    {
        public override void Load()
        {
            IL_WorldGen.GrowAlch += WorldGen_GrowAlch;
            On_TileDrawing.IsAlchemyPlantHarvestable += TileDrawing_IsAlchemyPlantHarvestable;
            On_WorldGen.IsHarvestableHerbWithSeed += WorldGen_IsHarvestableHerbWithSeed;
        }

        public override void Unload()
        {
            IL_WorldGen.GrowAlch -= WorldGen_GrowAlch;
            On_TileDrawing.IsAlchemyPlantHarvestable -= TileDrawing_IsAlchemyPlantHarvestable;
            On_WorldGen.IsHarvestableHerbWithSeed -= WorldGen_IsHarvestableHerbWithSeed;
        }

        public static void WorldGen_GrowAlch(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(MoveType.After, i => i.Match(OpCodes.Call), i => i.Match(OpCodes.Ldc_I4_S)))
                return;
            c.EmitDelegate<Func<int, int>>(num => QoLCompendium.mainConfig.FastHerbGrowth ? 1 : num);
        }


        public static bool TileDrawing_IsAlchemyPlantHarvestable(On_TileDrawing.orig_IsAlchemyPlantHarvestable orig, TileDrawing self, int style)
        {
            return QoLCompendium.mainConfig.FastHerbGrowth || orig.Invoke(self, style);
        }

        private bool WorldGen_IsHarvestableHerbWithSeed(On_WorldGen.orig_IsHarvestableHerbWithSeed orig, int type,
            int style)
        {
            return QoLCompendium.mainConfig.FastHerbGrowth || orig.Invoke(type, style);
        }
    }
}
