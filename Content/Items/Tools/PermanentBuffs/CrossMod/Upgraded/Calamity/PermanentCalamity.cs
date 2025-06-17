using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Catalyst;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class PermanentCalamity : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentCalamity";

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
            if (!ModConditions.calamityLoaded)
                return;

            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentCalamityAbyss>());
            r.AddIngredient(ModContent.ItemType<PermanentCalamityArena>());
            r.AddIngredient(ModContent.ItemType<PermanentCalamityDamage>());
            r.AddIngredient(ModContent.ItemType<PermanentCalamityDefense>());
            r.AddIngredient(ModContent.ItemType<PermanentCalamityFarming>());
            r.AddIngredient(ModContent.ItemType<PermanentCalamityMovement>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new CalamityEffect());
        }
    }
}
