using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Flasks;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Flasks
{
    public class PermanentFlaskOfCursedFlames : IPermanentBuffItem
    {
        public override void SetDefaults()
        {
            Common.SetDefaultsToPermanentBuff(Item);
            buffIDForSprite = BuffID.WeaponImbueCursedFlames;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.FlaskofCursedFlames, 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new WeaponImbueCursedFlamesEffect());
        }
    }
}
