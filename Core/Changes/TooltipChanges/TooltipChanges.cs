﻿using Humanizer;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Core.Changes.TooltipChanges
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
            TooltipLine oneDropLogo = tooltips.Find(l => l.Name == "OneDropLogo");

            TooltipLine id = tooltips.Find(l => l.Mod == "AfterYM");
            tooltips.Remove(id);

            if (QoLCompendium.tooltipConfig.NoFavoriteTooltip)
            {
                tooltips.Remove(fav); 
                tooltips.Remove(favDescr);
            }
            if (QoLCompendium.tooltipConfig.ShimmerableTooltip) ShimmmerableTooltips(item, tooltips);
            if (QoLCompendium.tooltipConfig.WorksInBanksTooltip && QoLCompendium.mainConfig.UtilityAccessoriesWorkInBanks) WorksInBankTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.WingStatsTooltips) WingStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.HookStatsTooltips) HookStatsTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.UsedPermanentUpgradeTooltip) UsedPermanentUpgrade(item, tooltips);
            if (QoLCompendium.tooltipConfig.AmmoTooltip) AmmoTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.ActiveTooltip) ActiveTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.NoYoyoTooltip) tooltips.Remove(oneDropLogo);
            if (QoLCompendium.tooltipConfig.FromModTooltip) ItemModTooltip(item, tooltips);
            if (QoLCompendium.tooltipConfig.ClassTagTooltip) ItemClassTooltip(item, tooltips);
            if (ModConditions.thoriumLoaded && ModConditions.exhaustionDisablerLoaded) RemoveExhaustionToolTip(item, tooltips);
        }

        public void ShimmmerableTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!item.CanShimmer())
            {
                return;
            }
            int countsAsIem = ItemID.Sets.ShimmerCountsAsItem[item.type];
            int type = countsAsIem != -1 ? countsAsIem : item.type;
            int transformsToItem = ItemID.Sets.ShimmerTransformToItem[type];
            int npcID = -1;
            if (type == ItemID.GelBalloon && !NPC.unlockedSlimeRainbowSpawn && !QoLCompendium.mainConfig.NoTownSlimes)
            {
                npcID = NPCID.TownSlimeRainbow;
            }
            else if (item.makeNPC > 0)
            {
                int npc = NPCID.Sets.ShimmerTransformToNPC[item.makeNPC];
                npcID = npc != -1 ? npc : item.makeNPC;
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
            string shimmerTextValue = Common.GetTooltipValue("Shimmerable");
            if (transformsToItem != -1)
            {
                _shimmerItemDisplay.SetDefaults(transformsToItem);
                shimmerTextValue = Common.GetTooltipValue("ShimmerableIntoItem", transformsToItem, _shimmerItemDisplay.Name);
            }
            else if (npcID != -1)
            {
                _shimmerNPCDisplay.SetDefaults(npcID, default);
                shimmerTextValue = Common.GetTooltipValue("ShimmerableIntoNPC", _shimmerNPCDisplay.GivenOrTypeName);
            }
            else
            {
                int coinLuck = ItemID.Sets.CoinLuckValue[type];
                if (coinLuck <= 0)
                {
                    return;
                }
                shimmerTextValue = Common.GetTooltipValue("ShimmerCoinLuck", $"+{coinLuck:##,###}");
            }
            var tooltipLine = new TooltipLine(Mod, "ShimmerInfo", shimmerTextValue) { OverrideColor = Color.Plum };
            Common.AddLastTooltip(tooltips, tooltipLine);
        }

        public void WorksInBankTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (!Common.BankItems.Contains(item.type))
                return;

            var tooltipLine = new TooltipLine(Mod, "WorksInBanks", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WorksInBanks")) { OverrideColor = Color.Gray };
            Common.AddLastTooltip(tooltips, tooltipLine);
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

        public void UsedPermanentUpgrade(Item item, List<TooltipLine> tooltips)
        {
            var tooltipLine = new TooltipLine(Mod, "UsedItem", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UsedItem")) { OverrideColor = Color.LightGreen };

            //Countable Upgrades
            if (item.type == ItemID.LifeCrystal)
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedLifeCrystals, 15);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.LifeFruit)
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedLifeFruit, 20);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ManaCrystal)
            {
                tooltipLine.Text = Common.GetTooltipValue("UsedItemCountable", Main.LocalPlayer.ConsumedManaCrystals, 9);
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            //Upgrades
            if (item.type == ItemID.AegisCrystal && Main.LocalPlayer.usedAegisCrystal)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ArcaneCrystal && Main.LocalPlayer.usedArcaneCrystal)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.AegisFruit && Main.LocalPlayer.usedAegisFruit)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.Ambrosia && Main.LocalPlayer.usedAmbrosia)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.GummyWorm && Main.LocalPlayer.usedGummyWorm)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.GalaxyPearl && Main.LocalPlayer.usedGalaxyPearl)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.PeddlersSatchel && NPC.peddlersSatchelWasUsed)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.ArtisanLoaf && Main.LocalPlayer.ateArtisanBread)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.CombatBook && NPC.combatBookWasUsed)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.CombatBookVolumeTwo && NPC.combatBookVolumeTwoWasUsed)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.TorchGodsFavor && Main.LocalPlayer.unlockedBiomeTorches)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.MinecartPowerup && Main.LocalPlayer.unlockedSuperCart)
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
            if (item.type == ItemID.DemonHeart && Main.LocalPlayer.CanDemonHeartAccessoryBeShown())
            {
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }

        public void AmmoTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.useAmmo != AmmoID.None)
            {
                Item displayItem = new(item.useAmmo);
                var tooltipLine = new TooltipLine(Mod, "UseAmmo", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.UseAmmo")) { Text = Common.GetTooltipValue("UseAmmo", item.useAmmo, displayItem.Name) };
                Common.AddLastTooltip(tooltips, tooltipLine);
            }
        }

        public void ActiveTooltip(Item item, List<TooltipLine> tooltips)
        {
            var tooltipActive = new TooltipLine(Mod, "Active", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Active")) { OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3) };

            var tooltipActiveBuff = new TooltipLine(Mod, "ActiveBuff", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ActiveBuff")) { OverrideColor = Common.ColorSwap(Color.Lime, Color.YellowGreen, 3) };

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeItems.Contains(item.type))
                Common.AddLastTooltip(tooltips, tooltipActive);
            else
                tooltips.Remove(tooltipActive);

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeBuffItems.Contains(item.type))
                Common.AddLastTooltip(tooltips, tooltipActiveBuff);
            else
                tooltips.Remove(tooltipActiveBuff);
        }

        public static void ItemDisabledTooltip(Item item, List<TooltipLine> tooltips, bool configOn)
        {
            TooltipLine name = tooltips.Find(l => l.Name == "ItemName");
            if (!configOn)
            {
                name.Text += " " + Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ItemDisabled");
                name.OverrideColor = Color.Red;
            }
                
        }

        public static void RemoveExhaustionToolTip(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tip in tooltips)
            {
                if (item.type > ItemID.Count && item.ModItem.Mod == ModConditions.thoriumMod && tip.Text == "Overuse of this weapon exhausts you, massively reducing its damage" || tip.Text == "Killing enemies recovers some of your exhaustion")
                    tip.Hide();
            }
        }

        public static void ItemClassTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0 || item.damage > 0 && item.createTile > -1 && !item.IsCurrency)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Tool")));
            if (item.CountsAsClass(DamageClass.Melee) && item.pick <= 0 && item.axe <= 0 && item.hammer <= 0 && item.createTile == -1 && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.WarriorClass")));
            if (item.CountsAsClass(DamageClass.Ranged) && !item.IsCurrency && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.RangerClass")));
            if (item.CountsAsClass(DamageClass.Magic) && item.type != ItemID.Dynamite && item.damage > 0 && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SorcererClass")));
            if (item.CountsAsClass(DamageClass.Summon) && !item.accessory)
            {
                if (!ProjectileID.Sets.IsAWhip[item.shoot])
                    tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SummonerClass")));
                else
                    tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.SummonerClassWhip")));
            }
            if (item.CountsAsClass(DamageClass.Throwing) && !item.accessory && !ModConditions.thoriumLoaded && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")))
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.ThrowerClass")));
            if (item.CountsAsClass(DamageClass.Generic) && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Classless")));
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "RogueDamageClass")) && ModConditions.calamityLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.RogueClass")));
            if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.ruptureMod, "DruidDamageClass")) && ModConditions.ruptureLoaded && !item.accessory)
                tooltips.Insert(1, new TooltipLine(QoLCompendium.instance, "DamageClassType", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.DruidClass")));
        }

        public static void ItemModTooltip(Item item, List<TooltipLine> tooltips)
        {
            if (item.ModItem != null)
            {
                TooltipLine name = tooltips.Find(l => l.Name == "ItemName");
                var tooltipFromMod = new TooltipLine(QoLCompendium.instance, "FromMod", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.FromMod").FormatWith(item.ModItem.Mod.DisplayName)) { OverrideColor = Common.ColorSwap(Color.AliceBlue, Color.Azure, 1) };
                tooltips.AddAfter(name, tooltipFromMod);
            }
        }
    }
}
