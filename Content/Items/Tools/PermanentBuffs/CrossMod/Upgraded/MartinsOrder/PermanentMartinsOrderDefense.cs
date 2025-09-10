using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.MartinsOrder;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.MartinsOrder;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.MartinsOrder
{
    [JITWhenModsEnabled(ModConditions.martainsOrderName)]
    [ExtendsFromMod(ModConditions.martainsOrderName)]
    public class PermanentMartinsOrderDefense : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentMartinsOrderDefense";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentBlackHole>());
            r.AddIngredient(ModContent.ItemType<PermanentBody>());
            r.AddIngredient(ModContent.ItemType<PermanentCharging>());
            r.AddIngredient(ModContent.ItemType<PermanentGourmetFlavor>());
            r.AddIngredient(ModContent.ItemType<PermanentHealing>());
            r.AddIngredient(ModContent.ItemType<PermanentRockskin>());
            r.AddIngredient(ModContent.ItemType<PermanentShielding>());
            r.AddIngredient(ModContent.ItemType<PermanentSoul>());
            r.AddIngredient(ModContent.ItemType<PermanentZincPill>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new MartinsOrderDefenseEffect());
        }
    }
}
