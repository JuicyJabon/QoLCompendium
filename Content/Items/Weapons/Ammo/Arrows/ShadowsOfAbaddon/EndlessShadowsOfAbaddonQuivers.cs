using SacredTools.Items.Weapons.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.ShadowsOfAbaddon
{
    [JITWhenModsEnabled(ModConditions.shadowsOfAbaddonName)]
    [ExtendsFromMod(ModConditions.shadowsOfAbaddonName)]
    public class EndlessAsthraltiteQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<AsthralArrow>();
    }

    [JITWhenModsEnabled(ModConditions.shadowsOfAbaddonName)]
    [ExtendsFromMod(ModConditions.shadowsOfAbaddonName)]
    public class EndlessFlariumQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FlariumArrow>();
    }

    [JITWhenModsEnabled(ModConditions.shadowsOfAbaddonName)]
    [ExtendsFromMod(ModConditions.shadowsOfAbaddonName)]
    public class EndlessLuminousQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<PhaseArrow>();
    }

    [JITWhenModsEnabled(ModConditions.shadowsOfAbaddonName)]
    [ExtendsFromMod(ModConditions.shadowsOfAbaddonName)]
    public class EndlessOblivionQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<OblivionArrow>();
    }
}
