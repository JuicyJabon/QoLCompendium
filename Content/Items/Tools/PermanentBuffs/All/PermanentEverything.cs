using QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Upgraded;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.All;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.All
{
    public class PermanentEverything : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentEverything";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentVanilla>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new EverythingEffect());
        }
    }
}
