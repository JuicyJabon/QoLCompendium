﻿using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.TooltipChanges
{
    public class StatsTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (QoLCompendium.tooltipConfig.WingStatsTooltips) WingStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.HookStatsTooltips) HookStatsTooltip(item, tooltips);
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
                    List<int> CalamityWings =
                    [
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
                    ];
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

            if (ModConditions.calamityLoaded && (item.type == Common.GetModItem(ModConditions.calamityMod, "SerpentsBite") || item.type == Common.GetModItem(ModConditions.calamityMod, "BobbitHook")))
                return;

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
    }
}
