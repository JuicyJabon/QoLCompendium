using ContinentOfJourney.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.HomewardJourney
{
    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class EndlessBewitchedQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BewitchedArrow>();
    }

    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class EndlessDivineFireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DivineFireArrow>();
    }

    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class EndlessMartyrQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ChampionArrow>();
    }

    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class EndlessPlagueQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PlagueArrow>();
    }

    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class EndlessSteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SteelArrow>();
    }
}
