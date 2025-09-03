using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Content.Tiles.AutoStructures;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Explosives
{
    public class AutoHouser : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.AutoStructures;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 17;
            Item.height = 13;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.consumable = false;
            Item.createTile = ModContent.TileType<AutoHouserTile>();

            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 0, 50, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.AutoStructures);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.AutoStructures, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Wood, 100);
            r.AddIngredient(ItemID.Torch);
            r.AddTile(TileID.WorkBenches);
            r.Register();
        }

        public override void HoldItem(Player player)
        {
            HandleShadow(player);
        }

        public void HandleShadow(Player player)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<BuildIndicatorProjectile>()] > 50)
                return;

            if (player.direction < 0)
            {
                for (int x = -9; x <= 0; x++)
                {
                    for (int y = -5; y <= 0; y++)
                    {
                        Vector2 mouse = Main.MouseWorld;
                        mouse.X += x * 16;
                        mouse.Y += y * 16;
                        Projectile.NewProjectile(player.GetSource_ItemUse(Item), mouse + new Vector2(0, 16), Vector2.Zero, ModContent.ProjectileType<BuildIndicatorProjectile>(), 0, 0f, player.whoAmI);
                    }
                }
                return;
            }
            for (int x = 0; x <= 9; x++)
            {
                for (int y = -5; y <= 0; y++)
                {
                    Vector2 mouse = Main.MouseWorld;
                    mouse.X += x * 16;
                    mouse.Y += y * 16;
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), mouse + new Vector2(0, 16), Vector2.Zero, ModContent.ProjectileType<BuildIndicatorProjectile>(), 0, 0f, player.whoAmI);
                }
            }
        }
    }
}
