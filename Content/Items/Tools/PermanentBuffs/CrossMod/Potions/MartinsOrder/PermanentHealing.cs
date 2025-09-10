using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.MartinsOrder;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.MartinsOrder
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class PermanentHealing : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.martainsOrderMod, Common.GetModBuff(ModConditions.martainsOrderMod, "Healing"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.martainsOrderMod, "RedBerryJam"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new HealingEffect());
        }
    }
}
