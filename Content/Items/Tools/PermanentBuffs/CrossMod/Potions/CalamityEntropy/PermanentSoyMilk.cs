using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.CalamityEntropy;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.CalamityEntropy
{
    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class PermanentSoyMilk : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.calamityEntropyMod, Common.GetModBuff(ModConditions.calamityEntropyMod, "SoyMilkBuff"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityEntropyMod, "SoyMilk"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new SoyMilkEffect());
        }
    }
}