using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Arena.Calamity;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Calamity;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class PermanentCalamityFarming : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentCalamityFarming";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentZen>());
            r.AddIngredient(ModContent.ItemType<PermanentTranquilityCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentZerg>());
            r.AddIngredient(ModContent.ItemType<PermanentChaosCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentCeaselessHunger>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new CalamityFarmingEffect());
        }
    }
}
