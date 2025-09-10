using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Thorium;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Thorium
{
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class PermanentThoriumRepellent : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentThoriumRepellent";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentBatRepellent>());
            r.AddIngredient(ModContent.ItemType<PermanentFishRepellent>());
            r.AddIngredient(ModContent.ItemType<PermanentInsectRepellent>());
            r.AddIngredient(ModContent.ItemType<PermanentSkeletonRepellent>());
            r.AddIngredient(ModContent.ItemType<PermanentZombieRepellent>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new ThoriumRepellentEffect());
        }
    }
}
