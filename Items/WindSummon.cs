using Microsoft.Xna.Framework;
using QoLCompendium.UI;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class WindSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 1;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return Main.windSpeedTarget <= 0.4f;
        }

        public override bool? UseItem(Player player)
        {
            Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);
            TextHelper.PrintText("The wind has been stirred", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Cloud, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
