using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.MartinsOrder
{
    [JITWhenModsEnabled("MartainsOrder")]
    [ExtendsFromMod("MartainsOrder")]
    public class PermanentMartinsOrder : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentMartinsOrder";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentMartinsOrderDamage>());
            r.AddIngredient(ModContent.ItemType<PermanentMartinsOrderDefense>());
            r.AddIngredient(ModContent.ItemType<PermanentMartinsOrderStations>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new MartinsOrderEffect());
        }
    }
}
