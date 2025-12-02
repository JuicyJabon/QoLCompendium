using Terraria.GameContent.Prefixes;
using Terraria.Utilities;

namespace QoLCompendium.Core.Changes.ItemChanges.ReforgeSystems
{
    public static class ReforgeRework
    {
        public static int GetReworkedReforge(Item item, UnifiedRandom rand, int currentPrefix)
        {
            // This is the hardcoded value to "do nothing", and is thus the default choice.
            int prefix = -1;

            // ACCESSORIES
            if (item.accessory)
            {
                int accRerolls = 0;
                do
                {
                    int newPrefix = IteratePrefix(rand, Prefixes.AccessoryReforgeTiers, currentPrefix);
                    if (newPrefix != currentPrefix)
                    {
                        prefix = newPrefix;
                        break;
                    }
                    accRerolls++;
                } while (accRerolls < 20);
            }

            //VOID MELEE
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee")))
                prefix = IteratePrefix(rand, Prefixes.VoidMeleeReforgeTiers, currentPrefix);


            //VOID RANGED
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged")))
                prefix = IteratePrefix(rand, Prefixes.VoidRangedReforgeTiers, currentPrefix);


            //VOID MAGIC
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic")))
                prefix = IteratePrefix(rand, Prefixes.VoidMagicReforgeTiers, currentPrefix);


            //VOID SUMMON
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon")))
                prefix = IteratePrefix(rand, Prefixes.VoidSummonReforgeTiers, currentPrefix);


            //VOID BARD
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic")))
                prefix = IteratePrefix(rand, Prefixes.VoidBardReforgeTiers, currentPrefix);


            //VOID HEALER
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant")))
            {
                if (item.ModItem.MeleePrefix() && item.ModItem.Mod.Name == "SOTSBardHealer")
                    prefix = IteratePrefix(rand, Prefixes.VoidMeleeHealerReforgeTiers, currentPrefix);
                else
                    prefix = IteratePrefix(rand, Prefixes.VoidHealerReforgeTiers, currentPrefix);
            }

            //VOID THROWER
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing")))
                prefix = IteratePrefix(rand, Prefixes.VoidThrowerReforgeTiers, currentPrefix);

            //VOID ROGUE
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")))
                prefix = IteratePrefix(rand, Prefixes.VoidRogueReforgeTiers, currentPrefix);

            // MELEE (includes tools and whips)
            else if ((item.CountsAsClass<MeleeDamageClass>() || item.CountsAsClass(Common.GetModDamageClass(ModConditions.calamityMod, "MeleeRangedHybridDamageClass")) || item.CountsAsClass<SummonMeleeSpeedDamageClass>()) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMelee")))
            {
                // Terrarian (has its own special "Legendary" for marketing reasons)
                // Other items that want to use Legendary2 are also compatible
                if (PrefixLegacy.ItemSets.ItemsThatCanHaveLegendary2[item.type])
                {
                    prefix = IteratePrefix(rand, Prefixes.TerrarianReforgeTiers, currentPrefix);
                }

                // Swords, Whips, Tools, other items that support the Legendary modifier
                else if (PrefixLegacy.ItemSets.SwordsHammersAxesPicks[item.type] || (item.ModItem != null && item.ModItem.MeleePrefix()) || item.IsATool())
                {
                    var tierListToUse = item.pick > 0 || item.axe > 0 || item.hammer > 0 ? Prefixes.ToolReforgeTiers : Prefixes.MeleeReforgeTiers;
                    prefix = IteratePrefix(rand, tierListToUse, currentPrefix);
                }

                // Yoyos, Flails, Spears, etc.
                // Spears actually work fine with Legendary, but vanilla doesn't give it to them, so we won't either.
                else
                    prefix = IteratePrefix(rand, Prefixes.MeleeNoSpeedReforgeTiers, currentPrefix);
            }

            // RANGED
            else if (item.CountsAsClass<RangedDamageClass>() && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidRanged")))
                prefix = IteratePrefix(rand, Prefixes.RangedReforgeTiers, currentPrefix);

            // MAGIC
            else if ((item.CountsAsClass<MagicDamageClass>() || item.CountsAsClass<MagicSummonHybridDamageClass>()) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidMagic")))
                prefix = IteratePrefix(rand, Prefixes.MagicReforgeTiers, currentPrefix);

            // SUMMON (not whips)
            else if (item.CountsAsClass<SummonDamageClass>() && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsMod, "VoidSummon")))
                prefix = IteratePrefix(rand, Prefixes.SummonReforgeTiers, currentPrefix);

            // THROWER
            else if (item.CountsAsClass<ThrowingDamageClass>() && !ModConditions.calamityLoaded && (!item.CountsAsClass(Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")) || !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing"))))
                prefix = IteratePrefix(rand, Prefixes.ThrowerReforgeTiers, currentPrefix);

            // ROGUE
            else if (item.CountsAsClass<ThrowingDamageClass>() && ModConditions.calamityLoaded && (!item.CountsAsClass(Common.GetModDamageClass(ModConditions.infernalEclipseMod, "VoidRogue")) || !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidThrowing"))))
                prefix = IteratePrefix(rand, Prefixes.RogueReforgeTiers, currentPrefix);
            
            //BARD
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.thoriumMod, "BardDamage")) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidSymphonic")))
                prefix = IteratePrefix(rand, Prefixes.BardReforgeTiers, currentPrefix);
            
            //HEALER
            else if ((item.CountsAsClass(Common.GetModDamageClass(ModConditions.thoriumMod, "HealerDamage")) || item.CountsAsClass(Common.GetModDamageClass(ModConditions.thoriumMod, "HealerToolDamageHybrid"))) && !item.CountsAsClass(Common.GetModDamageClass(ModConditions.secretsOfTheShadowsBardHealerMod, "VoidRadiant")))
            {
                if (item.ModItem.MeleePrefix() && item.ModItem.Mod.Name == "CalamityBardHealer" || item.ModItem.Mod.Name == "SOTSBardHealer" || item.ModItem.Mod.Name == "SpookyBardHealer" || item.ModItem.Mod.Name == "SpiritBardHealer" || item.ModItem.Mod.Name == "MacroBardHealer" || item.ModItem.Mod.Name == "RedemptionBardHealer" || item.ModItem.Mod.Name == ModConditions.thoriumBossReworkName)
                    prefix = IteratePrefix(rand, Prefixes.MeleeReforgeTiers, currentPrefix);
                else if (item.mana > 0 || item.ModItem.MagicPrefix())
                    prefix = IteratePrefix(rand, Prefixes.MagicReforgeTiers, currentPrefix);
                else
                    prefix = IteratePrefix(rand, Prefixes.GenericReforgeTiers, currentPrefix);
            }

            //BLOOD HUNTER
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.vitalityMod, "BloodHunterClass")))
                prefix = IteratePrefix(rand, Prefixes.BloodHunterReforgeTiers, currentPrefix);
            
            //CLICKER
            else if (item.CountsAsClass(Common.GetModDamageClass(ModConditions.clickerClassMod, "ClickerDamage")))
                prefix = IteratePrefix(rand, Prefixes.ClickerReforgeTiers, currentPrefix);

            return prefix;
        }

        public static int GetPrefixTier(int[][] tiers, int currentPrefix)
        {
            for (int checkingTier = 0; checkingTier < tiers.Length; ++checkingTier)
            {
                int[] tierList = tiers[checkingTier];
                for (int i = 0; i < tierList.Length; ++i)
                    if (tierList[i] == currentPrefix)
                        return checkingTier;
            }

            // If an invalid or modded prefix is detected, return -1.
            // This will give a random tier 0 prefix (the "next tier"), starting fresh with a low-tier prefix.
            return -1;
        }

        public static int IteratePrefix(UnifiedRandom rand, int[][] reforgeTiers, int currentPrefix)
        {
            int currentTier = GetPrefixTier(reforgeTiers, currentPrefix);

            // If max tier: give max tier reforges forever
            // Otherwise: go up by 1 tier with every reforge, guaranteed
            int newTier = currentTier == reforgeTiers.Length - 1 ? currentTier : currentTier + 1;
            return rand.Next(reforgeTiers[newTier]);
        }
    }
}
