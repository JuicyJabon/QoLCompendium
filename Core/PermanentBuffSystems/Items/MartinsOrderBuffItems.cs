namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class MartinsOrderBuffItems
    {
        public static void LoadTasks()
        {
            if (!CrossModSupport.MartinsOrder.Loaded)
                return;

            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            NewBuffEffect[] MartinsOrderEffects = [
            //potions
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "BlackHoleBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "BodyBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Charging")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "TurretBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "EmpowermentBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SummonSpeedBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Gourmet")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "HasteBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Healing")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "PainterBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "RockskinBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Shielding")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ShooterBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SoulBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "CasterBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Starreach")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SweepBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ThrowerBuff")),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "WhipperBuff")),
            //new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ZincPillBuff")),
            //stations
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ReschBuff"), (int)Constants.EffectTypes.Station),
            new NewBuffEffect(Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SporeSave"), (int)Constants.EffectTypes.Station),
        ];

            foreach (var newEffect in MartinsOrderEffects)
                ItemUtils.CreatePermanentBuffEffect(newEffect);

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "BlackHolePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "BlackHoleBuff")], 30, "PermanentBlackHole"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "BodyPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "BodyBuff")], 30, "PermanentBody"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "BlueBerryJam"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Charging")], 30, "PermanentCharging"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "DefenderPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "TurretBuff")], 30, "PermanentDefender"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "EmpowermentPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "EmpowermentBuff")], 30, "PermanentEmpowerment"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "SummonSpeedPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SummonSpeedBuff")], 30, "PermanentEvocation"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "FastFood"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Gourmet")], 30, "PermanentGourmetFlavor"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "HastePotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "HasteBuff")], 30, "PermanentHaste"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "RedBerryJam"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Healing")], 30, "PermanentHealing"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "PainterPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "PainterBuff")], 30, "PermanentPainter"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "RockskinPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "RockskinBuff")], 30, "PermanentRockskin"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ShieldingPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Shielding")], 30, "PermanentShielding"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ShooterPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ShooterBuff")], 30, "PermanentShooter"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "SoulPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SoulBuff")], 30, "PermanentSoul"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "CasterPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "CasterBuff")], 30, "PermanentSpellCaster"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "StarreachPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Starreach")], 30, "PermanentStarreach"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "SweepPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SweepBuff")], 30, "PermanentSweeper"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ThrowerPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ThrowerBuff")], 30, "PermanentThrower"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "WhipperPotion"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "WhipperBuff")], 30, "PermanentWhipper"),
                //new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ZincPills"), Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ZincPillBuff"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ZincPillBuff")], 30, "PermanentZincPill", "Permanent Zinc Pill"),
                //stations
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "ArcheologyTable"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ReschBuff")], 3, "PermanentArcheology"),
                new NewBuffItem(Common.GetModItem(CrossModSupport.MartinsOrder.Mod, "SporeFarm"), Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SporeSave")], 3, "PermanentSporeFarm"),
            ];

            foreach (var newBuffItem in BuffItems)
                ItemUtils.CreatePermanentBuffItem(newBuffItem);
        }

        public static void CombinedItems()
        {
            List<BuffEffect> PermanentMartinsOrderDamage =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "TurretBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "EmpowermentBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SummonSpeedBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "HasteBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "PainterBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ShooterBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "CasterBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Starreach")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SweepBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ThrowerBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "WhipperBuff")]
            ];
            List<int> PermanentMartinsOrderDamageIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentDefender"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEmpowerment"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentEvocation"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHaste"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentPainter"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShooter"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSpellCaster"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentStarreach"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSweeper"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentThrower"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentWhipper")];

            List<BuffEffect> PermanentMartinsOrderDefense =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "BlackHoleBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "BodyBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Charging")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Gourmet")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Healing")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "RockskinBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "Shielding")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SoulBuff")]
            ];
            List<int> PermanentMartinsOrderDefenseIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBlackHole"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentBody"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentCharging"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentGourmetFlavor"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentHealing"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentRockskin"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentShielding"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSoul")];

            List<BuffEffect> PermanentMartinsOrderStations =
            [
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "ReschBuff")],
                Constants.AllEffects[Common.GetModBuff(CrossModSupport.MartinsOrder.Mod, "SporeSave")]
            ];
            List<int> PermanentMartinsOrderStationsIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentArcheology"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentSporeFarm")];

            List<BuffEffect> PermanentMartinsOrder = [];
            PermanentMartinsOrder.AddRange(PermanentMartinsOrderDamage);
            PermanentMartinsOrder.AddRange(PermanentMartinsOrderDefense);
            PermanentMartinsOrder.AddRange(PermanentMartinsOrderStations);

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem("PermanentMartinsOrderDamage", PermanentMartinsOrderDamage, PermanentMartinsOrderDamageIngredients),
                new NewCombinedBuffItem("PermanentMartinsOrderDefense", PermanentMartinsOrderDefense, PermanentMartinsOrderDefenseIngredients),
                new NewCombinedBuffItem("PermanentMartinsOrderStations", PermanentMartinsOrderStations, PermanentMartinsOrderStationsIngredients),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
                ItemUtils.CreateUpgradedPermanentBuffItem(newCombinedBuffItem);

            List<int> PermanentMartinsOrderIngredients = [
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderDamage"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderDefense"),
                    Common.GetModItem(QoLCompendium.Instance, "PermanentMartinsOrderStations")];

            NewCombinedBuffItem permanentMartinsOrderItem = new("PermanentMartinsOrder", PermanentMartinsOrder, PermanentMartinsOrderIngredients);
            CombinedBuffItem newPermanentMartinsOrder = new(permanentMartinsOrderItem.itemName, permanentMartinsOrderItem.textureName, permanentMartinsOrderItem.effects, permanentMartinsOrderItem.ingredients);
            QoLCompendium.Instance.AddContent(newPermanentMartinsOrder);
            Constants.AllCombinedBuffItems.Add(newPermanentMartinsOrder.Type);
        }
    }
}
