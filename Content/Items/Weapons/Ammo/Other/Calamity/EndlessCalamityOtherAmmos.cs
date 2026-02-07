using CalamityMod.Items.Ammo;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Ranged;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessBloodRune : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodRune>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessWulfrumCogworkShard : BaseAmmo
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            IngredientStackCount = 396;
        }
        public override int AmmunitionItem => ModContent.ItemType<WulfrumMetalScrap>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class WulfrumBlunderbussEndless : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<WulfrumBlunderbuss>();
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (!player.HasItem(ModContent.ItemType<EndlessWulfrumCogworkShard>()))
                return;

            if (item.ModItem is WulfrumBlunderbuss wulfrumBlunderbuss)
                wulfrumBlunderbuss.storedScrap = 30;
        }
    }
}
