using Split.Content.Ammo.Misc;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other.Split
{
    [JITWhenModsEnabled(CrossModSupport.Split.Name)]
    [ExtendsFromMod(CrossModSupport.Split.Name)]
    public class EndlessLavaCreamTank : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<LavaCream>();

        public override int IngredientStackCount => 396;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.DamageType = DamageClass.Ranged;
        }
    }
}
