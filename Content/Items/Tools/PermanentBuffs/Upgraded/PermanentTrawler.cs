using QoLCompendium.Content.Items.Tools.PermanentBuffs.Potions;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Upgraded
{
    public class PermanentTrawler : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentTrawler";

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
            r.AddIngredient(ModContent.ItemType<PermanentCrate>());
            r.AddIngredient(ModContent.ItemType<PermanentFishing>());
            r.AddIngredient(ModContent.ItemType<PermanentSonar>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new TrawlerEffect());
        }
    }
}
