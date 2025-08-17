using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Thorium;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Thorium
{
    [JITWhenModsEnabled("ThoriumMod")]
    [ExtendsFromMod("ThoriumMod")]
    public class PermanentThoriumDamage : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentThoriumDamage";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentArtillery>());
            r.AddIngredient(ModContent.ItemType<PermanentBouncingFlames>());
            r.AddIngredient(ModContent.ItemType<PermanentCactusFruit>());
            r.AddIngredient(ModContent.ItemType<PermanentConflagration>());
            r.AddIngredient(ModContent.ItemType<PermanentFrenzy>());
            r.AddIngredient(ModContent.ItemType<PermanentWarmonger>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new ThoriumDamageEffect());
        }
    }
}
