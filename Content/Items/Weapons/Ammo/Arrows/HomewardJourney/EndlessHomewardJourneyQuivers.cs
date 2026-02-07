using ContinentOfJourney.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessBewitchedQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BewitchedArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessDivineFireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DivineFireArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessForceBreakQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ForceBreakArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessMartyrQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ChampionArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessPlagueQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PlagueArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessSteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SteelArrow>();
    }
}
