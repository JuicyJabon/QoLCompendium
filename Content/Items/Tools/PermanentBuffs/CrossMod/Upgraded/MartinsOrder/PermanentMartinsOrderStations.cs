using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Stations.MartinsOrder;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.MartinsOrder
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class PermanentMartinsOrderStations : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentMartinsOrderStations";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentArcheology>());
            r.AddIngredient(ModContent.ItemType<PermanentSporeFarm>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new MartinsOrderStationsEffect());
        }
    }
}
