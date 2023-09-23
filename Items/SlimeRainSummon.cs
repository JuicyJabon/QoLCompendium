using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class SlimeRainSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 1;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 11;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.slimeRain;
        }

        public override bool? UseItem(Player player)
        {
            Main.StartSlimeRain();
            Main.slimeWarningDelay = 1;
            Main.slimeWarningTime = 1;
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Gel, 5)
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
