using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.UI.ShopExpander
{
    internal class ArrowItem : ModItem
    {
        private string CustomName { get; }

        public override string Name => CustomName;

        protected override bool CloneNewInstances => true;

        public ArrowItem(string customName)
        {
            CustomName = customName;
        }

        public override void AutoStaticDefaults()
        {
            //Stop automatic texture and display name assignment
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 1;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
        }

        public override bool OnPickup(Player player)
        {
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.RemoveAll(x => !(x.Mod == "Terraria" && x.Name == "ItemName"));
        }
    }
}
