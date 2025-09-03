using QoLCompendium.Content.Projectiles.Fishing;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Fishing
{
    public class LegendaryCatcher : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.LegendaryCatcher;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.CanFishInLava[Item.type] = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.width = 24;
            Item.height = 15;
            Item.UseSound = SoundID.Item1;
            Item.fishingPole = 200;
            Item.shootSpeed = 15f;
            Item.shoot = ModContent.ProjectileType<LegendaryBobber>();
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 10, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.LegendaryCatcher);
        }

        public override void HoldItem(Player player)
        {
            player.accFishingLine = true;
            if (player.ZoneRain)
                player.fishingSkill += 100;
            if (!Main.dayTime)
                player.fishingSkill += 50;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int castAmount = 50;
            if (player.ZoneRain)
                castAmount += 20;
            if (!Main.dayTime)
                castAmount += 10;
            float castShootSpeed = 75f;
            for (int i = 0; i < castAmount; i++)
            {
                float speedx = velocity.X + Utils.NextFloat(Main.rand, 0f - castShootSpeed, castShootSpeed) * 0.05f;
                float speedy = velocity.Y + Utils.NextFloat(Main.rand, 0f - castShootSpeed, castShootSpeed) * 0.05f;
                Projectile.NewProjectile(source, position.X, position.Y, speedx, speedy, type, 0, 0f, player.whoAmI, 0f, 0f, 0f);
            }
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.LegendaryCatcher, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddIngredient(ItemID.Amber, 6);
            r.AddIngredient(ItemID.PlatinumCoin, 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}