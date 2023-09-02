using QoLCompendium.Tweaks;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class Magnet : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().Magnet;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 1);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<Magnet>(), 1).AddRecipeGroup(RecipeGroupID.IronBar, 7).AddIngredient(ItemID.Sapphire, 1).AddIngredient(ItemID.Ruby, 1).AddTile(TileID.Anvils).Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().magnetActive = true;

                if (player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < Main.maxItems; i++)
                    {
                        Item item = Main.item[i];

                        if (!item.active || item.noGrabDelay != 0 || item.playerIndexTheItemIsReservedFor != player.whoAmI)
                        {
                            continue;
                        }

                        item.beingGrabbed = true;
                        item.Center = player.Center;
                    }
                }
            }
        }
    }
}
