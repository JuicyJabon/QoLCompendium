using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Thorium;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Thorium
{
    [JITWhenModsEnabled("ThoriumMod")]
    [ExtendsFromMod("ThoriumMod")]
    public class PermanentThoriumMovement : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentThoriumMovement";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentAquaAffinity>());
            r.AddIngredient(ModContent.ItemType<PermanentBloodRush>());
            r.AddIngredient(ModContent.ItemType<PermanentKinetic>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new ThoriumMovementEffect());
        }
    }
}
