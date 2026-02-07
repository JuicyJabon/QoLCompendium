using ContinentOfJourney.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Bullets.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessDivineFireBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DivineFireBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessForceBreakBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ForceBreakBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessMartyrBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ChampionBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessPlagueBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PlagueBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessSteelBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SteelBullet>();
    }
}
