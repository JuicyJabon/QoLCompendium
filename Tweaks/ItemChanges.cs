using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class OtherItemStuff : GlobalItem
    {
        public static readonly int[] BossSummons = new int[]
        {
            560,
            43,
            70,
            1331,
            1133,
            5120,
            4988,
            556,
            544,
            557,
            3601
        };

        public static readonly int[] EventSummons = new int[]
        {
            4271,
            361,
            1315,
            2767,
            602,
            1844,
            1958
        };

        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<QoLCConfig>().NoDevs && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (ModContent.GetInstance<QoLCConfig>().FastExtractor)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0)
                return 1f - ModContent.GetInstance<QoLCConfig>().FastTools;
            return 1f;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod thor);
            ModLoader.TryGetMod("SOTS", out Mod sots);
            ModLoader.TryGetMod("VitalityMod", out Mod vitality);
            ModLoader.TryGetMod("Consolaria", out Mod consolaria);
            ModLoader.TryGetMod("Spooky", out Mod spooky);
            ModLoader.TryGetMod("FargowiltasSouls", out Mod souls);
            ModLoader.TryGetMod("ContinentOfJourney", out Mod hj);
            ModLoader.TryGetMod("GMR", out Mod gmr);
            ModLoader.TryGetMod("QwertyMod", out Mod qwerty);
            ModLoader.TryGetMod("StormDiversMod", out Mod storm);
            ModLoader.TryGetMod("SpiritMod", out Mod spirit);

            if (thor != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                thor.TryFind("JellyfishResonator", out ModItem JellyfishResonator);
                thor.TryFind("UnstableCore", out ModItem UnstableCore);
                thor.TryFind("AncientBlade", out ModItem AncientBlade);
                thor.TryFind("StarCaller", out ModItem StarCaller);
                thor.TryFind("StriderTear", out ModItem StriderTear);
                thor.TryFind("VoidLens", out ModItem VoidLens);
                thor.TryFind("AromaticBulb", out ModItem AromaticBulb);
                thor.TryFind("DoomSayersCoin", out ModItem DoomSayersCoin);

                List<ModItem> thorItems = new() { JellyfishResonator, UnstableCore, AncientBlade, StarCaller, StriderTear, VoidLens, AromaticBulb, DoomSayersCoin };

                for (int i = 0; i < thorItems.Count; i++)
                {
                    if (thorItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (sots != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                sots.TryFind("ElectromagneticLure", out ModItem ElectromagneticLure);
                sots.TryFind("SuspiciousLookingCandle", out ModItem SuspiciousLookingCandle);
                sots.TryFind("JarOfPeanuts", out ModItem JarOfPeanuts);
                sots.TryFind("CatalystBomb", out ModItem CatalystBomb);

                List<ModItem> sotsItems = new() { ElectromagneticLure, SuspiciousLookingCandle, JarOfPeanuts, CatalystBomb };

                for (int i = 0; i < sotsItems.Count; i++)
                {
                    if (sotsItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (vitality != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                vitality.TryFind("CloudCore", out ModItem CloudCore);
                vitality.TryFind("AncientCrown", out ModItem AncientCrown);
                vitality.TryFind("MultigemCluster", out ModItem MultigemCluster);
                vitality.TryFind("MoonlightLotusFlower", out ModItem MoonlightLotusFlower);
                vitality.TryFind("Dreadcandle", out ModItem Dreadcandle);
                vitality.TryFind("AnarchyCrystal", out ModItem AnarchyCrystal);
                vitality.TryFind("TotemofChaos", out ModItem TotemofChaos);
                vitality.TryFind("SpiritBox", out ModItem SpiritBox);

                List<ModItem> vitalityItems = new() { CloudCore, AncientCrown, MultigemCluster, MoonlightLotusFlower, Dreadcandle, AnarchyCrystal, TotemofChaos, SpiritBox };

                for (int i = 0; i < vitalityItems.Count; i++)
                {
                    if (vitalityItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (consolaria != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                consolaria.TryFind("SuspiciousLookingEgg", out ModItem SuspiciousLookingEgg);
                consolaria.TryFind("CursedStuffing", out ModItem CursedStuffing);
                consolaria.TryFind("SuspiciousLookingSkull", out ModItem SuspiciousLookingSkull);
                consolaria.TryFind("Wishbone", out ModItem Wishbone);

                List<ModItem> consolariaItems = new() { SuspiciousLookingEgg, CursedStuffing, SuspiciousLookingSkull, Wishbone };

                for (int i = 0; i < consolariaItems.Count; i++)
                {
                    if (consolariaItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (spooky != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                spooky.TryFind("RottenSeed", out ModItem RottenSeed);
                spooky.TryFind("Fertalizer", out ModItem Fertalizer);

                List<ModItem> spookyItems = new() { RottenSeed, Fertalizer };

                for (int i = 0; i < spookyItems.Count; i++)
                {
                    if (spookyItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (souls != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                souls.TryFind("SquirrelCoatofArms", out ModItem SquirrelCoatofArms);
                souls.TryFind("DevisCurse", out ModItem DevisCurse);
                souls.TryFind("FragilePixieLamp", out ModItem FragilePixieLamp);
                souls.TryFind("AbomsCurse", out ModItem AbomsCurse);
                souls.TryFind("MutantsCurse", out ModItem MutantsCurse);

                List<ModItem> soulsItems = new() { SquirrelCoatofArms, DevisCurse, FragilePixieLamp, AbomsCurse, MutantsCurse };

                for (int i = 0; i < soulsItems.Count; i++)
                {
                    if (soulsItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (hj != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                hj.TryFind("CannedSoulofFlight", out ModItem CannedSoulofFlight);
                hj.TryFind("SouthernPotting", out ModItem SouthernPotting);
                hj.TryFind("SunlightCrown", out ModItem SunlightCrown);
                hj.TryFind("MetalSpine", out ModItem MetalSpine);
                hj.TryFind("UnstableGlobe", out ModItem UnstableGlobe);

                List<ModItem> hjItems = new() { CannedSoulofFlight, SouthernPotting, SunlightCrown, MetalSpine, UnstableGlobe };

                for (int i = 0; i < hjItems.Count; i++)
                {
                    if (hjItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (gmr != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                gmr.TryFind("JackDroneOld", out ModItem JackDroneOld);

                List<ModItem> gmrItems = new() { JackDroneOld };

                for (int i = 0; i < gmrItems.Count; i++)
                {
                    if (gmrItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (qwerty != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                qwerty.TryFind("AncientEmblem", out ModItem AncientEmblem);
                qwerty.TryFind("B4Summon", out ModItem B4Summon);
                qwerty.TryFind("BladeBossSummon", out ModItem BladeBossSummon);
                qwerty.TryFind("DinoEgg", out ModItem DinoEgg);
                qwerty.TryFind("FortressBossSummon", out ModItem FortressBossSummon);
                qwerty.TryFind("GodSealKeycard", out ModItem GodSealKeycard);
                qwerty.TryFind("HydraSummon", out ModItem HydraSummon);
                qwerty.TryFind("RitualInterupter", out ModItem RitualInterupter);
                qwerty.TryFind("SummoningRune", out ModItem SummoningRune);

                List<ModItem> qwertyItems = new() { AncientEmblem, B4Summon, BladeBossSummon, DinoEgg, FortressBossSummon, GodSealKeycard, HydraSummon, RitualInterupter, SummoningRune };

                for (int i = 0; i < qwertyItems.Count; i++)
                {
                    if (qwertyItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (storm != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                storm.TryFind("AridBossSummon", out ModItem AridBossSummon);
                storm.TryFind("MoonlingSummoner", out ModItem MoonlingSummoner);
                storm.TryFind("StormBossSummoner", out ModItem StormBossSummoner);
                storm.TryFind("UltimateBossSummoner", out ModItem UltimateBossSummoner);

                List<ModItem> stormItems = new() { AridBossSummon, MoonlingSummoner, StormBossSummoner, UltimateBossSummoner };

                for (int i = 0; i < stormItems.Count; i++)
                {
                    if (stormItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if (spirit != null && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                spirit.TryFind("DistressJellyItem", out ModItem DistressJellyItem);
                spirit.TryFind("GladeWreath", out ModItem GladeWreath);
                spirit.TryFind("ReachBossSummon", out ModItem ReachBossSummon);
                spirit.TryFind("JewelCrown", out ModItem JewelCrown);
                spirit.TryFind("BlackPearl", out ModItem BlackPearl);
                spirit.TryFind("BlueMoonSpawn", out ModItem BlueMoonSpawn);
                spirit.TryFind("DuskCrown", out ModItem DuskCrown);
                spirit.TryFind("CursedCloth", out ModItem CursedCloth);
                spirit.TryFind("StoneSkin", out ModItem StoneSkin);
                spirit.TryFind("MartianTransmitter", out ModItem MartianTransmitter);

                List<ModItem> spiritItems = new() { DistressJellyItem, ReachBossSummon, GladeWreath, JewelCrown, BlackPearl, BlueMoonSpawn, DuskCrown, CursedCloth, StoneSkin, MartianTransmitter };

                for (int i = 0; i < spiritItems.Count; i++)
                {
                    if (spiritItems[i].Item.type == item.type)
                    {
                        return false;
                    }
                }
            }

            if ((BossSummons.Contains(item.type) || EventSummons.Contains(item.type)) && ModContent.GetInstance<QoLCConfig>().EndlessBossSummons)
            {
                return false;
            }

            if (item.consumable == true && item.stack >= ModContent.GetInstance<QoLCConfig>().EndlessAmount && ModContent.GetInstance<QoLCConfig>().EndlessConsumables)
            {
                return false;
            }

            return base.ConsumeItem(item, player);
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (ammo.ammo > 0 && ammo.stack >= ModContent.GetInstance<QoLCConfig>().EndlessAmount && ModContent.GetInstance<QoLCConfig>().EndlessAmmo)
            {
                return false;
            }
            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= ModContent.GetInstance<QoLCConfig>().EndlessAmount && ModContent.GetInstance<QoLCConfig>().EndlessBait)
            {
                return false;
            }
            return base.CanConsumeBait(player, bait);
        }
    }
}
