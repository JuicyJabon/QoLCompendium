using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Catalyst;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Catalyst
{
    [JITWhenModsEnabled("CatalystMod")]
    [ExtendsFromMod("CatalystMod")]
    public class PermanentAstracola : IPermanentModdedBuffItem
    {
        public override string Texture => Common.ModBuffAsset(ModConditions.catalystMod, Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff"));

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
            if (!ModConditions.catalystLoaded)
                return;

            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.catalystMod, "Lean"), 30);
            r.AddIngredient(ModContent.ItemType<PermanentAstraJelly>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new AstracolaEffect());
        }
    }
}
