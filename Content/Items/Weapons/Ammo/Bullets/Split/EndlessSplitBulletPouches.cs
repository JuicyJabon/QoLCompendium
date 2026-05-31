using Split.Content.Ammo.Bullets;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Bullets.Split
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class EndlessPiercingBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PiercingBullet>();
    }

    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class EndlessPrismaticBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PrismaticBullet>();
    }
}
