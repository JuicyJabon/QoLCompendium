using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Content.Items.Mirrors;
using Terraria.DataStructures;

namespace QoLCompendium.Core
{
    public class TooltipChanges : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine fav = tooltips.Find(l => l.Name == "Favorite");
            TooltipLine favDescr = tooltips.Find(l => l.Name == "FavoriteDesc");

            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip) tooltips.Remove(fav);
            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip) tooltips.Remove(favDescr);
            if (QoLCompendium.tooltipConfig.ShimmerableTooltip) ShimmmerableTooltips(item, tooltips);
            if (QoLCompendium.tooltipConfig.WorksInBanksTooltip && QoLCompendium.mainConfig.InformationBanks) WorksInBankTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.WingStatsTooltips) WingStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.HookStatsTooltips) HookStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
        }
        #pragma warning disable
        public static void AddLastTooltip(List<TooltipLine> tooltips, TooltipLine tooltip)
        {
            var last = tooltips.FindLast(t => t.Mod == "Terraria" && t.Name != "Expert" && t.Name != "Master")!;
            tooltips.AddAfter(last, tooltip);
        }

        public bool CanShimmer(Item item)
        {
            var shimmerEquivalentType = ItemID.Sets.ShimmerCountsAsItem[item.type] != -1
                ? ItemID.Sets.ShimmerCountsAsItem[item.type]
                : item.type;

            return ItemID.Sets.ShimmerTransformToItem[shimmerEquivalentType] > 0 ||
                   ShimmerTransforms.GetDecraftingRecipeIndex(shimmerEquivalentType) > -1 ||
                   ItemID.Sets.CoinLuckValue[item.type] > 0 || item.makeNPC > 0;
        }

        public void ShimmmerableTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!CanShimmer(item))
            {
                return;
            }

            string tooltip = "";
            int itemTransform = ItemID.Sets.ShimmerCountsAsItem[item.type];
            int sourceItem = itemTransform == -1 ? item.type : itemTransform;
            int targetItem = ItemID.Sets.ShimmerTransformToItem[sourceItem];
            var NPCTransform = NPCID.Sets.ShimmerTransformToNPC[item.makeNPC];
            var targetNPC = NPCTransform == -1 ? item.makeNPC : NPCTransform;
            int coinLuckValue = ItemID.Sets.CoinLuckValue[sourceItem];
            int decraftingRecipeIndex = ShimmerTransforms.GetDecraftingRecipeIndex(sourceItem);

            if (targetItem > 0)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            if (sourceItem == ItemID.GelBalloon)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            if (targetNPC > 0)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            if (coinLuckValue > 0)
            {
                tooltip = Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Shimmerable");
            }

            var tooltipLine = new TooltipLine(Mod, "ShimmerInfo", tooltip);
            tooltipLine.OverrideColor = Color.Plum;
            AddLastTooltip(tooltips, tooltipLine);
        }

        public void WorksInBankTooltip(Item item, List<TooltipLine> tooltips)
        {
            string tooltip;
            List<int> itemsForTooltip = new()
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
                Common.GetModItem(ModConditions.aequusMod, "HoloLens"),
                Common.GetModItem(ModConditions.aequusMod, "RichMansMonocle"),
                Common.GetModItem(ModConditions.aequusMod, "DevilsTongue"),
                Common.GetModItem(ModConditions.aequusMod, "NeonGenesis"),
                Common.GetModItem(ModConditions.aequusMod, "RadonFishingBobber"),
                Common.GetModItem(ModConditions.aequusMod, "Ramishroom"),
                Common.GetModItem(ModConditions.aequusMod, "BusinessCard"),
                Common.GetModItem(ModConditions.aequusMod, "FaultyCoin"),
                Common.GetModItem(ModConditions.aequusMod, "HaltingMachine"),
                Common.GetModItem(ModConditions.aequusMod, "HaltingMagnet"),
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
                Common.GetModItem(ModConditions.calamityMod, "ArchaicPowder"),
                Common.GetModItem(ModConditions.calamityMod, "OceanCrest"),
                Common.GetModItem(ModConditions.calamityMod, "SpelunkersAmulet"),
                Common.GetModItem(ModConditions.spiritMod, "MetalBand"),
                Common.GetModItem(ModConditions.spiritMod, "MimicRepellent"),
                Common.GetModItem(ModConditions.thoriumMod, "HightechSonarDevice")
            };

            if (!itemsForTooltip.Contains(item.type))
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
                    ModConditions.calamityMod.TryFind("AureateBooster", out ModItem AureateBooster);
                    ModConditions.calamityMod.TryFind("DrewsWings", out ModItem DrewsWings);
                    ModConditions.calamityMod.TryFind("ElysianWings", out ModItem ElysianWings);
                    ModConditions.calamityMod.TryFind("ExodusWings", out ModItem ExodusWings);
                    ModConditions.calamityMod.TryFind("HadalMantle", out ModItem HadalMantle);
                    ModConditions.calamityMod.TryFind("HadarianWings", out ModItem HadarianWings);
                    ModConditions.calamityMod.TryFind("MOAB", out ModItem MOAB);
                    ModConditions.calamityMod.TryFind("SilvaWings", out ModItem SilvaWings);
                    ModConditions.calamityMod.TryFind("SkylineWings", out ModItem SkylineWings);
                    ModConditions.calamityMod.TryFind("SoulofCryogen", out ModItem SoulofCryogen);
                    ModConditions.calamityMod.TryFind("StarlightWings", out ModItem StarlightWings);
                    ModConditions.calamityMod.TryFind("TarragonWings", out ModItem TarragonWings);
                    ModConditions.calamityMod.TryFind("TracersCelestial", out ModItem TracersCelestial);
                    ModConditions.calamityMod.TryFind("TracersElysian", out ModItem TracersElysian);
                    ModConditions.calamityMod.TryFind("TracersSeraph", out ModItem TracersSeraph);

                    if ((AureateBooster != null && AureateBooster.Type == item.type) 
                        || (DrewsWings != null && DrewsWings.Type == item.type)
                        || (ElysianWings != null && ElysianWings.Type == item.type)
                        || (ExodusWings != null && ExodusWings.Type == item.type)
                        || (HadalMantle != null && HadalMantle.Type == item.type)
                        || (HadarianWings != null && HadarianWings.Type == item.type)
                        || (MOAB != null && MOAB.Type == item.type)
                        || (SilvaWings != null && SilvaWings.Type == item.type)
                        || (SkylineWings != null && SkylineWings.Type == item.type)
                        || (SoulofCryogen != null && SoulofCryogen.Type == item.type)
                        || (StarlightWings != null && StarlightWings.Type == item.type)
                        || (TarragonWings != null && TarragonWings.Type == item.type)
                        || (TracersCelestial != null && TracersCelestial.Type == item.type)
                        || (TracersElysian != null && TracersElysian.Type == item.type)
                        || (TracersSeraph != null && TracersSeraph.Type == item.type))
                    {
                        return;
                    }
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

                if ((SerpentsBite != null && SerpentsBite.Type == item.type) || (BobbitHook != null && BobbitHook.Type == item.type))
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
