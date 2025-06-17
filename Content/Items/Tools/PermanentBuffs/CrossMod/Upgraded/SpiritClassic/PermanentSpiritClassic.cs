using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SpiritClassic
{
    [JITWhenModsEnabled("SpiritMod")]
    [ExtendsFromMod("SpiritMod")]
    public class PermanentSpiritClassic : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentSpiritClassic";

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
            r.AddIngredient(ModContent.ItemType<PermanentSpiritClassicArena>());
            r.AddIngredient(ModContent.ItemType<PermanentSpiritClassicCandies>());
            r.AddIngredient(ModContent.ItemType<PermanentSpiritClassicDamage>());
            r.AddIngredient(ModContent.ItemType<PermanentSpiritClassicDefense>());
            r.AddIngredient(ModContent.ItemType<PermanentSpiritClassicMovement>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new SpiritClassicEffect());
        }
    }
}
