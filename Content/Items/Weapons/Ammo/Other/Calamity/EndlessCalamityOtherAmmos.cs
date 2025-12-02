using CalamityMod.Items.Ammo;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Weapons.Ranged;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other.Calamity
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessBloodRune : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodRune>();
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class EndlessWulfrumCogworkShard : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WulfrumMetalScrap>();

        public override void SetStaticDefaults() => IngredientStackCount = 396;
    }

    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
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
