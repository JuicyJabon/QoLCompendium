using Microsoft.Xna.Framework;
using QoLCompendium.UI;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class RainSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 1;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 13;
            Item.height = 15;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.IsItRaining && !Main.IsItStorming;
        }

        public override bool? UseItem(Player player)
        {
            LanternNight.GenuineLanterns = false;
            LanternNight.ManualLanterns = false;

            //sets rain time to 12 hours
            int day = 86400;
            int hour = day / 24;
            Main.rainTime = hour * 12;
            Main.raining = true;
            Main.maxRaining = Main.cloudAlpha = 0.9f;

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
                Main.SyncRain();
            }
            TextHelper.PrintText("The skies darken", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.RainCloud, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
