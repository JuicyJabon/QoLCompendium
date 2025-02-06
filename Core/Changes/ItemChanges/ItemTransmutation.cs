namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class ItemTransmutation : GlobalItem
    {
        public override void SetDefaults(Item item)
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

                #region Event Bosses
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

                //Pre-HM Blood Moon
                Common.TransmuteItems(new int[] { ItemID.BloodRainBow, ItemID.VampireFrogStaff });

                //HM Blood Moon
                Common.TransmuteItems(new int[] { ItemID.SharpTears, ItemID.DripplerFlail });

                //Goblin Warlock
                Common.TransmuteItems(new int[] { ItemID.ShadowFlameKnife, ItemID.ShadowFlameBow, ItemID.ShadowFlameHexDoll });

                //Biome Chests
                Common.TransmuteItems(new int[] { ItemID.ScourgeoftheCorruptor, ItemID.VampireKnives });

                //Corruption Mimic Drops
                Common.TransmuteItems(new int[] { ItemID.DartRifle, ItemID.ClingerStaff, ItemID.ChainGuillotines, ItemID.PutridScent, ItemID.WormHook, ItemID.DartRifle });

                //Crimson Mimic Drops
                Common.TransmuteItems(new int[] { ItemID.SoulDrain, ItemID.DartPistol, ItemID.FetidBaghnakhs, ItemID.FleshKnuckles, ItemID.TendonHook, ItemID.SoulDrain });

                //Hallowed Mimic Drops
                Common.TransmuteItems(new int[] { ItemID.DaedalusStormbow, ItemID.FlyingKnife, ItemID.CrystalVileShard, ItemID.IlluminantHook });
                #endregion
            }
        }
    }
}
