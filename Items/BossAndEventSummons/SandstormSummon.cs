using Microsoft.Xna.Framework;
using QoLCompendium.UI;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class SandstormSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 1;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 13;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Sandstorm.Happening;
        }

        public override bool? UseItem(Player player)
        {
            Sandstorm.StartSandstorm();

            NetMessage.SendData(MessageID.WorldData);
            TextHelper.PrintText("The desert winds are howling", new Color(175, 75, 255));
            SoundEngine.PlaySound(SoundID.Roar, player.position);

            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.SandBlock, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
