using MartainsOrder.Items.Tantalum;
using MartainsOrder.Projectiles.Rocketeer;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Rockets.MartinsOrder
{
    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessMissile03Pouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MartainsOrder.Items.Charcoal.CoalRocket>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessMissile05Pouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MartainsOrder.Items.Crystal.CrystalRocket>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessMissile07Pouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MartainsOrder.Items.Extra.FishyumRocket>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessDiggerRocketPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MartainsOrder.Items.Technology.DiggerRocket>();
        public override int RocketProjectile => ModContent.ProjectileType<DiggerRocket>();
        public override int SnowmanProjectile => ModContent.ProjectileType<DiggerRocketSnowman>();
        public override int GrenadeProjectile => ModContent.ProjectileType<DiggerRocketGrenade>();
        public override int MineProjectile => ModContent.ProjectileType<DiggerRocketMine>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessDrillRocketPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MartainsOrder.Items.Technology.DrillRocket>();
        public override int RocketProjectile => ModContent.ProjectileType<DrillRocket>();
        public override int SnowmanProjectile => ModContent.ProjectileType<DrillRocketSnowman>();
        public override int GrenadeProjectile => ModContent.ProjectileType<DrillRocketGrenade>();
        public override int MineProjectile => ModContent.ProjectileType<DrillRocketMine>();
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessMakeshiftProximityMinePouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MakeshiftProximityMine>();
        public override int RocketProjectile => ProjectileID.ProximityMineI;
        public override int SnowmanProjectile => ProjectileID.ProximityMineIII;
        public override int GrenadeProjectile => ProjectileID.ProximityMineI;
        public override int MineProjectile => ProjectileID.ProximityMineIII;
    }

    [JITWhenModsEnabled(CrossModSupport.MartinsOrder.Name)]
    [ExtendsFromMod(CrossModSupport.MartinsOrder.Name)]
    public class EndlessPrototypeRocketPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MartainsOrder.Items.Technology.ExplosiveRocket>();
        public override int RocketProjectile => ModContent.ProjectileType<ExplosiveRocket>();
        public override int SnowmanProjectile => ModContent.ProjectileType<ExplosiveRocketSnowman>();
        public override int GrenadeProjectile => ModContent.ProjectileType<ExplosiveRocketGrenade>();
        public override int MineProjectile => ModContent.ProjectileType<ExplosiveRocketMine>();
    }
}
