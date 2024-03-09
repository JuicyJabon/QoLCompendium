using Mono.Cecil.Cil;
using MonoMod.Cil;
using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Content.Items.Mirrors;
using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Core.UI;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.ModLoader.Config;
using static MonoMod.Cil.ILContext;

namespace QoLCompendium.Core
{
    public class PlayerChanges : ModSystem
    {
        private static bool _rebuilt;

        public override void Load()
        {
            if (QoLCompendium.mainConfig.AllHairsAvailable)
            {
                On_HairstyleUnlocksHelper.ListWarrantsRemake += RebuildPatch;
                On_HairstyleUnlocksHelper.RebuildList += UnlockPatch;
            }
        }

        public override void Unload()
        {
            On_HairstyleUnlocksHelper.ListWarrantsRemake -= RebuildPatch;
            On_HairstyleUnlocksHelper.RebuildList -= UnlockPatch;
        }

        private static bool RebuildPatch(On_HairstyleUnlocksHelper.orig_ListWarrantsRemake orig,
            HairstyleUnlocksHelper self)
        {
            if (!_rebuilt)
            {
                _rebuilt = true;
                return true;
            }

            return false;
        }

        private static void UnlockPatch(On_HairstyleUnlocksHelper.orig_RebuildList orig,
            HairstyleUnlocksHelper self)
        {
            self.AvailableHairstyles.Clear();
            for (int i = 0; i < TextureAssets.PlayerHair.Length; i++)
            {
                self.AvailableHairstyles.Add(i);
            }
        }
    }

    public class AutofishPlayer : ModPlayer
    {
        internal bool Lockcast;

        internal Point CastPosition;

        internal int PullTimer;

        internal bool ActivatedByMod;

        internal bool Autocast;

        internal int AutocastDelay;

        public override void PreUpdate()
        {
            if (Player.whoAmI != Main.myPlayer || !QoLCompendium.mainConfig.AutoFishing)
            {
                return;
            }
            ActivatedByMod = false;
            if (PullTimer > 0)
            {
                PullTimer--;
                if (PullTimer == 0)
                {
                    Player.controlUseItem = true;
                    Player.releaseUseItem = true;
                    ActivatedByMod = true;
                    Player.ItemCheck();
                }
            }
            if (!Autocast)
            {
                return;
            }
            AutocastDelay--;
            if (Player.HeldItem.fishingPole == 0)
            {
                Autocast = false;
            }
            else if (AutocastDelay <= 0 && !CheckBobbersActive(Player.whoAmI))
            {
                int mouseX = Main.mouseX;
                int mouseY = Main.mouseY;
                if (Lockcast)
                {
                    Main.mouseX = CastPosition.X - (int)Main.screenPosition.X;
                    Main.mouseY = CastPosition.Y - (int)Main.screenPosition.Y;
                }
                Player.controlUseItem = true;
                Player.releaseUseItem = true;
                ActivatedByMod = true;
                Player.ItemCheck();
                AutocastDelay = 10;
                if (Lockcast)
                {
                    Main.mouseX = mouseX;
                    Main.mouseY = mouseY;
                }
            }
        }

        public static bool CheckBobbersActive(int whoAmI)
        {
            using IEnumerator<Projectile> enumerator = Main.projectile.Where((Projectile p) => p.active && p.owner == whoAmI && p.bobber).GetEnumerator();
            if (enumerator.MoveNext())
            {
                _ = enumerator.Current;
                return true;
            }
            return false;
        }

        public override void OnEnterWorld()
        {
            Lockcast = false;
            CastPosition = default;
            Autocast = false;
        }

        public override void Load()
        {
            if (QoLCompendium.mainConfig.AutoFishing)
            {
                On_Player.ItemCheck_CheckFishingBobbers += new On_Player.hook_ItemCheck_CheckFishingBobbers(Player_ItemCheck_CheckFishingBobbers);
                On_Player.ItemCheck_Shoot += new On_Player.hook_ItemCheck_Shoot(Player_ItemCheck_Shoot);
                IL_Projectile.FishingCheck += new Manipulator(Projectile_FishingCheck);
            }
        }

