using Microsoft.Xna.Framework;
using QoLCompendium.Projectiles;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class RangedAbsolution : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new(Mod, "Dedicated", "Dedicated - Nobisyu")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 7;
            Item.autoReuse = true;
            Item.damage = 30;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<RangedAbsolutionProj>();
            Item.useAmmo = AmmoID.Bullet;
            Item.rare = ItemRarityID.Orange;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<RangedAbsolutionProj>(), damage, knockback, Main.myPlayer, 0);
            return false;
        }

        public override bool RangedPrefix()
        {
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.DedicatedItems)
            {
                CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 10)
                .AddIngredient(ItemID.Obsidian, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
