using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity
{
    [JITWhenModsEnabled("ContinentOfJourney")]
    [ExtendsFromMod("ContinentOfJourney")]
    public class PermanentHomewardJourney : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentHomewardJourney";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentHomewardJourneyArena>());
            r.AddIngredient(ModContent.ItemType<PermanentHomewardJourneyFarming>());
            r.AddIngredient(ModContent.ItemType<PermanentHomewardJourneyMovement>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new HomewardJourneyEffect());
        }
    }
}
