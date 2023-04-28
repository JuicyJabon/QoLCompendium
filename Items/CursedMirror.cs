using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace QoLCompendium.Items
{
    // Token: 0x0200001E RID: 30
    public class CursedMirror : ModItem
    {
        // Token: 0x060000BD RID: 189 RVA: 0x0000F59E File Offset: 0x0000D79E
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().CursedMirror;
        }

        // Token: 0x060000BE RID: 190 RVA: 0x0000F5AA File Offset: 0x0000D7AA
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gaze into the mirror to materialize at your last death");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000BF RID: 191 RVA: 0x0000F5D2 File Offset: 0x0000D7D2
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
        }

        // Token: 0x060000C0 RID: 192 RVA: 0x0000F5E4 File Offset: 0x0000D7E4
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

        // Token: 0x060000C1 RID: 193 RVA: 0x0000F7E8 File Offset: 0x0000D9E8
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(ItemID.MagicMirror, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddCondition(Recipe.Condition.InGraveyardBiome);
            recipe.Register();
            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(ItemID.IceMirror, 1);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.AddCondition(Recipe.Condition.InGraveyardBiome);
            recipe2.Register();
        }
    }
}
