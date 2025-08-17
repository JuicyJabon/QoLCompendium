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
                Common.TransmuteItems(new int[] { ItemID.CandyCornRifle, ItemID.JackOLanternLauncher, ItemID.BlackFairyDust, ItemID.TheHorsemansBlade, ItemID.BatScepter, ItemID.RavenStaff, ItemID.ScytheWhip, ItemID.SpiderEgg });

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
                if (ModConditions.calamityLoaded)
                {
                    #region Bosses

                    #endregion

                    #region Event Bosses

                    #endregion

                    #region Enemies

                    #endregion
                }

                //Thorium
                if (ModConditions.thoriumLoaded)
                {
                    #region Bosses
                    //Grand Thunder Bird
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "Didgeridoo"), Common.GetModItem(ModConditions.thoriumMod, "StormHatchlingStaff"), Common.GetModItem(ModConditions.thoriumMod, "TalonBurst"), Common.GetModItem(ModConditions.thoriumMod, "ThunderTalon") });

                    //Queen Jellyfish
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "BuccaneerBlunderBuss"), Common.GetModItem(ModConditions.thoriumMod, "ConchShell"), Common.GetModItem(ModConditions.thoriumMod, "GiantGlowstick"), Common.GetModItem(ModConditions.thoriumMod, "JellyPondWand"), Common.GetModItem(ModConditions.thoriumMod, "SparkingJellyBall") });

                    //Viscount
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "BatScythe"), Common.GetModItem(ModConditions.thoriumMod, "BatWing"), Common.GetModItem(ModConditions.thoriumMod, "GuanoGunner"), Common.GetModItem(ModConditions.thoriumMod, "SonarCannon"), Common.GetModItem(ModConditions.thoriumMod, "VampireScepter"), Common.GetModItem(ModConditions.thoriumMod, "ViscountCane") });

                    //Granite Energy Storm
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "BoulderProbeStaff"), Common.GetModItem(ModConditions.thoriumMod, "EnergyProjector"), Common.GetModItem(ModConditions.thoriumMod, "EnergyStormBolter"), Common.GetModItem(ModConditions.thoriumMod, "EnergyStormPartisan"), Common.GetModItem(ModConditions.thoriumMod, "ShockAbsorber") });

                    //Buried Champion
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "ChampionBomberStaff"), Common.GetModItem(ModConditions.thoriumMod, "ChampionsGodHand"), Common.GetModItem(ModConditions.thoriumMod, "ChampionsRebuttal"), Common.GetModItem(ModConditions.thoriumMod, "ChampionSwiftBlade"), Common.GetModItem(ModConditions.thoriumMod, "ChampionsTrifectaShot") });

                    //Star Scouter
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "DistressCaller"), Common.GetModItem(ModConditions.thoriumMod, "GaussFlinger"), Common.GetModItem(ModConditions.thoriumMod, "HitScanner"), Common.GetModItem(ModConditions.thoriumMod, "ParticleWhip"), Common.GetModItem(ModConditions.thoriumMod, "Roboboe"), Common.GetModItem(ModConditions.thoriumMod, "StarRod"), Common.GetModItem(ModConditions.thoriumMod, "StarTrail") });

                    //Borean Strider
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "BoreanFangStaff"), Common.GetModItem(ModConditions.thoriumMod, "FreezeRay"), Common.GetModItem(ModConditions.thoriumMod, "GlacialSting"), Common.GetModItem(ModConditions.thoriumMod, "Glacier"), Common.GetModItem(ModConditions.thoriumMod, "TheCryoFang") });

                    //Fallen Beholder
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "BeholderGaze"), Common.GetModItem(ModConditions.thoriumMod, "BeholderStaff"), Common.GetModItem(ModConditions.thoriumMod, "Cello"), Common.GetModItem(ModConditions.thoriumMod, "HellishHalberd"), Common.GetModItem(ModConditions.thoriumMod, "HellRoller"), Common.GetModItem(ModConditions.thoriumMod, "Obliterator"), Common.GetModItem(ModConditions.thoriumMod, "PyroclastStaff"), Common.GetModItem(ModConditions.thoriumMod, "VoidPlanter") });

                    //Lich
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "CadaverCornet"), Common.GetModItem(ModConditions.thoriumMod, "PhantomWand"), Common.GetModItem(ModConditions.thoriumMod, "SoulCleaver"), Common.GetModItem(ModConditions.thoriumMod, "SoulRender"), Common.GetModItem(ModConditions.thoriumMod, "WitherStaff"), Common.GetModItem(ModConditions.thoriumMod, "TheLostCross") });

                    //Forgotten One
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "MantisShrimpPunch"), Common.GetModItem(ModConditions.thoriumMod, "OldGodsVision"), Common.GetModItem(ModConditions.thoriumMod, "RlyehLostRod"), Common.GetModItem(ModConditions.thoriumMod, "SirensLyre"), Common.GetModItem(ModConditions.thoriumMod, "TheIncubator"), Common.GetModItem(ModConditions.thoriumMod, "TrenchSpitter") });
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "WhisperingHood"), Common.GetModItem(ModConditions.thoriumMod, "WhisperingTabard"), Common.GetModItem(ModConditions.thoriumMod, "WhisperingLeggings") });

                    //The Primordials
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "DeathEssence"), Common.GetModItem(ModConditions.thoriumMod, "InfernoEssence"), Common.GetModItem(ModConditions.thoriumMod, "OceanEssence") });

                    //Lunatic Cultist
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "AncientFlame"), Common.GetModItem(ModConditions.thoriumMod, "AncientFrost"), Common.GetModItem(ModConditions.thoriumMod, "AncientSpark"), Common.GetModItem(ModConditions.thoriumMod, "EclipseFang"), Common.GetModItem(ModConditions.thoriumMod, "CosmicFluxStaff") });
                    #endregion

                    #region Mini and Event Bosses
                    //Patch Werk
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "GraveBuster"), Common.GetModItem(ModConditions.thoriumMod, "TheGoodBook") });

                    //Corpse Bloom
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "BloomGuard"), Common.GetModItem(ModConditions.thoriumMod, "WeedEater") });

                    //Illusionist
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "MageHand"), Common.GetModItem(ModConditions.thoriumMod, "ScryingGlass") });

                    //Dark Mage
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "DarkMageStaff"), Common.GetModItem(ModConditions.thoriumMod, "DarkTome"), Common.GetModItem(ModConditions.thoriumMod, "TabooWand") });

                    //Ogre
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "Hippocraticrossbow"), Common.GetModItem(ModConditions.thoriumMod, "OgreSnotGun"), Common.GetModItem(ModConditions.thoriumMod, "OgreSandal") });

                    //Flying Dutchman
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "TwentyFourCaratTuba"), Common.GetModItem(ModConditions.thoriumMod, "DutchmansAvarice"), Common.GetModItem(ModConditions.thoriumMod, "GreedfulGurdy"), Common.GetModItem(ModConditions.thoriumMod, "GreedyMagnet"), Common.GetModItem(ModConditions.thoriumMod, "HandCannon"), Common.GetModItem(ModConditions.thoriumMod, "ShipsHelm"), Common.GetModItem(ModConditions.thoriumMod, "TheJuggernaut") });

                    //Martian Saucer
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "CosmicDagger"), Common.GetModItem(ModConditions.thoriumMod, "Kinetoscythe"), Common.GetModItem(ModConditions.thoriumMod, "LivewireCrasher"), Common.GetModItem(ModConditions.thoriumMod, "MolecularStabilizer"), Common.GetModItem(ModConditions.thoriumMod, "SuperPlasmaCannon"), Common.GetModItem(ModConditions.thoriumMod, "TheTriangle"), Common.GetModItem(ModConditions.thoriumMod, "Turntable") });
                    #endregion

                    #region Enemies
                    //Hell Bringer Mimic
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "DevilDagger"), Common.GetModItem(ModConditions.thoriumMod, "DevilsReach"), Common.GetModItem(ModConditions.thoriumMod, "Schmelze"), Common.GetModItem(ModConditions.thoriumMod, "Scorn") });

                    //Mycelium Mimic
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "FungalCane"), Common.GetModItem(ModConditions.thoriumMod, "FungalHook"), Common.GetModItem(ModConditions.thoriumMod, "Funggat"), Common.GetModItem(ModConditions.thoriumMod, "MyceliumWhip") });

                    //Submerged Mimic
                    Common.TransmuteItems(new int[] { Common.GetModItem(ModConditions.thoriumMod, "HydromancerCatalyst"), Common.GetModItem(ModConditions.thoriumMod, "NeptuneGrasp"), Common.GetModItem(ModConditions.thoriumMod, "PoseidonCharge"), Common.GetModItem(ModConditions.thoriumMod, "SSDevastator") });
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
            }
        }
    }
}
