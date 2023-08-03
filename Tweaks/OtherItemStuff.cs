using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class OtherItemStuff : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<QoLCConfig>().NoDevs && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (ModContent.GetInstance<QoLCConfig>().FastExtractor)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0)
                return 1f - ModContent.GetInstance<QoLCConfig>().FastTools;
            return 1f;
        }
    }
}
