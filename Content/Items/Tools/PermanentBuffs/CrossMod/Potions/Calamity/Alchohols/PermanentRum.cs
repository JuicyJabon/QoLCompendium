using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity.Alchohols;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Calamity.Alchohols
{
    [JITWhenModsEnabled(ModConditions.calamityName)]
    [ExtendsFromMod(ModConditions.calamityName)]
    public class PermanentRum : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.calamityMod, Common.GetModBuff(ModConditions.calamityMod, "RumBuff"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "Rum"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new RumEffect());
        }
    }
}
