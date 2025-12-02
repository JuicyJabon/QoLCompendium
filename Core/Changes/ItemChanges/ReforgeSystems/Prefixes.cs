namespace QoLCompendium.Core.Changes.ItemChanges.ReforgeSystems
{
    public static class Prefixes
    {
        public static int[][] AccessoryReforgeTiers =
        [
            /* 0 */ [PrefixID.Hard, PrefixID.Jagged, PrefixID.Brisk, PrefixID.Wild],
            /* 1 */ [PrefixID.Guarding, PrefixID.Spiked, PrefixID.Precise, PrefixID.Fleeting, PrefixID.Rash],
            /* 2 */ [PrefixID.Armored, PrefixID.Angry, PrefixID.Hasty2, PrefixID.Intrepid, PrefixID.Arcane],
            /* 3 */ [PrefixID.Warding, PrefixID.Menacing, PrefixID.Lucky, PrefixID.Quick2, PrefixID.Violent],
        ];

        public static int[][] TerrarianReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous],
            /* 2 */ [PrefixID.Superior, PrefixID.Demonic, PrefixID.Godly],
            /* 3 */ [PrefixID.Legendary2],
        ];

        public static int[][] MeleeReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Light, PrefixID.Heavy, PrefixID.Light, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, PrefixID.Pointy, PrefixID.Bulky],
            /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Large, PrefixID.Dangerous, PrefixID.Sharp],
            /* 3 */ [PrefixID.Massive, PrefixID.Unpleasant, PrefixID.Savage, PrefixID.Superior],
            /* 4 */ [PrefixID.Demonic, PrefixID.Deadly2, PrefixID.Godly],
            /* 5 */ [PrefixID.Legendary]
        ];

        public static int[][] ToolReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Heavy, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, PrefixID.Pointy, PrefixID.Bulky],
            /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Large, PrefixID.Dangerous, PrefixID.Sharp],
            /* 3 */ [PrefixID.Massive, PrefixID.Unpleasant, PrefixID.Savage, PrefixID.Superior],
            /* 4 */ [PrefixID.Demonic, PrefixID.Deadly2, PrefixID.Godly],
            /* 5 */ [PrefixID.Legendary, PrefixID.Light]
        ];

        public static int[][] MeleeNoSpeedReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous],
            /* 2 */ [PrefixID.Superior, PrefixID.Demonic],
            /* 3 */ [PrefixID.Godly]
        ];

        public static int[][] RangedReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Powerful, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, PrefixID.Intimidating],
            /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Hasty, PrefixID.Staunch, PrefixID.Unpleasant],
            /* 3 */ [PrefixID.Superior, PrefixID.Demonic, PrefixID.Sighted],
            /* 4 */ [PrefixID.Godly, PrefixID.Rapid, /* ranged Deadly */ PrefixID.Deadly, /* universal Deadly */ PrefixID.Deadly2],
            /* 5 */ [PrefixID.Unreal]
        ];

        public static int[][] ThrowerReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Powerful, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, PrefixID.Intimidating],
            /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Hasty, PrefixID.Staunch, PrefixID.Unpleasant],
            /* 3 */ [PrefixID.Superior, PrefixID.Demonic, PrefixID.Sighted],
            /* 4 */ [PrefixID.Godly, PrefixID.Rapid, /* ranged Deadly */ PrefixID.Deadly, /* universal Deadly */ PrefixID.Deadly2],
            /* 5 */ [PrefixID.Unreal]
        ];

        public static int[][] MagicReforgeTiers =
        [
            /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Furious, PrefixID.Forceful, PrefixID.Strong],
            /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, PrefixID.Taboo, PrefixID.Manic],
            /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Adept, PrefixID.Celestial, PrefixID.Unpleasant],
            /* 3 */ [PrefixID.Superior, PrefixID.Demonic, PrefixID.Mystic],
            /* 4 */ [PrefixID.Godly, PrefixID.Masterful, PrefixID.Deadly2],
            /* 5 */ [PrefixID.Mythical]
        ];

        public static int[][] SummonReforgeTiers =
        [
            /* 0 */ [PrefixID.Nimble, PrefixID.Furious],
            /* 1 */ [PrefixID.Forceful, PrefixID.Strong, PrefixID.Quick, PrefixID.Taboo, PrefixID.Manic],
            /* 2 */ [PrefixID.Hurtful, PrefixID.Adept, PrefixID.Celestial],
            /* 3 */ [PrefixID.Superior, PrefixID.Demonic, PrefixID.Mystic, PrefixID.Deadly2],
            /* 4 */ [PrefixID.Masterful, PrefixID.Godly],
            /* 5 */ [PrefixID.Mythical, PrefixID.Ruthless]
        ];

        public static int[][] GenericReforgeTiers =
        [
            /* 0 */ [PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy, PrefixID.Weak, PrefixID.Lazy, PrefixID.Slow, PrefixID.Sluggish, PrefixID.Annoying],
            /* 1 */ [PrefixID.Zealous, PrefixID.Keen, PrefixID.Forceful, PrefixID.Strong, PrefixID.Nimble, PrefixID.Quick],
            /* 2 */ [PrefixID.Hurtful, PrefixID.Unpleasant, PrefixID.Nasty, PrefixID.Agile],
            /* 3 */ [PrefixID.Superior, PrefixID.Deadly2, PrefixID.Murderous],
            /* 4 */ [PrefixID.Godly, PrefixID.Demonic, PrefixID.Ruthless]
        ];

        public static int[][] RogueReforgeTiers;

        public static int[][] BardReforgeTiers;

        public static int[][] VoidMeleeReforgeTiers;

        public static int[][] VoidRangedReforgeTiers;

        public static int[][] VoidMagicReforgeTiers;

        public static int[][] VoidSummonReforgeTiers;

        public static int[][] VoidBardReforgeTiers;

        public static int[][] VoidHealerReforgeTiers;

        public static int[][] VoidMeleeHealerReforgeTiers;

        public static int[][] VoidThrowerReforgeTiers;

        public static int[][] VoidRogueReforgeTiers;

        public static int[][] BloodHunterReforgeTiers;

        public static int[][] ClickerReforgeTiers;

        public static void PostSetupTasks()
        {
            if (ModConditions.calamityLoaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.calamityMod, "Cloaked")], 1);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.calamityMod, "Silent")], 3);
                if (ModConditions.calamityEntropyLoaded)
                    AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.calamityEntropyMod, "Enchanted")], 3);

                //TIERS
                RogueReforgeTiers =
                    [
                    /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Forceful, PrefixID.Strong, Common.GetModPrefix(ModConditions.calamityMod, "Radical"), Common.GetModPrefix(ModConditions.calamityMod, "Pointy")],
                    /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, Common.GetModPrefix(ModConditions.calamityMod, "Sharp"), Common.GetModPrefix(ModConditions.calamityMod, "Glorious")],
                    /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Unpleasant, Common.GetModPrefix(ModConditions.calamityMod, "Feathered"), Common.GetModPrefix(ModConditions.calamityMod, "Sleek"), Common.GetModPrefix(ModConditions.calamityMod, "Hefty")],
                    /* 3 */ [PrefixID.Superior, PrefixID.Demonic, Common.GetModPrefix(ModConditions.calamityMod, "Mighty"), Common.GetModPrefix(ModConditions.calamityMod, "Serrated")],
                    /* 4 */ [PrefixID.Godly, PrefixID.Deadly2, Common.GetModPrefix(ModConditions.calamityMod, "Vicious"), Common.GetModPrefix(ModConditions.calamityMod, "Lethal")],
                    /* 5 */ [Common.GetModPrefix(ModConditions.calamityMod, "Flawless")]
                    ];

                //VOID CLASSES
                if (ModConditions.infernalEclipseLoaded && ModConditions.secretsOfTheShadowsLoaded)
                {
                    Array.Resize(ref VoidRogueReforgeTiers, RogueReforgeTiers.Length);
                    VoidRogueReforgeTiers = (int[][])RogueReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Famished")], 0);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Potent")], 3);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omnipotent")], 5);
                }
            }

            if (ModConditions.clickerClassLoaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.clickerClassMod, "ClickerRadius")], 3);

                ClickerReforgeTiers =
                    [
                    /* 0 */ [Common.GetModPrefix(ModConditions.clickerClassMod, "Disconnected"), Common.GetModPrefix(ModConditions.clickerClassMod, "Laggy")],
                    /* 1 */ [Common.GetModPrefix(ModConditions.clickerClassMod, "Novice")],
                    /* 2 */ [Common.GetModPrefix(ModConditions.clickerClassMod, "Amateur")],
                    /* 3 */ [Common.GetModPrefix(ModConditions.clickerClassMod, "Pro")],
                    /* 4 */ [Common.GetModPrefix(ModConditions.clickerClassMod, "Elite")]
                    ];
            }

            if (ModConditions.secretsOfTheShadowsLoaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Awakened"), Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Chained")], 2);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omniscient"), Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Soulbound")], 3);


                //WEAPONS
                Array.Resize(ref VoidMeleeReforgeTiers, MeleeReforgeTiers.Length);
                VoidMeleeReforgeTiers = (int[][])MeleeReforgeTiers.Clone();
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Famished")], 0);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Precarious")], 1);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Potent")], 3);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omnipotent")], 5);

                Array.Resize(ref VoidRangedReforgeTiers, RangedReforgeTiers.Length);
                VoidRangedReforgeTiers = (int[][])RangedReforgeTiers.Clone();
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Famished")], 0);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Precarious")], 1);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Potent")], 3);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omnipotent")], 5);

                Array.Resize(ref VoidMagicReforgeTiers, MagicReforgeTiers.Length);
                VoidMagicReforgeTiers = (int[][])MagicReforgeTiers.Clone();
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Famished")], 0);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Precarious")], 1);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Potent")], 3);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omnipotent")], 5);

                Array.Resize(ref VoidSummonReforgeTiers, SummonReforgeTiers.Length);
                VoidSummonReforgeTiers = (int[][])SummonReforgeTiers.Clone();
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Famished")], 0);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Precarious")], 1);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Potent")], 3);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsMod, "Omnipotent")], 5);
            }

            if (ModConditions.thoriumLoaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.thoriumMod, "Engrossing"), Common.GetModPrefix(ModConditions.thoriumMod, "Lucrative")], 2);


                //TIERS
                BardReforgeTiers = 
                    [
                    /* 0 */ [Common.GetModPrefix(ModConditions.thoriumMod, "Muted"), Common.GetModPrefix(ModConditions.thoriumMod, "OffKey"),Common.GetModPrefix(ModConditions.thoriumMod, "Rambling")],
                    /* 1 */ [Common.GetModPrefix(ModConditions.thoriumMod, "Buzzing"), Common.GetModPrefix(ModConditions.thoriumMod, "Refined"), Common.GetModPrefix(ModConditions.thoriumMod, "Loud")],
                    /* 2 */ [Common.GetModPrefix(ModConditions.thoriumMod, "Supersonic"), Common.GetModPrefix(ModConditions.thoriumMod, "Vibrant"), Common.GetModPrefix(ModConditions.thoriumMod, "Euphonic"), Common.GetModPrefix(ModConditions.thoriumMod, "Inspiring")],
                    /* 3 */ [Common.GetModPrefix(ModConditions.thoriumMod, "Melodic")],
                    /* 4 */ [Common.GetModPrefix(ModConditions.thoriumMod, "Fabled")]
                    ];


                //VOID CLASSES
                if (ModConditions.secretsOfTheShadowsLoaded && ModConditions.secretsOfTheShadowsBardHealerLoaded)
                {
                    Array.Resize(ref VoidBardReforgeTiers, BardReforgeTiers.Length);
                    VoidBardReforgeTiers = (int[][])BardReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Famished")], 0);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Potent")], 2);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Chthonic")], 3);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Omnipotent")], 4);

                    Array.Resize(ref VoidHealerReforgeTiers, MagicReforgeTiers.Length);
                    VoidHealerReforgeTiers = (int[][])MagicReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Famished")], 0);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Potent")], 3);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Omnipotent")], 5);

                    Array.Resize(ref VoidMeleeHealerReforgeTiers, MeleeReforgeTiers.Length);
                    VoidMeleeHealerReforgeTiers = (int[][])MeleeReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Famished")], 0);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Potent")], 3);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Omnipotent")], 5);

                    Array.Resize(ref VoidThrowerReforgeTiers, ThrowerReforgeTiers.Length);
                    VoidThrowerReforgeTiers = (int[][])ThrowerReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Famished")], 0);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Potent")], 3);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(ModConditions.secretsOfTheShadowsBardHealerMod, "Omnipotent")], 5);
                }
            }

            if (ModConditions.vitalityLoaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.vitalityMod, "CruelPrefix")], 0);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.vitalityMod, "FiendishPrefix")], 1);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.vitalityMod, "BrutalPrefix")], 2);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(ModConditions.vitalityMod, "RelentlessPrefix")], 3);

                BloodHunterReforgeTiers =
                    [
                    /* 0 */ [PrefixID.Broken, PrefixID.Shoddy, Common.GetModPrefix(ModConditions.vitalityMod, "SpitefulPrefix"), Common.GetModPrefix(ModConditions.vitalityMod, "DeprecatingPrefix"),Common.GetModPrefix(ModConditions.vitalityMod, "CrudePrefix")],
                    /* 1 */ [PrefixID.Damaged, PrefixID.Weak, Common.GetModPrefix(ModConditions.vitalityMod, "DishonestPrefix")],
                    /* 2 */ [PrefixID.Keen, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Hurtful, PrefixID.Strong, PrefixID.Forceful, Common.GetModPrefix(ModConditions.vitalityMod, "DeceitfulPrefix"), Common.GetModPrefix(ModConditions.vitalityMod, "BarbedPrefix")],
                    /* 3 */ [PrefixID.Unpleasant, PrefixID.Demonic, PrefixID.Superior, PrefixID.Godly, Common.GetModPrefix(ModConditions.vitalityMod, "ViciousPrefix"), Common.GetModPrefix(ModConditions.vitalityMod, "MaliciousPrefix"), Common.GetModPrefix(ModConditions.vitalityMod, "BloodthirstyPrefix"), Common.GetModPrefix(ModConditions.vitalityMod, "WoundingPrefix") ],
                    /* 4 */ [Common.GetModPrefix(ModConditions.vitalityMod, "MalevolentPrefix")]
                    ];
            }
        }

        public static int[][] AddPrefixesToArrays(int[][] prefixList, int[] prefixesToAdd, int index)
        {
            Array.Resize(ref prefixList[index], prefixList[index].Length + prefixesToAdd.Length);
            Array.Copy(prefixesToAdd, 0, prefixList[index], prefixList[index].Length - prefixesToAdd.Length, prefixesToAdd.Length);
            return prefixList;
        }
    }
}
