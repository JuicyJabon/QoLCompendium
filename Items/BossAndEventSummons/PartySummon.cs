using System.Linq;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class PartySummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 1;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 11;
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
            if (Main.dayTime && !BirthdayParty.PartyIsUp)
            {
                return Main.npc.Count((n) => n.active && n.townNPC && n.aiStyle != 0 && n.type != NPCID.OldMan && n.type != NPCID.SkeletonMerchant && n.type != NPCID.TaxCollector && !NPCID.Sets.IsTownPet[n.type]) >= 2;
            }
            return false;
        }

        public override bool? UseItem(Player player)
        {
            BirthdayParty.PartyDaysOnCooldown = 0;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int num = 0;
                while (num < 100 && !BirthdayParty.PartyIsUp)
                {
                    BirthdayParty.CheckMorning();
                    num++;
                }
            }

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.WorldData);

            return true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.BossSummoners)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Confetti, 5)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
