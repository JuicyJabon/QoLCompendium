using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Clicker;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Clicker
{
    [JITWhenModsEnabled(ModConditions.clickerClassName)]
    [ExtendsFromMod(ModConditions.clickerClassName)]
    public class PermanentInfluence : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.clickerClassMod, Common.GetModBuff(ModConditions.clickerClassMod, "InfluenceBuff"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.clickerClassMod, "InfluencePotion"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new InfluenceEffect());
        }
    }
}
