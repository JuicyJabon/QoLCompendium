using Mono.Cecil.Cil;
using MonoMod.Cil;
using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Content.Items.Mirrors;
using QoLCompendium.Content.Projectiles.MobileStorages;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.IO;
using static MonoMod.Cil.ILContext;

namespace QoLCompendium.Core.Changes
{
    public class PlayerChanges : ModSystem
    {
        private static bool _rebuilt;

        public override void Load()
        {
            On_HairstyleUnlocksHelper.ListWarrantsRemake += RebuildPatch;
            On_HairstyleUnlocksHelper.RebuildList += UnlockPatch;
        }

        public override void Unload()
        {
            On_HairstyleUnlocksHelper.ListWarrantsRemake -= RebuildPatch;
            On_HairstyleUnlocksHelper.RebuildList -= UnlockPatch;
        }

        private static bool RebuildPatch(On_HairstyleUnlocksHelper.orig_ListWarrantsRemake orig,
            HairstyleUnlocksHelper self)
        {
            if (!QoLCompendium.mainServerConfig.AllHairStylesAvailable)
                return false;

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
            if (!QoLCompendium.mainServerConfig.AllHairStylesAvailable)
                return;

            self.AvailableHairstyles.Clear();
            for (int i = 0; i < TextureAssets.PlayerHair.Length; i++)
            {
                self.AvailableHairstyles.Add(i);
            }
        }
    }

    public class PermanentUpgradePlayer : ModPlayer
    {
        //Exxo Avalon Origins
        public static int usedStaminaCrystalCount = 0;
        public static bool usedEnergyCrystal;

        //Fargos Souls
        public static bool usedDeerSinew;
        public static bool usedMutantsCreditCard;
        public static bool usedMutantsDiscountCard;
        public static bool usedMutantsPact;
        public static bool usedRabiesVaccine;

        //Redemption
        public static bool usedMedicKit;
        public static bool usedGalaxyHeart;

        //Thorium
        public static int usedCrystalWaveCount = 0;
        public static bool usedAstralWave;
        public static bool usedInspirationGem;

        public override void SaveData(TagCompound tag)
        {
            //Exxo Avalon Origins
            tag.Add("usedStaminaCrystalCount", usedStaminaCrystalCount);
            tag.Add("usedEnergyCrystal", usedEnergyCrystal);
            //Fargos Souls
            tag.Add("usedDeerSinew", usedDeerSinew);
            tag.Add("usedMutantsCreditCard", usedMutantsCreditCard);
            tag.Add("usedMutantsDiscountCard", usedMutantsDiscountCard);
            tag.Add("usedMutantsPact", usedMutantsPact);
            tag.Add("usedRabiesVaccine", usedRabiesVaccine);
            //Redemption
            tag.Add("usedMedicKit", usedMedicKit);
            tag.Add("usedGalaxyHeart", usedGalaxyHeart);
            //Thorium
            tag.Add("usedCrystalWaveCount", usedCrystalWaveCount);
            tag.Add("usedAstralWave", usedAstralWave);
            tag.Add("usedInspirationGem", usedInspirationGem);
        }

        public override void LoadData(TagCompound tag)
        {
            //Exxo Avalon Origins
            usedStaminaCrystalCount = tag.Get<int>("usedStaminaCrystalCount");
            usedEnergyCrystal = tag.Get<bool>("usedEnergyCrystal");
            //Fargos Souls
            usedDeerSinew = tag.Get<bool>("usedDeerSinew");
            usedMutantsCreditCard = tag.Get<bool>("usedMutantsCreditCard");
            usedMutantsDiscountCard = tag.Get<bool>("usedMutantsDiscountCard");
            usedMutantsPact = tag.Get<bool>("usedMutantsPact");
            usedRabiesVaccine = tag.Get<bool>("usedRabiesVaccine");
            //Redemption
            usedMedicKit = tag.Get<bool>("usedMedicKit");
            usedGalaxyHeart = tag.Get<bool>("usedGalaxyHeart");
            //Thorium
            usedCrystalWaveCount = tag.Get<int>("usedCrystalWaveCount");
            usedAstralWave = tag.Get<bool>("usedAstralWave");
            usedInspirationGem = tag.Get<bool>("usedInspirationGem");
        }
    }

    public class PermanentUpgradeItem : GlobalItem
    {
        public override bool? UseItem(Item item, Player player)
        {
            //EXXO AVALON ORIGINS
            //STAMINA CRYSTAL
            if (item.type == Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "StaminaCrystal") && PermanentUpgradePlayer.usedStaminaCrystalCount < 10)
                PermanentUpgradePlayer.usedStaminaCrystalCount += 1;
            //ENERGY CRYSTAL
            if (item.type == Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "EnergyCrystal"))
                PermanentUpgradePlayer.usedEnergyCrystal = true;

