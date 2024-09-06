using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Content.Items.Mirrors;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Core.Changes
{
    public class TooltipChanges : GlobalItem
    {
        private static Item _shimmerItemDisplay;

        private static NPC _shimmerNPCDisplay;

        public override void SetStaticDefaults()
        {
            _shimmerItemDisplay = new Item();
            _shimmerNPCDisplay = new NPC();
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine fav = tooltips.Find(l => l.Name == "Favorite");
            TooltipLine favDescr = tooltips.Find(l => l.Name == "FavoriteDesc");

            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip) tooltips.Remove(fav);
            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip) tooltips.Remove(favDescr);
            if (QoLCompendium.tooltipConfig.ShimmerableTooltip) ShimmmerableTooltips(item, tooltips);
            if (QoLCompendium.tooltipConfig.WorksInBanksTooltip && QoLCompendium.mainServerConfig.UtilityAccessoriesWorkInBanks) WorksInBankTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.WingStatsTooltips) WingStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.HookStatsTooltips) HookStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
            if (QoLCompendium.tooltipConfig.AmmoTooltip) AmmoTooltip(item, tooltips);
        }
#pragma warning disable
        public static void AddLastTooltip(List<TooltipLine> tooltips, TooltipLine tooltip)
        {
            var last = tooltips.FindLast(t => t.Mod == "Terraria" && t.Name != "Expert" && t.Name != "Master")!;
            tooltips.AddAfter(last, tooltip);
        }

        public void ShimmmerableTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!item.CanShimmer())
            {
                return;
            }
            int countsAsIem = ItemID.Sets.ShimmerCountsAsItem[item.type];
            int type = ((countsAsIem != -1) ? countsAsIem : item.type);
            int transformsToItem = ItemID.Sets.ShimmerTransformToItem[type];
            int npcID = -1;
            if (type == ItemID.GelBalloon && !NPC.unlockedSlimeRainbowSpawn && !QoLCompendium.mainServerConfig.NoTownSlimes)
            {
                npcID = NPCID.TownSlimeRainbow;
            }
            else if (item.makeNPC > 0)
            {
                int npc = NPCID.Sets.ShimmerTransformToNPC[item.makeNPC];
                npcID = ((npc != -1) ? npc : item.makeNPC);
            }
            else if (type == ItemID.LunarBrick)
            {
                MoonPhase moonPhase = Main.GetMoonPhase();
                transformsToItem = (int)moonPhase switch
                {
                    5 => ItemID.StarRoyaleBrick,
                    6 => ItemID.CryocoreBrick,
                    7 => ItemID.CosmicEmberBrick,
                    0 => ItemID.HeavenforgeBrick,
                    1 => ItemID.LunarRustBrick,
                    2 => ItemID.AstraBrick,
                    3 => ItemID.DarkCelestialBrick,
                    _ => ItemID.MercuryBrick,
                };
            }
            else if (item.createTile == TileID.MusicBoxes)
            {
                transformsToItem = ItemID.MusicBox;
            }
            string shimmerTextValue = GetTooltipValue("Shimmerable");
            if (transformsToItem != -1)
            {
                _shimmerItemDisplay.SetDefaults(transformsToItem);
                shimmerTextValue = GetTooltipValue("ShimmerableIntoItem", transformsToItem, _shimmerItemDisplay.Name);
            }
            else if (npcID != -1)
            {
                _shimmerNPCDisplay.SetDefaults(npcID, default(NPCSpawnParams));
                shimmerTextValue = GetTooltipValue("ShimmerableIntoNPC", _shimmerNPCDisplay.GivenOrTypeName);
            }
            else
            {
                int coinLuck = ItemID.Sets.CoinLuckValue[type];
                if (coinLuck <= 0)
                {
                    return;
                }
                shimmerTextValue = GetTooltipValue("ShimmerCoinLuck", $"+{coinLuck:##,###}");
            }
            var tooltipLine = new TooltipLine(Mod, "ShimmerInfo", shimmerTextValue);
            tooltipLine.OverrideColor = Color.Plum;
            AddLastTooltip(tooltips, tooltipLine);
        }

        public void WorksInBankTooltip(Item item, List<TooltipLine> tooltips)
        {
            string tooltip;
            List<int> ItemsForBanks = new()
            {
                ItemID.DiscountCard,
                ItemID.LuckyCoin,
                ItemID.GoldRing,
                ItemID.CoinRing,
                ItemID.GreedyRing,
                ItemID.MechanicalLens,
                ItemID.LaserRuler,
                ItemID.WireKite,
                ItemID.PDA,
                ItemID.CellPhone,
                ItemID.ShellphoneDummy,
                ItemID.Shellphone,
                ItemID.ShellphoneSpawn,
                ItemID.ShellphoneOcean,
                ItemID.ShellphoneHell,
                ItemID.GPS,
                ItemID.REK,
                ItemID.GoblinTech,
                ItemID.FishFinder,
                ItemID.CopperWatch,
                ItemID.TinWatch,
                ItemID.SilverWatch,
                ItemID.TungstenWatch,
                ItemID.GoldWatch,
                ItemID.PlatinumWatch,
                ItemID.DepthMeter,
                ItemID.Compass,
                ItemID.Radar,
                ItemID.LifeformAnalyzer,
                ItemID.TallyCounter,
                ItemID.MetalDetector,
                ItemID.Stopwatch,
                ItemID.DPSMeter,
                ItemID.FishermansGuide,
                ItemID.WeatherRadio,
                ItemID.Sextant,
                ItemID.AncientChisel,
                ItemID.Toolbelt,
                ItemID.Toolbox,
                ItemID.ExtendoGrip,
                ItemID.PortableCementMixer,
                ItemID.PaintSprayer,
                ItemID.BrickLayer,
                ItemID.ArchitectGizmoPack,
                ItemID.HandOfCreation,
                ItemID.ActuationAccessory,
                ItemID.HighTestFishingLine,
                ItemID.AnglerEarring,
                ItemID.TackleBox,
                ItemID.LavaFishingHook,
                ItemID.AnglerTackleBag,
                ItemID.LavaproofTackleBag,
                ItemID.FishingBobber,
                ItemID.FishingBobberGlowingStar,
                ItemID.FishingBobberGlowingLava,
                ItemID.FishingBobberGlowingKrypton,
                ItemID.FishingBobberGlowingXenon,
                ItemID.FishingBobberGlowingArgon,
                ItemID.FishingBobberGlowingViolet,
                ItemID.FishingBobberGlowingRainbow,
                ItemID.TreasureMagnet,
                ItemID.RoyalGel,
                ItemID.SpectreGoggles,
                ItemID.DontHurtCrittersBook,
                ItemID.DontHurtNatureBook,
                ItemID.DontHurtComboBook,
                ItemID.ShimmerCloak,
                ItemID.DontStarveShaderItem,
                ModContent.ItemType<BattalionLog>(),
                ModContent.ItemType<HarmInducer>(),
                ModContent.ItemType<HeadCounter>(),
                ModContent.ItemType<Kettlebell>(),
                ModContent.ItemType<LuckyDie>(),
                ModContent.ItemType<MetallicClover>(),
                ModContent.ItemType<PlateCracker>(),
                ModContent.ItemType<Regenerator>(),
                ModContent.ItemType<ReinforcedPanel>(),
                ModContent.ItemType<Replenisher>(),
                ModContent.ItemType<TrackingDevice>(),
                ModContent.ItemType<WingTimer>(),
                ModContent.ItemType<Fitbit>(),
                ModContent.ItemType<HeartbeatSensor>(),
                ModContent.ItemType<ToleranceDetector>(),
                ModContent.ItemType<VitalDisplay>(),
                ModContent.ItemType<IAH>(),
                ModContent.ItemType<MosaicMirror>(),
                Common.GetModItem(ModConditions.aequusMod, "AnglerBroadcaster"),
                Common.GetModItem(ModConditions.aequusMod, "Calendar"),
                Common.GetModItem(ModConditions.aequusMod, "GeigerCounter"),
                Common.GetModItem(ModConditions.aequusMod, "HoloLens"),
                Common.GetModItem(ModConditions.aequusMod, "RichMansMonocle"),
                Common.GetModItem(ModConditions.aequusMod, "DevilsTongue"),
                Common.GetModItem(ModConditions.aequusMod, "NeonGenesis"),
                Common.GetModItem(ModConditions.aequusMod, "RadonFishingBobber"),
                Common.GetModItem(ModConditions.aequusMod, "Ramishroom"),
                Common.GetModItem(ModConditions.aequusMod, "RegrowingBait"),
                Common.GetModItem(ModConditions.aequusMod, "LavaproofMitten"),
                Common.GetModItem(ModConditions.aequusMod, "BusinessCard"),
                Common.GetModItem(ModConditions.aequusMod, "HaltingMachine"),
                Common.GetModItem(ModConditions.aequusMod, "HaltingMagnet"),
                Common.GetModItem(ModConditions.aequusMod, "HyperJet"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "AttendanceLog"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "BiomeCrystal"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "EngiRegistry"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "FortuneMirror"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "HitMarker"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "Magimeter"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "RSH"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "SafteyScanner"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "ScryingMirror"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "SmartHeart"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "ThreatAnalyzer"),
                Common.GetModItem(ModConditions.blocksInfoAccessoriesMod, "WantedPoster"),
                Common.GetModItem(ModConditions.calamityMod, "AlluringBait"),
                Common.GetModItem(ModConditions.calamityMod, "EnchantedPearl"),
                Common.GetModItem(ModConditions.calamityMod, "SupremeBaitTackleBoxFishingStation"),
                Common.GetModItem(ModConditions.calamityMod, "AncientFossil"),
                Common.GetModItem(ModConditions.calamityMod, "OceanCrest"),
                Common.GetModItem(ModConditions.calamityMod, "SpelunkersAmulet"),
                Common.GetModItem(ModConditions.spiritMod, "MetalBand"),
                Common.GetModItem(ModConditions.spiritMod, "MimicRepellent"),
                Common.GetModItem(ModConditions.thoriumMod, "HeartRateMonitor"),
                Common.GetModItem(ModConditions.thoriumMod, "HightechSonarDevice"),
                Common.GetModItem(ModConditions.thoriumMod, "GlitteringChalice"),
                Common.GetModItem(ModConditions.thoriumMod, "GreedyGoblet")
            };

            if (!ItemsForBanks.Contains(item.type))
            {
                return;
            }
            tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WorksInBanks");
            var tooltipLine = new TooltipLine(Mod, "WorksInBanks", tooltip);
            tooltipLine.OverrideColor = Color.Gray;
            AddLastTooltip(tooltips, tooltipLine);
        }

        public void WingStatsTooltip(Item item, List<TooltipLine> tooltips)
        {
            int wingsID = item.wingSlot;
            if (wingsID != -1 && !item.social)
            {
                if (ModConditions.calamityLoaded && item.type <= ItemID.Count)
                    return;

                //Don't do cal wing stats
                if (ModConditions.calamityLoaded)
                {
                    List<int> CalamityWings = new()
                    {
                        Common.GetModItem(ModConditions.calamityMod, "AureateBooster"),
                        Common.GetModItem(ModConditions.calamityMod, "DrewsWings"),
                        Common.GetModItem(ModConditions.calamityMod, "ElysianWings"),
                        Common.GetModItem(ModConditions.calamityMod, "ExodusWings"),
                        Common.GetModItem(ModConditions.calamityMod, "HadalMantle"),
                        Common.GetModItem(ModConditions.calamityMod, "HadarianWings"),
                        Common.GetModItem(ModConditions.calamityMod, "MOAB"),
                        Common.GetModItem(ModConditions.calamityMod, "SilvaWings"),
                        Common.GetModItem(ModConditions.calamityMod, "SkylineWings"),
                        Common.GetModItem(ModConditions.calamityMod, "SoulofCryogen"),
                        Common.GetModItem(ModConditions.calamityMod, "StarlightWings"),
                        Common.GetModItem(ModConditions.calamityMod, "TarragonWings"),
                        Common.GetModItem(ModConditions.calamityMod, "TracersCelestial"),
                        Common.GetModItem(ModConditions.calamityMod, "TracersElysian"),
                        Common.GetModItem(ModConditions.calamityMod, "TracersSeraph")
                    };
                    if (CalamityWings.Contains(item.type))
                        return;
                }

                if (ModConditions.fargosSoulsLoaded)
                {
                    if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "FlightMasterySoul")
                        || item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "DimensionSoul") 
                        || item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "EternitySoul"))
                        return;
                }

                if (ModConditions.wrathOfTheGodsLoaded)
                {
                    if (item.type == Common.GetModItem(ModConditions.wrathOfTheGodsMod, "DivineWings"))
                        return;
                }

                WingStats wingStats = ArmorIDs.Wing.Sets.Stats[wingsID];
                float flyTime = wingStats.FlyTime / 60f;

                TooltipLine equip = tooltips.Find(l => l.Name == "Equipable");

                TooltipLine flightTime = new(Mod, "FlightTime", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.FlightTime", flyTime.ToString("0.##")));
                TooltipLine horizontalSpeed = new(Mod, "HorizontalSpeed", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HorizontalSpeed", wingStats.AccRunSpeedOverride.ToString("~0.##")));
                TooltipLine verticalSpeedMul = new(Mod, "VerticalSpeedMul", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VerticalSpeedMul", wingStats.AccRunAccelerationMult.ToString("~0.##")));

                tooltips.Insert(tooltips.IndexOf(equip) + 1, flightTime);
                tooltips.Insert(tooltips.IndexOf(flightTime) + 1, horizontalSpeed);
                tooltips.Insert(tooltips.IndexOf(horizontalSpeed) + 1, verticalSpeedMul);
            }
        }

        public void HookStatsTooltip(Item item, List<TooltipLine> tooltips)
        {
            //VANILLA HOOKS
            if (!ModConditions.calamityLoaded)
            {
                //PRE-HARDMODE
                if (item.type == ItemID.GrapplingHook)
                {
                    CreateVanillaHookTooltip(18.75f, 11.5f, tooltips);
                }
                if (item.type == ItemID.AmethystHook)
                {
                    CreateVanillaHookTooltip(18.75f, 10f, tooltips);
                }
                if (item.type == ItemID.SquirrelHook)
                {
                    CreateVanillaHookTooltip(19f, 11.5f, tooltips);
                }
                if (item.type == ItemID.TopazHook)
                {
                    CreateVanillaHookTooltip(20.625f, 10.5f, tooltips);
                }
                if (item.type == ItemID.SapphireHook)
                {
                    CreateVanillaHookTooltip(22.5f, 11f, tooltips);
                }
                if (item.type == ItemID.EmeraldHook)
                {
                    CreateVanillaHookTooltip(24.375f, 11.5f, tooltips);
                }
                if (item.type == ItemID.RubyHook)
                {
                    CreateVanillaHookTooltip(26.25f, 12f, tooltips);
                }
                if (item.type == ItemID.AmberHook)
                {
                    CreateVanillaHookTooltip(27.5f, 12.5f, tooltips);
                }
                if (item.type == ItemID.DiamondHook)
                {
                    CreateVanillaHookTooltip(29.125f, 12.5f, tooltips);
                }
                if (item.type == ItemID.WebSlinger)
                {
                    CreateVanillaHookTooltip(22.625f, 10f, tooltips);
                }
                if (item.type == ItemID.SkeletronHand)
                {
                    CreateVanillaHookTooltip(21.875f, 15f, tooltips);
                }
                if (item.type == ItemID.SlimeHook)
                {
                    CreateVanillaHookTooltip(18.75f, 13f, tooltips);
                }
                if (item.type == ItemID.FishHook)
                {
                    CreateVanillaHookTooltip(25f, 13f, tooltips);
                }
                if (item.type == ItemID.IvyWhip)
                {
                    CreateVanillaHookTooltip(28f, 13f, tooltips);
                }
                if (item.type == ItemID.BatHook)
                {
                    CreateVanillaHookTooltip(31.25f, 13.5f, tooltips);
                }
                if (item.type == ItemID.CandyCaneHook)
                {
                    CreateVanillaHookTooltip(25f, 11.5f, tooltips);
                }
                //HARDMODE
                if (item.type == ItemID.DualHook)
                {
                    CreateVanillaHookTooltip(27.5f, 14f, tooltips);
                }
                if (item.type == ItemID.QueenSlimeHook)
                {
                    CreateVanillaHookTooltip(30f, 16f, tooltips);
                }
                if (item.type == ItemID.ThornHook)
                {
                    CreateVanillaHookTooltip(30f, 16f, tooltips);
                }
                if (item.type == ItemID.IlluminantHook)
                {
                    CreateVanillaHookTooltip(30f, 15f, tooltips);
                }
                if (item.type == ItemID.WormHook)
                {
                    CreateVanillaHookTooltip(30f, 15f, tooltips);
                }
                if (item.type == ItemID.TendonHook)
                {
                    CreateVanillaHookTooltip(30f, 15f, tooltips);
                }
                if (item.type == ItemID.AntiGravityHook)
                {
                    CreateVanillaHookTooltip(31.25f, 14f, tooltips);
                }
                if (item.type == ItemID.SpookyHook)
                {
                    CreateVanillaHookTooltip(34.375f, 15.5f, tooltips);
                }
                if (item.type == ItemID.ChristmasHook)
                {
                    CreateVanillaHookTooltip(34.375f, 15.5f, tooltips);
                }
                if (item.type == ItemID.LunarHook)
                {
                    CreateVanillaHookTooltip(34.375f, 18f, tooltips);
                }
                if (item.type == ItemID.StaticHook)
                {
                    CreateVanillaHookTooltip(37.5f, 16f, tooltips);
                }
            }

            //MOD HOOKS
            float hookReach = float.NegativeInfinity;
            float hookSpeed = 11;

            if (ModConditions.calamityLoaded)
            {
                ModConditions.calamityMod.TryFind("SerpentsBite", out ModItem SerpentsBite);
                ModConditions.calamityMod.TryFind("BobbitHook", out ModItem BobbitHook);

                if (SerpentsBite != null && SerpentsBite.Type == item.type || BobbitHook != null && BobbitHook.Type == item.type)
                {
                    return;
                }
            }
            if (item.shoot != ProjectileID.None && Main.projHook[item.shoot] && item.type > ItemID.Count)
            {
                ProjectileLoader.GetProjectile(item.shoot).GrapplePullSpeed(Main.CurrentPlayer, ref hookSpeed);
                hookReach = ProjectileLoader.GetProjectile(item.shoot).GrappleRange() / 16f;

                TooltipLine equip = tooltips.Find(l => l.Name == "Equipable");

                TooltipLine reach = new(Mod, "HookReach", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookReach", hookReach));
                TooltipLine pullSpeed = new(Mod, "HookPullSpeed", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookPullSpeed", hookSpeed));

                tooltips.Insert(tooltips.IndexOf(equip) + 1, reach);
                tooltips.Insert(tooltips.IndexOf(reach) + 1, pullSpeed);
            }
        }

        public void CreateVanillaHookTooltip(float hookReach, float hookSpeed, List<TooltipLine> tooltips)
        {
            TooltipLine equip = tooltips.Find(l => l.Name == "Equipable");

            TooltipLine reach = new(Mod, "HookReach", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookReach", hookReach));
            TooltipLine pullSpeed = new(Mod, "HookPullSpeed", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookPullSpeed", hookSpeed));

            tooltips.Insert(tooltips.IndexOf(equip) + 1, reach);
            tooltips.Insert(tooltips.IndexOf(reach) + 1, pullSpeed);
        }

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem"));
            tooltipLine.OverrideColor = Color.LightGreen;
            #region Vanilla
            //Countable Upgrades
            if (item.type == ItemID.LifeCrystal)
            {
                tooltipLine.Text = GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedLifeCrystals, 15);
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.LifeFruit)
            {
                tooltipLine.Text = GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedLifeFruit, 20);
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ManaCrystal)
            {
                tooltipLine.Text = GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedManaCrystals, 9);
                AddLastTooltip(tooltips, tooltipLine);
            }
            //Upgrades
            if (item.type == ItemID.AegisCrystal && Main.LocalPlayer.usedAegisCrystal)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ArcaneCrystal && Main.LocalPlayer.usedArcaneCrystal)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.AegisFruit && Main.LocalPlayer.usedAegisFruit)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.Ambrosia && Main.LocalPlayer.usedAmbrosia)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.GummyWorm && Main.LocalPlayer.usedGummyWorm)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.GalaxyPearl && Main.LocalPlayer.usedGalaxyPearl)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.PeddlersSatchel && NPC.peddlersSatchelWasUsed)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ArtisanLoaf && Main.LocalPlayer.ateArtisanBread)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.CombatBook && NPC.combatBookWasUsed)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.CombatBookVolumeTwo && NPC.combatBookVolumeTwoWasUsed)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.TorchGodsFavor && Main.LocalPlayer.unlockedBiomeTorches)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.MinecartPowerup && Main.LocalPlayer.unlockedSuperCart)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.DemonHeart && Main.LocalPlayer.CanDemonHeartAccessoryBeShown())
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            #endregion

            #region Calamity
            //Mana
            if (item.type == Common.GetModItem(ModConditions.calamityMod, "EnchantedStarfish"))
            {
                tooltipLine.Text = GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedManaCrystals, 9);
                AddLastTooltip(tooltips, tooltipLine);
            }
            //Rage
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "MushroomPlasmaRoot") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "MushroomPlasmaRoot"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "InfernalBlood") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "InfernalBlood"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "RedLightningContainer") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "RedLightningContainer"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            //Adrenaline
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "ElectrolyteGelPack") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "ElectrolyteGelPack"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "StarlightFuelCell") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "StarlightFuelCell"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "Ectoheart") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "Ectoheart"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            //Accessory
            if (ModConditions.calamityLoaded && item.type == Common.GetModItem(ModConditions.calamityMod, "CelestialOnion") && (bool)ModConditions.calamityMod.Call("HasPermanentPowerup", Main.LocalPlayer, "CelestialOnion"))
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            #endregion

            #region Exxo Avalon Origins
            if (item.type == Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "StaminaCrystal"))
            {
                tooltipLine.Text = GetTooltipValue("UsedItemCountable", PermanentUpgradePlayer.usedStaminaCrystalCount, 9);
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.exxoAvalonOriginsMod, "EnergyCrystal") && PermanentUpgradePlayer.usedEnergyCrystal)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            #endregion

            #region Fargos Souls
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "DeerSinew") && PermanentUpgradePlayer.usedDeerSinew)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsCreditCard") && PermanentUpgradePlayer.usedMutantsCreditCard)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsDiscountCard") && PermanentUpgradePlayer.usedMutantsDiscountCard)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "MutantsPact") && PermanentUpgradePlayer.usedMutantsPact)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.fargosSoulsMod, "RabiesVaccine") && PermanentUpgradePlayer.usedRabiesVaccine)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            #endregion

            #region Redemption
            if (item.type == Common.GetModItem(ModConditions.redemptionMod, "MedicKit") && PermanentUpgradePlayer.usedMedicKit)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == Common.GetModItem(ModConditions.redemptionMod, "GalaxyHeart") && PermanentUpgradePlayer.usedGalaxyHeart)
            {
                AddLastTooltip(tooltips, tooltipLine);
            }
            #endregion

            #region Thorium
            if (ModConditions.thoriumLoaded)
            {
                if (item.type == Common.GetModItem(ModConditions.thoriumMod, "CrystalWave"))
                {
                    tooltipLine.Text = GetTooltipValue("UsedItemCountable", PermanentUpgradePlayer.usedCrystalWaveCount, 5);
                    AddLastTooltip(tooltips, tooltipLine);
                }
                if (item.type == Common.GetModItem(ModConditions.thoriumMod, "AstralWave") && PermanentUpgradePlayer.usedAstralWave)
                {
                    AddLastTooltip(tooltips, tooltipLine);
                }
                if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationGem") && PermanentUpgradePlayer.usedInspirationGem)
                {
                    AddLastTooltip(tooltips, tooltipLine);
                }
                int bardResourceMax = (int)ModConditions.thoriumMod.Call("GetBardInspirationMax", Main.LocalPlayer);
                int fragmentMax = 10;
                int shardMax = 20;
                int crystalMax = 30;
                if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationFragment"))
                {
                    tooltipLine.Text = GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - fragmentMax, 0), 0, 10), 10);
                    AddLastTooltip(tooltips, tooltipLine);
                }
                if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationShard"))
                {
                    tooltipLine.Text = GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - shardMax, 0), 0, 10), 10);
                    AddLastTooltip(tooltips, tooltipLine);
                }
                if (item.type == Common.GetModItem(ModConditions.thoriumMod, "InspirationCrystalNew"))
                {
                    tooltipLine.Text = GetTooltipValue("UsedItemCountable", Math.Clamp(Math.Max(bardResourceMax - crystalMax, 0), 0, 10), 10);
                    AddLastTooltip(tooltips, tooltipLine);
                }
            }
            #endregion
        }

        public void AmmoTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.useAmmo != AmmoID.None)
            {
                Item displayItem = new Item(item.useAmmo);
                var tooltipLine = new TooltipLine(Mod, "UseAmmo", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UseAmmo"));
                tooltipLine.Text = GetTooltipValue("UseAmmo", item.useAmmo, displayItem.Name);
                AddLastTooltip(tooltips, tooltipLine);
            }
        }

        private string GetTooltipValue(string suffix, params object[] args)
        {
            return Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips." + suffix, args);
        }
#pragma warning restore
    }

    public static class ListExtension
    {
        public static void AddAfter<T>(this List<T> list, T element, T item)
        {
            var idx = list.IndexOf(element);
            list.Insert(idx + 1, item);
        }
    }
}
