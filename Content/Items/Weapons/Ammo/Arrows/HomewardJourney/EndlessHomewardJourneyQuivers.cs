using ContinentOfJourney.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.HomewardJourney
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class EndlessBewitchedQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BewitchedArrow>();
    }

    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class EndlessDivineFireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DivineFireArrow>();
    }

    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class EndlessMartyrQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<ChampionArrow>();
    }

    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class EndlessPlagueQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PlagueArrow>();
    }

    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class EndlessSteelQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<SteelArrow>();
    }
}
