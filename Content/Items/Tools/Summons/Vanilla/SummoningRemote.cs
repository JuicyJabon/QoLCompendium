using Humanizer;
using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Core.UI.Panels;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Events;

namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class SummoningRemote : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.SummoningRemote;

        public new string LocalizationCategory => "Items.Tools.Summons";

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 0;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 7;
            Item.height = 17;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.shoot = ModContent.ProjectileType<NPCSpawner>();
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.SummoningRemote);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
                return false;

            Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;

            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn != 0 && player.GetModPlayer<QoLCPlayer>().bossSpawn)
            {
                if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.WallofFlesh)
                    return false;

                if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.Retinazer)
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.Spazmatism);

                Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, player.GetModPlayer<QoLCPlayer>().bossToSpawn);
                SoundEngine.PlaySound(SoundID.Roar, player.position);
            }

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn != 0 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
            {
                if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 14)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.LunarTowerNebula);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                }
                if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 15)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.LunarTowerSolar);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                }
                if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 16)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.LunarTowerStardust);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                }
                if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 17)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.LunarTowerVortex);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                }
            }
            return false;
        }

        public override bool? UseItem(Player player)
        {
            //new Color(175, 75, 255) - PURPLE
            //new Color(50, 255, 130) - GREEN
            if (player.altFunctionUse == 2)
            {
                if (!SummoningRemoteUI.visible) SummoningRemoteUI.timeStart = Main.GameUpdateCount;
                SummoningRemoteUI.visible = true;
                SoundEngine.PlaySound(SoundID.MenuOpen, player.Center);
                return true;
            }
            else
            {
                if (player.GetModPlayer<QoLCPlayer>().bossToSpawn != 0 && player.GetModPlayer<QoLCPlayer>().bossSpawn && player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.WallofFlesh)
                {
                    NPC.SpawnWOF(player.Center);
                    SoundEngine.PlaySound(SoundID.Roar, player.position);
                    return true;
                }
                if (player.GetModPlayer<QoLCPlayer>().eventToSpawn != 0 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                {
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 1)
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
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventRain"), new Color(50, 255, 130));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 2)
                    {
                        Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventWind"), new Color(50, 255, 130));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 3)
                    {
                        Sandstorm.StartSandstorm();

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventSandstorm"), new Color(50, 255, 130));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 4 && !BirthdayParty.PartyIsUp)
                    {
                        BirthdayParty.PartyDaysOnCooldown = 0;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                if (BirthdayParty.PartyIsUp)
                                    break;
                                BirthdayParty.CheckMorning();
                            }
                        }

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 5)
                    {
                        Main.StartSlimeRain(true);
                        Main.slimeWarningDelay = 1;
                        Main.slimeWarningTime = 1;
                        SoundEngine.PlaySound(SoundID.Roar, player.position);

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 6)
                    {
                        if (!Main.dayTime)
                        {
                            Main.bloodMoon = true;
                            SoundEngine.PlaySound(SoundID.Roar, player.position);
                            TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventBloodMoon"), new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 7)
                    {
                        Main.StartInvasion(InvasionID.GoblinArmy);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 8)
                    {
                        Main.StartInvasion(InvasionID.SnowLegion);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 9)
                    {
                        Main.StartInvasion(InvasionID.PirateInvasion);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 10)
                    {
                        if (Main.dayTime)
                        {
                            Main.eclipse = true;
                            SoundEngine.PlaySound(SoundID.Roar, player.position);
                            TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventEclipse"), new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 11)
                    {
                        if (!Main.dayTime)
                        {
                            Main.startPumpkinMoon();
                            TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventPumpkinMoon"), new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 12)
                    {
                        if (!Main.dayTime)
                        {
                            Main.startSnowMoon();
                            TextHelper.PrintText(Language.GetTextValue("Mods.QoLCompendium.Messages.EventFrostMoon"), new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 13)
                    {
                        Main.StartInvasion(InvasionID.MartianMadness);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 18)
                    {
                        WorldGen.TriggerLunarApocalypse();
                        NPC.LunarApocalypseIsUp = true;
                    }
                }
                return true;
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn > 0 && player.GetModPlayer<QoLCPlayer>().bossToSpawn != NPCID.Retinazer && player.GetModPlayer<QoLCPlayer>().bossToSpawn != NPCID.MoonLordCore && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.Boss").FormatWith(ContentSamples.NpcsByNetId[player.GetModPlayer<QoLCPlayer>().bossToSpawn].FullName));

            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.Retinazer && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.BossTwins"));

            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.MoonLordCore && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.BossMoonLord"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 1 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventRain"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 2 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventWind"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 3 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSandstorm"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 4 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventParty"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 5 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSlimeRain"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 6 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventBloodMoon"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 7 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventGoblinArmy"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 8 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSnowLegion"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 9 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventPirateInvasion"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 10 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventEclipse"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 11 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventPumpkinMoon"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 12 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventFrostMoon"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 13 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventMartianMadness"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 14 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventNebulaPillar"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 15 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSolarPillar"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 16 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventStardustPillar"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 17 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventVortexPillar"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 18 && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventLunar"));

            if (!player.GetModPlayer<QoLCPlayer>().bossSpawn && !player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.NoModifier"));
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.SummoningRemote, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddIngredient(ItemID.Ruby, 5);
            r.AddIngredient(ItemID.Lens, 2);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
