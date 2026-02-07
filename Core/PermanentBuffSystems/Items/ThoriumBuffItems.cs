using ThoriumMod.Buffs;
using ThoriumMod.Buffs.Bard;
using ThoriumMod.Buffs.Healer;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Consumable;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Donate;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Placeable;
using ThoriumMod.Items.ThrownItems;
using ThoriumRework;
using ThoriumRework.Buffs;
using ThoriumRework.Items;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.Thorium.Name)]
    [ExtendsFromMod(CrossModSupport.Thorium.Name)]
    public static class ThoriumBuffItems
    {
        public static NewBuffEffect[] ThoriumEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<AquaAffinity>()),
            new NewBuffEffect(ModContent.BuffType<ArcanePotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<ArtilleryBuff>()),
            new NewBuffEffect(ModContent.BuffType<AssassinPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<BloodRush>()),
            new NewBuffEffect(ModContent.BuffType<BouncingFlamePotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<CactusFruitBuff>()),
            new NewBuffEffect(ModContent.BuffType<ConflagrationPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<CreativityPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<EarwormPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<FrenzyPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<GlowingPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<HolyPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<HydrationBuff>()),
            new NewBuffEffect(ModContent.BuffType<InspirationReachPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<KineticPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<WarmongerBuff>()),
            //repellents
            new NewBuffEffect(ModContent.BuffType<BatRepellentBuff>(), (int) Common.EffectTypes.Repellent),
            new NewBuffEffect(ModContent.BuffType<FishRepellentBuff>(), (int) Common.EffectTypes.Repellent),
            new NewBuffEffect(ModContent.BuffType<InsectRepellentBuff>(), (int) Common.EffectTypes.Repellent),
            new NewBuffEffect(ModContent.BuffType<SkeletonRepellentBuff>(), (int) Common.EffectTypes.Repellent),
            new NewBuffEffect(ModContent.BuffType<ZombieRepellentBuff>(), (int) Common.EffectTypes.Repellent),
            //arena
            new NewBuffEffect(ModContent.BuffType<MistletoeBuff>(), (int) Common.EffectTypes.Arena),
            //stations
            new NewBuffEffect(ModContent.BuffType<AltarBuff>(), (int) Common.EffectTypes.Station),
            new NewBuffEffect(ModContent.BuffType<ConductorsStandBuff>(), (int) Common.EffectTypes.Station),
            new NewBuffEffect(ModContent.BuffType<NinjaBuff>(), (int) Common.EffectTypes.Station),
            //coatings
            new NewBuffEffect(ModContent.BuffType<DeepFreezeCoatingBuff>(), (int) Common.EffectTypes.Coating),
            new NewBuffEffect(ModContent.BuffType<ExplosiveCoatingBuff>(), (int) Common.EffectTypes.Coating),
            new NewBuffEffect(ModContent.BuffType<GorgonCoatingBuff>(), (int) Common.EffectTypes.Coating),
            new NewBuffEffect(ModContent.BuffType<SporeCoatingBuff>(), (int) Common.EffectTypes.Coating),
            new NewBuffEffect(ModContent.BuffType<ToxicCoatingBuff>(), (int) Common.EffectTypes.Coating)
        ];

        public static void LoadTasks()
        {
            BaseItems();
            if (CrossModSupport.ThoriumHelheim.Loaded)
                ThoriumBossReworkBuffItems.LoadTasks();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in ThoriumEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<Mistletoe>(), ModContent.BuffType<MistletoeBuff>(), Common.AllEffects[ModContent.BuffType<MistletoeBuff>()], 3, "PermanentMistletoe", "Permanent Mistletoe"),
                new NewBuffItem(ModContent.ItemType<DeepFreezeCoatingItem>(), ModContent.BuffType<DeepFreezeCoatingBuff>(), Common.AllEffects[ModContent.BuffType<DeepFreezeCoatingBuff>()], 30, "PermanentDeepFreezeCoating", "Permanent Deep Freeze Coating"),
                new NewBuffItem(ModContent.ItemType<ExplosiveCoatingItem>(), ModContent.BuffType<ExplosiveCoatingBuff>(), Common.AllEffects[ModContent.BuffType<ExplosiveCoatingBuff>()], 30, "PermanentExplosiveCoating", "Permanent Explosive Coating"),
                new NewBuffItem(ModContent.ItemType<GorgonCoatingItem>(), ModContent.BuffType<GorgonCoatingBuff>(), Common.AllEffects[ModContent.BuffType<GorgonCoatingBuff>()], 30, "PermanentGorgonCoating", "Permanent Gorgon Coating"),
                new NewBuffItem(ModContent.ItemType<SporeCoatingItem>(), ModContent.BuffType<SporeCoatingBuff>(), Common.AllEffects[ModContent.BuffType<SporeCoatingBuff>()], 30, "PermanentSporeCoating", "Permanent Spore Coating"),
                new NewBuffItem(ModContent.ItemType<ToxicCoatingItem>(), ModContent.BuffType<ToxicCoatingBuff>(), Common.AllEffects[ModContent.BuffType<ToxicCoatingBuff>()], 30, "PermanentToxicCoating", "Permanent Toxic Coating"),
                new NewBuffItem(ModContent.ItemType<AquaPotion>(), ModContent.BuffType<AquaAffinity>(), Common.AllEffects[ModContent.BuffType<AquaAffinity>()], 30, "PermanentAquaAffinity", "Permanent Aqua Affinity"),
                new NewBuffItem(ModContent.ItemType<ArcanePotion>(), ModContent.BuffType<ArcanePotionBuff>(), Common.AllEffects[ModContent.BuffType<ArcanePotionBuff>()], 30, "PermanentArcane", "Permanent Arcane"),
                new NewBuffItem(ModContent.ItemType<ArtilleryPotion>(), ModContent.BuffType<ArtilleryBuff>(), Common.AllEffects[ModContent.BuffType<ArtilleryBuff>()], 30, "PermanentArtillery", "Permanent Artillery"),
                new NewBuffItem(ModContent.ItemType<AssassinPotion>(), ModContent.BuffType<AssassinPotionBuff>(), Common.AllEffects[ModContent.BuffType<AssassinPotionBuff>()], 30, "PermanentAssassin", "Permanent Assassin"),
                new NewBuffItem(ModContent.ItemType<BatRepellent>(), ModContent.BuffType<BatRepellentBuff>(), Common.AllEffects[ModContent.BuffType<BatRepellentBuff>()], 30, "PermanentBatRepellent", "Permanent Bat Repellent"),
                new NewBuffItem(ModContent.ItemType<BloodPotion>(), ModContent.BuffType<BloodRush>(), Common.AllEffects[ModContent.BuffType<BloodRush>()], 30, "PermanentBloodRush", "Permanent Blood Rush"),
                new NewBuffItem(ModContent.ItemType<BouncingFlamePotion>(), ModContent.BuffType<BouncingFlamePotionBuff>(), Common.AllEffects[ModContent.BuffType<BouncingFlamePotionBuff>()], 30, "PermanentBouncingFlames", "Permanent Bouncing Flames"),
                new NewBuffItem(ModContent.ItemType<CactusFruit>(), ModContent.BuffType<CactusFruitBuff>(), Common.AllEffects[ModContent.BuffType<CactusFruitBuff>()], 30, "PermanentCactusFruit", "Permanent Cactus Fruit"),
                new NewBuffItem(ModContent.ItemType<ConflagrationPotion>(), ModContent.BuffType<ConflagrationPotionBuff>(), Common.AllEffects[ModContent.BuffType<ConflagrationPotionBuff>()], 30, "PermanentConflagration", "Permanent Conflagration"),
                new NewBuffItem(ModContent.ItemType<CreativityPotion>(), ModContent.BuffType<CreativityPotionBuff>(), Common.AllEffects[ModContent.BuffType<CreativityPotionBuff>()], 30, "PermanentCreativity", "Permanent Creativity"),
                new NewBuffItem(ModContent.ItemType<EarwormPotion>(), ModContent.BuffType<EarwormPotionBuff>(), Common.AllEffects[ModContent.BuffType<EarwormPotionBuff>()], 30, "PermanentEarworm", "Permanent Earworm"),
                new NewBuffItem(ModContent.ItemType<FishRepellent>(), ModContent.BuffType<FishRepellentBuff>(), Common.AllEffects[ModContent.BuffType<FishRepellentBuff>()], 30, "PermanentFishRepellent", "Permanent Fish Repellent"),
                new NewBuffItem(ModContent.ItemType<FrenzyPotion>(), ModContent.BuffType<FrenzyPotionBuff>(), Common.AllEffects[ModContent.BuffType<FrenzyPotionBuff>()], 30, "PermanentFrenzy", "Permanent Frenzy"),
                new NewBuffItem(ModContent.ItemType<GlowingPotion>(), ModContent.BuffType<GlowingPotionBuff>(), Common.AllEffects[ModContent.BuffType<GlowingPotionBuff>()], 30, "PermanentGlowing", "Permanent Glowing"),
                new NewBuffItem(ModContent.ItemType<HolyPotion>(), ModContent.BuffType<HolyPotionBuff>(), Common.AllEffects[ModContent.BuffType<HolyPotionBuff>()], 30, "PermanentHoly", "Permanent Holy"),
                new NewBuffItem(ModContent.ItemType<HydrationPotion>(), ModContent.BuffType<HydrationBuff>(), Common.AllEffects[ModContent.BuffType<HydrationBuff>()], 30, "PermanentHydration", "Permanent Hydration"),
                new NewBuffItem(ModContent.ItemType<InsectRepellent>(), ModContent.BuffType<InsectRepellentBuff>(), Common.AllEffects[ModContent.BuffType<InsectRepellentBuff>()], 30, "PermanentInsectRepellent", "Permanent Insect Repellent"),
                new NewBuffItem(ModContent.ItemType<InspirationReachPotion>(), ModContent.BuffType<InspirationReachPotionBuff>(), Common.AllEffects[ModContent.BuffType<InspirationReachPotionBuff>()], 30, "PermanentInspirationalReach", "Permanent Inspirational Reach"),
                new NewBuffItem(ModContent.ItemType<KineticPotion>(), ModContent.BuffType<KineticPotionBuff>(), Common.AllEffects[ModContent.BuffType<KineticPotionBuff>()], 30, "PermanentKinetic", "Permanent Kinetic"),
                new NewBuffItem(ModContent.ItemType<SkeletonRepellent>(), ModContent.BuffType<SkeletonRepellentBuff>(), Common.AllEffects[ModContent.BuffType<SkeletonRepellentBuff>()], 30, "PermanentSkeletonRepellent", "Permanent Skeleton Repellent"),
                new NewBuffItem(ModContent.ItemType<WarmongerPotion>(), ModContent.BuffType<WarmongerBuff>(), Common.AllEffects[ModContent.BuffType<WarmongerBuff>()], 30, "PermanentWarmonger", "Permanent Warmonger"),
                new NewBuffItem(ModContent.ItemType<ZombieRepellent>(), ModContent.BuffType<ZombieRepellentBuff>(), Common.AllEffects[ModContent.BuffType<ZombieRepellentBuff>()], 30, "PermanentZombieRepellent", "Permanent Zombie Repellent"),
                new NewBuffItem(ModContent.ItemType<Altar>(), ModContent.BuffType<AltarBuff>(), Common.AllEffects[ModContent.BuffType<AltarBuff>()], 3, "PermanentAltar", "Permanent Altar"),
                new NewBuffItem(ModContent.ItemType<ConductorsStand>(), ModContent.BuffType<ConductorsStandBuff>(), Common.AllEffects[ModContent.BuffType<ConductorsStandBuff>()], 3, "PermanentConductorsStand", "Permanent Conductor's Stand"),
                new NewBuffItem(ModContent.ItemType<NinjaRack>(), ModContent.BuffType<NinjaBuff>(), Common.AllEffects[ModContent.BuffType<NinjaBuff>()], 3, "PermanentNinjaRack", "Permanent Ninja Rack")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentThoriumBard = new()
            {
                { Common.AllEffects[ModContent.BuffType<CreativityPotionBuff>()], ModContent.BuffType<CreativityPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<EarwormPotionBuff>()], ModContent.BuffType<EarwormPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<InspirationReachPotionBuff>()], ModContent.BuffType<InspirationReachPotionBuff>() }
            };

            if (CrossModSupport.ThoriumHelheim.Loaded)
            {
                if (ThoriumBossReworkBuffItems.ConfigOn)
                {
                    PermanentThoriumBard.Add(Common.AllEffects[ThoriumBossReworkBuffItems.DeathsingerID], ThoriumBossReworkBuffItems.DeathsingerID);
                    PermanentThoriumBard.Add(Common.AllEffects[ThoriumBossReworkBuffItems.InspiredID], ThoriumBossReworkBuffItems.InspiredID);
                }
            }

            Dictionary<BuffEffect, int> PermanentThoriumHealer = new()
            {
                { Common.AllEffects[ModContent.BuffType<ArcanePotionBuff>()], ModContent.BuffType<ArcanePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<GlowingPotionBuff>()], ModContent.BuffType<GlowingPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<HolyPotionBuff>()], ModContent.BuffType<HolyPotionBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThoriumThrower = new()
            {
                { Common.AllEffects[ModContent.BuffType<AssassinPotionBuff>()], ModContent.BuffType<AssassinPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<HydrationBuff>()], ModContent.BuffType<HydrationBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThoriumDamage = new()
            {
                { Common.AllEffects[ModContent.BuffType<ArtilleryBuff>()], ModContent.BuffType<ArtilleryBuff>() },
                { Common.AllEffects[ModContent.BuffType<BouncingFlamePotionBuff>()], ModContent.BuffType<BouncingFlamePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<CactusFruitBuff>()], ModContent.BuffType<CactusFruitBuff>() },
                { Common.AllEffects[ModContent.BuffType<ConflagrationPotionBuff>()], ModContent.BuffType<ConflagrationPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FrenzyPotionBuff>()], ModContent.BuffType<FrenzyPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<WarmongerBuff>()], ModContent.BuffType<WarmongerBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThoriumMovement = new()
            {
                { Common.AllEffects[ModContent.BuffType<AquaAffinity>()], ModContent.BuffType<AquaAffinity>() },
                { Common.AllEffects[ModContent.BuffType<BloodRush>()], ModContent.BuffType<BloodRush>() },
                { Common.AllEffects[ModContent.BuffType<KineticPotionBuff>()], ModContent.BuffType<KineticPotionBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThoriumRepellent = new()
            {
                { Common.AllEffects[ModContent.BuffType<BatRepellentBuff>()], ModContent.BuffType<BatRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<FishRepellentBuff>()], ModContent.BuffType<FishRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<InsectRepellentBuff>()], ModContent.BuffType<InsectRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<SkeletonRepellentBuff>()], ModContent.BuffType<SkeletonRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<ZombieRepellentBuff>()], ModContent.BuffType<ZombieRepellentBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThoriumStations = new()
            {
                { Common.AllEffects[ModContent.BuffType<MistletoeBuff>()], ModContent.BuffType<MistletoeBuff>() },
                { Common.AllEffects[ModContent.BuffType<AltarBuff>()], ModContent.BuffType<AltarBuff>() },
                { Common.AllEffects[ModContent.BuffType<ConductorsStandBuff>()], ModContent.BuffType<ConductorsStandBuff>() },
                { Common.AllEffects[ModContent.BuffType<NinjaBuff>()], ModContent.BuffType<NinjaBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThoriumCoatings = new()
            {
                { Common.AllEffects[ModContent.BuffType<DeepFreezeCoatingBuff>()], ModContent.BuffType<DeepFreezeCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<ExplosiveCoatingBuff>()], ModContent.BuffType<ExplosiveCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<GorgonCoatingBuff>()], ModContent.BuffType<GorgonCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<SporeCoatingBuff>()], ModContent.BuffType<SporeCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<ToxicCoatingBuff>()], ModContent.BuffType<ToxicCoatingBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentThorium = new()
            {
                { Common.AllEffects[ModContent.BuffType<CreativityPotionBuff>()], ModContent.BuffType<CreativityPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<EarwormPotionBuff>()], ModContent.BuffType<EarwormPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<InspirationReachPotionBuff>()], ModContent.BuffType<InspirationReachPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<ArcanePotionBuff>()], ModContent.BuffType<ArcanePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<GlowingPotionBuff>()], ModContent.BuffType<GlowingPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<HolyPotionBuff>()], ModContent.BuffType<HolyPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<AssassinPotionBuff>()], ModContent.BuffType<AssassinPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<HydrationBuff>()], ModContent.BuffType<HydrationBuff>() },
                { Common.AllEffects[ModContent.BuffType<ArtilleryBuff>()], ModContent.BuffType<ArtilleryBuff>() },
                { Common.AllEffects[ModContent.BuffType<BouncingFlamePotionBuff>()], ModContent.BuffType<BouncingFlamePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<CactusFruitBuff>()], ModContent.BuffType<CactusFruitBuff>() },
                { Common.AllEffects[ModContent.BuffType<ConflagrationPotionBuff>()], ModContent.BuffType<ConflagrationPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FrenzyPotionBuff>()], ModContent.BuffType<FrenzyPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<WarmongerBuff>()], ModContent.BuffType<WarmongerBuff>() },
                { Common.AllEffects[ModContent.BuffType<AquaAffinity>()], ModContent.BuffType<AquaAffinity>() },
                { Common.AllEffects[ModContent.BuffType<BloodRush>()], ModContent.BuffType<BloodRush>() },
                { Common.AllEffects[ModContent.BuffType<KineticPotionBuff>()], ModContent.BuffType<KineticPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<BatRepellentBuff>()], ModContent.BuffType<BatRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<FishRepellentBuff>()], ModContent.BuffType<FishRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<InsectRepellentBuff>()], ModContent.BuffType<InsectRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<SkeletonRepellentBuff>()], ModContent.BuffType<SkeletonRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<ZombieRepellentBuff>()], ModContent.BuffType<ZombieRepellentBuff>() },
                { Common.AllEffects[ModContent.BuffType<MistletoeBuff>()], ModContent.BuffType<MistletoeBuff>() },
                { Common.AllEffects[ModContent.BuffType<AltarBuff>()], ModContent.BuffType<AltarBuff>() },
                { Common.AllEffects[ModContent.BuffType<ConductorsStandBuff>()], ModContent.BuffType<ConductorsStandBuff>() },
                { Common.AllEffects[ModContent.BuffType<NinjaBuff>()], ModContent.BuffType<NinjaBuff>() },
                { Common.AllEffects[ModContent.BuffType<DeepFreezeCoatingBuff>()], ModContent.BuffType<DeepFreezeCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<ExplosiveCoatingBuff>()], ModContent.BuffType<ExplosiveCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<GorgonCoatingBuff>()], ModContent.BuffType<GorgonCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<SporeCoatingBuff>()], ModContent.BuffType<SporeCoatingBuff>() },
                { Common.AllEffects[ModContent.BuffType<ToxicCoatingBuff>()], ModContent.BuffType<ToxicCoatingBuff>() }
            };

            if (CrossModSupport.ThoriumHelheim.Loaded)
            {
                if (ThoriumBossReworkBuffItems.ConfigOn)
                {
                    PermanentThorium.Add(Common.AllEffects[ThoriumBossReworkBuffItems.DeathsingerID], ThoriumBossReworkBuffItems.DeathsingerID);
                    PermanentThorium.Add(Common.AllEffects[ThoriumBossReworkBuffItems.InspiredID], ThoriumBossReworkBuffItems.InspiredID);
                }
            }

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentThoriumBard, "PermanentThoriumBard", "Permanent Thorium Bard", "PermanentThoriumBard"),
                new NewCombinedBuffItem(PermanentThoriumHealer, "PermanentThoriumHealer", "Permanent Thorium Healer", "PermanentThoriumHealer"),
                new NewCombinedBuffItem(PermanentThoriumThrower, "PermanentThoriumThrower", "Permanent Thorium Thrower", "PermanentThoriumThrower"),
                new NewCombinedBuffItem(PermanentThoriumDamage, "PermanentThoriumDamage", "Permanent Thorium Damage", "PermanentThoriumDamage"),
                new NewCombinedBuffItem(PermanentThoriumMovement, "PermanentThoriumMovement", "Permanent Thorium Movement", "PermanentThoriumMovement"),
                new NewCombinedBuffItem(PermanentThoriumRepellent, "PermanentThoriumRepellent", "Permanent Thorium Repellent", "PermanentThoriumRepellent"),
                new NewCombinedBuffItem(PermanentThoriumStations, "PermanentThoriumStations", "Permanent Thorium Stations", "PermanentThoriumStations"),
                new NewCombinedBuffItem(PermanentThoriumCoatings, "PermanentThoriumCoatings", "Permanent Thorium Coatings", "PermanentThoriumCoatings"),
                new NewCombinedBuffItem(PermanentThorium, "PermanentThorium", "Permanent Thorium", "PermanentThorium")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.ThoriumHelheim.Name)]
    [ExtendsFromMod(CrossModSupport.ThoriumHelheim.Name)]
    public static class ThoriumBossReworkBuffItems
    {
        public static NewBuffEffect[] ThoriumBossReworkEffects = [];

        public static int DeathsingerID = -1;
        public static int InspiredID = -1;

        public static bool ConfigOn = ModContent.GetInstance<CompatConfig>().extraPotions;

        public static void LoadTasks()
        {
            if (!ConfigOn)
                return;

            DeathsingerID = ModContent.BuffType<Deathsinger>();
            InspiredID = ModContent.BuffType<Inspired>();

            ThoriumBossReworkEffects = [
                //potions
                new NewBuffEffect(ModContent.BuffType<Deathsinger>()),
                new NewBuffEffect(ModContent.BuffType<Inspired>())
            ];

            foreach (var newEffect in ThoriumBossReworkEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                new NewBuffItem(ModContent.ItemType<DeathsingerPotion>(), ModContent.BuffType<Deathsinger>(), Common.AllEffects[ModContent.BuffType<Deathsinger>()], 30, "PermanentDeathsinger", "Permanent Deathsinger"),
                new NewBuffItem(ModContent.ItemType<InspirationRegenerationPotion>(), ModContent.BuffType<Inspired>(), Common.AllEffects[ModContent.BuffType<Inspired>()], 30, "PermanentInspirationRegeneration", "Permanent Inspiration Regeneration")
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
