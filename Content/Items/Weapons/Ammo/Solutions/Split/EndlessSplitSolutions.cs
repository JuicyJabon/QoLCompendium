using Split.Content.Misc;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Solutions.Split
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class EndlessRedHotSolution : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<RedHotSolution>();
    }
}
