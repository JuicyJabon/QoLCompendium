using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.SpiritClassic.Candies;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SpiritClassic
{
    [JITWhenModsEnabled(ModConditions.spiritClassicName)]
    [ExtendsFromMod(ModConditions.spiritClassicName)]
    public class PermanentSpiritClassicCandies : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentSpiritClassicCandies";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentCandy>());
            r.AddIngredient(ModContent.ItemType<PermanentChocolateBar>());
            r.AddIngredient(ModContent.ItemType<PermanentHealthCandy>());
            r.AddIngredient(ModContent.ItemType<PermanentLollipop>());
            r.AddIngredient(ModContent.ItemType<PermanentManaCandy>());
            r.AddIngredient(ModContent.ItemType<PermanentTaffy>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new SpiritClassicCandyEffect());
        }
    }
}
