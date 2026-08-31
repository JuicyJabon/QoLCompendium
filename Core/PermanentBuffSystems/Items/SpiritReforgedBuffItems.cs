namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class SpiritReforgedBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.SpiritReforged.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] SpiritReforgedEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "RemedyPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlightPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "DoubleJumpPotionBuff")),
            //flasks
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff"), (int) Constants.EffectTypes.Flask),
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "KoiTotemBuff"), (int) Constants.EffectTypes.Arena),
            ];

            foreach (var newEffect in SpiritReforgedEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "QuenchPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff")], 30, "PermanentQuenched"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "RemedyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "RemedyPotionBuff")], 30, "PermanentRemedy"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "FlightPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlightPotionBuff")], 30, "PermanentSRSoaring"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "DoubleJumpPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "DoubleJumpPotionBuff")], 30, "PermanentSRZephyr"),
                //flasks
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")], 30, "PermanentFlaskOfFrost"),
                //arena
                new NewBuffItem(Common.GetModItem(CrossModSupport.SpiritReforged.Mod, "KoiTotem"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "KoiTotemBuff")], 3, "PermanentSRKoiTotem")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentSpiritReforged =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "QuenchPotion_Buff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "RemedyPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlightPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "DoubleJumpPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "KoiTotemBuff")]
            ];
            List<int> PermanentSpiritReforgedIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentQuenched"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRemedy"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSRSoaring"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSRZephyr"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSRKoiTotem"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfFrost")];

            NewCombinedBuffItem[] CombinedBuffItems = [new NewCombinedBuffItem("PermanentSpiritReforged", PermanentSpiritReforged, PermanentSpiritReforgedIngredients)];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);
        }
    }
}
