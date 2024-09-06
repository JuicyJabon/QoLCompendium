using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class RangedAbsolution : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            
            Item.damage = 26;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 7;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 16f;

            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 4, 0, 0));
        }

        public override bool RangedPrefix() => true;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", "Dedicated - Nobisyu")
            {
                OverrideColor = Common.ColorSwap(Color.Crimson, Color.Tomato, 2)
            };
            tooltips.Add(dedicated);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type);
            r.AddIngredient(ItemID.CrimtaneBar, 10);
            r.AddIngredient(ItemID.Obsidian, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
