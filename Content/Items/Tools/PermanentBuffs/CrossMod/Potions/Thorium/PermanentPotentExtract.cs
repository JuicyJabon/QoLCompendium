using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Thorium
{
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class PermanentPotentExtract : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.thoriumMod, Common.GetModBuff(ModConditions.thoriumMod, "PotentExtractBuff"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.thoriumMod, "PotentExtract"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new PotentExtractEffect());
        }
    }
}
