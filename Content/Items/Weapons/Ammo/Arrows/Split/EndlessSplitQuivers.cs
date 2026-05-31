using Split.Content.Ammo.Arrows;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Split
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class EndlessBlackQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<DragonslayerArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class EndlessTracingQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<TracingArrow>();
    }
}
