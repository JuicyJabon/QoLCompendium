using Terraria.ModLoader.IO;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class PermanentBuffPlayer : ModPlayer
    {
        public bool buffActive = false;

        public SortedSet<IPermanentBuff> potionEffects = new();

        public SortedSet<IPermanentModdedBuff> modPotionEffects = new();

        public override void ResetEffects() => ResetValues();

        public override void UpdateDead() => ResetValues();

        public override void Unload() => PermanentBuffsBools = null;

        public void ResetValues()
        {
            buffActive = false;
            potionEffects.Clear();
            modPotionEffects.Clear();
        }

        public override void PostUpdateEquips()
        {
            CheckForPotions(Player.bank.item);
            CheckForPotions(Player.bank2.item);
            CheckForPotions(Player.bank3.item);
            CheckForPotions(Player.bank4.item);
            UpdatePotions();
        }

        public void UpdatePotions()
        {
            foreach (IPermanentBuff potionEffect in potionEffects)
                potionEffect.ApplyEffect(this);

            foreach (IPermanentModdedBuff modPotionEffect in modPotionEffects)
                modPotionEffect.ApplyEffect(this);
        }
        
        public void CheckForPotions(Item[] inventory)
        {
            foreach(Item item in inventory)
            {
                if (!item.IsAir && item.ModItem is IPermanentBuffItem pBuffItem)
                    pBuffItem.ApplyBuff(this);

                if (!item.IsAir && item.ModItem is IPermanentModdedBuffItem pModBuffItem)
                    pModBuffItem.ApplyBuff(this);
            }
        }

        public override void SaveData(TagCompound tag)
        {
            //VANILLA
            List<string> buffsEnabled = [];
            for (int i = 0; i < PermanentBuffsBools.Length; i++)
            {
                if (PermanentBuffsBools[i])
                    buffsEnabled.Add("QoLCPBuff" + i);
            }
            tag.Add("QoLCPBuff", buffsEnabled);

            //CALAMITY
            List<string> calamityBuffsEnabled = [];
            for (int i = 0; i < PermanentCalamityBuffsBools.Length; i++)
            {
                if (PermanentCalamityBuffsBools[i])
                    calamityBuffsEnabled.Add("QoLCPCalamityBuff" + i);
            }
            tag.Add("QoLCPCalamityBuff", calamityBuffsEnabled);

            //MARTIN'S ORDER
            List<string> martinsOrderBuffsEnabled = [];
            for (int i = 0; i < PermanentMartinsOrderBuffsBools.Length; i++)
            {
                if (PermanentMartinsOrderBuffsBools[i])
                    martinsOrderBuffsEnabled.Add("QoLCPMartinsOrderBuff" + i);
            }
            tag.Add("QoLCPMartinsOrderBuff", martinsOrderBuffsEnabled);

            //SPIRIT CLASSIC
            List<string> spiritClassicBuffsEnabled = [];
            for (int i = 0; i < PermanentSpiritClassicBuffsBools.Length; i++)
            {
                if (PermanentSpiritClassicBuffsBools[i])
                    spiritClassicBuffsEnabled.Add("QoLCPSpiritClassicBuff" + i);
            }
            tag.Add("QoLCPSpiritClassicBuff", spiritClassicBuffsEnabled);

            //THORIUM
            List<string> thoriumBuffsEnabled = [];
            for (int i = 0; i < PermanentThoriumBuffsBools.Length; i++)
            {
                if (PermanentThoriumBuffsBools[i])
                    thoriumBuffsEnabled.Add("QoLCPThoriumBuff" + i);
            }
            tag.Add("QoLCPThoriumBuff", thoriumBuffsEnabled);
        }

        public override void LoadData(TagCompound tag)
        {
            //VANILLA
            IList<string> buffsEnabled = tag.GetList<string>("QoLCPBuff");
            for (int i = 0; i < PermanentBuffsBools.Length; i++)
                PermanentBuffsBools[i] = buffsEnabled.Contains($"QoLCPBuff{i}");

            //CALAMITY
            IList<string> calamityBuffsEnabled = tag.GetList<string>("QoLCPCalamityBuff");
            for (int i = 0; i < PermanentCalamityBuffsBools.Length; i++)
                PermanentCalamityBuffsBools[i] = calamityBuffsEnabled.Contains($"QoLCPCalamityBuff{i}");

            //MARTIN'S ORDER
            IList<string> martinsOrderBuffsEnabled = tag.GetList<string>("QoLCPMartinsOrderBuff");
            for (int i = 0; i < PermanentMartinsOrderBuffsBools.Length; i++)
                PermanentMartinsOrderBuffsBools[i] = martinsOrderBuffsEnabled.Contains($"QoLCPMartinsOrderBuff{i}");

            //SPIRIT CLASSIC
            IList<string> spiritClassicBuffsEnabled = tag.GetList<string>("QoLCPSpiritClassicBuff");
            for (int i = 0; i < PermanentSpiritClassicBuffsBools.Length; i++)
                PermanentSpiritClassicBuffsBools[i] = spiritClassicBuffsEnabled.Contains($"QoLCPSpiritClassicBuff{i}");

            //THORIUM
            IList<string> thoriumBuffsEnabled = tag.GetList<string>("QoLCPThoriumBuff");
            for (int i = 0; i < PermanentThoriumBuffsBools.Length; i++)
                PermanentThoriumBuffsBools[i] = thoriumBuffsEnabled.Contains($"QoLCPThoriumBuff{i}");
        }

        public enum PermanentBuffs
        {
            //Arena
            BastStatue,
            Campfire,
            GardenGnome,
            HeartLantern,
            Honey,
            PeaceCandle,
            ShadowCandle,
            StarInABottle,
            Sunflower,
            WaterCandle,
            //Potions
            AmmoReservation,
            Archery,
            Battle,
            BiomeSight,
            Builder,
            Calm,
            Crate,
            Dangersense,
            Endurance,
            ExquisitelyStuffed,
            Featherfall,
            Fishing,
            Flipper,
            Gills,
            Gravitation,
            Heartreach,
            Hunter,
            Inferno,
            Invisibility,
            Ironskin,
            Lifeforce,
            Lucky,
            MagicPower,
            ManaRegeneration,
            Mining,
            NightOwl,
            ObsidianSkin,
            PlentySatisfied,
            Rage,
            Regeneration,
            Shine,
            Sonar,
            Spelunker,
            Summoning,
            Swiftness,
            Thorns,
            Tipsy,
            Titan,
            Warmth,
            WaterWalking,
            WellFed,
            Wrath,
            //Stations
            AmmoBox,
            BewitchingTable,
            CrystalBall,
            SharpeningStation,
            SliceOfCake,
            WarTable,
        }

        public static bool[] permanentBuffsBools = new bool[Enum.GetValues(typeof(PermanentBuffs)).Length];

        public static bool[] PermanentBuffsBools { get => permanentBuffsBools; set => permanentBuffsBools = value; }

        public enum PermanentCalamityBuffs
        {
            //Calamity
            //Arena
            ChaosCandle,
            CorruptionEffigy,
            CrimsonEffigy,
            EffigyOfDecay,
            ResilientCandle,
            SpitefulCandle,
            TranquilityCandle,
            VigorousCandle,
            WeightlessCandle,
            //Potions
            AnechoicCoating,
            AstralInjection,
            Baguette,
            Bloodfin,
            Bounding,
            Calcium,
            CeaselessHunger,
            GravityNormalizer,
            Omniscience,
            Photosynthesis,
            Shadow,
            Soaring,
            Sulphurskin,
            Tesla,
            Zen,
            Zerg,

            //Catalyst
            //Potions
            AstraJelly,
            Astracola,

            //Clamity
            //Potions
            ExoBaguette,
            SupremeLuck,
            TitanScale,
        }

        public static bool[] permanentCalamityBuffsBools = new bool[Enum.GetValues(typeof(PermanentCalamityBuffs)).Length];

        public static bool[] PermanentCalamityBuffsBools { get => permanentCalamityBuffsBools; set => permanentCalamityBuffsBools = value; }

        public enum PermanentMartinsOrderBuffs
        {
            //Potions
            BlackHole,
            Charging,
            Defender,
            Empowerment,
            Evocation,
            GourmetFlavor,
            Haste,
            Healing,
            Rockskin,
            Shooter,
            Soul,
            SpellCaster,
            Starreach,
            Sweeper,
            Thrower,
            Whipper,
            ZincPill,
            //Stations
            Archeology,
            SporeFarm
        }

        public static bool[] permanentMartinsOrderBuffsBools = new bool[Enum.GetValues(typeof(PermanentMartinsOrderBuffs)).Length];

        public static bool[] PermanentMartinsOrderBuffsBools { get => permanentMartinsOrderBuffsBools; set => permanentMartinsOrderBuffsBools = value; }

        public enum PermanentSpiritClassicBuffs
        {
            //Arena
            CoiledEnergizer,
            KoiTotem,
            SunPot,
            TheCouch,
            //Potions
            Jump,
            MirrorCoat,
            MoonJelly,
            Runescribe,
            Soulguard,
            Spirit,
            Soaring,
            Sporecoid,
            Starburn,
            Steadfast,
            Toxin,
            Zephyr,
        }

        public static bool[] permanentSpiritClassicBuffsBools = new bool[Enum.GetValues(typeof(PermanentSpiritClassicBuffs)).Length];

        public static bool[] PermanentSpiritClassicBuffsBools { get => permanentSpiritClassicBuffsBools; set => permanentSpiritClassicBuffsBools = value; }

        public enum PermanentThoriumBuffs
        {
            //Arena
            Mistletoe,
            //Potions
            AquaAffinity,
            Arcane,
            Artillery,
            Assassin,
            BloodRush,
            BouncingFlame,
            CactusFruit,
            Conflagration,
            Creativity,
            Earworm,
            Frenzy,
            Glowing,
            Holy,
            Hydration,
            InspirationalReach,
            Kinetic,
            Warmonger,
            //Repellents
            BatRepellent,
            FishRepellent,
            InsectRepellent,
            SkeletonRepellent,
            ZombieRepellent,
            //Stations
            Altar,
            ConductorsStand,
            NinjaRack,
            //Addons
            Deathsinger,
            InspirationRegeneration
        }

        public static bool[] permanentThoriumBuffsBools = new bool[Enum.GetValues(typeof(PermanentThoriumBuffs)).Length];

        public static bool[] PermanentThoriumBuffsBools { get => permanentThoriumBuffsBools; set => permanentThoriumBuffsBools = value; }
    }
}