        private bool Player_ItemCheck_CheckFishingBobbers(On_Player.orig_ItemCheck_CheckFishingBobbers orig, Player player, bool canUse)
        {
            bool num = orig.Invoke(player, canUse);
            if (!num && player.whoAmI == Main.myPlayer && player.TryGetModPlayer(out AutofishPlayer autofishPlayer) && !autofishPlayer.ActivatedByMod)
            {
                autofishPlayer.Autocast = false;
            }
            return num;
        }

        private void Player_ItemCheck_Shoot(On_Player.orig_ItemCheck_Shoot orig, Player player, int i, Item sItem, int weaponDamage)
        {
            if (player.whoAmI == Main.myPlayer && player.TryGetModPlayer(out AutofishPlayer autofishPlayer) && !autofishPlayer.ActivatedByMod && sItem.fishingPole > 0)
            {
                autofishPlayer.Autocast = true;
            }
            orig.Invoke(player, i, sItem, weaponDamage);
        }

        private void Projectile_FishingCheck(ILContext il)
        {
            ILCursor val = new(il);
            if (!val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
            {
            (Instruction i) => ILPatternMatchingExt.MatchLdfld(i, typeof(FishingAttempt), "rolledItemDrop")
            }))
            {
                throw new Exception("Hook location not found, if (fisher.rolledItemDrop > 0)");
            }
            val.Emit(OpCodes.Ldarg_0);
            val.EmitDelegate(delegate (int caughtType, Projectile projectile)
            {
                if (projectile.owner != Main.myPlayer || !Main.player[projectile.owner].active || Main.player[projectile.owner].dead)
                {
                    return caughtType;
                }
                AutofishPlayer modPlayer2 = Main.player[projectile.owner].GetModPlayer<AutofishPlayer>();
                if (modPlayer2.PullTimer == 0 && caughtType > 0)
                {
                    modPlayer2.PullTimer = (int)(0.5 * 60f + 1f);
                    return caughtType;
                }
                return caughtType;
            });
            val = new ILCursor(il);
            if (!val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
            {
            (Instruction i) => ILPatternMatchingExt.MatchLdfld(i, typeof(FishingAttempt), "rolledEnemySpawn")
            }))
            {
                throw new Exception("Hook location not found, if (fisher.rolledEnemySpawn > 0)");
            }
            val.Emit(OpCodes.Ldarg_0);
            val.EmitDelegate(delegate (int caughtType, Projectile projectile)
            {
                if (projectile.owner != Main.myPlayer || !Main.player[projectile.owner].active || Main.player[projectile.owner].dead)
                {
                    return caughtType;
                }
                AutofishPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<AutofishPlayer>();
                if (caughtType > 0 && modPlayer.PullTimer == 0)
                {
                    modPlayer.PullTimer = (int)(0.5f * 60f + 1f);
                }
                return caughtType;
            });
        }
    }

    public class PortableStationSystem : ModSystem
    {
        public override void Load()
        {
            IL_Player.AdjTiles += AddPortableStations;
        }

        private void AddPortableStations(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(MoveType.Before, i => i.MatchLdsfld<Main>(nameof(Main.playerInventory))))
                return;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Action<Player>>(player =>
            {
                if (!QoLCompendium.mainConfig.PortableCrafting)
                    return;

                CheckStations(player.inventory);
                CheckStations(player.bank.item);
                CheckStations(player.bank2.item);
                CheckStations(player.bank3.item);
                CheckStations(player.bank4.item);
            });
        }

        private void CheckStations(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                int tileType = item.createTile;
                if (tileType > -1 && tileType < TileLoader.TileCount)
                {
                    CheckChainedStations(tileType, Main.LocalPlayer);
                }

                if (item.type is ItemID.WaterBucket or ItemID.BottomlessBucket)
                {
                    Main.LocalPlayer.adjWater = true;
                }

                if (item.type is ItemID.LavaBucket or ItemID.BottomlessLavaBucket)
                {
                    Main.LocalPlayer.adjLava = true;
                }

                if (item.type is ItemID.HoneyBucket or ItemID.BottomlessHoneyBucket)
                {
                    Main.LocalPlayer.adjHoney = true;
                }

                for (int i = 0; i < Main.recipe.Length; i++)
                {
                    if (tileType > -1 && Main.recipe[i].HasTile(tileType))
                    {
                        Main.LocalPlayer.adjTile[tileType] = true;
                    }
                }
            }
        }

        private static void CheckChainedStations(int tileType, Player player)
        {
            player.adjTile[tileType] = true;
            if (TileID.Sets.CountsAsWaterSource[tileType])
            {
                player.adjWater = true;
            }

            if (TileID.Sets.CountsAsLavaSource[tileType])
            {
                player.adjLava = true;
            }

            if (TileID.Sets.CountsAsHoneySource[tileType])
            {
                player.adjHoney = true;
            }

            switch (tileType)
            {
                case TileID.Hellforge:
                case TileID.GlassKiln:
                    player.adjTile[TileID.Furnaces] = true;
                    break;
                case TileID.AdamantiteForge:
                    player.adjTile[TileID.Furnaces] = true;
                    player.adjTile[TileID.Hellforge] = true;
                    break;
                case TileID.MythrilAnvil:
                    player.adjTile[TileID.Anvils] = true;
                    break;
                case TileID.BewitchingTable:
                case TileID.Tables2:
                case TileID.PicnicTable:
                    player.adjTile[TileID.Tables] = true;
                    break;
                case TileID.AlchemyTable:
                    player.adjTile[TileID.Bottles] = true;
                    player.adjTile[TileID.Tables] = true;
                    player.alchemyTable = true;
                    break;
            }

            TileLoader.AdjTiles(player, tileType);
        }
    }

    public class RespawnPlayer : ModPlayer
    {
        public int respawnFullHPTimer = 0;

        private (int type, int time)[] buffCache;

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (QoLCompendium.mainConfig.InstantRespawn && Main.netMode == NetmodeID.SinglePlayer)
            {
                for (int k = 0; k < Main.maxNPCs; k++)
                {
                    if (Main.npc[k].boss && Main.npc[k].active)
                    {
                        DespawnNPC(k);
                    }
                    Player.respawnTimer = 60;
                }
            }

            if (QoLCompendium.mainConfig.KeepBuffsOnDeath)
            {
                if (buffCache == null)
                {
                    buffCache = new (int, int)[Player.MaxBuffs];
                }
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    buffCache[i] = (Player.buffType[i], Player.buffTime[i]);
                }
            }
        }

        public override void OnRespawn()
        {
            if (QoLCompendium.mainConfig.FullHPRespawn)
            {
                respawnFullHPTimer = 1;
            }

            if (QoLCompendium.mainConfig.KeepBuffsOnDeath)
            {
                (int, int)[] array = buffCache;
                for (int i = 0; i < array.Length; i++)
                {
                    var (num, num2) = array[i];
                    if ((QoLCompendium.mainConfig.KeepDebuffsOnDeath || !Main.debuff[num]) && num > 0 && !Main.persistentBuff[num] && num2 > 2)
                    {
                        int num3 = (int)(float)num2;
                        Player.AddBuff(num, num3, false, false);
                    }
                }
            }
        }

        public override void PostUpdate()
        {
            if (QoLCompendium.mainConfig.FullHPRespawn && respawnFullHPTimer == 0)
            {
                respawnFullHPTimer = -1;
                Player.statLife = Player.statLifeMax2;
                Player.statMana = Player.statManaMax2;
            }
            respawnFullHPTimer--;
        }

        public static void DespawnNPC(int npc)
        {
            Main.npc[npc].life = 0;
            Main.npc[npc].active = false;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc, 0f, 0f, 0f, 0, 0, 0);
            }
        }
    }

    public class BankPlayer : ModPlayer
    {
        internal bool chests;
        internal int safe = -1;
        internal int defenders = -1;

        public override void SetControls()
        {
            if (Player.whoAmI == Main.myPlayer && chests)
            {
                Main.SmartCursorShowing = false;
                Player.tileRangeX = 9999;
                Player.tileRangeY = 5000;
                if (Player.chest >= -1)
                {
                    safe = -1;
                    defenders = -1;
                    chests = false;
                }
                if (safe != -1 && Main.projectile[safe].type != ModContent.ProjectileType<FlyingSafeProj>())
                {
                    safe = -1;
                    chests = false;
                }
                if (defenders != -1 && Main.projectile[defenders].type != ModContent.ProjectileType<EtherianConstructProj>())
                {
                    defenders = -1;
                    chests = false;
                }
            }
        }
        public override void UpdateEquips()
        {
            if (QoLCompendium.mainConfig.InformationBanks)
            {
                for (int i = 0; i < Player.bank.item.Length; i++)
                {
                    CheckTrinkets(Player.bank.item[i].type);
                }
                for (int j = 0; j < Player.bank2.item.Length; j++)
                {
                    CheckTrinkets(Player.bank2.item[j].type);
                }
                for (int k = 0; k < Player.bank3.item.Length; k++)
                {
                    CheckTrinkets(Player.bank3.item[k].type);
                }
                for (int l = 0; l < Player.bank4.item.Length; l++)
                {
                    CheckTrinkets(Player.bank4.item[l].type);
                }
            }
        }

        private void CheckTrinkets(int itemType)
        {
            if (itemType == ItemID.DiscountCard)
            {
                Player.discountAvailable = true;
            }
            if (itemType == ItemID.LuckyCoin)
            {
                Player.hasLuckyCoin = true;
            }
            if (itemType == ItemID.GoldRing)
            {
                Player.goldRing = true;
            }
            if (itemType == ItemID.CoinRing)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.luck += 0.05f;
            }
            if (itemType == ItemID.GreedyRing)
            {
                Player.discountAvailable = true;
                Player.hasLuckyCoin = true;
                Player.goldRing = true;
                Player.luck += 0.05f;
            }
            if (itemType == ItemID.MechanicalLens)
            {
                Player.InfoAccMechShowWires = true;
            }
            if (itemType == ItemID.LaserRuler)
            {
                Player.rulerGrid = true;
            }
            if (itemType == ItemID.WireKite)
            {
                Player.InfoAccMechShowWires = true;
                Player.rulerGrid = true;
            }
            if (itemType == ItemID.PDA || itemType == ItemID.CellPhone || itemType == ItemID.ShellphoneDummy || itemType == ItemID.Shellphone || itemType == ItemID.ShellphoneSpawn || itemType == ItemID.ShellphoneOcean || itemType == ItemID.ShellphoneHell)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
            }
            if (itemType == ItemID.GPS)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
            }
            if (itemType == ItemID.REK)
            {
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
            }
            if (itemType == ItemID.GoblinTech)
            {
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
            }
            if (itemType == ItemID.FishFinder)
            {
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
            }
            if ((itemType == ItemID.CopperWatch || itemType == ItemID.TinWatch) && Player.accWatch < 1)
            {
                Player.accWatch = 1;
            }
            if ((itemType == ItemID.SilverWatch || itemType == ItemID.TungstenWatch) && Player.accWatch < 2)
            {
                Player.accWatch = 2;
            }
            if (itemType == ItemID.GoldWatch || itemType == ItemID.PlatinumWatch)
            {
                Player.accWatch = 3;
            }
            if (itemType == ItemID.DepthMeter)
            {
                Player.accDepthMeter = 1;
            }
            if (itemType == ItemID.Compass)
            {
                Player.accCompass = 1;
            }
            if (itemType == ItemID.Radar)
            {
                Player.accThirdEye = true;
            }
            if (itemType == ItemID.LifeformAnalyzer)
            {
                Player.accCritterGuide = true;
            }
            if (itemType == ItemID.TallyCounter)
            {
                Player.accJarOfSouls = true;
            }
            if (itemType == ItemID.MetalDetector)
            {
                Player.accOreFinder = true;
            }
            if (itemType == ItemID.Stopwatch)
            {
                Player.accStopwatch = true;
            }
            if (itemType == ItemID.DPSMeter)
            {
                Player.accDreamCatcher = true;
            }
            if (itemType == ItemID.FishermansGuide)
            {
                Player.accFishFinder = true;
            }
            if (itemType == ItemID.WeatherRadio)
            {
                Player.accWeatherRadio = true;
            }
            if (itemType == ItemID.Sextant)
            {
                Player.accCalendar = true;
            }
            if (itemType == ItemID.AncientChisel)
            {
                Player.pickSpeed -= 0.25f;
            }
            if (itemType == ItemID.Toolbelt)
            {
                Player.blockRange += 1;
            }
            if (itemType == ItemID.Toolbox)
            {
                Player.blockRange += 1;
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (itemType == ItemID.ExtendoGrip)
            {
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
            }
            if (itemType == ItemID.PortableCementMixer)
            {
                Player.wallSpeed += 0.5f;
            }
            if (itemType == ItemID.PaintSprayer)
            {
                Player.autoPaint = true;
            }
            if (itemType == ItemID.BrickLayer)
            {
                Player.tileSpeed += 0.5f;
            }
            if (itemType == ItemID.ArchitectGizmoPack)
            {
                Player.autoPaint = true;
                Player.wallSpeed += 0.5f;
                Player.tileSpeed += 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
            }
            if (itemType == ItemID.HandOfCreation)
            {
                Player.autoPaint = true;
                Player.wallSpeed += 0.5f;
                Player.tileSpeed += 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                Player.pickSpeed -= 0.25f;
                Player.treasureMagnet = true;
            }
            if (itemType == ItemID.ActuationAccessory)
            {
                Player.autoActuator = true;
            }
            if (itemType == ItemID.HighTestFishingLine)
            {
                Player.accFishingLine = true;
            }
            if (itemType == ItemID.AnglerEarring)
            {
                Player.fishingSkill += 10;
            }
            if (itemType == ItemID.TackleBox)
            {
                Player.accTackleBox = true;
            }
            if (itemType == ItemID.LavaFishingHook)
            {
                Player.accLavaFishing = true;
            }
            if (itemType == ItemID.AnglerTackleBag)
            {
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
            }
            if (itemType == ItemID.LavaproofTackleBag)
            {
                Player.accLavaFishing = true;
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
            }
            if (itemType == ItemID.FishingBobber || itemType == ItemID.FishingBobberGlowingStar || itemType == ItemID.FishingBobberGlowingLava || itemType == ItemID.FishingBobberGlowingKrypton || itemType == ItemID.FishingBobberGlowingXenon || itemType == ItemID.FishingBobberGlowingArgon || itemType == ItemID.FishingBobberGlowingViolet || itemType == ItemID.FishingBobberGlowingRainbow)
            {
                Player.fishingSkill += 10;
            }
            if (itemType == ItemID.TreasureMagnet)
            {
                Player.treasureMagnet = true;
            }
            if (itemType == ItemID.RoyalGel)
            {
                Player.npcTypeNoAggro[1] = true;
                Player.npcTypeNoAggro[16] = true;
                Player.npcTypeNoAggro[59] = true;
                Player.npcTypeNoAggro[71] = true;
                Player.npcTypeNoAggro[81] = true;
                Player.npcTypeNoAggro[138] = true;
                Player.npcTypeNoAggro[121] = true;
                Player.npcTypeNoAggro[122] = true;
                Player.npcTypeNoAggro[141] = true;
                Player.npcTypeNoAggro[147] = true;
                Player.npcTypeNoAggro[183] = true;
                Player.npcTypeNoAggro[184] = true;
                Player.npcTypeNoAggro[204] = true;
                Player.npcTypeNoAggro[225] = true;
                Player.npcTypeNoAggro[244] = true;
                Player.npcTypeNoAggro[302] = true;
                Player.npcTypeNoAggro[333] = true;
                Player.npcTypeNoAggro[335] = true;
                Player.npcTypeNoAggro[334] = true;
                Player.npcTypeNoAggro[336] = true;
                Player.npcTypeNoAggro[537] = true;
            }
            if (itemType == ItemID.SpectreGoggles)
            {
                Player.CanSeeInvisibleBlocks = true;
            }
            if (itemType == ItemID.CordageGuide)
            {
                Player.cordage = true;
            }
            if (itemType == ItemID.DontHurtCrittersBook)
            {
                Player.dontHurtCritters = true;
            }
            if (itemType == ItemID.DontHurtNatureBook)
            {
                Player.dontHurtNature = true;
            }
            if (itemType == ItemID.DontHurtComboBook)
            {
                Player.dontHurtCritters = true;
                Player.dontHurtNature = true;
            }
            if (itemType == ModContent.ItemType<BattalionLog>())
            {
                Player.GetModPlayer<InfoPlayer>().battalionLog = true;
            }
            if (itemType == ModContent.ItemType<HarmInducer>())
            {
                Player.GetModPlayer<InfoPlayer>().harmInducer = true;
            }
            if (itemType == ModContent.ItemType<HeadCounter>())
            {
                Player.GetModPlayer<InfoPlayer>().headCounter = true;
            }
            if (itemType == ModContent.ItemType<Kettlebell>())
            {
                Player.GetModPlayer<InfoPlayer>().kettlebell = true;
            }
            if (itemType == ModContent.ItemType<LuckyDie>())
            {
                Player.GetModPlayer<InfoPlayer>().luckyDie = true;
            }
            if (itemType == ModContent.ItemType<MetallicClover>())
            {
                Player.GetModPlayer<InfoPlayer>().metallicClover = true;
            }
            if (itemType == ModContent.ItemType<PlateCracker>())
            {
                Player.GetModPlayer<InfoPlayer>().plateCracker = true;
            }
            if (itemType == ModContent.ItemType<Regenerator>())
            {
                Player.GetModPlayer<InfoPlayer>().regenerator = true;
            }
            if (itemType == ModContent.ItemType<ReinforcedPanel>())
            {
                Player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            }
            if (itemType == ModContent.ItemType<Replenisher>())
            {
                Player.GetModPlayer<InfoPlayer>().replenisher = true;
            }
            if (itemType == ModContent.ItemType<TrackingDevice>())
            {
                Player.GetModPlayer<InfoPlayer>().trackingDevice = true;
            }
            if (itemType == ModContent.ItemType<WingTimer>())
            {
                Player.GetModPlayer<InfoPlayer>().wingTimer = true;
            }
            if (itemType == ModContent.ItemType<Fitbit>())
            {
                Player.GetModPlayer<InfoPlayer>().kettlebell = true;
                Player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
                Player.GetModPlayer<InfoPlayer>().wingTimer = true;
            }
            if (itemType == ModContent.ItemType<HeartbeatSensor>())
            {
                Player.GetModPlayer<InfoPlayer>().battalionLog = true;
                Player.GetModPlayer<InfoPlayer>().headCounter = true;
                Player.GetModPlayer<InfoPlayer>().trackingDevice = true;
            }
            if (itemType == ModContent.ItemType<ToleranceDetector>())
            {
                Player.GetModPlayer<InfoPlayer>().harmInducer = true;
                Player.GetModPlayer<InfoPlayer>().luckyDie = true;
                Player.GetModPlayer<InfoPlayer>().plateCracker = true;
            }
            if (itemType == ModContent.ItemType<VitalDisplay>())
            {
                Player.GetModPlayer<InfoPlayer>().metallicClover = true;
                Player.GetModPlayer<InfoPlayer>().regenerator = true;
                Player.GetModPlayer<InfoPlayer>().replenisher = true;
            }
            if (itemType == ModContent.ItemType<IAH>() || itemType == ModContent.ItemType<MosaicMirror>())
            {
                Player.GetModPlayer<InfoPlayer>().battalionLog = true;
                Player.GetModPlayer<InfoPlayer>().harmInducer = true;
                Player.GetModPlayer<InfoPlayer>().headCounter = true;
                Player.GetModPlayer<InfoPlayer>().kettlebell = true;
                Player.GetModPlayer<InfoPlayer>().luckyDie = true;
                Player.GetModPlayer<InfoPlayer>().metallicClover = true;
                Player.GetModPlayer<InfoPlayer>().plateCracker = true;
                Player.GetModPlayer<InfoPlayer>().regenerator = true;
                Player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
                Player.GetModPlayer<InfoPlayer>().replenisher = true;
                Player.GetModPlayer<InfoPlayer>().trackingDevice = true;
                Player.GetModPlayer<InfoPlayer>().wingTimer = true;
            }
        }
    }

    public class MiscEffectsPlayer : ModPlayer
    {
        public bool joinedTeam = false;

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (Player != Main.player[Main.myPlayer])
            {
                return;
            }

            if (QoLCompendium.mainConfig.AutoTeams > 0 && joinedTeam == false && Main.netMode == NetmodeID.MultiplayerClient)
            {
                Main.player[Main.myPlayer].team = QoLCompendium.mainConfig.AutoTeams;
                joinedTeam = true;
                NetMessage.SendData(MessageID.PlayerTeam, -1, -1, null, Main.myPlayer, QoLCompendium.mainConfig.AutoTeams, 0f, 0f, 0, 0, 0);
            }
        }

        public override void PostUpdateMiscEffects()
        {
            Player.tileSpeed -= QoLCompendium.mainConfig.IncreasePlaceSpeed;
            Player.wallSpeed -= QoLCompendium.mainConfig.IncreasePlaceSpeed;

            Player.tileRangeX += QoLCompendium.mainConfig.IncreasePlaceRange;
            Player.tileRangeY += QoLCompendium.mainConfig.IncreasePlaceRange;
        }

        public override void PostUpdateEquips()
        {
            if (ModContent.GetInstance<QoLCConfig>().NoChilled && Player.wet && Player.ZoneSnow && Main.expertMode)
            {
                Player.buffImmune[BuffID.Chilled] = true;
            }

            if (ModContent.GetInstance<QoLCConfig>().NoShimmerSink && Player.wet)
            {
                Player.buffImmune[BuffID.Shimmer] = true;
            }
        }

        public override void PreUpdateBuffs()
        {
            if (QoLCompendium.mainConfig.ToggleHappiness)
            {
                Player.currentShoppingSettings.PriceAdjustment = QoLCompendium.mainConfig.HappinessPriceChange;
            }
        }
    }

    public class VeinMiningPlayer : ModPlayer
    {
        public int ctr;
        private bool _canMine;
        private int cd;
        private int mcd;

        public static int miningSpeed => QoLCompendium.mainConfig.VeinMinerSpeed;

        private PriorityQueue<Point16, double> picks = new();

        // to stop cheating :P
        public int pickPower;

        public override void Initialize()
        {
            canMine = true;
        }

        public bool canMine
        {
            get => _canMine;
            set
            {
                cd = 60;
                _canMine = value;
            }
        }


        public override void PreUpdate()
        {
            // reflection
            var GetPickaxeDamage =
                typeof(Player).GetMethod("GetPickaxeDamage", BindingFlags.Instance | BindingFlags.NonPublic)!;
            cd--;
            mcd--;
            if (cd == 0)
            {
                canMine = true;
            }

            if (mcd <= 0)
            {
                var success = picks.TryDequeue(out var tile, out var _);
                if (success)
                {
                    var x = tile.X;
                    var y = tile.Y;

                    int dmg = (int)GetPickaxeDamage.Invoke(Player, new object[] { x, y, pickPower, 0, Main.tile[x, y] })!;
                    if (!WorldGen.CanKillTile(x, y))
                    {
                        dmg = 0;
                    }

                    if (dmg != 0)
                    {
                        WorldGen.KillTile(tile.X, tile.Y);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.TileManipulation, number2: tile.X, number3: tile.Y);
                        }

                        mcd = miningSpeed;
                    }
                }
            }
        }

        public void QueueTile(int x, int y)
        {
            var prio = Player.Distance(new Vector2(x * 16, y * 16));
            picks.Enqueue(new Point16(x, y), prio);
        }

        public bool NotInQueue(int x, int y)
        {
            return !Contains(picks, new Point16(x, y));
        }

        private bool Contains<T, U>(PriorityQueue<T, U> priorityQueue, T item)
        {
            return priorityQueue.UnorderedItems.Any(el => el.Element!.Equals(item));
        }
    }

    public class VeinMiningSystem : ModSystem
    {
        public static int threshold = 120;

        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("VanillaQoL", out Mod VanillaQoL);
            return QoLCompendium.mainConfig.VeinMiner && VanillaQoL == null;
        }

        public override void Load()
        {
            IL_Player.PickTile += pickTilePatch;
        }

        public override void Unload()
        {
            IL_Player.PickTile -= pickTilePatch;
        }

        // [38928 9 - 38928 32]
        // IL_02be: ldarg.1      // x
        // IL_02bf: ldarg.2      // y
        // IL_02c0: ldc.i4.0
        // IL_02c1: ldc.i4.0
        // IL_02c2: ldc.i4.0
        // IL_02c3: call         void Terraria.WorldGen::KillTile(int32, int32, bool, bool, bool)
        public void pickTilePatch(ILContext il)
        {
            var ilCursor = new ILCursor(il);
            if (!ilCursor.TryGotoNext(MoveType.Before, i => i.MatchLdarg1(),
                    i => i.MatchLdarg2(),
                    i => i.MatchLdcI4(0),
                    i => i.MatchLdcI4(0),
                    i => i.MatchLdcI4(0),
                    i => i.MatchCall<WorldGen>("KillTile")))
            {
                return;
            }

            ilCursor.EmitLdarg0();
            ilCursor.EmitCall<VeinMiningSystem>("ClearCD");
            ilCursor.EmitLdarg0();
            ilCursor.EmitLdarg1();
            ilCursor.EmitLdarg2();
            ilCursor.EmitLdarg3();
            ilCursor.EmitCall<VeinMiningSystem>("VeinMine");
        }

        public static void ClearCD(Player player)
        {
            // we reset counter *before* mining. Could do with additional parameter to veinMine functional-style
            // but eh, injecting another call is way easier
            var modPlayer = player.GetModPlayer<VeinMiningPlayer>();
            modPlayer.ctr = 0;
        }

        public static void VeinMine(Player player, int x, int y, int pickPower)
        {
            // if this is ore, don't even bother so we won't fall into recursion
            var tile = Framing.GetTileSafely(x, y);
            var modPlayer = player.GetModPlayer<VeinMiningPlayer>();

            if (tile.HasTile && CanVeinMine(tile) && modPlayer.canMine)
            {
                modPlayer.pickPower = pickPower;
                foreach (var coords in tileRot(x, y))
                {
                    var tile2 = Framing.GetTileSafely(coords.x, coords.y);

                    bool notInQueue = modPlayer.NotInQueue(coords.x, coords.y);

                    if (tile2.HasTile && CanVeinMine(tile2) && notInQueue)
                    {
                        // handle limits
                        modPlayer.ctr++;
                        if (modPlayer.ctr > threshold)
                        {
                            modPlayer.ctr = 0;
                            modPlayer.canMine = false;
                        }

                        // queue it first
                        modPlayer.QueueTile(coords.x, coords.y);
                        // recursion!
                        VeinMine(player, coords.x, coords.y, pickPower);
                    }
                }
            }
        }

        public static bool CanVeinMine(Tile tile)
        {
            if (QoLCompendium.mainConfig.VeinMinerWhitelist != null)
            {
                for (int i = 0; i < QoLCompendium.mainConfig.VeinMinerWhitelist.Count; i++)
                {
                    TileDefinition definition = QoLCompendium.mainConfig.VeinMinerWhitelist[i];
                    if (!definition.IsUnloaded && QoLCompendium.mainConfig.VeinMinerWhitelist.Contains(definition) && tile.TileType == definition.Type && definition != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // the other kind of rot
        public static IEnumerable<(int x, int y)> tileRot(int x, int y)
        {
            for (int i = x - 1; i <= x + 1; ++i)
            {
                for (int j = y - 1; j <= y + 1; ++j)
                {
                    if (i != x || j != y)
                    {
                        yield return (i, j);
                    }
                }
            }
        }
    }

    public static class VeinMinerExtension
    {
        public static ILCursor EmitCall<T>(this ILCursor ilCursor, string memberName) =>
        ilCursor.Emit<T>(OpCodes.Call, memberName);
    }
}