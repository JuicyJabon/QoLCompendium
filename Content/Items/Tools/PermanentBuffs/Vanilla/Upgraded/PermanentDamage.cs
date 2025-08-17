using QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Potions;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Upgraded
{
    public class PermanentDamage : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentDamage";

        public override void SetDefaults()
        {
            Common.SetDefaultsToPermanentBuff(Item);
        }

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentAmmoReservation>());
            r.AddIngredient(ModContent.ItemType<PermanentArchery>());
            r.AddIngredient(ModContent.ItemType<PermanentBattle>());
            r.AddIngredient(ModContent.ItemType<PermanentLucky>());
            r.AddIngredient(ModContent.ItemType<PermanentMagicPower>());
            r.AddIngredient(ModContent.ItemType<PermanentManaRegeneration>());
            r.AddIngredient(ModContent.ItemType<PermanentSummoning>());
            r.AddIngredient(ModContent.ItemType<PermanentTipsy>());
            r.AddIngredient(ModContent.ItemType<PermanentTitan>());
            r.AddIngredient(ModContent.ItemType<PermanentRage>());
            r.AddIngredient(ModContent.ItemType<PermanentWrath>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new DamageEffect());
        }
    }
}
