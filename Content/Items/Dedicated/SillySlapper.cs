using QoLCompendium.Content.Projectiles.Dedicated;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Dedicated
{
    public class SillySlapper : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.DedicatedItems;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 19;

            Item.accessory = true;
            Item.autoReuse = true;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item152;
            
            Item.damage = 100;
            Item.DamageType = DamageClass.Generic;
            Item.knockBack = 2;
            Item.shootSpeed = 5;
            Item.shoot = ModContent.ProjectileType<SillySlapperWhip>();

            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 8, 0, 0));
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.GetModPlayer<QoLCPlayer>().sillySlapper = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.GetModPlayer<QoLCPlayer>().sillySlapper = true;
        }

        public override void HoldItem(Player player)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.GetModPlayer<QoLCPlayer>().sillySlapper = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine dedicated = new(Mod, "Dedicated", Language.GetTextValue("Mods.QoLCompendium.DedicatedTooltips.Quinn"))
            {
                OverrideColor = Common.ColorSwap(Color.LightSeaGreen, Color.Aquamarine, 3)
            };
            tooltips.Add(dedicated);

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.DedicatedItems);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.DedicatedItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Gel, 100);
            r.AddIngredient(ItemID.FallenStar, 50);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
