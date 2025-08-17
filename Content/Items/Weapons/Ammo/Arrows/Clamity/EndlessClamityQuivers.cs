﻿using Clamity.Content.Items.Ammo;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Arrows.Clamity
{
    [JITWhenModsEnabled("Clamity")]
    [ExtendsFromMod("Clamity")]
    public class EndlessFrostfireQuiver : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<FrostfireArrow>();
    }
}
