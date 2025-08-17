using QoLCompendium.Content.NPCs;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class CensusSupport : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("Census", out Mod Census))
            {
                if (QoLCompendium.mainConfig.BlackMarketDealerCanSpawn)
                    Census.Call("TownNPCCondition", ModContent.NPCType<BMDealerNPC>(), ModContent.GetInstance<BMDealerNPC>().GetLocalization("Census.SpawnCondition"));
                if (QoLCompendium.mainConfig.EtherealCollectorCanSpawn)
                    Census.Call("TownNPCCondition", ModContent.NPCType<EtherealCollectorNPC>(), ModContent.GetInstance<EtherealCollectorNPC>().GetLocalization("Census.SpawnCondition"));
            }
        }
    }
}
