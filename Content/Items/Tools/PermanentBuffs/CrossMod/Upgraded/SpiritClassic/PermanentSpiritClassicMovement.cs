using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.SpiritClassic;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.SpiritClassic
{
    [JITWhenModsEnabled(ModConditions.spiritClassicName)]
    [ExtendsFromMod(ModConditions.spiritClassicName)]
    public class PermanentSpiritClassicMovement : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentSpiritClassicMovement";

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentJump>());
            r.AddIngredient(ModContent.ItemType<PermanentSpiritSoaring>());
            r.AddIngredient(ModContent.ItemType<PermanentZephyr>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new SpiritClassicMovementEffect());
        }
    }
}
