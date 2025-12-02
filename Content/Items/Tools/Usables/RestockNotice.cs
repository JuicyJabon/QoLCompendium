using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class RestockNotice : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RestockNotice;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 15;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 50, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RestockNotice);
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode is NetmodeID.SinglePlayer)
            {
                Chest.SetupTravelShop();
            }
            if (Main.netMode is NetmodeID.MultiplayerClient)
            {
                Chest.SetupTravelShop();
                NetMessage.SendTravelShop(Main.myPlayer);
            }
            if (Main.netMode is NetmodeID.Server)
            {
                Chest.SetupTravelShop();
                NetMessage.SendTravelShop(Main.myPlayer);
            }

            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.RestockNotice, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Silk, 12);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
