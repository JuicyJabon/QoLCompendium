using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.MartinsOrder;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.MartinsOrder
{
    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class PermanentMartinsOrderDamage : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentMartinsOrderDamage";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentDefender>());
            r.AddIngredient(ModContent.ItemType<PermanentEmpowerment>());
            r.AddIngredient(ModContent.ItemType<PermanentEvocation>());
            r.AddIngredient(ModContent.ItemType<PermanentHaste>());
            r.AddIngredient(ModContent.ItemType<PermanentShooter>());
            r.AddIngredient(ModContent.ItemType<PermanentSpellCaster>());
            r.AddIngredient(ModContent.ItemType<PermanentStarreach>());
            r.AddIngredient(ModContent.ItemType<PermanentSweeper>());
            r.AddIngredient(ModContent.ItemType<PermanentThrower>());
            r.AddIngredient(ModContent.ItemType<PermanentWhipper>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new MartinsOrderDamageEffect());
        }
    }
}
