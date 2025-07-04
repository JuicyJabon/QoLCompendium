﻿using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.Clamity;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Clamity;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Clamity
{
    [JITWhenModsEnabled("Clamity")]
    [ExtendsFromMod("Clamity")]
    public class PermanentClamity : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentClamity";

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
            r.AddIngredient(ModContent.ItemType<PermanentExoBaguette>());
            r.AddIngredient(ModContent.ItemType<PermanentSupremeLuck>());
            r.AddIngredient(ModContent.ItemType<PermanentTitanScale>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new ClamityEffect());
        }
    }
}
