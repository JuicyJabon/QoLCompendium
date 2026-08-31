namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class RedemptionBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.Redemption.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] RedemptionEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "CharismaPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "EvilJellyBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "HydraCorrosionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "SkirmishBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "VendettaPotionBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "VigourousBuff")),
            //arena
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "MoonflareCandleBuff"), (int)Constants.EffectTypes.Arena),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "SoulboundBuff"), (int)Constants.EffectTypes.Arena),
            //stations
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "EnergyStationBuff"), (int)Constants.EffectTypes.Station),
            //flasks
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "BileFlaskBuff"), (int) Constants.EffectTypes.Flask),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.Redemption.Mod, "ExplosiveFlaskBuff"), (int)Constants.EffectTypes.Flask)
            ];

            foreach (var newEffect in RedemptionEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "CharismaPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "CharismaPotionBuff")], 30, "PermanentCharisma"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "EvilJelly"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "EvilJellyBuff")], 30, "PermanentEvilJelly"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "HydraCorrosionPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "HydraCorrosionBuff")], 30, "PermanentHydricAcid"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "SkirmishPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "SkirmishBuff")], 30, "PermanentSkirmish"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "VendettaPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "VendettaPotionBuff")], 30, "PermanentVendetta"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "VigourousPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "VigourousBuff")], 30, "PermanentVigourous"),
                //flasks
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "BileFlask"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "BileFlaskBuff")], 30, "PermanentFlaskOfBile"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "NitroglycerineFlask"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "ExplosiveFlaskBuff")], 30, "PermanentFlaskOfNitroglycerine"),
                //arena
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "MoonflareCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "MoonflareCandleBuff")], 3, "PermanentMoonflareCandle"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "SoulCandle"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "SoulboundBuff")], 3, "PermanentSoulCandle"),
                //stations
                new NewBuffItem(Common.GetModItem(CrossModSupport.Redemption.Mod, "EnergyStation"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "EnergyStationBuff")], 3, "PermanentEnergyStation")
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentRedemption =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "CharismaPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "EvilJellyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "HydraCorrosionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "SkirmishBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "VendettaPotionBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "VigourousBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "BileFlaskBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "ExplosiveFlaskBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "MoonflareCandleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "SoulboundBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.Redemption.Mod, "EnergyStationBuff")]
            ];
            List<int> PermanentRedemptionIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCharisma"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEvilJelly"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHydricAcid"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSkirmish"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVendetta"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentVigourous"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMoonflareCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoulCandle"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEnergyStation"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfBile"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentFlaskOfNitroglycerine")];

            NewCombinedBuffItem[] CombinedBuffItems = [new NewCombinedBuffItem("PermanentRedemption", PermanentRedemption, PermanentRedemptionIngredients)];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);
        }
    }
}
