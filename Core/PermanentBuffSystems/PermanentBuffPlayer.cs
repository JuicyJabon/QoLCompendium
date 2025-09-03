using ClickerClass;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.All;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Clicker;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.HomewardJourney;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.SOTS;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SOTS;
using SOTS;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class PermanentBuffPlayer : ModPlayer
    {
        public bool buffActive = false;

        public SortedSet<IPermanentBuff> potionEffects = new();

        public SortedSet<IPermanentModdedBuff> modPotionEffects = new();

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
            WarTable
        }

        public bool[] PermanentBuffsBools =  new bool[Enum.GetValues(typeof(PermanentBuffs)).Length];

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

            //Calamity Entropy
            //Arena
            VoidCandle,
            //Potions
            SoyMilk,
            YharimsStimulants
        }

        public bool[] PermanentCalamityBuffsBools = new bool[Enum.GetValues(typeof(PermanentCalamityBuffs)).Length];

        public enum PermanentHomewardJourneyBuffs
        {
            //Arena
            BushOfLife,
            LifeLantern,
            //Potions
            Flight,
            FluorescentBerry,
            Haste,
            Reanimation,
            Yang,
            Yin
        }

        public bool[] PermanentHomewardJourneyBuffsBools = new bool[Enum.GetValues(typeof(PermanentHomewardJourneyBuffs)).Length];

        public enum PermanentMartinsOrderBuffs
        {
            //Potions
            BlackHole,
            Body,
            Charging,
            Defender,
            Empowerment,
            Evocation,
            GourmetFlavor,
            Haste,
            Healing,
            Rockskin,
            Shielding,
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

        public bool[] PermanentMartinsOrderBuffsBools = new bool[Enum.GetValues(typeof(PermanentMartinsOrderBuffs)).Length];

        public enum PermanentSOTSBuffs
        {
            //Potions
            Assassination,
            Bluefire,
            Brittle,
            DoubleVision,
            Harmony,
            Nightmare,
            Ripple,
            Roughskin,
            SoulAccess,
            Vibe,
            //Stations
            DigitalDisplay
        }

        public bool[] PermanentSOTSBuffsBools = new bool[Enum.GetValues(typeof(PermanentSOTSBuffs)).Length];

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
            //Candies
            Candy,
            ChocolateBar,
            HealthCandy,
            Lollipop,
            ManaCandy,
            Taffy
        }

        public bool[] PermanentSpiritClassicBuffsBools = new bool[Enum.GetValues(typeof(PermanentSpiritClassicBuffs)).Length];

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

        public bool[] PermanentThoriumBuffsBools = new bool[Enum.GetValues(typeof(PermanentThoriumBuffs)).Length];

        public override void ResetEffects() => ResetValues();

        public override void UpdateDead() => ResetValues();

        public void ResetValues()
        {
            buffActive = false;
            potionEffects.Clear();
            modPotionEffects.Clear();
        }

        public override void PostUpdateEquips()
        {
            CheckForPotions(Common.GetAllInventoryItemsList(Player).ToArray());
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
            tag.Add("QoLCEnabledPermanentBuffs", PermanentBuffsBools);
            tag.Add("QoLCEnabledPermanentCalamityBuffs", PermanentCalamityBuffsBools);
            tag.Add("QoLCEnabledPermanentHomewardJourneyBuffs", PermanentHomewardJourneyBuffsBools);
            tag.Add("QoLCEnabledPermanentMartinsOrderBuffs", PermanentMartinsOrderBuffsBools);
            tag.Add("QoLCEnabledPermanentSOTSBuffs", PermanentSOTSBuffsBools);
            tag.Add("QoLCEnabledPermanentSpiritClassicBuffs", PermanentSpiritClassicBuffsBools);
            tag.Add("QoLCEnabledPermanentThoriumBuffs", PermanentThoriumBuffsBools);
        }

        public override void LoadData(TagCompound tag)
        {
            PermanentBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentBuffs");
            PermanentCalamityBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentCalamityBuffs");
            PermanentHomewardJourneyBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentHomewardJourneyBuffs");
            PermanentMartinsOrderBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentMartinsOrderBuffs");
            PermanentSOTSBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentSOTSBuffs");
            PermanentSpiritClassicBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentSpiritClassicBuffs");
            PermanentThoriumBuffsBools = tag.Get<bool[]>("QoLCEnabledPermanentThoriumBuffs");

            if (PermanentBuffsBools.Length < Enum.GetValues(typeof(PermanentBuffs)).Length)
                Array.Resize(ref PermanentBuffsBools, Enum.GetValues(typeof(PermanentBuffs)).Length);

            if (PermanentCalamityBuffsBools.Length < Enum.GetValues(typeof(PermanentCalamityBuffs)).Length)
                Array.Resize(ref PermanentCalamityBuffsBools, Enum.GetValues(typeof(PermanentCalamityBuffs)).Length);

            if (PermanentHomewardJourneyBuffsBools.Length < Enum.GetValues(typeof(PermanentHomewardJourneyBuffs)).Length)
                Array.Resize(ref PermanentHomewardJourneyBuffsBools, Enum.GetValues(typeof(PermanentHomewardJourneyBuffs)).Length);

            if (PermanentMartinsOrderBuffsBools.Length < Enum.GetValues(typeof(PermanentMartinsOrderBuffs)).Length)
                Array.Resize(ref PermanentMartinsOrderBuffsBools, Enum.GetValues(typeof(PermanentMartinsOrderBuffs)).Length);

            if (PermanentSOTSBuffsBools.Length < Enum.GetValues(typeof(PermanentSOTSBuffs)).Length)
                Array.Resize(ref PermanentSOTSBuffsBools, Enum.GetValues(typeof(PermanentSOTSBuffs)).Length);

            if (PermanentSpiritClassicBuffsBools.Length < Enum.GetValues(typeof(PermanentSpiritClassicBuffs)).Length)
                Array.Resize(ref PermanentSpiritClassicBuffsBools, Enum.GetValues(typeof(PermanentSpiritClassicBuffs)).Length);

            if (PermanentThoriumBuffsBools.Length < Enum.GetValues(typeof(PermanentThoriumBuffs)).Length)
                Array.Resize(ref PermanentThoriumBuffsBools, Enum.GetValues(typeof(PermanentThoriumBuffs)).Length);
        }
    }

    [JITWhenModsEnabled("SOTS")]
    [ExtendsFromMod("SOTS")]
    public class SOTSRippleEffect : ModPlayer
    {
        public override void PreUpdateBuffs()
        {
            if (Player.GetModPlayer<PermanentBuffPlayer>().PermanentSOTSBuffsBools[(int)PermanentBuffPlayer.PermanentSOTSBuffs.Ripple])
                return;

            if (Player.HasItemInAnyInventory(ModContent.ItemType<PermanentRipple>()) || Player.HasItemInAnyInventory(ModContent.ItemType<PermanentSecretsOfTheShadows>()) || Player.HasItemInAnyInventory(ModContent.ItemType<PermanentEverything>()))
            {
                SOTSPlayer modPlayer = SOTSPlayer.ModPlayer(Player);
                modPlayer.rippleBonusDamage += 2;
                modPlayer.rippleEffect = true;
                modPlayer.rippleTimer++;
            }
        }
    }

    [JITWhenModsEnabled("ClickerClass")]
    [ExtendsFromMod("ClickerClass")]
    public class ClickerClassInfluenceEffect : ModPlayer
    {
        public readonly int RadiusIncrease = 20;

        public override void PreUpdateBuffs()
        {
            if (Player.HasItemInAnyInventory(ModContent.ItemType<PermanentInfluence>()))
                Player.GetModPlayer<ClickerPlayer>().clickerRadius += (float)(2 * RadiusIncrease) / 100f;
        }
    }

    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class HomewardJourneyFluorescentBerryEffect : GlobalWall
    {
        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            if (Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.FluorescentBerry])
                return;

            if (Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentFluorescentBerry>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentHomewardJourneyFarming>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentHomewardJourney>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentEverything>()))
            {
                r = Utils.Clamp(r + 0.7f, 0f, 1f);
                g = Utils.Clamp(g + 0.7f, 0f, 1f);
                b = Utils.Clamp(b + 0.7f, 0f, 1f);
            }
        }
    }

    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class HomewardJourneyYinYangEffect : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentYin>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentHomewardJourneyFarming>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentHomewardJourney>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentEverything>()))
            {
                if (Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Yin])
                    return;

                spawnRate *= 10;
                maxSpawns /= 5;
            }
            if (Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentYang>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentHomewardJourneyFarming>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentHomewardJourney>()) || Main.LocalPlayer.HasItemInAnyInventory(ModContent.ItemType<PermanentEverything>()))
            {
                if (Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentHomewardJourneyBuffsBools[(int)PermanentBuffPlayer.PermanentHomewardJourneyBuffs.Yang])
                    return;

                spawnRate = (int)((float)spawnRate * 0.08f);
                maxSpawns = (int)((float)maxSpawns * 2.4f);
            }
        }
    }
}