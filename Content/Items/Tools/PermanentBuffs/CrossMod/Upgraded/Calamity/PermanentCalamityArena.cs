using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Arena.Calamity;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Calamity
{
    [JITWhenModsEnabled("CalamityMod")]
    [ExtendsFromMod("CalamityMod")]
    public class PermanentCalamityArena : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentCalamityArena";

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
            r.AddIngredient(ModContent.ItemType<PermanentCorruptionEffigy>());
            r.AddIngredient(ModContent.ItemType<PermanentCrimsonEffigy>());
            r.AddIngredient(ModContent.ItemType<PermanentEffigyOfDecay>());
            r.AddIngredient(ModContent.ItemType<PermanentResilientCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentSpitefulCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentVigorousCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentWeightlessCandle>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new CalamityArenaEffect());
        }
    }
}
