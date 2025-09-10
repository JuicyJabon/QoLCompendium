using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class SpectreMagnet : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Magnets;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 13;
            Item.maxStack = 1;

            Item.SetShopValues(ItemRarityColor.Yellow8, Item.buyPrice(0, 4, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Magnets);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<SoulMagnet>());
            r.AddIngredient(ItemID.SpectreBar, 10);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);
                player.GetModPlayer<MagnetPlayer>().SpectreMagnet = true;
            }
        }
    }
}
