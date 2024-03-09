using QoLCompendium.Content.Buffs;
using QoLCompendium.Content.Projectiles.Dedicated;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class LittleEgg : ModItem
    {
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new(Mod, "Dedicated", "Dedicated - Jay")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);
        }

        public override void SetStaticDefaults()
        {
            if (QoLCompendium.itemConfig.DedicatedItems)
            {
                ItemID.Sets.ShimmerTransformToItem[ItemID.RottenEgg] = Item.type;
            }
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.shoot = ModContent.ProjectileType<LittleYagi>();
            Item.buffType = ModContent.BuffType<LittleYagiBuff>();
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }
            return true;
        }
    }
}
