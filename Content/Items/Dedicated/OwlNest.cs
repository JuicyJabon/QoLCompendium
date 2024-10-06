using QoLCompendium.Content.Buffs;
using QoLCompendium.Content.Projectiles.Dedicated;
using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class OwlNest : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);

            Item.shoot = ModContent.ProjectileType<Owl>();
            Item.buffType = ModContent.BuffType<OwlBuff>();

            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<OwlBuff>()))
            {
                return false;
            }
            return base.CanUseItem(player);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", "Dedicated - Ned")
            {
                OverrideColor = Common.ColorSwap(Color.Crimson, Color.Tomato, 2)
            };
            tooltips.Add(dedicated);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type);
            r.AddIngredient(ItemID.Wood, 12);
            r.AddIngredient(ItemID.Cobweb, 7);
            r.AddIngredient(ItemID.Vine, 2);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
