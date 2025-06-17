using QoLCompendium.Content.Items.Tools.PermanentBuffs.Potions;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Upgraded
{
    public class PermanentMovement : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentMovement";

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
            r.AddIngredient(ModContent.ItemType<PermanentFeatherfall>());
            r.AddIngredient(ModContent.ItemType<PermanentGravitation>());
            r.AddIngredient(ModContent.ItemType<PermanentSwiftness>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new MovementEffect());
        }
    }
}
