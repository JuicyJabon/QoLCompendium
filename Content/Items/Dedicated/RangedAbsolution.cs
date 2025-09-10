using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class RangedAbsolution : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DedicatedItems;

        public int shootType = 0;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            shootType = type;
            return false;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (player.itemAnimation == (int)(player.itemAnimationMax * 0.1) || player.itemAnimation == (int)(player.itemAnimationMax * 0.3) || player.itemAnimation == (int)(player.itemAnimationMax * 0.5) || player.itemAnimation == (int)(player.itemAnimationMax * 0.7) || player.itemAnimation == (int)(player.itemAnimationMax * 0.9))
            {
                float speedY = 0f;
                float speedX = 0f;
                float posY = 0f;
                float posX = 0f;
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.9))
                {
                    speedY = -7f;
                    if (player.direction == -1)
                        posX -= 8f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.7))
                {
                    speedY = -6f;
                    speedX = 2f;
                    if (player.direction == -1)
                        posX -= 6f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.5))
                {
                    speedY = -4f;
                    speedX = 4f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.3))
                {
                    speedY = -2f;
                    speedX = 6f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.1))
                {
                    speedX = 7f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.7))
                {
                    posX = 26f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.3))
                {
                    posX -= 4f;
                    posY -= 20f;
                }
                if (player.itemAnimation == (int)(player.itemAnimationMax * 0.1))
                {
                    posY += 6f;
                }
                speedY *= 1.5f;
                speedX *= 1.5f;
                float direction = posX * player.direction;
                float yDirection = posY * player.gravDir;
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), (hitbox.X + hitbox.Width / 2) + direction, (hitbox.Y + hitbox.Height / 2) + yDirection, player.direction * speedX, speedY * player.gravDir, shootType, Item.damage, 0f, player.whoAmI);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", Language.GetTextValue("Mods.QoLCompendium.DedicatedTooltips.Nobisyu"))
            {
                OverrideColor = Common.ColorSwap(Color.LightSeaGreen, Color.Aquamarine, 3)
            };
            tooltips.Add(dedicated);

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DedicatedItems);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.CrimtaneBar, 10);
            r.AddIngredient(ItemID.Obsidian, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
