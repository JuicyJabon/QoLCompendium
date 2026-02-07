using MartainsOrder.Buffs;
using MartainsOrder.Buffs.Extra;
using MartainsOrder.Items.Consumable;
using MartainsOrder.Items.Consumable.Food;
using MartainsOrder.Items.Geo;
using MartainsOrder.Items.Placeable;
using MartainsOrder.Items.Spore;
using MartainsOrder.Items.Zinc;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public static class MartinsOrderBuffItems
    {
        public static NewBuffEffect[] MartinsOrderEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<BlackHoleBuff>()),
            new NewBuffEffect(ModContent.BuffType<BodyBuff>()),
            new NewBuffEffect(ModContent.BuffType<Charging>()),
            new NewBuffEffect(ModContent.BuffType<TurretBuff>()),
            new NewBuffEffect(ModContent.BuffType<EmpowermentBuff>()),
            new NewBuffEffect(ModContent.BuffType<SummonSpeedBuff>()),
            new NewBuffEffect(ModContent.BuffType<Gourmet>()),
            new NewBuffEffect(ModContent.BuffType<HasteBuff>()),
            new NewBuffEffect(ModContent.BuffType<Healing>()),
            new NewBuffEffect(ModContent.BuffType<RockskinBuff>()),
            new NewBuffEffect(ModContent.BuffType<Shielding>()),
            new NewBuffEffect(ModContent.BuffType<ShooterBuff>()),
            new NewBuffEffect(ModContent.BuffType<SoulBuff>()),
            new NewBuffEffect(ModContent.BuffType<CasterBuff>()),
            new NewBuffEffect(ModContent.BuffType<Starreach>()),
            new NewBuffEffect(ModContent.BuffType<SweepBuff>()),
            new NewBuffEffect(ModContent.BuffType<ThrowerBuff>()),
            new NewBuffEffect(ModContent.BuffType<WhipperBuff>()),
            new NewBuffEffect(ModContent.BuffType<ZincPillBuff>()),
            //stations
            new NewBuffEffect(ModContent.BuffType<ReschBuff>(), (int)Common.EffectTypes.Station),
            new NewBuffEffect(ModContent.BuffType<SporeSave>(), (int)Common.EffectTypes.Station),
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in MartinsOrderEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<BlackHolePotion>(), ModContent.BuffType<BlackHoleBuff>(), Common.AllEffects[ModContent.BuffType<BlackHoleBuff>()], 30, "PermanentBlackHole", "Permanent Black Hole"),
                new NewBuffItem(ModContent.ItemType<BodyPotion>(), ModContent.BuffType<BodyBuff>(), Common.AllEffects[ModContent.BuffType<BodyBuff>()], 30, "PermanentBody", "Permanent Body"),
                new NewBuffItem(ModContent.ItemType<BlueBerryJam>(), ModContent.BuffType<Charging>(), Common.AllEffects[ModContent.BuffType<Charging>()], 30, "PermanentCharging", "Permanent Charging"),
                new NewBuffItem(ModContent.ItemType<DefenderPotion>(), ModContent.BuffType<TurretBuff>(), Common.AllEffects[ModContent.BuffType<TurretBuff>()], 30, "PermanentDefender", "Permanent Defender"),
                new NewBuffItem(ModContent.ItemType<EmpowermentPotion>(), ModContent.BuffType<EmpowermentBuff>(), Common.AllEffects[ModContent.BuffType<EmpowermentBuff>()], 30, "PermanentEmpowerment", "Permanent Empowerment"),
                new NewBuffItem(ModContent.ItemType<SummonSpeedPotion>(), ModContent.BuffType<SummonSpeedBuff>(), Common.AllEffects[ModContent.BuffType<SummonSpeedBuff>()], 30, "PermanentEvocation", "Permanent Evocation"),
                new NewBuffItem(ModContent.ItemType<FastFood>(), ModContent.BuffType<Gourmet>(), Common.AllEffects[ModContent.BuffType<Gourmet>()], 30, "PermanentGourmetFlavor", "Permanent Gourmet Flavor"),
                new NewBuffItem(ModContent.ItemType<HastePotion>(), ModContent.BuffType<HasteBuff>(), Common.AllEffects[ModContent.BuffType<HasteBuff>()], 30, "PermanentHaste", "Permanent Haste"),
                new NewBuffItem(ModContent.ItemType<RedBerryJam>(), ModContent.BuffType<Healing>(), Common.AllEffects[ModContent.BuffType<Healing>()], 30, "PermanentHealing", "Permanent Healing"),
                new NewBuffItem(ModContent.ItemType<RockskinPotion>(), ModContent.BuffType<RockskinBuff>(), Common.AllEffects[ModContent.BuffType<RockskinBuff>()], 30, "PermanentRockskin", "Permanent Rockskin"),
                new NewBuffItem(ModContent.ItemType<ShieldingPotion>(), ModContent.BuffType<Shielding>(), Common.AllEffects[ModContent.BuffType<Shielding>()], 30, "PermanentShielding", "Permanent Shielding"),
                new NewBuffItem(ModContent.ItemType<ShooterPotion>(), ModContent.BuffType<ShooterBuff>(), Common.AllEffects[ModContent.BuffType<ShooterBuff>()], 30, "PermanentShooter", "Permanent Shooter"),
                new NewBuffItem(ModContent.ItemType<SoulPotion>(), ModContent.BuffType<SoulBuff>(), Common.AllEffects[ModContent.BuffType<SoulBuff>()], 30, "PermanentSoul", "Permanent Soul"),
                new NewBuffItem(ModContent.ItemType<CasterPotion>(), ModContent.BuffType<CasterBuff>(), Common.AllEffects[ModContent.BuffType<CasterBuff>()], 30, "PermanentSpellCaster", "Permanent Spell Caster"),
                new NewBuffItem(ModContent.ItemType<StarreachPotion>(), ModContent.BuffType<Starreach>(), Common.AllEffects[ModContent.BuffType<Starreach>()], 30, "PermanentStarreach", "Permanent Starreach"),
                new NewBuffItem(ModContent.ItemType<SweepPotion>(), ModContent.BuffType<SweepBuff>(), Common.AllEffects[ModContent.BuffType<SweepBuff>()], 30, "PermanentSweeper", "Permanent Sweeper"),
                new NewBuffItem(ModContent.ItemType<ThrowerPotion>(), ModContent.BuffType<ThrowerBuff>(), Common.AllEffects[ModContent.BuffType<ThrowerBuff>()], 30, "PermanentThrower", "Permanent Thrower"),
                new NewBuffItem(ModContent.ItemType<WhipperPotion>(), ModContent.BuffType<WhipperBuff>(), Common.AllEffects[ModContent.BuffType<WhipperBuff>()], 30, "PermanentWhipper", "Permanent Whipper"),
                new NewBuffItem(ModContent.ItemType<ZincPill>(), ModContent.BuffType<ZincPillBuff>(), Common.AllEffects[ModContent.BuffType<ZincPillBuff>()], 30, "PermanentZincPill", "Permanent Zinc Pill"),
                //stations
                new NewBuffItem(ModContent.ItemType<ArcheologyTable>(), ModContent.BuffType<ReschBuff>(), Common.AllEffects[ModContent.BuffType<ReschBuff>()], 3, "PermanentArcheology", "Permanent Archeology"),
                new NewBuffItem(ModContent.ItemType<SporeFarm>(), ModContent.BuffType<SporeSave>(), Common.AllEffects[ModContent.BuffType<SporeSave>()], 3, "PermanentSporeFarm", "Permanent Spore Farm"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentMartinsOrderDamage = new()
            {
                { Common.AllEffects[ModContent.BuffType<TurretBuff>()], ModContent.BuffType<TurretBuff>() },
                { Common.AllEffects[ModContent.BuffType<EmpowermentBuff>()], ModContent.BuffType<EmpowermentBuff>() },
                { Common.AllEffects[ModContent.BuffType<SummonSpeedBuff>()], ModContent.BuffType<SummonSpeedBuff>() },
                { Common.AllEffects[ModContent.BuffType<HasteBuff>()], ModContent.BuffType<HasteBuff>() },
                { Common.AllEffects[ModContent.BuffType<ShooterBuff>()], ModContent.BuffType<ShooterBuff>() },
                { Common.AllEffects[ModContent.BuffType<CasterBuff>()], ModContent.BuffType<CasterBuff>() },
                { Common.AllEffects[ModContent.BuffType<Starreach>()], ModContent.BuffType<Starreach>() },
                { Common.AllEffects[ModContent.BuffType<SweepBuff>()], ModContent.BuffType<SweepBuff>() },
                { Common.AllEffects[ModContent.BuffType<ThrowerBuff>()], ModContent.BuffType<ThrowerBuff>() },
                { Common.AllEffects[ModContent.BuffType<WhipperBuff>()], ModContent.BuffType<WhipperBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentMartinsOrderDefense = new()
            {
                { Common.AllEffects[ModContent.BuffType<BlackHoleBuff>()], ModContent.BuffType<BlackHoleBuff>() },
                { Common.AllEffects[ModContent.BuffType<BodyBuff>()], ModContent.BuffType<BodyBuff>() },
                { Common.AllEffects[ModContent.BuffType<Charging>()], ModContent.BuffType<Charging>() },
                { Common.AllEffects[ModContent.BuffType<Gourmet>()], ModContent.BuffType<Gourmet>() },
                { Common.AllEffects[ModContent.BuffType<Healing>()], ModContent.BuffType<Healing>() },
                { Common.AllEffects[ModContent.BuffType<RockskinBuff>()], ModContent.BuffType<RockskinBuff>() },
                { Common.AllEffects[ModContent.BuffType<Shielding>()], ModContent.BuffType<Shielding>() },
                { Common.AllEffects[ModContent.BuffType<SoulBuff>()], ModContent.BuffType<SoulBuff>() },
                { Common.AllEffects[ModContent.BuffType<ZincPillBuff>()], ModContent.BuffType<ZincPillBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentMartinsOrderStations = new()
            {
                { Common.AllEffects[ModContent.BuffType<ReschBuff>()], ModContent.BuffType<ReschBuff>() },
                { Common.AllEffects[ModContent.BuffType<SporeSave>()], ModContent.BuffType<SporeSave>() }
            };

            Dictionary<BuffEffect, int> PermanentMartinsOrder = new()
            {
                { Common.AllEffects[ModContent.BuffType<TurretBuff>()], ModContent.BuffType<TurretBuff>() },
                { Common.AllEffects[ModContent.BuffType<EmpowermentBuff>()], ModContent.BuffType<EmpowermentBuff>() },
                { Common.AllEffects[ModContent.BuffType<SummonSpeedBuff>()], ModContent.BuffType<SummonSpeedBuff>() },
                { Common.AllEffects[ModContent.BuffType<HasteBuff>()], ModContent.BuffType<HasteBuff>() },
                { Common.AllEffects[ModContent.BuffType<ShooterBuff>()], ModContent.BuffType<ShooterBuff>() },
                { Common.AllEffects[ModContent.BuffType<CasterBuff>()], ModContent.BuffType<CasterBuff>() },
                { Common.AllEffects[ModContent.BuffType<Starreach>()], ModContent.BuffType<Starreach>() },
                { Common.AllEffects[ModContent.BuffType<SweepBuff>()], ModContent.BuffType<SweepBuff>() },
                { Common.AllEffects[ModContent.BuffType<ThrowerBuff>()], ModContent.BuffType<ThrowerBuff>() },
                { Common.AllEffects[ModContent.BuffType<WhipperBuff>()], ModContent.BuffType<WhipperBuff>() },
                { Common.AllEffects[ModContent.BuffType<BlackHoleBuff>()], ModContent.BuffType<BlackHoleBuff>() },
                { Common.AllEffects[ModContent.BuffType<BodyBuff>()], ModContent.BuffType<BodyBuff>() },
                { Common.AllEffects[ModContent.BuffType<Charging>()], ModContent.BuffType<Charging>() },
                { Common.AllEffects[ModContent.BuffType<Gourmet>()], ModContent.BuffType<Gourmet>() },
                { Common.AllEffects[ModContent.BuffType<Healing>()], ModContent.BuffType<Healing>() },
                { Common.AllEffects[ModContent.BuffType<RockskinBuff>()], ModContent.BuffType<RockskinBuff>() },
                { Common.AllEffects[ModContent.BuffType<Shielding>()], ModContent.BuffType<Shielding>() },
                { Common.AllEffects[ModContent.BuffType<SoulBuff>()], ModContent.BuffType<SoulBuff>() },
                { Common.AllEffects[ModContent.BuffType<ZincPillBuff>()], ModContent.BuffType<ZincPillBuff>() },
                { Common.AllEffects[ModContent.BuffType<ReschBuff>()], ModContent.BuffType<ReschBuff>() },
                { Common.AllEffects[ModContent.BuffType<SporeSave>()], ModContent.BuffType<SporeSave>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentMartinsOrderDamage, "PermanentMartinsOrderDamage", "Permanent Martin's Order Damage", "PermanentMartinsOrderDamage"),
                new NewCombinedBuffItem(PermanentMartinsOrderDefense, "PermanentMartinsOrderDefense", "Permanent Martin's Order Defense", "PermanentMartinsOrderDefense"),
                new NewCombinedBuffItem(PermanentMartinsOrderStations, "PermanentMartinsOrderStations", "Permanent Martin's Order Stations", "PermanentMartinsOrderStations"),
                new NewCombinedBuffItem(PermanentMartinsOrder, "PermanentMartinsOrder", "Permanent Martin's Order", "PermanentMartinsOrder"),
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
