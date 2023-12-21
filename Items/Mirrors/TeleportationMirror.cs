namespace QoLCompendium.Items.Mirrors
{
    public class TeleportationMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.rare = ItemRarityID.Orange;
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
                player.TeleportationPotion();

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
            if (QoLCompendium.itemConfig.Mirrors)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Glass, 3)
                .AddIngredient(ItemID.TeleportationPotion, 5)
                .AddRecipeGroup(RecipeGroupID.IronBar, 4)
                .AddTile(TileID.Tombstones)
                .Register();
            }
        }
    }
}
