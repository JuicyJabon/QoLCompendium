namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class ThoriumBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Thorium.Loaded)
                return;

            BaseItems();
            if (CrossModSupport.ThoriumHelheim.Loaded)
                ThoriumBossReworkBuffItems.LoadTasks();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] ThoriumEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "AquaAffinity")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ArcanePotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ArtilleryBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "AssassinPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "BloodRush")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "BouncingFlamePotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "CactusFruitBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ConflagrationPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "CreativityPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "EarwormPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "FrenzyPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "GlowingPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "HolyPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "HydrationBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "InspirationReachPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "KineticPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "WarmongerBuff")),
            //repellents
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "BatRepellentBuff"), (int) Constants.EffectTypes.Repellent),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "FishRepellentBuff"), (int) Constants.EffectTypes.Repellent),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "InsectRepellentBuff"), (int) Constants.EffectTypes.Repellent),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "SkeletonRepellentBuff"), (int) Constants.EffectTypes.Repellent),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ZombieRepellentBuff"), (int) Constants.EffectTypes.Repellent),
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "MistletoeBuff"), (int) Constants.EffectTypes.Arena),
            //stations
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "AltarBuff"), (int) Constants.EffectTypes.Station),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ConductorsStandBuff"), (int) Constants.EffectTypes.Station),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "NinjaBuff"), (int) Constants.EffectTypes.Station),
            //coatings
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "DeepFreezeCoatingBuff"), (int) Constants.EffectTypes.Coating),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ExplosiveCoatingBuff"), (int) Constants.EffectTypes.Coating),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "GorgonCoatingBuff"), (int) Constants.EffectTypes.Coating),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "SporeCoatingBuff"), (int) Constants.EffectTypes.Coating),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Thorium.Mod, "ToxicCoatingBuff"), (int) Constants.EffectTypes.Coating)
            ];

            foreach (var newEffect in ThoriumEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "Mistletoe"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "MistletoeBuff")], 3, "PermanentMistletoe"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "DeepFreezeCoatingItem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "DeepFreezeCoatingBuff")], 30, "PermanentDeepFreezeCoating"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ExplosiveCoatingItem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ExplosiveCoatingBuff")], 30, "PermanentExplosiveCoating"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "GorgonCoatingItem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "GorgonCoatingBuff")], 30, "PermanentGorgonCoating"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "SporeCoatingItem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "SporeCoatingBuff")], 30, "PermanentSporeCoating"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ToxicCoatingItem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ToxicCoatingBuff")], 30, "PermanentToxicCoating"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "AquaPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "AquaAffinity")], 30, "PermanentAquaAffinity"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ArcanePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ArcanePotionBuff")], 30, "PermanentArcane"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ArtilleryPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ArtilleryBuff")], 30, "PermanentArtillery"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "AssassinPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "AssassinPotionBuff")], 30, "PermanentAssassin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "BatRepellent"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "BatRepellentBuff")], 3, "PermanentBatRepellent"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "BloodPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "BloodRush")], 30, "PermanentBloodRush"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "BouncingFlamePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "BouncingFlamePotionBuff")], 30, "PermanentBouncingFlames"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "CactusFruit"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "CactusFruitBuff")], 30, "PermanentCactusFruit"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ConflagrationPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ConflagrationPotionBuff")], 30, "PermanentConflagration"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "CreativityPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "CreativityPotionBuff")], 30, "PermanentCreativity"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "EarwormPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "EarwormPotionBuff")], 30, "PermanentEarworm"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "FishRepellent"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "FishRepellentBuff")], 3, "PermanentFishRepellent"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "FrenzyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "FrenzyPotionBuff")], 30, "PermanentFrenzy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "GlowingPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "GlowingPotionBuff")], 30, "PermanentGlowing"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "HolyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "HolyPotionBuff")], 30, "PermanentHoly"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "HydrationPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "HydrationBuff")], 30, "PermanentHydration"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "InsectRepellent"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "InsectRepellentBuff")], 3, "PermanentInsectRepellent"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "InspirationReachPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "InspirationReachPotionBuff")], 30, "PermanentInspirationalReach"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "KineticPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "KineticPotionBuff")], 30, "PermanentKinetic"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "SkeletonRepellent"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "SkeletonRepellentBuff")], 3, "PermanentSkeletonRepellent"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "WarmongerPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "WarmongerBuff")], 30, "PermanentWarmonger"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ZombieRepellent"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ZombieRepellentBuff")], 3, "PermanentZombieRepellent"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "Altar"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "AltarBuff")], 3, "PermanentAltar"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "ConductorsStand"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ConductorsStandBuff")], 3, "PermanentConductorsStand"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Thorium.Mod, "NinjaRack"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "NinjaBuff")], 3, "PermanentNinjaRack")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentThoriumBard =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "CreativityPotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "EarwormPotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "InspirationReachPotionBuff")]
            ];
            List<int> PermanentThoriumBardIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCreativity"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEarworm"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentInspirationalReach")];
            if (CrossModSupport.ThoriumHelheim.Loaded)
            {
                PermanentThoriumBard.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.ThoriumHelheim.Mod, "Deathsinger")]);
                PermanentThoriumBard.Add(Constants.AllEffects[Common.GetModBuff(CrossModSupport.ThoriumHelheim.Mod, "Inspired")]);
                PermanentThoriumBardIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentDeathsinger"));
                PermanentThoriumBardIngredients.Add(Common.GetModItem(QoLCompendium.Instance, "PermanentInspirationRegeneration"));
            }

            List<BuffEffect> PermanentThoriumHealer =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ArcanePotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "GlowingPotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "HolyPotionBuff")]
            ];
            List<int> PermanentThoriumHealerIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentArcane"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGlowing"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHoly")];

            List<BuffEffect> PermanentThoriumThrower =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "AssassinPotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "HydrationBuff")]
            ];
            List<int> PermanentThoriumThrowerIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAssassin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHydration")];

            List<BuffEffect> PermanentThoriumDamage =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ArtilleryBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "BouncingFlamePotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "CactusFruitBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ConflagrationPotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "FrenzyPotionBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "WarmongerBuff")]
            ];
            List<int> PermanentThoriumDamageIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentArtillery"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBouncingFlames"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCactusFruit"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentConflagration"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFrenzy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWarmonger")];

            List<BuffEffect> PermanentThoriumMovement =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "AquaAffinity")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "BloodRush")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "KineticPotionBuff")]
            ];
            List<int> PermanentThoriumMovementIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAquaAffinity"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBloodRush"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentKinetic")];

            List<BuffEffect> PermanentThoriumRepellent =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "BatRepellentBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "FishRepellentBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "InsectRepellentBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "SkeletonRepellentBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ZombieRepellentBuff")]
            ];
            List<int> PermanentThoriumRepellentIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBatRepellent"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFishRepellent"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentInsectRepellent"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSkeletonRepellent"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZombieRepellent")];

            List<BuffEffect> PermanentThoriumStations =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "MistletoeBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "AltarBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ConductorsStandBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "NinjaBuff")]
            ];
            List<int> PermanentThoriumStationsIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMistletoe"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentAltar"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentConductorsStand"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentNinjaRack")];

            List<BuffEffect> PermanentThoriumCoatings =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "DeepFreezeCoatingBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ExplosiveCoatingBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "GorgonCoatingBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "SporeCoatingBuff")],
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.Thorium.Mod, "ToxicCoatingBuff")]
            ];
            List<int> PermanentThoriumCoatingsIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDeepFreezeCoating"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentExplosiveCoating"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGorgonCoating"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSporeCoating"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentToxicCoating")];

            List<BuffEffect> PermanentThorium = [];
            PermanentThorium.AddRange(PermanentThoriumBard);
            PermanentThorium.AddRange(PermanentThoriumHealer);
            PermanentThorium.AddRange(PermanentThoriumThrower);
            PermanentThorium.AddRange(PermanentThoriumDamage);
            PermanentThorium.AddRange(PermanentThoriumMovement);
            PermanentThorium.AddRange(PermanentThoriumRepellent);
            PermanentThorium.AddRange(PermanentThoriumStations);
            PermanentThorium.AddRange(PermanentThoriumCoatings);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentThoriumBard", PermanentThoriumBard, PermanentThoriumBardIngredients),
                new NewCombinedBuffItem("PermanentThoriumHealer", PermanentThoriumHealer, PermanentThoriumHealerIngredients),
                new NewCombinedBuffItem("PermanentThoriumThrower", PermanentThoriumThrower, PermanentThoriumThrowerIngredients),
                new NewCombinedBuffItem("PermanentThoriumDamage", PermanentThoriumDamage, PermanentThoriumDamageIngredients),
                new NewCombinedBuffItem("PermanentThoriumMovement", PermanentThoriumMovement, PermanentThoriumMovementIngredients),
                new NewCombinedBuffItem("PermanentThoriumRepellent", PermanentThoriumRepellent, PermanentThoriumRepellentIngredients),
                new NewCombinedBuffItem("PermanentThoriumStations", PermanentThoriumStations, PermanentThoriumStationsIngredients),
                new NewCombinedBuffItem("PermanentThoriumCoatings", PermanentThoriumCoatings, PermanentThoriumCoatingsIngredients)
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentThoriumIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumBard"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumHealer"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumThrower"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumRepellent"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumStations"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThoriumCoatings")];

            NewCombinedBuffItem permanentThoriumItem = new("PermanentThorium", PermanentThorium, PermanentThoriumIngredients);
            CombinedBuffItem newPermanentThorium = new(permanentThoriumItem.itemName, permanentThoriumItem.textureName, permanentThoriumItem.effects, permanentThoriumItem.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentThorium);
            Constants.AllCombinedBuffItems.Add(newPermanentThorium.Type);
        }
    }
    public static class ThoriumBossReworkBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.ThoriumHelheim.Loaded)
                return;
            
            NewBuffEffect[] ThoriumBossReworkEffects = [
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.ThoriumHelheim.Mod, "Deathsinger")),
                new NewBuffEffect(Common.GetModBuff(CrossModSupport.ThoriumHelheim.Mod, "Inspired"))
            ];

            foreach (var newEffect in ThoriumBossReworkEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                new NewBuffItem(Common.GetModItem(CrossModSupport.ThoriumHelheim.Mod, "DeathsingerPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ThoriumHelheim.Mod, "Deathsinger")], 30, "PermanentDeathsinger"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.ThoriumHelheim.Mod, "InspirationRegenerationPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.ThoriumHelheim.Mod, "Inspired")], 30, "PermanentInspirationRegeneration"),
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }
    }
}
