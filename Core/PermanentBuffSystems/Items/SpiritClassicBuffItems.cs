namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class SpiritClassicBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.SpiritClassic.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] SpiritClassicEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "PinkPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MirrorCoatBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MoonBlessing")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "OliveBranchBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "RunePotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SoulPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SpiritBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "FlightPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MushroomPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "StarPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "TurtlePotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "BismitePotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "DoubleJumpPotionBuff")),
            //candies
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "CandyBuff"), (int) Constants.EffectTypes.Candy),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "ChocolateBuff"), (int) Constants.EffectTypes.Candy),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "HealthBuffC"), (int) Constants.EffectTypes.Candy),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "LollipopBuff"), (int) Constants.EffectTypes.Candy),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "ManaBuffC"), (int) Constants.EffectTypes.Candy),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "TaffyBuff"), (int) Constants.EffectTypes.Candy),
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "OverDrive"), (int) Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "KoiTotemBuff"), (int) Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SunPotBuff"), (int) Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "CouchPotato"), (int) Constants.EffectTypes.Arena),
            ];

            foreach (var newEffect in SpiritClassicEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "PinkPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "PinkPotionBuff")], 30, "PermanentJump"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "MirrorCoat"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MirrorCoatBuff")], 30, "PermanentMirrorCoat"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "MoonJelly"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MoonBlessing")], 30, "PermanentMoonJelly"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "OliveBranch"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "OliveBranchBuff")], 30, "PermanentOliveBranch"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "RunePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "RunePotionBuff")], 30, "PermanentRunescribe"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "SoulPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SoulPotionBuff")], 30, "PermanentSoulguard"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "SpiritPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SpiritBuff")], 30, "PermanentSpirit"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "FlightPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "FlightPotionBuff")], 30, "PermanentSpiritSoaring"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "MushroomPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MushroomPotionBuff")], 30, "PermanentSporecoid"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "StarPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "StarPotionBuff")], 30, "PermanentStarburn"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "TurtlePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "TurtlePotionBuff")], 30, "PermanentSteadfast"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "BismitePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "BismitePotionBuff")], 30, "PermanentToxin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "DoubleJumpPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "DoubleJumpPotionBuff")], 30, "PermanentZephyr"),
                //candies
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "Candy"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "CandyBuff")], 3, "PermanentCandy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ChocolateBar"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "ChocolateBuff")], 3, "PermanentChocolateBar"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "HealthCandy"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "HealthBuffC")], 3, "PermanentHealthCandy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "Lollipop"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "LollipopBuff")], 3, "PermanentLollipop"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "ManaCandy"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "ManaBuffC")], 3, "PermanentManaCandy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "Taffy"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "TaffyBuff")], 3, "PermanentTaffy"),
                //arena
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "CoilEnergizerItem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "OverDrive")], 3, "PermanentCoiledEnergizer"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "KoiTotem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "KoiTotemBuff")], 3, "PermanentKoiTotem"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "SunPot"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SunPotBuff")], 3, "PermanentSunPot"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritClassic.Mod, "TheCouch"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "CouchPotato")], 3, "PermanentCouchPotato"),
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentSpiritClassicDamage =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "RunePotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SoulPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SpiritBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "StarPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "BismitePotionBuff")]
            ];
            List<int> PermanentSpiritClassicDamageIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRunescribe"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoulguard"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpirit"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentStarburn"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentToxin")];

            List<BuffEffect> PermanentSpiritClassicDefense =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MirrorCoatBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MoonBlessing")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "OliveBranchBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "MushroomPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "TurtlePotionBuff")]
            ];
            List<int> PermanentSpiritClassicDefenseIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMirrorCoat"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonJelly"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentOliveBranch"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSporecoid"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSteadfast")];

            List<BuffEffect> PermanentSpiritClassicMovement =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "PinkPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "FlightPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "DoubleJumpPotionBuff")]
            ];
            List<int> PermanentSpiritClassicMovementIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentJump"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritSoaring"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentZephyr")];

            List<BuffEffect> PermanentSpiritClassicCandies =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "CandyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "ChocolateBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "HealthBuffC")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "LollipopBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "ManaBuffC")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "TaffyBuff")]
            ];
            List<int> PermanentSpiritClassicCandiesIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCandy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentChocolateBar"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHealthCandy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentLollipop"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentManaCandy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentTaffy")];

            List<BuffEffect> PermanentSpiritClassicArena =
            [
               Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "OverDrive")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "KoiTotemBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "SunPotBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritClassic.Mod, "CouchPotato")]
            ];
            List<int> PermanentSpiritClassicArenaIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCoiledEnergizer"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentKoiTotem"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSunPot"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCouchPotato")];

            List<BuffEffect> PermanentSpiritClassic = [];
            PermanentSpiritClassic.AddRange(PermanentSpiritClassicDamage);
            PermanentSpiritClassic.AddRange(PermanentSpiritClassicDefense);
            PermanentSpiritClassic.AddRange(PermanentSpiritClassicMovement);
            PermanentSpiritClassic.AddRange(PermanentSpiritClassicCandies);
            PermanentSpiritClassic.AddRange(PermanentSpiritClassicArena);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentSpiritClassicDamage", PermanentSpiritClassicDamage, PermanentSpiritClassicDamageIngredients),
                new NewCombinedBuffItem("PermanentSpiritClassicDefense", PermanentSpiritClassicDefense, PermanentSpiritClassicDefenseIngredients),
                new NewCombinedBuffItem("PermanentSpiritClassicMovement", PermanentSpiritClassicMovement, PermanentSpiritClassicMovementIngredients),
                new NewCombinedBuffItem("PermanentSpiritClassicCandies", PermanentSpiritClassicCandies, PermanentSpiritClassicCandiesIngredients),
                new NewCombinedBuffItem("PermanentSpiritClassicArena", PermanentSpiritClassicArena, PermanentSpiritClassicArenaIngredients)
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentSpiritClassicIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicMovement"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicCandies"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpiritClassicArena")];

            NewCombinedBuffItem permanentSpiritClassicItem = new("PermanentSpiritClassic", PermanentSpiritClassic, PermanentSpiritClassicIngredients);
            CombinedBuffItem newPermanentSpiritClassic = new(permanentSpiritClassicItem.itemName, permanentSpiritClassicItem.textureName, permanentSpiritClassicItem.effects, permanentSpiritClassicItem.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentSpiritClassic);
            Constants.AllCombinedBuffItems.Add(newPermanentSpiritClassic.Type);
        }
    }
}
