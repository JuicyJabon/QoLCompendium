﻿using QoLCompendium.Content.Items.Tools.PermanentBuffs.Arena;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Upgraded
{
    public class PermanentArena : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentArena";

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
            r.AddIngredient(ModContent.ItemType<PermanentBastStatue>());
            r.AddIngredient(ModContent.ItemType<PermanentCampfire>());
            r.AddIngredient(ModContent.ItemType<PermanentGardenGnome>());
            r.AddIngredient(ModContent.ItemType<PermanentHeartLantern>());
            r.AddIngredient(ModContent.ItemType<PermanentHoney>());
            r.AddIngredient(ModContent.ItemType<PermanentPeaceCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentShadowCandle>());
            r.AddIngredient(ModContent.ItemType<PermanentStarInABottle>());
            r.AddIngredient(ModContent.ItemType<PermanentSunflower>());
            r.AddIngredient(ModContent.ItemType<PermanentWaterCandle>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new ArenaEffect());
        }
    }
}