            //FARGOS SOULS
            //DEER SINEW
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "DeerSinew"))
                PermanentUpgradePlayer.usedDeerSinew = true;
            //MUTANT'S CREDIT CARD
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsCreditCard"))
                PermanentUpgradePlayer.usedMutantsCreditCard = true;
            //MUTANT'S DISCOUNT CARD
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsDiscountCard"))
                PermanentUpgradePlayer.usedMutantsDiscountCard = true;
            //MUTANT'S PACT
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsPact"))
                PermanentUpgradePlayer.usedMutantsPact = true;
            //RABIES VACCINE
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "RabiesVaccine"))
                PermanentUpgradePlayer.usedRabiesVaccine = true;

            //REDEMPTION
            //MEDIC KIT
            if (item.type == Common.GetModItem(ModConditions.redemptionMod, "MedicKit"))
                PermanentUpgradePlayer.usedMedicKit = true;
            //GALAXY HEART
            if (item.type == Common.GetModItem(ModConditions.redemptionMod, "GalaxyHeart"))
                PermanentUpgradePlayer.usedGalaxyHeart = true;

            //THORIUM
            //CRYSTAL WAVE
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "CrystalWave") && PermanentUpgradePlayer.usedCrystalWaveCount < 5)
                PermanentUpgradePlayer.usedCrystalWaveCount += 1;
            //ASTRAL WAVE
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "AstralWave"))
                PermanentUpgradePlayer.usedAstralWave = true;
            //INSPIRATION GEM
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationGem"))
                PermanentUpgradePlayer.usedInspirationGem = true;
            return base.UseItem(item, player);
        }
    }

    public class DashPlayer : ModPlayer
    {
        public int latestXDirPressed = 0;
        public int latestXDirReleased = 0;
        private bool LeftLastPressed = false;
        private bool RightLastPressed = false;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Main.LocalPlayer.controlLeft && !LeftLastPressed)
            {
                latestXDirPressed = -1;
            }
            if (Main.LocalPlayer.controlRight && !RightLastPressed)
            {
                latestXDirPressed = 1;
            }
            if (!Main.LocalPlayer.controlLeft && !Main.LocalPlayer.releaseLeft)
            {
                latestXDirReleased = -1;
            }
            if (!Main.LocalPlayer.controlRight && !Main.LocalPlayer.releaseRight)
            {
                latestXDirReleased = 1;
            }
            LeftLastPressed = Main.LocalPlayer.controlLeft;
            RightLastPressed = Main.LocalPlayer.controlRight;
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
            if (Player.whoAmI != Main.myPlayer || !QoLCompendium.mainServerConfig.AutoFishing)
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
            using IEnumerator<Projectile> enumerator = Main.projectile.Where((p) => p.active && p.owner == whoAmI && p.bobber).GetEnumerator();
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
            if (QoLCompendium.mainServerConfig.AutoFishing)
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
            (i) => i.MatchLdfld(typeof(FishingAttempt), "rolledItemDrop")
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
            (i) => i.MatchLdfld(typeof(FishingAttempt), "rolledEnemySpawn")
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
                if (!QoLCompendium.mainServerConfig.PortableCraftingStations)
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
        public int respawnFullHealthTimer = 0;

        private (int type, int time)[] buffCache;

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (QoLCompendium.mainServerConfig.InstantRespawn && Main.netMode == NetmodeID.SinglePlayer)
            {
                for (int k = 0; k < Main.maxNPCs; k++)
                {
                    if (!Main.npc[k].friendly && Main.npc[k].active)
                        DespawnNPC(k);
                    Player.respawnTimer = 60;
                }
            }

            if (QoLCompendium.mainServerConfig.KeepBuffsOnDeath)
            {
                buffCache ??= new (int, int)[Player.MaxBuffs];
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    buffCache[i] = (Player.buffType[i], Player.buffTime[i]);
                }
            }
        }

        public override void OnRespawn()
        {
            respawnFullHealthTimer = 1;

            if (QoLCompendium.mainServerConfig.KeepBuffsOnDeath)
            {
                (int, int)[] array = buffCache;
                for (int i = 0; i < array.Length; i++)
                {
                    var (num, num2) = array[i];
                    if ((QoLCompendium.mainServerConfig.KeepDebuffsOnDeath || !Main.debuff[num]) && num > 0 && !Main.persistentBuff[num] && num2 > 2)
                    {
                        int num3 = (int)(float)num2;
                        Player.AddBuff(num, num3, false, false);
                    }
                }
            }
        }

        public override void PostUpdate()
        {
            if (QoLCompendium.mainServerConfig.FullHealthRespawn && respawnFullHealthTimer == 0)
            {
                respawnFullHealthTimer = -1;
                Player.statLife = Player.statLifeMax2;
                Player.statMana = Player.statManaMax2;
            }
            respawnFullHealthTimer--;
        }

        public static void DespawnNPC(int npc)
        {
            Main.npc[npc].life = 0;
            Main.npc[npc].active = false;
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc, 0f, 0f, 0f, 0, 0, 0);
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
                if (safe != -1 && Main.projectile[safe].type != ModContent.ProjectileType<FlyingSafeProjectile>())
                {
                    safe = -1;
                    chests = false;
                }
                if (defenders != -1 && Main.projectile[defenders].type != ModContent.ProjectileType<EtherianConstructProjectile>())
                {
                    defenders = -1;
                    chests = false;
                }
            }
        }

        public override void UpdateEquips()
        {
            if (QoLCompendium.mainServerConfig.UtilityAccessoriesWorkInBanks)
            {
                for (int i = 0; i < Player.bank.item.Length; i++)
                    CheckAllAccessories(Player.bank.item[i]);
                for (int j = 0; j < Player.bank2.item.Length; j++)
                    CheckAllAccessories(Player.bank2.item[j]);
                for (int k = 0; k < Player.bank3.item.Length; k++)
                    CheckAllAccessories(Player.bank3.item[k]);
                for (int l = 0; l < Player.bank4.item.Length; l++)
                    CheckAllAccessories(Player.bank4.item[l]);
            }
        }

        public void CheckAllAccessories(Item item)
        {
            //CHECKS ALL ACCESSORY TYPES
            CheckMoneyAccessories(item);
            CheckWireAccessories(item);
            CheckInformationAccessories(item);
            CheckBuildingAccessories(item);
            CheckFishingAccessories(item);
            CheckMiscAccessories(item);

            //FIX CALAMITY STAT INCREASES FOR DEFENSE PREFIXES
            if (ModConditions.calamityLoaded)
                RemoveCalamityDefensePrefix(Player, item);
        }

        public void CheckMoneyAccessories(Item item)
        {
            //GREEDY RING
            if (item.type == ItemID.GreedyRing)
            {
                Player.goldRing = true; //GOLD RING
                Player.hasLuckyCoin = true; //LUCKY COIN
                Player.hasLuck_LuckyCoin = true; //LUCKY COIN
                Player.discountEquipped = true; //DISCOUNT CARD
            }

            //COIN RING
            if (item.type == ItemID.CoinRing)
            {
                Player.goldRing = true; //GOLD RING
                Player.hasLuckyCoin = true; //LUCKY COIN
                Player.hasLuck_LuckyCoin = true; //LUCKY COIN
            }

            //COMPONENTS
            if (item.type == ItemID.DiscountCard) //DISCOUNT CARD
                Player.discountEquipped = true;
            if (item.type == ItemID.LuckyCoin) //LUCKY COIN
            {
                Player.hasLuckyCoin = true;
                Player.hasLuck_LuckyCoin = true;
            }
            if (item.type == ItemID.GoldRing) //GOLD RING
                Player.goldRing = true;

            //MODDED
            #region AEQUUS
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "BusinessCard"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion

            #region THORIUM
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "GlitteringChalice"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "GreedyGoblet"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion
        }

        public void CheckWireAccessories(Item item)
        {
            //GRAND DESIGN
            if (item.type == ItemID.WireKite)
            {
                Player.InfoAccMechShowWires = true; //MECHANICAL LENS
                Player.rulerGrid = true; //MECHANICAL RULER
                Player.rulerLine = true; //RULER
            }

            //COMPONENTS
            if (item.type == ItemID.MechanicalLens) //MECHANICAL LENS
                Player.InfoAccMechShowWires = true;
            if (item.type == ItemID.LaserRuler) //MECHANICAL RULER
                Player.rulerGrid = true;
            
        }

        public void CheckInformationAccessories(Item item)
        {
            //PDA / CELL PHONE / SHELLPHONE
            if (item.type == ItemID.PDA || item.type == ItemID.CellPhone || item.type == ItemID.ShellphoneDummy || item.type == ItemID.Shellphone || item.type == ItemID.ShellphoneSpawn || item.type == ItemID.ShellphoneOcean || item.type == ItemID.ShellphoneHell)
            {
                //GPS
                Player.accWatch = 3; //GOLD / PLATINUM WATCH
                Player.accDepthMeter = 1; //DEPTH METER
                Player.accCompass = 1; //COMPASS

                //R.E.K. 3000
                Player.accThirdEye = true; //RADAR
                Player.accCritterGuide = true; //LIFEFORM ANALYZER
                Player.accJarOfSouls = true; //TALLY COUNTER

                //GOBLIN TECH
                Player.accOreFinder = true; //METAL DETECTOR
                Player.accStopwatch = true; //STOPWATCH
                Player.accDreamCatcher = true; //DPS METER

                //FISH FINDER
                Player.accFishFinder = true; //FISHERMAN'S POCKET GUIDE
                Player.accWeatherRadio = true; //WEATHER RADIO
                Player.accCalendar = true; //SEXTANT
            }

            //COMBOS
            if (item.type == ItemID.GPS) //GPS
            {
                Player.accWatch = 3; //GOLD / PLATINUM WATCH
                Player.accDepthMeter = 1; //DEPTH METER
                Player.accCompass = 1; //COMPASS
            }
            if (item.type == ItemID.REK) //R.E.K. 3000
            {
                Player.accThirdEye = true; //RADAR
                Player.accCritterGuide = true; //LIFEFORM ANALYZER
                Player.accJarOfSouls = true; //TALLY COUNTER
            }
            if (item.type == ItemID.GoblinTech) //GOBLIN TECH
            {
                Player.accOreFinder = true; //METAL DETECTOR
                Player.accStopwatch = true; //STOPWATCH
                Player.accDreamCatcher = true; //DPS METER
            }
            if (item.type == ItemID.FishFinder) //FISH FINDER
            {
                Player.accFishFinder = true; //FISHERMAN'S POCKET GUIDE
                Player.accWeatherRadio = true; //WEATHER RADIO
                Player.accCalendar = true; //SEXTANT
            }

            //GPS
            if ((item.type == ItemID.CopperWatch || item.type == ItemID.TinWatch) && Player.accWatch < 1) //COPPER / TIN WATCHES
                Player.accWatch = 1;
            if ((item.type == ItemID.SilverWatch || item.type == ItemID.TungstenWatch) && Player.accWatch < 2) //SILVER / TUNGSTEN WATCHES
                Player.accWatch = 2;
            if (item.type == ItemID.GoldWatch || item.type == ItemID.PlatinumWatch && Player.accWatch < 3) //GOLD / PLATINUM WATCHES
                Player.accWatch = 3;
            if (item.type == ItemID.DepthMeter) //DEPTH METER
                Player.accDepthMeter = 1;
            if (item.type == ItemID.Compass) //COMPASS
                Player.accCompass = 1;

            //R.E.K. 3000
            if (item.type == ItemID.Radar) //RADAR
                Player.accThirdEye = true;
            if (item.type == ItemID.LifeformAnalyzer) //LIFEFORM ANALYZER
                Player.accCritterGuide = true;
            if (item.type == ItemID.TallyCounter) //TALLY COUNTER
                Player.accJarOfSouls = true;

            //GOBLIN TECH
            if (item.type == ItemID.MetalDetector) //METAL DETECTOR
                Player.accOreFinder = true;
            if (item.type == ItemID.Stopwatch) //STOPWATCH
                Player.accStopwatch = true;
            if (item.type == ItemID.DPSMeter) //DPS METER
                Player.accDreamCatcher = true;

            //FISH FINDER
            if (item.type == ItemID.FishermansGuide) //FISHERMAN'S POCKET GUIDE
                Player.accFishFinder = true;
            if (item.type == ItemID.WeatherRadio) //WEATHER RADIO
                Player.accWeatherRadio = true;
            if (item.type == ItemID.Sextant) //SEXTANT
                Player.accCalendar = true;

            //MODDED
            #region AEQUUS
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "AnglerBroadcaster"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "Calendar"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "GeigerCounter"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "HoloLens"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "RichMansMonocle"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            #endregion

            #region BLOCKS INFO ACCESSORIES
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "AttendanceLog"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "BiomeCrystal"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "EngiRegistry"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "FortuneMirror"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "HitMarker"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "Magimeter"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "RSH"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "SafteyScanner"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "ScryingMirror"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "SmartHeart"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "ThreatAnalyzer"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            if (item.type == Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "WantedPoster"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            #endregion

            #region QUALITY OF LIFE COMPENDIUM
            //IAH / MOSAIC MIRROR
            if (item.type == ModContent.ItemType<IAH>() || item.type == ModContent.ItemType<MosaicMirror>())
            {
                //FITBIT
                Player.GetInfoPlayer().kettlebell = true; //KETTLEBELL
                Player.GetInfoPlayer().reinforcedPanel = true; //REINFORCED PANEL
                Player.GetInfoPlayer().wingTimer = true; //WING TIMER

                //HEARTBEAT SENSOR
                Player.GetInfoPlayer().battalionLog = true; //BATTALION LOG
                Player.GetInfoPlayer().headCounter = true; //HEAD COUNTER
                Player.GetInfoPlayer().trackingDevice = true; //TRACKING DEVICE

                //TOLERANCE DETECTOR
                Player.GetInfoPlayer().harmInducer = true; //HARM INDUCER
                Player.GetInfoPlayer().luckyDie = true; //LUCKY DIE
                Player.GetInfoPlayer().plateCracker = true; //PLATE CRACKER

                //VITAL DISPLAY
                Player.GetInfoPlayer().metallicClover = true; //METALLIC CLOVER
                Player.GetInfoPlayer().regenerator = true; //REGENERATOR
                Player.GetInfoPlayer().replenisher = true; //REPLENISHER
            }

            //COMBOS
            if (item.type == ModContent.ItemType<Fitbit>()) //FITBIT
            {
                Player.GetInfoPlayer().kettlebell = true; //KETTLEBELL
                Player.GetInfoPlayer().reinforcedPanel = true; //REINFORCED PANEL
                Player.GetInfoPlayer().wingTimer = true; //WING TIMER
            }
            if (item.type == ModContent.ItemType<HeartbeatSensor>()) //HEARTBEAT SENSOR
            {
                Player.GetInfoPlayer().battalionLog = true; //BATTALION LOG
                Player.GetInfoPlayer().headCounter = true; //HEAD COUNTER
                Player.GetInfoPlayer().trackingDevice = true; //TRACKING DEVICE
            }
            if (item.type == ModContent.ItemType<ToleranceDetector>()) //TOLERANCE DETECTOR
            {
                Player.GetInfoPlayer().harmInducer = true; //HARM INDUCER
                Player.GetInfoPlayer().luckyDie = true; //LUCKY DIE
                Player.GetInfoPlayer().plateCracker = true; //PLATE CRACKER
            }
            if (item.type == ModContent.ItemType<VitalDisplay>()) //VITAL DISPLAY
            {
                Player.GetInfoPlayer().metallicClover = true; //METALLIC CLOVER
                Player.GetInfoPlayer().regenerator = true; //REGENERATOR
                Player.GetInfoPlayer().replenisher = true; //REPLENISHER
            }

            //FITBIT
            if (item.type == ModContent.ItemType<Kettlebell>()) //KETTLEBELL
                Player.GetInfoPlayer().kettlebell = true;
            if (item.type == ModContent.ItemType<ReinforcedPanel>()) //REINFORCED PANEL
                Player.GetInfoPlayer().reinforcedPanel = true;
            if (item.type == ModContent.ItemType<WingTimer>()) //WING TIMER
                Player.GetInfoPlayer().wingTimer = true;

            //HEARTBEAT SENSOR
            if (item.type == ModContent.ItemType<BattalionLog>()) //BATTALION LOG
                Player.GetInfoPlayer().battalionLog = true;
            if (item.type == ModContent.ItemType<HeadCounter>()) //HEAD COUNTER
                Player.GetInfoPlayer().headCounter = true;
            if (item.type == ModContent.ItemType<TrackingDevice>()) //TRACKING DEVICE
                Player.GetInfoPlayer().trackingDevice = true;

            //TOLERANCE DETECTOR
            if (item.type == ModContent.ItemType<HarmInducer>()) //HARM INDUCER
                Player.GetInfoPlayer().harmInducer = true;
            if (item.type == ModContent.ItemType<LuckyDie>()) //LUCKY DIE
                Player.GetInfoPlayer().luckyDie = true;
            if (item.type == ModContent.ItemType<PlateCracker>()) //PLATE CRACKER
                Player.GetInfoPlayer().plateCracker = true;

            //VITAL DISPLAY
            if (item.type == ModContent.ItemType<MetallicClover>()) //METALLIC CLOVER
                Player.GetInfoPlayer().metallicClover = true;
            if (item.type == ModContent.ItemType<Regenerator>()) //REGENERATOR
                Player.GetInfoPlayer().regenerator = true;
            if (item.type == ModContent.ItemType<Replenisher>()) //REPLENISHER
                Player.GetInfoPlayer().replenisher = true;
            #endregion

            #region THORIUM
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "HeartRateMonitor"))
            {
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
            }
            #endregion
        }

        public void CheckBuildingAccessories(Item item)
        {
            //HAND OF CREATION
            if (item.type == ItemID.HandOfCreation)
            {
                Player.equippedAnyTileSpeedAcc = true; //BRICK LAYER
                Player.equippedAnyTileRangeAcc = true; //EXTENDO GRIP
                Player.autoPaint = true; //PAINT SPRAYER
                Player.equippedAnyWallSpeedAcc = true; //PORTABLE CEMENT MIXER
                Player.chiselSpeed = true; //ANCIENT CHISEL
                Player.treasureMagnet = true; //TREASURE MAGNET
            }

            //ARCHITECT GIZMO PACK
            if (item.type == ItemID.ArchitectGizmoPack)
            {
                Player.equippedAnyTileSpeedAcc = true; //BRICK LAYER
                Player.equippedAnyTileRangeAcc = true; //EXTENDO GRIP
                Player.autoPaint = true; //PAINT SPRAYER
                Player.equippedAnyWallSpeedAcc = true; //PORTABLE CEMENT MIXER
            }

            //COMPONENTS
            if (item.type == ItemID.BrickLayer) //BRICK LAYER
                Player.equippedAnyTileSpeedAcc = true;
            if (item.type == ItemID.ExtendoGrip) //EXTENDO GRIP
                Player.equippedAnyTileRangeAcc = true;
            if (item.type == ItemID.PaintSprayer) //PAINT SPRAYER
                Player.autoPaint = true;
            if (item.type == ItemID.PortableCementMixer) //PORTABLE CEMENT MIXER
                Player.equippedAnyWallSpeedAcc = true;
            if (item.type == ItemID.AncientChisel) //ANCIENT CHISEL
                Player.chiselSpeed = true;
            if (item.type == ItemID.TreasureMagnet) //TREASURE MAGNET
                Player.treasureMagnet = true;

            //MISC
            if (item.type == ItemID.ActuationAccessory) //PRESSERATOR
                Player.autoActuator = true;
            if (item.type == ItemID.Toolbelt) //TOOLBELT
                Player.blockRange += 1;
            if (item.type == ItemID.Toolbox) //TOOLBOX
            {
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
            }
            if (item.type == ItemID.SpectreGoggles) //SPECTRE GOGGLES
                Player.CanSeeInvisibleBlocks = true;
            if (item.type == ItemID.DontHurtComboBook)//GUIDE TO PEACEFUL COEXISTENCE
            {
                Player.dontHurtCritters = true;
                Player.dontHurtNature = true;
            }
            if (item.type == ItemID.DontHurtCrittersBook) //GUIDE TO CRITTER COMPANIONSHIP
                Player.dontHurtCritters = true;
            if (item.type == ItemID.DontHurtNatureBook) //GUIDE TO ENVIRONMENTAL PRESERVATION
                Player.dontHurtNature = true;

            //MODDED
            #region AEQUUS
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "LavaproofMitten"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "HaltingMachine"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "HaltingMagnet"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion

            #region CALAMITY
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "AncientFossil"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "OceanCrest"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "SpelunkersAmulet"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion

            #region SPIRIT
            if (item.type == Common.GetModItem(ModConditions.spiritMod, "MetalBand"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion
        }

        public void CheckFishingAccessories(Item item)
        {
            //LAVAPROOF TACKLE BAG
            if (item.type == ItemID.LavaproofTackleBag)
            {
                Player.accFishingLine = true; //HIGH TEST FISHING LINE
                Player.fishingSkill += 10; //ANGLER EARRING
                Player.accTackleBox = true; //TACKLE BOX
                Player.accLavaFishing = true; //LAVA FISHING HOOK
            }

            //ANGLER TACKLE BAG
            if (item.type == ItemID.AnglerTackleBag)
            {
                Player.accFishingLine = true; //HIGH TEST FISHING LINE
                Player.fishingSkill += 10; //ANGLER EARRING
                Player.accTackleBox = true; //TACKLE BOX
            }

            //COMPONENTS
            if (item.type == ItemID.HighTestFishingLine) //HIGH TEST FISHING LINE
                Player.accFishingLine = true;
            if (item.type == ItemID.AnglerEarring) //ANGLER EARRING
                Player.fishingSkill += 10;
            if (item.type == ItemID.TackleBox) //TACKLE BOX
                Player.accTackleBox = true;
            if (item.type == ItemID.LavaFishingHook) //LAVA FISHING HOOK
                Player.accLavaFishing = true;

            //FISHING BOBBERS
            if (item.type == ItemID.FishingBobber || item.type == ItemID.FishingBobberGlowingStar || item.type == ItemID.FishingBobberGlowingLava || item.type == ItemID.FishingBobberGlowingKrypton || item.type == ItemID.FishingBobberGlowingXenon || item.type == ItemID.FishingBobberGlowingArgon || item.type == ItemID.FishingBobberGlowingViolet || item.type == ItemID.FishingBobberGlowingRainbow)
                Player.accFishingBobber = true;

            //MODDED
            #region AEQUUS
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "DevilsTongue"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "NeonGenesis"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "RadonFishingBobber"))
            {
                Player.ApplyEquipFunctional(item, false);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "Ramishroom"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "RegrowingBait"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion

            #region CALAMITY
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "AlluringBait"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "EnchantedPearl"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "SupremeBaitTackleBoxFishingStation"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion

            #region SPIRIT
            if (item.type == Common.GetModItem(ModConditions.spiritMod, "MimicRepellent"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion

            #region THORIUM
            if (item.type == Common.GetModItem(ModConditions.thoriumMod, "HightechSonarDevice"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion
        }

        public void CheckMiscAccessories(Item item)
        {
            if (item.type == ItemID.RoyalGel) //ROYAL GEL
            {
                Player.npcTypeNoAggro[NPCID.BlueSlime] = true;
                Player.npcTypeNoAggro[NPCID.MotherSlime] = true;
                Player.npcTypeNoAggro[NPCID.LavaSlime] = true;
                Player.npcTypeNoAggro[NPCID.DungeonSlime] = true;
                Player.npcTypeNoAggro[NPCID.CorruptSlime] = true;
                Player.npcTypeNoAggro[NPCID.IlluminantSlime] = true;
                Player.npcTypeNoAggro[NPCID.Slimer] = true;
                Player.npcTypeNoAggro[NPCID.Gastropod] = true;
                Player.npcTypeNoAggro[NPCID.ToxicSludge] = true;
                Player.npcTypeNoAggro[NPCID.IceSlime] = true;
                Player.npcTypeNoAggro[NPCID.Crimslime] = true;
                Player.npcTypeNoAggro[NPCID.SpikedIceSlime] = true;
                Player.npcTypeNoAggro[NPCID.SpikedJungleSlime] = true;
                Player.npcTypeNoAggro[NPCID.UmbrellaSlime] = true;
                Player.npcTypeNoAggro[NPCID.RainbowSlime] = true;
                Player.npcTypeNoAggro[NPCID.SlimeMasked] = true;
                Player.npcTypeNoAggro[NPCID.SlimeRibbonWhite] = true;
                Player.npcTypeNoAggro[NPCID.SlimeRibbonGreen] = true;
                Player.npcTypeNoAggro[NPCID.SlimeRibbonYellow] = true;
                Player.npcTypeNoAggro[NPCID.SlimeRibbonRed] = true;
                Player.npcTypeNoAggro[NPCID.SandSlime] = true;
                Player.npcTypeNoAggro[NPCID.ShimmerSlime] = true;
                Player.npcTypeNoAggro[NPCID.GoldenSlime] = true;
            }
            if (item.type == ItemID.ShimmerCloak && !Player.controlDownHold) //CHROMATIC CLOAK
                Player.shimmerImmune = true;
            if (item.type == ItemID.DontStarveShaderItem) //RADIO THING
                Player.dontStarveShader = true;

            //MODDED
            #region AEQUUS
            if (item.type == Common.GetModItem(ModConditions.aequusMod, "HyperJet"))
            {
                Player.ApplyEquipFunctional(item, true);
            }
            #endregion
        }

        public static void RemoveCalamityDefensePrefix(Player player, Item item)
        {
            if (item.prefix == PrefixID.Hard)
            {
                if (ModConditions.downedDevourerOfGods)
                {
                    player.statDefense -= 3;
                }
                else if (NPC.downedMoonlord)
                {
                    player.statDefense -= 2;
                }
                else if (Main.hardMode)
                {
                    player.statDefense -= 1;
                }
                player.endurance -= 0.0025f;
            }
            if (item.prefix == PrefixID.Guarding)
            {
                if (ModConditions.downedDevourerOfGods)
                {
                    player.statDefense -= 4;
                }
                else if (NPC.downedMoonlord)
                {
                    player.statDefense -= 2;
                }
                else if (Main.hardMode)
                {
                    player.statDefense -= 1;
                }
                player.endurance -= 0.005f;
            }
            if (item.prefix == PrefixID.Armored)
            {
                if (ModConditions.downedDevourerOfGods)
                {
                    player.statDefense -= 5;
                }
                else if (NPC.downedMoonlord)
                {
                    player.statDefense -= 3;
                }
                else if (Main.hardMode)
                {
                    player.statDefense -= 2;
                }
                player.endurance -= 0.0075f;
            }
            if (item.prefix == PrefixID.Warding)
            {
                if (ModConditions.downedDevourerOfGods)
                {
                    player.statDefense -= 6;
                }
                else if (NPC.downedMoonlord)
                {
                    player.statDefense -= 4;
                }
                else if (Main.hardMode)
                {
                    player.statDefense -= 2;
                }
                player.endurance -= 0.01f;
            }
        }
    }

    public class MiscEffectsPlayer : ModPlayer
    {
        public bool joinedTeam = false;

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (Player != Main.player[Main.myPlayer])
                return;

            if (QoLCompendium.mainServerConfig.AutoTeams > 0 && joinedTeam == false && Main.netMode == NetmodeID.MultiplayerClient)
            {
                Main.player[Main.myPlayer].team = QoLCompendium.mainServerConfig.AutoTeams;
                joinedTeam = true;
                NetMessage.SendData(MessageID.PlayerTeam, -1, -1, null, Main.myPlayer, QoLCompendium.mainServerConfig.AutoTeams, 0f, 0f, 0, 0, 0);
            }
        }

        public override void PostUpdateMiscEffects()
        {
            //PLACE SPEED INCREASE
            Player.tileSpeed -= QoLCompendium.mainServerConfig.IncreasePlaceSpeed;
            Player.wallSpeed -= QoLCompendium.mainServerConfig.IncreasePlaceSpeed;

            //PLACE RANGE INCREASE
            Player.tileRangeX += QoLCompendium.mainServerConfig.IncreasePlaceRange;
            Player.tileRangeY += QoLCompendium.mainServerConfig.IncreasePlaceRange;
        }

        public override void PostUpdateEquips()
        {
            //REMOVES ICE BIOME EXPERT CHANGE
            if (ModContent.GetInstance<QoLCConfig>().NoExpertIceWaterChilled && Player.wet && Player.ZoneSnow && Main.expertMode)
            {
                Player.buffImmune[BuffID.Chilled] = true;
                Player.chilled = false;
            }

            //REMOVES SHIMMER SINKING
            if (ModContent.GetInstance<QoLCConfig>().NoShimmerSink && Player.wet)
            {
                Player.buffImmune[BuffID.Shimmer] = true;
                Player.shimmerImmune = true;
            }
        }

        public override void PreUpdateBuffs()
        {
            //CHANGES SHOP PRICES WHEN HAPPINESS IS DISABLED
            if (QoLCompendium.mainServerConfig.DisableHappiness)
                Player.currentShoppingSettings.PriceAdjustment = QoLCompendium.mainServerConfig.HappinessPriceChange;
        }
    }

    public class VeinMiningPlayer : ModPlayer
    {
        public int ctr;
        private bool _canMine;
        private int cd;
        private int mcd;

        public static int MiningSpeed => QoLCompendium.mainServerConfig.VeinMinerSpeed;

        private PriorityQueue<Point16, double> picks = new();

        public int pickPower;

        public override void Initialize()
        {
            CanMine = true;
        }

        public bool CanMine
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
            var GetPickaxeDamage =
                typeof(Player).GetMethod("GetPickaxeDamage", BindingFlags.Instance | BindingFlags.NonPublic)!;
            cd--;
            mcd--;
            if (cd == 0)
            {
                CanMine = true;
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

                        mcd = MiningSpeed;
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
#pragma warning disable
        public static int threshold = QoLCompendium.mainServerConfig.VeinMinerTileLimit;
#pragma warning restore

        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("VanillaQoL", out Mod VanillaQoL);
            return QoLCompendium.mainServerConfig.VeinMiner && VanillaQoL == null;
        }

        public override void Load()
        {
            IL_Player.PickTile += PickTilePatch;
        }

        public override void Unload()
        {
            IL_Player.PickTile -= PickTilePatch;
        }

        public void PickTilePatch(ILContext il)
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
            var modPlayer = player.GetModPlayer<VeinMiningPlayer>();
            modPlayer.ctr = 0;
        }

        public static void VeinMine(Player player, int x, int y, int pickPower)
        {
            var tile = Framing.GetTileSafely(x, y);
            var modPlayer = player.GetModPlayer<VeinMiningPlayer>();

            if (tile.HasTile && CanVeinMine(tile) && modPlayer.CanMine)
            {
                modPlayer.pickPower = pickPower;
                foreach (var coords in TileRot(x, y))
                {
                    var tile2 = Framing.GetTileSafely(coords.x, coords.y);

                    bool notInQueue = modPlayer.NotInQueue(coords.x, coords.y);

                    if (tile2.HasTile && CanVeinMine(tile2) && notInQueue)
                    {
                        modPlayer.ctr++;
                        if (modPlayer.ctr > threshold)
                        {
                            modPlayer.ctr = 0;
                            modPlayer.CanMine = false;
                        }

                        modPlayer.QueueTile(coords.x, coords.y);
                        VeinMine(player, coords.x, coords.y, pickPower);
                    }
                }
            }
        }

        public static bool CanVeinMine(Tile tile)
        {
            if (QoLCompendium.mainServerConfig.VeinMinerWhitelist != null)
            {
                for (int i = 0; i < QoLCompendium.mainServerConfig.VeinMinerWhitelist.Count; i++)
                {
                    TileDefinition definition = QoLCompendium.mainServerConfig.VeinMinerWhitelist.ElementAt(i);
                    if (!definition.IsUnloaded && QoLCompendium.mainServerConfig.VeinMinerWhitelist.Contains(definition) && tile.TileType == definition.Type && definition != null)
                    {
                        return true;
                    }
                }
            }
            if (tile.TileType <= TileID.Count && Common.DefaultVeinMinerWhitelist != null)
            {
                for (int i = 0; i < Common.DefaultVeinMinerWhitelist.Count; i++)
                {
                    TileDefinition definition = Common.DefaultVeinMinerWhitelist.ElementAt(i);
                    if (!definition.IsUnloaded && Common.DefaultVeinMinerWhitelist.Contains(definition) && tile.TileType == definition.Type && definition != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static IEnumerable<(int x, int y)> TileRot(int x, int y)
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