using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using QoLCompendium.Core.UI;
using Terraria.Enums;
using Terraria.GameContent.Events;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class SummoningRemote : ModItem
    {
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
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.White0, Item.buyPrice(0, 1, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            //new Color(175, 75, 255) - PURPLE
            //new Color(50, 255, 130) - GREEN
            if (player.altFunctionUse == 2)
            {
                if (!BossUI.visible) BossUI.timeStart = Main.GameUpdateCount;
                BossUI.visible = true;
                return base.UseItem(player);
            }
            else
            {
                if (player.GetQoLCPlayer().bossToSpawn != 0 && player.GetQoLCPlayer().bossSpawn)
                {
                    if (player.GetQoLCPlayer().bossToSpawn == NPCID.WallofFlesh)
                    {
                        NPC.SpawnWOF(player.Center);
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                        return true;
                    }
                    if (player.GetQoLCPlayer().bossToSpawn == NPCID.Retinazer)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.Spazmatism);
                    }
                    NetcodeBossSpawn.SpawnBossNetcoded(player, player.GetQoLCPlayer().bossToSpawn);
                }
                if (player.GetQoLCPlayer().eventToSpawn != 0 && player.GetQoLCPlayer().eventSpawn)
                {
                    if (player.GetQoLCPlayer().eventToSpawn == 1)
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
                        TextHelper.PrintText("The skies darken", new Color(50, 255, 130));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 2)
                    {
                        Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        TextHelper.PrintText("The wind has been stirred", new Color(50, 255, 130));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 3)
                    {
                        Sandstorm.StartSandstorm();

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        TextHelper.PrintText("The desert winds are howling", new Color(50, 255, 130));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 4)
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
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 5)
                    {
                        Main.StartSlimeRain();
                        Main.slimeWarningDelay = 1;
                        Main.slimeWarningTime = 1;
                        SoundEngine.PlaySound(SoundID.Roar, player.position);

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 6)
                    {
                        if (!Main.dayTime)
                        {
                            Main.bloodMoon = true;
                            SoundEngine.PlaySound(SoundID.Roar, player.position);
                            TextHelper.PrintText("The Blood Moon is rising...", new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 7)
                    {
                        Main.StartInvasion(InvasionID.GoblinArmy);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 8)
                    {
                        Main.StartInvasion(InvasionID.SnowLegion);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 9)
                    {
                        Main.StartInvasion(InvasionID.PirateInvasion);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 10)
                    {
                        if (Main.dayTime)
                        {
                            Main.eclipse = true;
                            SoundEngine.PlaySound(SoundID.Roar, player.position);
                            TextHelper.PrintText("A solar eclipse is happening!", new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 11)
                    {
                        if (!Main.dayTime)
                        {
                            Main.startPumpkinMoon();
                            TextHelper.PrintText("The Pumpkin Moon is rising...", new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 12)
                    {
                        if (!Main.dayTime)
                        {
                            Main.startSnowMoon();
                            TextHelper.PrintText("The Frost Moon is rising...", new Color(50, 255, 130));
                            if (Main.netMode == NetmodeID.Server)
                                NetMessage.SendData(MessageID.WorldData);
                        }
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 13)
                    {
                        Main.StartInvasion(InvasionID.MartianMadness);
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 14)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerNebula);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 15)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerSolar);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 16)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerStardust);
                    }
                    if (player.GetQoLCPlayer().eventToSpawn == 17)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerVortex);
                    }
                }
                return true;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.SummoningRemote, Type);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 7);
            r.AddIngredient(ItemID.Ruby, 2);
            r.AddIngredient(ItemID.Lens, 3);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
