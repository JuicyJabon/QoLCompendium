using Fargowiltas.Common.Configs;
using QoLCompendium.Content.NPCs.Town.BlackMarketDealer;
using QoLCompendium.Content.NPCs.Town.EtherealCollector;

namespace QoLCompendium.Content.NPCs.Town
{
    [JITWhenModsEnabled(CrossModSupport.Fargowiltas.Name)]
    [ExtendsFromMod(CrossModSupport.Fargowiltas.Name)]
    public class FargoCaughNPCSupport : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => FargoServerConfig.Instance.CatchNPCs && QoLCompendium.crossModConfig.FargosCaughtNPCs;

        public override void Load()
        {
            CrossModSupport.Fargowiltas.Mod.Call("AddCaughtNPC", "BlackMarketDealer", ModContent.NPCType<BMDealerNPC>(), Mod.Name);
            CrossModSupport.Fargowiltas.Mod.Call("AddCaughtNPC", "EtherealCollector", ModContent.NPCType<EtherealCollectorNPC>(), Mod.Name);
        }
    }
}
