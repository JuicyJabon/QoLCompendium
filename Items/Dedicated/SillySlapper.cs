using QoLCompendium.Projectiles;
using QoLCompendium.Tweaks;

namespace QoLCompendium.Items.Dedicated
{
    public class SillySlapper : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new(Mod, "Dedicated", "Dedicated - Quinn")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.width = 14;
            Item.height = 20;
            Item.shoot = ModContent.ProjectileType<SillySlapperWhip>();
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.damage = 100;
            Item.DamageType = DamageClass.Generic;
            Item.knockBack = 2;
            Item.maxStack = 1;
            Item.shootSpeed = 5;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 8);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.DedicatedItems)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Gel, 100)
                .AddIngredient(ItemID.FallenStar, 50)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.GetModPlayer<QoLCPlayer>().sillySlapper = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.GetModPlayer<QoLCPlayer>().sillySlapper = true;
        }
    }
}
