using QoLCompendium.Content.Buffs;
using QoLCompendium.Content.Projectiles.Dedicated;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class Lamp : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new(Mod, "Dedicated", "Dedicated - Jack")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.shoot = ModContent.ProjectileType<Moth>();
            Item.buffType = ModContent.BuffType<MothBuff>();
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.DedicatedItems)
            {
                CreateRecipe()
                .AddIngredient(ItemID.PurpleMucos)
                .AddIngredient(ItemID.Wire, 17)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
