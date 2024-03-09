using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Content.Items.Mirrors;
using Terraria.DataStructures;
using tModPorter;

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
        }

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
                ItemID.CordageGuide,
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
                ModContent.ItemType<MosaicMirror>()
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

                WingStats wingStats = ArmorIDs.Wing.Sets.Stats[wingsID];
                float flyTime = wingStats.FlyTime / 60f;

                TooltipLine equip = tooltips.Find(l => l.Name == "Equipable");

                TooltipLine flightTime = new(Mod, "FlightTime", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.FlightTime", flyTime.ToString("0.##")));
                TooltipLine horizontalSpeed = new(Mod, "HorizontalSpeed", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HorizontalSpeed", wingStats.AccRunSpeedOverride.ToString("~0.##")));
                TooltipLine verticalSpeedMul = new(Mod, "VerticalSpeedMul", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.VerticalSpeedMul", wingStats.AccRunAccelerationMult.ToString("~0.##")));

                tooltips.Insert(tooltips.IndexOf(equip), flightTime);
                tooltips.Insert(tooltips.IndexOf(flightTime), horizontalSpeed);
                tooltips.Insert(tooltips.IndexOf(horizontalSpeed), verticalSpeedMul);
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

                if (SerpentsBite != null || BobbitHook != null)
                {
                    return;
                }
            }
            if (item.shoot != ProjectileID.None && Main.projHook[item.shoot] && item.type > ItemID.Count)
            {
                ProjectileLoader.GetProjectile(item.shoot).GrapplePullSpeed(Main.CurrentPlayer, ref hookSpeed);
                hookReach = ProjectileLoader.GetProjectile(item.shoot).GrappleRange() / 16f;

                TooltipLine equip = tooltips.Find(l => l.Name == "Equipable");

                TooltipLine reach = new(Mod, "FlightTime", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookReach", hookReach));
                TooltipLine pullSpeed = new(Mod, "HorizontalSpeed", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookPullSpeed", hookSpeed));

                tooltips.Insert(tooltips.IndexOf(equip), reach);
                tooltips.Insert(tooltips.IndexOf(reach), pullSpeed);
            }
        }

        public void CreateVanillaHookTooltip(float hookReach, float hookSpeed, List<TooltipLine> tooltips)
        {
            TooltipLine equip = tooltips.Find(l => l.Name == "Equipable");

            TooltipLine reach = new(Mod, "FlightTime", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookReach", hookReach));
            TooltipLine pullSpeed = new(Mod, "HorizontalSpeed", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.HookPullSpeed", hookSpeed));

            tooltips.Insert(tooltips.IndexOf(equip), reach);
            tooltips.Insert(tooltips.IndexOf(reach), pullSpeed);
        }
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
