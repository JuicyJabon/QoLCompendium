using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Arena.CalamityEntropy;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.CalamityEntropy;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.CalamityEntropy;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.CalamityEntropy
{
    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
    public class PermanentCalamityEntropy : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentCalamityEntropy";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentVoidCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentYharimsStimulants>());
            r.AddIngredient(ModContent.ItemType<PermanentSoyMilk>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new CalamityEntropyEffect());
        }
    }
}
