using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.SOTS;
using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Stations.SOTS;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SOTS;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SOTS
{
    [JITWhenModsEnabled(ModConditions.secretsOfTheShadowsName)]
    [ExtendsFromMod(ModConditions.secretsOfTheShadowsName)]
    public class PermanentSecretsOfTheShadows : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentSecretsOfTheShadows";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentAssassination>());
            r.AddIngredient(ModContent.ItemType<PermanentBluefire>());
            r.AddIngredient(ModContent.ItemType<PermanentBrittle>());
            r.AddIngredient(ModContent.ItemType<PermanentDoubleVision>());
            r.AddIngredient(ModContent.ItemType<PermanentHarmony>());
            r.AddIngredient(ModContent.ItemType<PermanentNightmare>());
            r.AddIngredient(ModContent.ItemType<PermanentRipple>());
            r.AddIngredient(ModContent.ItemType<PermanentRoughskin>());
            r.AddIngredient(ModContent.ItemType<PermanentSoulAccess>());
            r.AddIngredient(ModContent.ItemType<PermanentVibe>());
            r.AddIngredient(ModContent.ItemType<PermanentDigitalDisplay>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new SecretsOfTheShadowsEffect());
        }
    }
}
