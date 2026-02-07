using ContinentOfJourney.Items;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessRailgunBattery : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RailgunBattery>();
    }
}
