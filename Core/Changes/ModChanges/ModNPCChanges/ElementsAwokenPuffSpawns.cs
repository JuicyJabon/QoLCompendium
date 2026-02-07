using ElementsAwoken.Content.NPCs.ItemSets.Puff;
using Terraria.ModLoader.Utilities;

namespace QoLCompendium.Core.Changes.ModChanges.ModNPCChanges
{
    [JITWhenModsEnabled(CrossModSupport.ElementsAwoken.Name)]
    [ExtendsFromMod(CrossModSupport.ElementsAwoken.Name)]
    public class ElementsAwokenPuffSpawns : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
        {
            return entity.type == ModContent.NPCType<Puff>() || entity.type == ModContent.NPCType<SpikedPuff>();
        }

        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneForest && QoLCompendium.crossModConfig.ElementsAwokenPuffSlimes)
            {
                pool.Add(ModContent.NPCType<Puff>(), SpawnCondition.OverworldDaySlime.Chance * 0.15f);
                pool.Add(ModContent.NPCType<SpikedPuff>(), SpawnCondition.OverworldDaySlime.Chance * 0.15f);
            }
        }
    }
}
