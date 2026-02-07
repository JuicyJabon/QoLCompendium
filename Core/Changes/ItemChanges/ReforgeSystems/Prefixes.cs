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
            if (CrossModSupport.Calamity.Loaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Cloaked")], 1);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Silent")], 3);
                if (CrossModSupport.CalamityEntropy.Loaded)
                    AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.CalamityEntropy.Mod, "Enchanted")], 3);

                //TIERS
                RogueReforgeTiers =
                    [
                    /* 0 */ [PrefixID.Keen, PrefixID.Nimble, PrefixID.Nasty, PrefixID.Forceful, PrefixID.Strong, Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Radical"), Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Pointy")],
                    /* 1 */ [PrefixID.Hurtful, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Quick, Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Sharp"), Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Glorious")],
                    /* 2 */ [PrefixID.Murderous, PrefixID.Agile, PrefixID.Unpleasant, Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Feathered"), Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Sleek"), Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Hefty")],
                    /* 3 */ [PrefixID.Superior, PrefixID.Demonic, Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Mighty"), Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Serrated")],
                    /* 4 */ [PrefixID.Godly, PrefixID.Deadly2, Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Vicious"), Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Lethal")],
                    /* 5 */ [Common.GetModPrefix(CrossModSupport.Calamity.Mod, "Flawless")]
                    ];

                //VOID CLASSES
                if (CrossModSupport.InfernalEclipse.Loaded && CrossModSupport.SecretsOfTheShadows.Loaded)
                {
                    Array.Resize(ref VoidRogueReforgeTiers, RogueReforgeTiers.Length);
                    VoidRogueReforgeTiers = (int[][])RogueReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Famished")], 0);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Potent")], 3);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidRogueReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omnipotent")], 5);
                }
            }

            if (CrossModSupport.ClickerClass.Loaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "ClickerRadius")], 3);

                ClickerReforgeTiers =
                    [
                    /* 0 */ [Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "Disconnected"), Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "Laggy")],
                    /* 1 */ [Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "Novice")],
                    /* 2 */ [Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "Amateur")],
                    /* 3 */ [Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "Pro")],
                    /* 4 */ [Common.GetModPrefix(CrossModSupport.ClickerClass.Mod, "Elite")]
                    ];
            }

            if (CrossModSupport.SecretsOfTheShadows.Loaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Awakened"), Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Chained")], 2);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omniscient"), Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Soulbound")], 3);


                //WEAPONS
                Array.Resize(ref VoidMeleeReforgeTiers, MeleeReforgeTiers.Length);
                VoidMeleeReforgeTiers = (int[][])MeleeReforgeTiers.Clone();
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Famished")], 0);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Precarious")], 1);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Potent")], 3);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidMeleeReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omnipotent")], 5);

                Array.Resize(ref VoidRangedReforgeTiers, RangedReforgeTiers.Length);
                VoidRangedReforgeTiers = (int[][])RangedReforgeTiers.Clone();
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Famished")], 0);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Precarious")], 1);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Potent")], 3);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidRangedReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omnipotent")], 5);

                Array.Resize(ref VoidMagicReforgeTiers, MagicReforgeTiers.Length);
                VoidMagicReforgeTiers = (int[][])MagicReforgeTiers.Clone();
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Famished")], 0);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Precarious")], 1);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Potent")], 3);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidMagicReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omnipotent")], 5);

                Array.Resize(ref VoidSummonReforgeTiers, SummonReforgeTiers.Length);
                VoidSummonReforgeTiers = (int[][])SummonReforgeTiers.Clone();
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Famished")], 0);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Precarious")], 1);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Potent")], 3);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Chthonic")], 4);
                AddPrefixesToArrays(VoidSummonReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadows.Mod, "Omnipotent")], 5);
            }

            if (CrossModSupport.Thorium.Loaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Engrossing"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Lucrative")], 2);


                //TIERS
                BardReforgeTiers = 
                    [
                    /* 0 */ [Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Muted"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "OffKey"),Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Rambling")],
                    /* 1 */ [Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Buzzing"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Refined"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Loud")],
                    /* 2 */ [Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Supersonic"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Vibrant"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Euphonic"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Inspiring"), Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Melodic")],
                    /* 3 */ [Common.GetModPrefix(CrossModSupport.Thorium.Mod, "Fabled")]
                    ];


                //VOID CLASSES
                if (CrossModSupport.SecretsOfTheShadows.Loaded && CrossModSupport.SecretsOfTheShadowsBardHealer.Loaded)
                {
                    Array.Resize(ref VoidBardReforgeTiers, BardReforgeTiers.Length);
                    VoidBardReforgeTiers = (int[][])BardReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Famished")], 0);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Potent"), Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Chthonic")], 2);
                    AddPrefixesToArrays(VoidBardReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Omnipotent")], 3);

                    Array.Resize(ref VoidHealerReforgeTiers, MagicReforgeTiers.Length);
                    VoidHealerReforgeTiers = (int[][])MagicReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Famished")], 0);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Potent")], 3);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Omnipotent")], 5);

                    Array.Resize(ref VoidMeleeHealerReforgeTiers, MeleeReforgeTiers.Length);
                    VoidMeleeHealerReforgeTiers = (int[][])MeleeReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Famished")], 0);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Potent")], 3);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidMeleeHealerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Omnipotent")], 5);

                    Array.Resize(ref VoidThrowerReforgeTiers, ThrowerReforgeTiers.Length);
                    VoidThrowerReforgeTiers = (int[][])ThrowerReforgeTiers.Clone();
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Famished")], 0);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Precarious")], 1);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Potent")], 3);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Chthonic")], 4);
                    AddPrefixesToArrays(VoidThrowerReforgeTiers, [Common.GetModPrefix(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "Omnipotent")], 5);
                }
            }

            if (CrossModSupport.Vitality.Loaded)
            {
                //ACCESSORIES
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Vitality.Mod, "CruelPrefix")], 0);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Vitality.Mod, "FiendishPrefix")], 1);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Vitality.Mod, "BrutalPrefix")], 2);
                AddPrefixesToArrays(AccessoryReforgeTiers, [Common.GetModPrefix(CrossModSupport.Vitality.Mod, "RelentlessPrefix")], 3);

                BloodHunterReforgeTiers =
                    [
                    /* 0 */ [PrefixID.Broken, PrefixID.Shoddy, Common.GetModPrefix(CrossModSupport.Vitality.Mod, "SpitefulPrefix"), Common.GetModPrefix(CrossModSupport.Vitality.Mod, "DeprecatingPrefix"),Common.GetModPrefix(CrossModSupport.Vitality.Mod, "CrudePrefix")],
                    /* 1 */ [PrefixID.Damaged, PrefixID.Weak, Common.GetModPrefix(CrossModSupport.Vitality.Mod, "DishonestPrefix")],
                    /* 2 */ [PrefixID.Keen, PrefixID.Ruthless, PrefixID.Zealous, PrefixID.Hurtful, PrefixID.Strong, PrefixID.Forceful, Common.GetModPrefix(CrossModSupport.Vitality.Mod, "DeceitfulPrefix"), Common.GetModPrefix(CrossModSupport.Vitality.Mod, "BarbedPrefix")],
                    /* 3 */ [PrefixID.Unpleasant, PrefixID.Demonic, PrefixID.Superior, PrefixID.Godly, Common.GetModPrefix(CrossModSupport.Vitality.Mod, "ViciousPrefix"), Common.GetModPrefix(CrossModSupport.Vitality.Mod, "MaliciousPrefix"), Common.GetModPrefix(CrossModSupport.Vitality.Mod, "BloodthirstyPrefix"), Common.GetModPrefix(CrossModSupport.Vitality.Mod, "WoundingPrefix") ],
                    /* 4 */ [Common.GetModPrefix(CrossModSupport.Vitality.Mod, "MalevolentPrefix")]
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
