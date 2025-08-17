using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.HomewardJourney;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Arena.HomewardJourney
{
    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class PermanentLifeLantern : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.homewardJourneyMod, Common.GetModBuff(ModConditions.homewardJourneyMod, "LifeLanternBuff"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "LifeLantern"), 3);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new LifeLanternEffect());
        }
    }
}
