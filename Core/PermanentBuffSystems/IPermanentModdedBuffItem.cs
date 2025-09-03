using QoLCompendium.Core.Changes.TooltipChanges;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public abstract class IPermanentModdedBuffItem : ModItem, IComparable
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.PermanentBuffs;

        public int CompareTo(object obj) => GetType().Name.CompareTo(obj.GetType().Name);

        internal abstract void ApplyBuff(PermanentBuffPlayer player);

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
            if (Texture == "QoLCompendium/Assets/Items/PermanentBuff")
            {
                TooltipLine name = tooltips.Find(l => l.Name == "ItemName");
                var tooltipAssetNotFound = new TooltipLine(QoLCompendium.instance, "AssetNotFound", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.AssetNotFound"));
                tooltips.AddAfter(name, tooltipAssetNotFound);
            }

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.PermanentBuffs);
        }
    }
}
