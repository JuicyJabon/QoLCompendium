using CalamityMod.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Bullets.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessBloodfireBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodfireBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessBubonicRoundPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BubonicRound>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessDryadsTearPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DryadsTear>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessFlashRoundPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FlashRound>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessGodSlayerSlugPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<GodSlayerSlug>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessHailstormBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HailstormBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessHallowPointRoundPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HallowPointRound>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessHolyFireBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HolyFireBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessHyperiusBulletPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<HyperiusBullet>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessMarksmanRoundPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MarksmanRound>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessMortarRoundPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<MortarRound>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessRubberMortarRoundPouch : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RubberMortarRound>();
    }
}
