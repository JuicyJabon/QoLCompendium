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
            new NewBuffEffect(ModContent.BuffType<PainterBuff>()),
            new NewBuffEffect(ModContent.BuffType<RockskinBuff>()),
            new NewBuffEffect(ModContent.BuffType<Shielding>()),
            new NewBuffEffect(ModContent.BuffType<ShooterBuff>()),
            new NewBuffEffect(ModContent.BuffType<SoulBuff>()),
            new NewBuffEffect(ModContent.BuffType<CasterBuff>()),
            new NewBuffEffect(ModContent.BuffType<Starreach>()),
            new NewBuffEffect(ModContent.BuffType<SweepBuff>()),
            new NewBuffEffect(ModContent.BuffType<ThrowerBuff>()),
            new NewBuffEffect(ModContent.BuffType<WhipperBuff>()),
            //new NewBuffEffect(ModContent.BuffType<ZincPillBuff>()),
            //stations
            new NewBuffEffect(ModContent.BuffType<ReschBuff>(), (int)Constants.EffectTypes.Station),
            new NewBuffEffect(ModContent.BuffType<SporeSave>(), (int)Constants.EffectTypes.Station),
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
                Constants.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<BlackHolePotion>(), ModContent.BuffType<BlackHoleBuff>(), Constants.AllEffects[ModContent.BuffType<BlackHoleBuff>()], 30, "PermanentBlackHole", "Permanent Black Hole"),
                new NewBuffItem(ModContent.ItemType<BodyPotion>(), ModContent.BuffType<BodyBuff>(), Constants.AllEffects[ModContent.BuffType<BodyBuff>()], 30, "PermanentBody", "Permanent Body"),
                new NewBuffItem(ModContent.ItemType<BlueBerryJam>(), ModContent.BuffType<Charging>(), Constants.AllEffects[ModContent.BuffType<Charging>()], 30, "PermanentCharging", "Permanent Charging"),
                new NewBuffItem(ModContent.ItemType<DefenderPotion>(), ModContent.BuffType<TurretBuff>(), Constants.AllEffects[ModContent.BuffType<TurretBuff>()], 30, "PermanentDefender", "Permanent Defender"),
                new NewBuffItem(ModContent.ItemType<EmpowermentPotion>(), ModContent.BuffType<EmpowermentBuff>(), Constants.AllEffects[ModContent.BuffType<EmpowermentBuff>()], 30, "PermanentEmpowerment", "Permanent Empowerment"),
                new NewBuffItem(ModContent.ItemType<SummonSpeedPotion>(), ModContent.BuffType<SummonSpeedBuff>(), Constants.AllEffects[ModContent.BuffType<SummonSpeedBuff>()], 30, "PermanentEvocation", "Permanent Evocation"),
                new NewBuffItem(ModContent.ItemType<FastFood>(), ModContent.BuffType<Gourmet>(), Constants.AllEffects[ModContent.BuffType<Gourmet>()], 30, "PermanentGourmetFlavor", "Permanent Gourmet Flavor"),
                new NewBuffItem(ModContent.ItemType<HastePotion>(), ModContent.BuffType<HasteBuff>(), Constants.AllEffects[ModContent.BuffType<HasteBuff>()], 30, "PermanentHaste", "Permanent Haste"),
                new NewBuffItem(ModContent.ItemType<RedBerryJam>(), ModContent.BuffType<Healing>(), Constants.AllEffects[ModContent.BuffType<Healing>()], 30, "PermanentHealing", "Permanent Healing"),
                new NewBuffItem(ModContent.ItemType<PainterPotion>(), ModContent.BuffType<PainterBuff>(), Constants.AllEffects[ModContent.BuffType<PainterBuff>()], 30, "PermanentPainter", "Permanent Painter"),
                new NewBuffItem(ModContent.ItemType<RockskinPotion>(), ModContent.BuffType<RockskinBuff>(), Constants.AllEffects[ModContent.BuffType<RockskinBuff>()], 30, "PermanentRockskin", "Permanent Rockskin"),
                new NewBuffItem(ModContent.ItemType<ShieldingPotion>(), ModContent.BuffType<Shielding>(), Constants.AllEffects[ModContent.BuffType<Shielding>()], 30, "PermanentShielding", "Permanent Shielding"),
                new NewBuffItem(ModContent.ItemType<ShooterPotion>(), ModContent.BuffType<ShooterBuff>(), Constants.AllEffects[ModContent.BuffType<ShooterBuff>()], 30, "PermanentShooter", "Permanent Shooter"),
                new NewBuffItem(ModContent.ItemType<SoulPotion>(), ModContent.BuffType<SoulBuff>(), Constants.AllEffects[ModContent.BuffType<SoulBuff>()], 30, "PermanentSoul", "Permanent Soul"),
                new NewBuffItem(ModContent.ItemType<CasterPotion>(), ModContent.BuffType<CasterBuff>(), Constants.AllEffects[ModContent.BuffType<CasterBuff>()], 30, "PermanentSpellCaster", "Permanent Spell Caster"),
                new NewBuffItem(ModContent.ItemType<StarreachPotion>(), ModContent.BuffType<Starreach>(), Constants.AllEffects[ModContent.BuffType<Starreach>()], 30, "PermanentStarreach", "Permanent Starreach"),
                new NewBuffItem(ModContent.ItemType<SweepPotion>(), ModContent.BuffType<SweepBuff>(), Constants.AllEffects[ModContent.BuffType<SweepBuff>()], 30, "PermanentSweeper", "Permanent Sweeper"),
                new NewBuffItem(ModContent.ItemType<ThrowerPotion>(), ModContent.BuffType<ThrowerBuff>(), Constants.AllEffects[ModContent.BuffType<ThrowerBuff>()], 30, "PermanentThrower", "Permanent Thrower"),
                new NewBuffItem(ModContent.ItemType<WhipperPotion>(), ModContent.BuffType<WhipperBuff>(), Constants.AllEffects[ModContent.BuffType<WhipperBuff>()], 30, "PermanentWhipper", "Permanent Whipper"),
                //new NewBuffItem(ModContent.ItemType<ZincPills>(), ModContent.BuffType<ZincPillBuff>(), Constants.AllEffects[ModContent.BuffType<ZincPillBuff>()], 30, "PermanentZincPill", "Permanent Zinc Pill"),
                //stations
                new NewBuffItem(ModContent.ItemType<ArcheologyTable>(), ModContent.BuffType<ReschBuff>(), Constants.AllEffects[ModContent.BuffType<ReschBuff>()], 3, "PermanentArcheology", "Permanent Archeology"),
                new NewBuffItem(ModContent.ItemType<SporeFarm>(), ModContent.BuffType<SporeSave>(), Constants.AllEffects[ModContent.BuffType<SporeSave>()], 3, "PermanentSporeFarm", "Permanent Spore Farm"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName);
                QoLCompendium.Instance.AddContent(item);
                Constants.AllBuffItems.Add(item.Type);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentMartinsOrderDamage = new()
            {
                { Constants.AllEffects[ModContent.BuffType<TurretBuff>()], ModContent.BuffType<TurretBuff>() },
                { Constants.AllEffects[ModContent.BuffType<EmpowermentBuff>()], ModContent.BuffType<EmpowermentBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SummonSpeedBuff>()], ModContent.BuffType<SummonSpeedBuff>() },
                { Constants.AllEffects[ModContent.BuffType<HasteBuff>()], ModContent.BuffType<HasteBuff>() },
                { Constants.AllEffects[ModContent.BuffType<PainterBuff>()], ModContent.BuffType<PainterBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ShooterBuff>()], ModContent.BuffType<ShooterBuff>() },
                { Constants.AllEffects[ModContent.BuffType<CasterBuff>()], ModContent.BuffType<CasterBuff>() },
                { Constants.AllEffects[ModContent.BuffType<Starreach>()], ModContent.BuffType<Starreach>() },
                { Constants.AllEffects[ModContent.BuffType<SweepBuff>()], ModContent.BuffType<SweepBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ThrowerBuff>()], ModContent.BuffType<ThrowerBuff>() },
                { Constants.AllEffects[ModContent.BuffType<WhipperBuff>()], ModContent.BuffType<WhipperBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentMartinsOrderDefense = new()
            {
                { Constants.AllEffects[ModContent.BuffType<BlackHoleBuff>()], ModContent.BuffType<BlackHoleBuff>() },
                { Constants.AllEffects[ModContent.BuffType<BodyBuff>()], ModContent.BuffType<BodyBuff>() },
                { Constants.AllEffects[ModContent.BuffType<Charging>()], ModContent.BuffType<Charging>() },
                { Constants.AllEffects[ModContent.BuffType<Gourmet>()], ModContent.BuffType<Gourmet>() },
                { Constants.AllEffects[ModContent.BuffType<Healing>()], ModContent.BuffType<Healing>() },
                { Constants.AllEffects[ModContent.BuffType<RockskinBuff>()], ModContent.BuffType<RockskinBuff>() },
                { Constants.AllEffects[ModContent.BuffType<Shielding>()], ModContent.BuffType<Shielding>() },
                { Constants.AllEffects[ModContent.BuffType<SoulBuff>()], ModContent.BuffType<SoulBuff>() },
                //{ Constants.AllEffects[ModContent.BuffType<ZincPillBuff>()], ModContent.BuffType<ZincPillBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentMartinsOrderStations = new()
            {
                { Constants.AllEffects[ModContent.BuffType<ReschBuff>()], ModContent.BuffType<ReschBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SporeSave>()], ModContent.BuffType<SporeSave>() }
            };

            Dictionary<BuffEffect, int> PermanentMartinsOrder = new()
            {
                { Constants.AllEffects[ModContent.BuffType<TurretBuff>()], ModContent.BuffType<TurretBuff>() },
                { Constants.AllEffects[ModContent.BuffType<EmpowermentBuff>()], ModContent.BuffType<EmpowermentBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SummonSpeedBuff>()], ModContent.BuffType<SummonSpeedBuff>() },
                { Constants.AllEffects[ModContent.BuffType<HasteBuff>()], ModContent.BuffType<HasteBuff>() },
                { Constants.AllEffects[ModContent.BuffType<PainterBuff>()], ModContent.BuffType<PainterBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ShooterBuff>()], ModContent.BuffType<ShooterBuff>() },
                { Constants.AllEffects[ModContent.BuffType<CasterBuff>()], ModContent.BuffType<CasterBuff>() },
                { Constants.AllEffects[ModContent.BuffType<Starreach>()], ModContent.BuffType<Starreach>() },
                { Constants.AllEffects[ModContent.BuffType<SweepBuff>()], ModContent.BuffType<SweepBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ThrowerBuff>()], ModContent.BuffType<ThrowerBuff>() },
                { Constants.AllEffects[ModContent.BuffType<WhipperBuff>()], ModContent.BuffType<WhipperBuff>() },
                { Constants.AllEffects[ModContent.BuffType<BlackHoleBuff>()], ModContent.BuffType<BlackHoleBuff>() },
                { Constants.AllEffects[ModContent.BuffType<BodyBuff>()], ModContent.BuffType<BodyBuff>() },
                { Constants.AllEffects[ModContent.BuffType<Charging>()], ModContent.BuffType<Charging>() },
                { Constants.AllEffects[ModContent.BuffType<Gourmet>()], ModContent.BuffType<Gourmet>() },
                { Constants.AllEffects[ModContent.BuffType<Healing>()], ModContent.BuffType<Healing>() },
                { Constants.AllEffects[ModContent.BuffType<RockskinBuff>()], ModContent.BuffType<RockskinBuff>() },
                { Constants.AllEffects[ModContent.BuffType<Shielding>()], ModContent.BuffType<Shielding>() },
                { Constants.AllEffects[ModContent.BuffType<SoulBuff>()], ModContent.BuffType<SoulBuff>() },
                //{ Constants.AllEffects[ModContent.BuffType<ZincPillBuff>()], ModContent.BuffType<ZincPillBuff>() },
                { Constants.AllEffects[ModContent.BuffType<ReschBuff>()], ModContent.BuffType<ReschBuff>() },
                { Constants.AllEffects[ModContent.BuffType<SporeSave>()], ModContent.BuffType<SporeSave>() }
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
                Constants.AllCombinedBuffItems.Add(item.Type);
            }
        }
    }
}
