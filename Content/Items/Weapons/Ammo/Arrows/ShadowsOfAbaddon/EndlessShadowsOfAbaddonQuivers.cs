using SacredTools.Items.Weapons.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.ShadowsOfAbaddon
{
    [JITWhenModsEnabled(CrossModSupport.ShadowsOfAbaddon.Name)]
    [ExtendsFromMod(CrossModSupport.ShadowsOfAbaddon.Name)]
    public class EndlessAsthraltiteQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AsthralArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.ShadowsOfAbaddon.Name)]
    [ExtendsFromMod(CrossModSupport.ShadowsOfAbaddon.Name)]
    public class EndlessFlariumQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FlariumArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.ShadowsOfAbaddon.Name)]
    [ExtendsFromMod(CrossModSupport.ShadowsOfAbaddon.Name)]
    public class EndlessLuminousQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PhaseArrow>();
    }

    [JITWhenModsEnabled(CrossModSupport.ShadowsOfAbaddon.Name)]
    [ExtendsFromMod(CrossModSupport.ShadowsOfAbaddon.Name)]
    public class EndlessOblivionQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<OblivionArrow>();
    }
}
