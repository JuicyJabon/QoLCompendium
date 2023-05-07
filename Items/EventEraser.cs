using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000022 RID: 34
    public class EventEraser : ModItem
    {
        // Token: 0x060000D5 RID: 213 RVA: 0x0000F92E File Offset: 0x0000DB2E
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Erasers;
        }

        // Token: 0x060000D6 RID: 214 RVA: 0x0000FAF5 File Offset: 0x0000DCF5
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Favorite this item to disable events \nLunar towers only cancel if you have beaten them before");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000D7 RID: 215 RVA: 0x0000FB20 File Offset: 0x0000DD20
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 20;
            Item.noUseGraphic = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HiddenAnimation;
            Item.rare = ItemRarityID.Blue;
        }

        // Token: 0x060000D8 RID: 216 RVA: 0x0000FB84 File Offset: 0x0000DD84
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<EventEraser>(), 1).AddIngredient(ItemID.SharkFin, 1).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000D9 RID: 217 RVA: 0x0000FBB8 File Offset: 0x0000DDB8
        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                if (Main.invasionType != 0)
                {
                    Main.invasionType = 0;
                }
                if (Main.pumpkinMoon)
                {
                    Main.pumpkinMoon = false;
                }
                if (Main.snowMoon)
                {
                    Main.snowMoon = false;
                }
                if (Main.eclipse)
                {
                    Main.eclipse = false;
                }
                if (Main.bloodMoon)
                {
                    Main.bloodMoon = false;
                }
                if (Main.WindyEnoughForKiteDrops)
                {
                    Main.windSpeedTarget = 0f;
                    Main.windSpeedCurrent = 0f;
                }
                if (Main.slimeRain)
                {
                    Main.StopSlimeRain(true);
                    Main.slimeWarningDelay = 1;
                    Main.slimeWarningTime = 1;
                }
                if (BirthdayParty.PartyIsUp)
                {
                    BirthdayParty.CheckNight();
                }
                if (DD2Event.Ongoing && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    DD2Event.StopInvasion(false);
                }
                if (Sandstorm.Happening)
                {
                    Sandstorm.Happening = false;
                    Sandstorm.TimeLeft = 0.0;
                    Sandstorm.IntendedSeverity = 0f;
                }
                if (NPC.downedTowers && (NPC.LunarApocalypseIsUp || NPC.ShieldStrengthTowerNebula > 0 || NPC.ShieldStrengthTowerSolar > 0 || NPC.ShieldStrengthTowerStardust > 0 || NPC.ShieldStrengthTowerVortex > 0))
                {
                    NPC.LunarApocalypseIsUp = false;
                    NPC.ShieldStrengthTowerNebula = 0;
                    NPC.ShieldStrengthTowerSolar = 0;
                    NPC.ShieldStrengthTowerStardust = 0;
                    NPC.ShieldStrengthTowerVortex = 0;
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].active && (Main.npc[i].type == NPCID.LunarTowerNebula || Main.npc[i].type == NPCID.LunarTowerSolar || Main.npc[i].type == NPCID.LunarTowerStardust || Main.npc[i].type == NPCID.LunarTowerVortex))
                        {
                            Main.npc[i].dontTakeDamage = false;
                            Main.npc[i].StrikeInstantKill();
                        }
                    }
                }
                if (Main.IsItRaining || Main.IsItStorming)
                {
                    Main.StopRain();
                    Main.cloudAlpha = 0f;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        Main.SyncRain();
                    }
                }
            }
        }
    }
}
