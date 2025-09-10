using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Upgraded
{
    public class PermanentVanilla : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentVanilla";

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
            r.AddIngredient(ModContent.ItemType<PermanentAquatic>());
            r.AddIngredient(ModContent.ItemType<PermanentArena>());
            r.AddIngredient(ModContent.ItemType<PermanentConstruction>());
            r.AddIngredient(ModContent.ItemType<PermanentDamage>());
            r.AddIngredient(ModContent.ItemType<PermanentDefense>());
            r.AddIngredient(ModContent.ItemType<PermanentMovement>());
            r.AddIngredient(ModContent.ItemType<PermanentStation>());
            r.AddIngredient(ModContent.ItemType<PermanentTrawler>());
            r.AddIngredient(ModContent.ItemType<PermanentVision>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new VanillaEffect());
        }
    }
}
