using QoLCompendium.Projectiles;
using Terraria.DataStructures;

namespace QoLCompendium.Items.Dedicated
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

        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.rare = ItemRarityID.Orange;

            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item11;

            Item.knockBack = 7;
            Item.damage = 26;
            Item.DamageType = DamageClass.Ranged;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 16f;
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
