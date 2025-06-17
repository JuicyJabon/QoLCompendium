using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Mirrors
{
    public class MirrorOfReturn : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Mirrors;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 2, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Mirrors);
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            // Make dust each frame
            if (Main.rand.NextBool())
            {
                Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.1f);
                d.velocity *= 0.5f;
            }

            // Set up itemTime correctly
            if (player.ItemTimeIsZero)
            {
                player.ApplyItemTime(Item);
            }

            if (player.itemTime == player.itemTimeMax / 2)
            {
                // Dust where the player starts
                for (int i = 0; i < 70; i++)
                {
                    Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.5f);
                    d.velocity *= 0.5f;
                }

                // Release grappling hooks
                player.grappling[0] = -1;
                player.grapCount = 0;
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
                    {
                        Main.projectile[i].Kill();
                    }
                }

                // Teleport the player
                player.DoPotionOfReturnTeleportationAndSetTheComebackPoint();

                // Dust where the player appears
                for (int i = 0; i < 70; i++)
                {
                    Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.5f);
                    d.velocity *= 0.5f;
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Mirrors, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Glass, 10);
            r.AddRecipeGroup("QoLCompendium:GoldBars", 8);
            r.AddIngredient(ItemID.PotionOfReturn, 3);
            r.AddTile(TileID.Furnaces);
            r.Register();
        }
    }
}
