using QoLCompendium.Content.Projectiles.Dedicated;
using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class SillySlapper : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", "Dedicated - Quinn")
            {
                OverrideColor = Common.ColorSwap(Color.Crimson, Color.Tomato, 2)
            };
            tooltips.Add(dedicated);
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
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
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type);
            r.AddIngredient(ItemID.Gel, 100);
            r.AddIngredient(ItemID.FallenStar, 50);
            r.AddTile(TileID.Anvils);
            r.Register();
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
