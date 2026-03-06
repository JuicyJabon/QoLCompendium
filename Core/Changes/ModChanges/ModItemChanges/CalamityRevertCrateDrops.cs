using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class CalamityRevertCrateDrops : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (!QoLCompendium.crossModConfig.CalamityCrateDropRevert)
                return;

            #region Astral Infection Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "MonolithCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"))
            {
                itemLoot.Add(ItemID.FallenStar, 1, 5, 10);
                itemLoot.Add(ItemID.Meteorite, 5, 10, 20);
                itemLoot.Add(ItemID.MeteoriteBar, 10, 1, 3);
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralCrate"))
            {
                LeadingConditionRule AstrumAureus = itemLoot.DefineConditionalDropSet(ModConditions.DownedAstrumAureus.IsMet);
                LeadingConditionRule AstrumDeus = itemLoot.DefineConditionalDropSet(ModConditions.DownedAstrumDeus.IsMet);
                LeadingConditionRule LunarEvent = itemLoot.DefineConditionalDropSet(ModConditions.DownedLunarEvent.IsMet);

                AstrumAureus.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AureusCell"), 5, 2, 5);
                AstrumDeus.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralOre"), 5, 10, 20);
                AstrumDeus.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralBar"), 10, 1, 3);
                LunarEvent.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "MeldBlob"), 4, 5, 10);

                AstrumAureus.Add(new OneFromOptionsDropRule(7, 1,
                [
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralScythe"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "TitanArm"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "StellarCannon"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralachneaStaff"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "HivePod"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "StellarKnife"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "StarbusterCore")
                ]));
            }
            #endregion

            #region Brimstone Crags Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "SlagCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"))
            {
                itemLoot.Add(ItemID.InfernoPotion, 10, 1, 3);
                itemLoot.Add(ItemID.Obsidian, 1, 2, 5);
                itemLoot.Add(ItemID.Hellstone, 4, 2, 5);
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "BrimstoneCrate"))
            {
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "EssenceofHavoc"), 10, 1, 3);
                itemLoot.AddIf(ModConditions.DownedBrimstoneElemental.IsMet, Common.GetModItem(CrossModSupport.Calamity.Mod, "UnholyCore"), 10, 1, 3);
                itemLoot.AddIf(ModConditions.DownedProvidence.IsMet, Common.GetModItem(CrossModSupport.Calamity.Mod, "Bloodstone"), 2, 1, 3);
            }
            #endregion

            #region Sulphur Sea Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"))
            {
                LeadingConditionRule AbyssTier1 = itemLoot.DefineConditionalDropSet(() => ModConditions.DownedSlimeGod.IsMet() || Condition.Hardmode.IsMet());
                LeadingConditionRule AcidRainTier1 = itemLoot.DefineConditionalDropSet(ModConditions.DownedAcidRain1.IsMet);
                
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AnechoicCoating"), 10, 1, 3);
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurskinPotion"), 10, 1, 3);
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "Acidwood"), 1, 15, 20);
                AcidRainTier1.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphuricScale"), 10, 1, 3);

                AbyssTier1.Add(new OneFromOptionsDropRule(10, 1,
                [
                Common.GetModItem(CrossModSupport.Calamity.Mod, "BallOFugu"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "Archerfish"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "BlackAnurian"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "HerringStaff"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "Lionfish"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "AnechoicPlating"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "DepthCharm"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "IronBoots"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "StrangeOrb"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "TorrentialTear")
                ]));
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "HydrothermalCrate"))
            {
                LeadingConditionRule AbyssTier1 = itemLoot.DefineConditionalDropSet(() => ModConditions.DownedSlimeGod.IsMet() || Condition.Hardmode.IsMet());
                LeadingConditionRule AbyssTier2 = itemLoot.DefineConditionalDropSet(ModConditions.DownedLeviathanAndAnahita.IsMet);
                LeadingConditionRule Golem = itemLoot.DefineConditionalDropSet(Condition.DownedGolem.IsMet);
                LeadingConditionRule AcidRainTier2 = itemLoot.DefineConditionalDropSet(ModConditions.DownedAcidRain2.IsMet);
                LeadingConditionRule AcidRainTier3 = itemLoot.DefineConditionalDropSet(() => ModConditions.DownedPolterghast.IsMet() && ModConditions.DownedOldDuke.IsMet());

                AcidRainTier2.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "CorrodedFossil"), 10, 1, 3);

                AbyssTier2.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "DepthCells"), 5, 2, 5);
                AbyssTier2.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "Lumenyl"), 5, 2, 5);
                AbyssTier2.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "PlantyMush"), 5, 2, 5);

                Golem.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "ScoriaOre"), 5, 16, 28);
                Golem.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "ScoriaBar"), 10, 1, 3);

                AcidRainTier3.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "ReaperTooth"), 10, 1, 5);

                AcidRainTier2.Add(new OneFromOptionsDropRule(7, 1,
                [
                Common.GetModItem(CrossModSupport.Calamity.Mod, "SulphurousGrabber"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "FlakToxicannon"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "BelchingSaxophone"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "SlitheringEels"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "SkyfinBombers"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "SpentFuelContainer"),
                Common.GetModItem(CrossModSupport.Calamity.Mod, "NuclearFuelRod")
                ]));
            }
            #endregion

            #region Sunken Sea Crates
            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "EutrophicCrate") || item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"))
            {
                LeadingConditionRule DesertScourge = itemLoot.DefineConditionalDropSet(ModConditions.DownedDesertScourge.IsMet);
                LeadingConditionRule GiantClam = itemLoot.DefineConditionalDropSet(ModConditions.DownedGiantClam.IsMet);

                DesertScourge.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismShard"), 1, 5, 10);
                DesertScourge.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "SeaPrism"), 5, 2, 5);

                GiantClam.Add(new OneFromOptionsNotScaledWithLuckDropRule(2, 100,
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "GiantPearl"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "AmidiasPendant")
                ));
            }

            if (item.type == Common.GetModItem(CrossModSupport.Calamity.Mod, "PrismCrate"))
            {
                LeadingConditionRule GiantClam = itemLoot.DefineConditionalDropSet(() => ModConditions.DownedGiantClam.IsMet() && Condition.Hardmode.IsMet());

                GiantClam.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "MolluskHusk"), new Fraction(12, 100), 2, 5);
                GiantClam.Add(new OneFromOptionsNotScaledWithLuckDropRule(4, 100,
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "ClamCrusher"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "ClamorRifle"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "Poseidon"),
                    Common.GetModItem(CrossModSupport.Calamity.Mod, "ShellfishStaff")
                ));
            }
            #endregion

            #region Wooden Crates
            if (item.type == ItemID.WoodenCrate || item.type == ItemID.WoodenCrateHard)
            {
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "WulfrumMetalScrap"), 4, 3, 5);
            }

            if (item.type == ItemID.WoodenCrateHard)
            {
                //tier 1
                itemLoot.Add(ItemID.CobaltOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.PalladiumOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.CobaltBar, new Fraction(3, 56), 2, 3);
                itemLoot.Add(ItemID.PalladiumBar, new Fraction(3, 56), 2, 3);
            }
            #endregion

            #region Iron Crates
            if (item.type == ItemID.IronCrate || item.type == ItemID.IronCrateHard)
            {
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "WulfrumMetalScrap"), 4, 3, 5);
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AncientBoneDust"), 4, 5, 8);
            }

            if (item.type == ItemID.IronCrateHard)
            {
                //tier 1
                itemLoot.Add(ItemID.CobaltOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.PalladiumOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.CobaltBar, new Fraction(3, 56), 2, 3);
                itemLoot.Add(ItemID.PalladiumBar, new Fraction(3, 56), 2, 3);
                //tier 2
                itemLoot.Add(ItemID.MythrilOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.OrichalcumOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.MythrilBar, new Fraction(3, 56), 2, 3);
                itemLoot.Add(ItemID.OrichalcumBar, new Fraction(3, 56), 2, 3);
            }
            #endregion

            #region Golden Crates
            if (item.type == ItemID.GoldenCrate || item.type == ItemID.GoldenCrateHard)
            {

            }

            if (item.type == ItemID.GoldenCrateHard)
            {
                //tier 2
                itemLoot.Add(ItemID.MythrilOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.OrichalcumOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.MythrilBar, new Fraction(3, 56), 2, 3);
                itemLoot.Add(ItemID.OrichalcumBar, new Fraction(3, 56), 2, 3);
                //tier 3
                itemLoot.Add(ItemID.AdamantiteOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.TitaniumOre, new Fraction(1, 14), 4, 15);
                itemLoot.Add(ItemID.AdamantiteBar, new Fraction(3, 56), 2, 3);
                itemLoot.Add(ItemID.TitaniumBar, new Fraction(3, 56), 2, 3);

                LeadingConditionRule Yharon = itemLoot.DefineConditionalDropSet(ModConditions.DownedYharon.IsMet);
                Yharon.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AuricOre"), new Fraction(5, 100), 60, 60);
                Yharon.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AuricBar"), 10, 1, 3);
            }
            #endregion

            #region Sky Crates
            if (item.type == ItemID.FloatingIslandFishingCrate || item.type == ItemID.FloatingIslandFishingCrateHard)
            {
                LeadingConditionRule PerforatorsOrHiveMind = itemLoot.DefineConditionalDropSet(ModConditions.DownedPerforatorsOrHiveMind.IsMet);
                PerforatorsOrHiveMind.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AerialiteOre"), 5, 16, 28);
                PerforatorsOrHiveMind.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "AerialiteBar"), 10, 1, 3);
            }

            if (item.type == ItemID.FloatingIslandFishingCrateHard)
            {
                itemLoot.AddIf(Condition.Hardmode.IsMet, Common.GetModItem(CrossModSupport.Calamity.Mod, "EssenceofSunlight"), 5, 2, 4);
                itemLoot.AddIf(Condition.DownedMoonLord.IsMet, Common.GetModItem(CrossModSupport.Calamity.Mod, "ExodiumCluster"), 5, 16, 28);
            }
            #endregion

            #region Dungeon Crates
            if (item.type == ItemID.DungeonFishingCrate || item.type == ItemID.DungeonFishingCrateHard)
            {

            }

            if (item.type == ItemID.DungeonFishingCrateHard)
            {
                itemLoot.AddIf(ModConditions.DownedPolterghast.IsMet, Common.GetModItem(CrossModSupport.Calamity.Mod, "Necroplasm"), 10, 1, 5);
            }
            #endregion

            #region Evil Crates
            if (item.type == ItemID.CorruptFishingCrate || item.type == ItemID.CorruptFishingCrateHard || item.type == ItemID.CrimsonFishingCrate || item.type == ItemID.CrimsonFishingCrateHard)
            {
                itemLoot.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "BlightedGel"), new Fraction(15, 100), 5, 8);
            }
            #endregion

            #region Ice Crates
            if (item.type == ItemID.FrozenCrate || item.type == ItemID.FrozenCrateHard)
            {

            }

            if (item.type == ItemID.FrozenCrateHard)
            {
                LeadingConditionRule Cryogen = itemLoot.DefineConditionalDropSet(ModConditions.DownedCryogen.IsMet);
                Cryogen.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "CryonicOre"), 5, 16, 28);
                Cryogen.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "CryonicBar"), 10, 1, 3);

                itemLoot.AddIf(Condition.Hardmode.IsMet, Common.GetModItem(CrossModSupport.Calamity.Mod, "EssenceofEleum"), 5, 2, 4);
            }
            #endregion

            #region Hallowed Crates
            if (item.type == ItemID.HallowedFishingCrate || item.type == ItemID.HallowedFishingCrateHard)
            {

            }

            if (item.type == ItemID.HallowedFishingCrateHard)
            {
                LeadingConditionRule Moonlord = itemLoot.DefineConditionalDropSet(Condition.DownedMoonLord.IsMet);
                Moonlord.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "UnholyEssence"), new Fraction(15, 100), 5, 10);
            }
            #endregion

            #region Jungle Crates
            if (item.type == ItemID.JungleFishingCrate || item.type == ItemID.JungleFishingCrateHard)
            {

            }

            if (item.type == ItemID.JungleFishingCrateHard)
            {
                LeadingConditionRule Plantera = itemLoot.DefineConditionalDropSet(Condition.DownedPlantera.IsMet);
                Plantera.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "PerennialOre"), 5, 16, 28);
                Plantera.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "PerennialBar"), 10, 1, 3);

                itemLoot.AddIf(() => NPC.downedGolemBoss, Common.GetModItem(CrossModSupport.Calamity.Mod, "PlagueCellCanister"), 5, 3, 6);
                itemLoot.AddIf(() => NPC.downedMoonlord, Common.GetModItem(CrossModSupport.Calamity.Mod, "EffulgentFeather"), new Fraction(5, 100), 5, 7);

                LeadingConditionRule Providence = itemLoot.DefineConditionalDropSet(ModConditions.DownedProvidence.IsMet);
                Providence.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "UelibloomOre"), 5, 16, 28);
                Providence.Add(Common.GetModItem(CrossModSupport.Calamity.Mod, "UelibloomBar"), 10, 1, 3);
            }
            #endregion
        }
    }
}
