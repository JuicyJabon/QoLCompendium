using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using QoLCompendium.Core.UI.Panels;
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

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EntityManipulator);
        }

        public override bool? UseItem(Player player)
        {
            if (!EntityManipulatorUI.visible) EntityManipulatorUI.timeStart = Main.GameUpdateCount;
            EntityManipulatorUI.visible = true;

            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EntityManipulator, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.BattlePotion, 10);
            r.AddIngredient(ItemID.WaterCandle, 3);
            r.AddIngredient(ItemID.CalmingPotion, 10);
            r.AddIngredient(ItemID.PeaceCandle, 3);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 0)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.NoModifier"));

            if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 1)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.SpawnIncrease"));

            if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 2)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.SpawnDecrease"));

            if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 3)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.CanceledSpawns"));

            if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 4)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.CanceledEvents"));

            if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 5)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.CanceledSpawnsAndEvents"));

            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 1)
                    player.GetModPlayer<QoLCPlayer>().increasedSpawns = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 2)
                    player.GetModPlayer<QoLCPlayer>().decreasedSpawns = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 3)
                    player.GetModPlayer<QoLCPlayer>().noSpawns = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 4)
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

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 5)
                {
                    player.GetModPlayer<QoLCPlayer>().noSpawns = true;
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
