using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.SpiritClassic;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.SpiritClassic
{
    [JITWhenModsEnabled(ModConditions.spiritClassicName)]
    [ExtendsFromMod(ModConditions.spiritClassicName)]
    public class PermanentMoonJelly : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.spiritClassicMod, Common.GetModBuff(ModConditions.spiritClassicMod, "MoonBlessing"));

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.spiritClassicMod, "MoonJelly"), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new MoonJellyEffect());
        }
    }
}
