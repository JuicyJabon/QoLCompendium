using QoLCompendium.Core;
using QoLCompendium.Core.UI;
using Terraria.Enums;
using Terraria.GameContent.Events;

namespace QoLCompendium.Content.Items.Tools.FavoriteEffect
{
    internal class EntityManipulator : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 5, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            if (!EntityManipulatorUI.visible) EntityManipulatorUI.timeStart = Main.GameUpdateCount;
            EntityManipulatorUI.visible = true;

            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EntityManipulator, Type);
            r.AddIngredient(ItemID.BattlePotion, 10);
            r.AddIngredient(ItemID.WaterCandle, 3);
            r.AddIngredient(ItemID.CalmingPotion, 10);
            r.AddIngredient(ItemID.PeaceCandle, 3);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.favorited)
            {
                if (player.GetQoLCPlayer().selectedSpawnModifier == 0)
                {
                    player.GetQoLCPlayer().enemyAggressor = true;
                }

                if (player.GetQoLCPlayer().selectedSpawnModifier == 1)
                {
                    player.GetQoLCPlayer().enemyCalmer = true;
                }

                if (player.GetQoLCPlayer().selectedSpawnModifier == 2)
                {
                    player.GetQoLCPlayer().enemyEraser = true;
                }

                if (player.GetQoLCPlayer().selectedSpawnModifier == 3)
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

                if (player.GetQoLCPlayer().selectedSpawnModifier == 4)
                {
                    player.GetQoLCPlayer().enemyEraser = true;
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
}
