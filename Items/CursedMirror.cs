using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class CursedMirror : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().CursedMirror;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (Utils.NextBool(Main.rand))
            {
                Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Yellow, 1.1f);
            }
            if (player.itemTime == 0)
            {
                player.ApplyItemTime(Item, 1f, default);
                return;
            }
            if (player.itemTime == player.itemTimeMax / 2)
            {
                for (int i = 0; i < 70; i++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.5f);
                }
                player.grappling[0] = -1;
                player.grapCount = 0;
                for (int j = 0; j < 1000; j++)
                {
                    if (Main.projectile[j].active && Main.projectile[j].owner == player.whoAmI && Main.projectile[j].aiStyle == 7)
                    {
                        Main.projectile[j].Kill();
                    }
                }
                if (player.lastDeathPostion.X != 0f && player.lastDeathPostion.Y != 0f)
                {
                    Vector2 vector = new(player.lastDeathPostion.X - 16f, player.lastDeathPostion.Y - 24f);
                    player.Teleport(vector, 0, 0);
                }
                else if (player == Main.player[Main.myPlayer])
                {
                    Main.NewText("No sign of recent death appears in the mirror", byte.MaxValue, byte.MaxValue, byte.MaxValue);
                }
                for (int k = 0; k < 70; k++)
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.MagicMirror, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(Condition.InGraveyard);
            recipe.Register();
            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.IceMirror, 1);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.AddCondition(Condition.InGraveyard);
            recipe2.Register();
        }
    }
}
