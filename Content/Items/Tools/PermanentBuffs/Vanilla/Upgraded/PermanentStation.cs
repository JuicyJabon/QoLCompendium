using QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Stations;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Upgraded
{
    public class PermanentStation : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentStation";

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
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentAmmoBox>());
            r.AddIngredient(ModContent.ItemType<PermanentBewitchingTable>());
            r.AddIngredient(ModContent.ItemType<PermanentCrystalBall>());
            r.AddIngredient(ModContent.ItemType<PermanentSharpeningStation>());
            r.AddIngredient(ModContent.ItemType<PermanentSliceOfCake>());
            r.AddIngredient(ModContent.ItemType<PermanentWarTable>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new StationEffect());
        }
    }
}
