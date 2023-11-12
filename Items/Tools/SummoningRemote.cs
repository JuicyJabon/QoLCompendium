using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using QoLCompendium.UI;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.Tools
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
            Item.maxStack = 1;
            Item.rare = ItemRarityID.White;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (!BossUI.visible) BossUI.timeStart = Main.GameUpdateCount;
                BossUI.visible = true;
                return base.UseItem(player);
            }
            else
            {
                if (player.GetModPlayer<QoLCPlayer>().bossToSpawn != 0 && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                {
                    if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.Retinazer)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.Spazmatism);
                    }
                    NetcodeBossSpawn.SpawnBossNetcoded(player, player.GetModPlayer<QoLCPlayer>().bossToSpawn);
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
                        TextHelper.PrintText("The skies darken", new Color(175, 75, 255));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 2)
                    {
                        Main.windSpeedTarget = Main.windSpeedCurrent = 0.8f;

                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.WorldData);
                        TextHelper.PrintText("The wind has been stirred", new Color(175, 75, 255));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 3)
                    {
                        Sandstorm.StartSandstorm();

                        NetMessage.SendData(MessageID.WorldData);
                        TextHelper.PrintText("The desert winds are howling", new Color(175, 75, 255));
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 4)
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
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 5)
                    {
                        Main.StartSlimeRain();
                        Main.slimeWarningDelay = 1;
                        Main.slimeWarningTime = 1;
                        SoundEngine.PlaySound(SoundID.Roar, player.position);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 6)
                    {
                        if (!Main.dayTime)
                        {
                            Main.bloodMoon = true;
                        }
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 7)
                    {
                        Main.StartInvasion(InvasionID.GoblinArmy);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 8)
                    {
                        Main.StartInvasion(InvasionID.SnowLegion);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 9)
                    {
                        Main.StartInvasion(InvasionID.PirateInvasion);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 10)
                    {
                        Main.startPumpkinMoon();
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 11)
                    {
                        Main.startSnowMoon();
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 12)
                    {
                        Main.StartInvasion(InvasionID.MartianMadness);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 13)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerNebula);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 14)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerSolar);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 15)
                    {
                        NetcodeBossSpawn.SpawnBossNetcoded(player, NPCID.LunarTowerStardust);
                    }
                    if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == 16)
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
            if (QoLCompendium.itemConfig.SummoningRemote)
            {
                CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.Ruby, 1)
                .AddIngredient(ItemID.Lens, 3)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
