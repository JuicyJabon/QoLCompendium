using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic.Candies;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.SpiritClassic.Candies
{
    [JITWhenModsEnabled("SpiritMod")]
    [ExtendsFromMod("SpiritMod")]
    public class PermanentManaCandy : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.spiritMod, Common.GetModBuff(ModConditions.spiritMod, "ManaBuffC"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.spiritMod, "ManaCandy"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new ManaCandyEffect());
        }
    }
}
