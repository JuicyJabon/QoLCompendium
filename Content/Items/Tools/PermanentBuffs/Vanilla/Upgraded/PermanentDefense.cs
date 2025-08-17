using QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Potions;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Upgraded
{
    public class PermanentDefense : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentDefense";

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
            r.AddIngredient(ModContent.ItemType<PermanentEndurance>());
            r.AddIngredient(ModContent.ItemType<PermanentExquisitelyStuffed>());
            r.AddIngredient(ModContent.ItemType<PermanentHeartreach>());
            r.AddIngredient(ModContent.ItemType<PermanentInferno>());
            r.AddIngredient(ModContent.ItemType<PermanentIronskin>());
            r.AddIngredient(ModContent.ItemType<PermanentLifeforce>());
            r.AddIngredient(ModContent.ItemType<PermanentObsidianSkin>());
            r.AddIngredient(ModContent.ItemType<PermanentRegeneration>());
            r.AddIngredient(ModContent.ItemType<PermanentThorns>());
            r.AddIngredient(ModContent.ItemType<PermanentWarmth>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new DefenseEffect());
        }
    }
}
