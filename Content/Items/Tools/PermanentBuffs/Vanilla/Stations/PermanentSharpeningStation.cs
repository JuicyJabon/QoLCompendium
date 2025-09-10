using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Stations;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Stations
{
    public class PermanentSharpeningStation : IPermanentBuffItem
    {
        public override void SetDefaults()
        {
            Common.SetDefaultsToPermanentBuff(Item);
            buffIDForSprite = BuffID.Sharpened;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.SharpeningStation, 3);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new SharpeningStationEffect());
        }
    }
}
