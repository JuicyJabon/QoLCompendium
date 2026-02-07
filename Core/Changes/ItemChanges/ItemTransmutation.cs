namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class ItemTransmutation : GlobalItem
    {
        public override void SetStaticDefaults()
        {
            if (QoLCompendium.mainConfig.BossItemTransmutation)
            {
                //Vanilla
                #region Bosses
                //King Slime
                Common.TransmuteItems(new int[] { ItemID.NinjaHood, ItemID.NinjaShirt, ItemID.NinjaPants });

                //Queen Bee
                Common.TransmuteItems(new int[] { ItemID.BeeKeeper, ItemID.BeesKnees, ItemID.BeeGun });
                Common.TransmuteItems(new int[] { ItemID.BeeHat, ItemID.BeeShirt, ItemID.BeePants });

                //Deerclops
                Common.TransmuteItems(new int[] { ItemID.LucyTheAxe, ItemID.PewMaticHorn, ItemID.WeatherPain, ItemID.HoundiusShootius });

                //Wall of Flesh
                Common.TransmuteItems(new int[] { ItemID.BreakerBlade, ItemID.ClockworkAssaultRifle, ItemID.LaserRifle, ItemID.FireWhip });

                //Queen Slime
                Common.TransmuteItems(new int[] { ItemID.CrystalNinjaHelmet, ItemID.CrystalNinjaChestplate, ItemID.CrystalNinjaLeggings });

                //Plantera
                Common.TransmuteItems(new int[] { ItemID.Seedler, ItemID.FlowerPow, ItemID.GrenadeLauncher, ItemID.VenusMagnum, ItemID.NettleBurst, ItemID.LeafBlower, ItemID.WaspGun });

                //Golem
                Common.TransmuteItems(new int[] { ItemID.GolemFist, ItemID.PossessedHatchet, ItemID.Stynger, ItemID.HeatRay, ItemID.StaffofEarth, ItemID.SunStone, ItemID.EyeoftheGolem });

                //Duke Fishron
                Common.TransmuteItems(new int[] { ItemID.Flairon, ItemID.Tsunami, ItemID.RazorbladeTyphoon, ItemID.BubbleGun, ItemID.TempestStaff });

                //Empress of Light
                Common.TransmuteItems(new int[] { ItemID.PiercingStarlight, ItemID.FairyQueenRangedItem, ItemID.FairyQueenMagicItem, ItemID.RainbowWhip });

                //Moon Lord
                Common.TransmuteItems(new int[] { ItemID.Terrarian, ItemID.Meowmere, ItemID.StarWrath, ItemID.Celeb2, ItemID.SDMG, ItemID.LastPrism, ItemID.LunarFlareBook, ItemID.RainbowCrystalStaff, ItemID.MoonlordTurretStaff });
                #endregion

                #region Mini and Event Bosses
                //Ogre
                Common.TransmuteItems(new int[] { ItemID.DD2SquireDemonSword, ItemID.MonkStaffT1, ItemID.MonkStaffT2, ItemID.DD2PhoenixBow, ItemID.BookStaff });

                //Betsy
                Common.TransmuteItems(new int[] { ItemID.DD2SquireBetsySword, ItemID.MonkStaffT3, ItemID.DD2BetsyBow, ItemID.ApprenticeStaffT3 });

                //Mourning Wood
                Common.TransmuteItems(new int[] { ItemID.SpookyHook, ItemID.SpookyTwig, ItemID.StakeLauncher, ItemID.CursedSapling, ItemID.NecromanticScroll });

                //Pumpking
                Common.TransmuteItems(new int[] { ItemID.CandyCornRifle, ItemID.JackOLanternLauncher, ItemID.BlackFairyDust, ItemID.TheHorsemansBlade, ItemID.BatScepter, ItemID.RavenStaff, ItemID.ScytheWhip });

                //Everscream
                Common.TransmuteItems(new int[] { ItemID.ChristmasTreeSword, ItemID.ChristmasHook, ItemID.Razorpine, ItemID.FestiveWings });

                //Santa-NK1
                Common.TransmuteItems(new int[] { ItemID.ElfMelter, ItemID.ChainGun });

                //Ice Queen
                Common.TransmuteItems(new int[] { ItemID.NorthPole, ItemID.SnowmanCannon, ItemID.BlizzardStaff, ItemID.BabyGrinchMischiefWhistle });

                //Martian Saucer
                Common.TransmuteItems(new int[] { ItemID.InfluxWaver, ItemID.Xenopopper, ItemID.ElectrosphereLauncher, ItemID.LaserMachinegun, ItemID.XenoStaff, ItemID.CosmicCarKey });
                #endregion

                #region Enemies
                //Pre-HM Blood Moon
                Common.TransmuteItems(new int[] { ItemID.BloodRainBow, ItemID.VampireFrogStaff });

                //HM Blood Moon
                Common.TransmuteItems(new int[] { ItemID.SharpTears, ItemID.DripplerFlail });

                //Goblin Warlock
                Common.TransmuteItems(new int[] { ItemID.ShadowFlameKnife, ItemID.ShadowFlameBow, ItemID.ShadowFlameHexDoll });

                //Biome Chests
                Common.TransmuteItems(new int[] { ItemID.ScourgeoftheCorruptor, ItemID.VampireKnives });

                //Corruption Mimic Drops
                Common.TransmuteItems(new int[] { ItemID.DartRifle, ItemID.ClingerStaff, ItemID.ChainGuillotines, ItemID.PutridScent, ItemID.WormHook });

                //Crimson Mimic Drops
                Common.TransmuteItems(new int[] { ItemID.SoulDrain, ItemID.DartPistol, ItemID.FetidBaghnakhs, ItemID.FleshKnuckles, ItemID.TendonHook });

                //Hallowed Mimic Drops
                Common.TransmuteItems(new int[] { ItemID.DaedalusStormbow, ItemID.FlyingKnife, ItemID.CrystalVileShard, ItemID.IlluminantHook });
                #endregion

                #region Other
                Common.TransmuteItems(new int[] { ItemID.HelFire, ItemID.Cascade });

                Common.TransmuteItems(new int[] { ItemID.GladiatorHelmet, ItemID.GladiatorBreastplate, ItemID.GladiatorLeggings });
                #endregion

                //Calamity [WIP]
                if (CrossModSupport.Calamity.Loaded)
                {
                    #region Bosses

                    #endregion

                    #region Event Bosses

                    #endregion

                    #region Enemies

                    #endregion
                }

                //Thorium
                if (CrossModSupport.Thorium.Loaded)
                {
                    #region Bosses
                    //Grand Thunder Bird
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "Didgeridoo"), Common.GetModItem(CrossModSupport.Thorium.Mod, "StormHatchlingStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TalonBurst"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ThunderTalon") });

                    //Queen Jellyfish
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "BuccaneerBlunderBuss"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ConchShell"), Common.GetModItem(CrossModSupport.Thorium.Mod, "GiantGlowstick"), Common.GetModItem(CrossModSupport.Thorium.Mod, "JellyPondWand"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SparkingJellyBall") });

                    //Viscount
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "BatScythe"), Common.GetModItem(CrossModSupport.Thorium.Mod, "BatWing"), Common.GetModItem(CrossModSupport.Thorium.Mod, "GuanoGunner"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SonarCannon"), Common.GetModItem(CrossModSupport.Thorium.Mod, "VampireScepter"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ViscountCane") });

                    //Granite Energy Storm
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "BoulderProbeStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "EnergyProjector"), Common.GetModItem(CrossModSupport.Thorium.Mod, "EnergyStormBolter"), Common.GetModItem(CrossModSupport.Thorium.Mod, "EnergyStormPartisan"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ShockAbsorber") });

                    //Buried Champion
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "ChampionBomberStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ChampionsGodHand"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ChampionsRebuttal"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ChampionSwiftBlade"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ChampionsTrifectaShot") });

                    //Star Scouter
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "DistressCaller"), Common.GetModItem(CrossModSupport.Thorium.Mod, "GaussFlinger"), Common.GetModItem(CrossModSupport.Thorium.Mod, "HitScanner"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ParticleWhip"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Roboboe"), Common.GetModItem(CrossModSupport.Thorium.Mod, "StarRod"), Common.GetModItem(CrossModSupport.Thorium.Mod, "StarTrail") });

                    //Borean Strider
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "BoreanFangStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "FreezeRay"), Common.GetModItem(CrossModSupport.Thorium.Mod, "GlacialSting"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Glacier"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TheCryoFang") });

                    //Fallen Beholder
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "BeholderGaze"), Common.GetModItem(CrossModSupport.Thorium.Mod, "BeholderStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Cello"), Common.GetModItem(CrossModSupport.Thorium.Mod, "HellishHalberd"), Common.GetModItem(CrossModSupport.Thorium.Mod, "HellRoller"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Obliterator"), Common.GetModItem(CrossModSupport.Thorium.Mod, "PyroclastStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "VoidPlanter") });

                    //Lich
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "CadaverCornet"), Common.GetModItem(CrossModSupport.Thorium.Mod, "PhantomWand"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SoulCleaver"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SoulRender"), Common.GetModItem(CrossModSupport.Thorium.Mod, "WitherStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TheLostCross") });

                    //Forgotten One
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "MantisShrimpPunch"), Common.GetModItem(CrossModSupport.Thorium.Mod, "OldGodsVision"), Common.GetModItem(CrossModSupport.Thorium.Mod, "RlyehLostRod"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SirensLyre"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TheIncubator"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TrenchSpitter") });
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "WhisperingHood"), Common.GetModItem(CrossModSupport.Thorium.Mod, "WhisperingTabard"), Common.GetModItem(CrossModSupport.Thorium.Mod, "WhisperingLeggings") });

                    //The Primordials
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "DeathEssence"), Common.GetModItem(CrossModSupport.Thorium.Mod, "InfernoEssence"), Common.GetModItem(CrossModSupport.Thorium.Mod, "OceanEssence") });

                    //Lunatic Cultist
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "AncientFlame"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AncientFrost"), Common.GetModItem(CrossModSupport.Thorium.Mod, "AncientSpark"), Common.GetModItem(CrossModSupport.Thorium.Mod, "EclipseFang"), Common.GetModItem(CrossModSupport.Thorium.Mod, "CosmicFluxStaff") });
                    #endregion

                    #region Mini and Event Bosses
                    //Patch Werk
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "GraveBuster"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TheGoodBook") });

                    //Corpse Bloom
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "BloomGuard"), Common.GetModItem(CrossModSupport.Thorium.Mod, "WeedEater") });

                    //Illusionist
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "MageHand"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ScryingGlass") });

                    //Dark Mage
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "DarkMageStaff"), Common.GetModItem(CrossModSupport.Thorium.Mod, "DarkTome"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TabooWand") });

                    //Ogre
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "Hippocraticrossbow"), Common.GetModItem(CrossModSupport.Thorium.Mod, "OgreSnotGun"), Common.GetModItem(CrossModSupport.Thorium.Mod, "OgreSandal") });

                    //Flying Dutchman
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "TwentyFourCaratTuba"), Common.GetModItem(CrossModSupport.Thorium.Mod, "DutchmansAvarice"), Common.GetModItem(CrossModSupport.Thorium.Mod, "GreedfulGurdy"), Common.GetModItem(CrossModSupport.Thorium.Mod, "GreedyMagnet"), Common.GetModItem(CrossModSupport.Thorium.Mod, "HandCannon"), Common.GetModItem(CrossModSupport.Thorium.Mod, "ShipsHelm"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TheJuggernaut") });

                    //Martian Saucer
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "CosmicDagger"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Kinetoscythe"), Common.GetModItem(CrossModSupport.Thorium.Mod, "LivewireCrasher"), Common.GetModItem(CrossModSupport.Thorium.Mod, "MolecularStabilizer"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SuperPlasmaCannon"), Common.GetModItem(CrossModSupport.Thorium.Mod, "TheTriangle"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Turntable") });
                    #endregion

                    #region Enemies
                    //Hell Bringer Mimic
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "DevilDagger"), Common.GetModItem(CrossModSupport.Thorium.Mod, "DevilsReach"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Schmelze"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Scorn") });

                    //Mycelium Mimic
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "FungalCane"), Common.GetModItem(CrossModSupport.Thorium.Mod, "FungalHook"), Common.GetModItem(CrossModSupport.Thorium.Mod, "Funggat"), Common.GetModItem(CrossModSupport.Thorium.Mod, "MyceliumWhip") });

                    //Submerged Mimic
                    Common.TransmuteItems(new int[] { Common.GetModItem(CrossModSupport.Thorium.Mod, "HydromancerCatalyst"), Common.GetModItem(CrossModSupport.Thorium.Mod, "NeptuneGrasp"), Common.GetModItem(CrossModSupport.Thorium.Mod, "PoseidonCharge"), Common.GetModItem(CrossModSupport.Thorium.Mod, "SSDevastator") });
                    #endregion
                }
            }

            if (QoLCompendium.mainConfig.ItemConversions)
            {
                //Architect Gizmo Pack Accessories
                Common.TransmuteItems([ItemID.BrickLayer, ItemID.ExtendoGrip, ItemID.PaintSprayer, ItemID.PortableCementMixer]);

                //Toolbelt / Toolbox
                Common.TransmuteItems([ItemID.Toolbelt, ItemID.Toolbox]);

                //Bottomless Buckets
                Common.TransmuteItems([ItemID.BottomlessBucket, ItemID.BottomlessLavaBucket, ItemID.BottomlessHoneyBucket]);

                //Sponges
                Common.TransmuteItems([ItemID.SuperAbsorbantSponge, ItemID.LavaAbsorbantSponge, ItemID.HoneyAbsorbantSponge]);

                //Mimic
                //Common.TransmuteItems([ItemID.DualHook, ItemID.MagicDagger, ItemID.PhilosophersStone, ItemID.TitanGlove, ItemID.StarCloak, ItemID.CrossNecklace]);

                //Ice Mimic
                Common.TransmuteItems([ItemID.ToySled, ItemID.Frostbrand, ItemID.IceBow, ItemID.FlowerofFrost]);
            }
        }
    }
}
