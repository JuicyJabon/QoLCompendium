﻿using QoLCompendium.Content.Projectiles.Explosives;
using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Explosives
{
    public class Minibridge : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.AutoStructures;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 17;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<MinibridgeProj>();
            Item.shootSpeed = 5f;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.AutoStructures);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 mouse = Main.MouseWorld;
            Projectile.NewProjectile(player.GetSource_ItemUse(source.Item), mouse, Vector2.Zero, type, 0, 0, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AutoStructures, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Wood, 10);
            r.AddIngredient(ItemID.Dynamite, 1);
            r.AddIngredient(ItemID.Diamond, 2);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void HoldItem(Player player)
        {
            HandleShadow(player);
        }

        public void HandleShadow(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<BuildIndicatorProjectile>()] > 200)
                return;

            for (int i = -100; i <= 100; i++)
            {
                Vector2 mouse = Main.MouseWorld;
                mouse.X += i * 16;
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), mouse, Vector2.Zero, ModContent.ProjectileType<BuildIndicatorProjectile>(), 0, 0f, player.whoAmI);
            }
        }
    }
}
