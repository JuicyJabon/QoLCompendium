using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class EventEraser : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ItemConfig>().Erasers;
        }

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

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

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<EventEraser>(), 1).AddIngredient(ItemID.SharkFin, 1).AddIngredient(ItemID.RubyGemsparkBlock, 20).AddTile(TileID.Anvils).Register();
        }

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
