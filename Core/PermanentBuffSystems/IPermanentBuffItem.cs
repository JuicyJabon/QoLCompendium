using QoLCompendium.Core.Changes.TooltipChanges;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public abstract class IPermanentBuffItem : ModItem, IComparable
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.PermanentBuffs;

        public int buffIDForSprite = 204;

        public int CompareTo(object obj) => GetType().Name.CompareTo(obj.GetType().Name);

        internal abstract void ApplyBuff(PermanentBuffPlayer player);

        public override string Texture => "Terraria/Images/Buff_" + buffIDForSprite;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Common.SetDefaultsToPermanentBuff(Item);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PermanentBuffs);
        }
    }
}
