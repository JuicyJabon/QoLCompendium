using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Calamity;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class PermanentCalamityAbyss : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentCalamityAbyss";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentAnechoicCoating>());
            r.AddIngredient(ModContent.ItemType<PermanentOmniscience>());
            r.AddIngredient(ModContent.ItemType<PermanentSulphurskin>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new CalamityAbyssEffect());
        }
    }
}
