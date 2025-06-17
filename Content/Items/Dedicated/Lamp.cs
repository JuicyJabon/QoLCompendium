﻿using QoLCompendium.Content.Buffs;
using QoLCompendium.Content.Projectiles.Dedicated;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class Lamp : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DedicatedItems;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);

            Item.shoot = ModContent.ProjectileType<Moth>();
            Item.buffType = ModContent.BuffType<MothBuff>();

            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 5, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<MothBuff>()))
            {
                return false;
            }
            return base.CanUseItem(player);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", Language.GetTextValue("Mods.QoLCompendium.DedicatedTooltips.Jack"))
            {
                OverrideColor = Common.ColorSwap(Color.LightSeaGreen, Color.Aquamarine, 3)
            };
            tooltips.Add(dedicated);

            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DedicatedItems);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.PurpleMucos);
            r.AddIngredient(ItemID.Wire, 17);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
