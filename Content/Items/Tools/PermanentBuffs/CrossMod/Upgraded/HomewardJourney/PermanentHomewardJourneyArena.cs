using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Arena.HomewardJourney;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.HomewardJourney;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity
{
    [JITWhenModsEnabled(ModConditions.homewardJourneyName)]
    [ExtendsFromMod(ModConditions.homewardJourneyName)]
    public class PermanentHomewardJourneyArena : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentHomewardJourneyArena";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentBushOfLife>());
            r.AddIngredient(ModContent.ItemType<PermanentLifeLantern>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new HomewardJourneyArenaEffect());
        }
    }
}
