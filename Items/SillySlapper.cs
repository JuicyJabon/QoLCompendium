using Microsoft.Xna.Framework;
using QoLCompendium.Tweaks;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    public class SillySlapper : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new(Mod, "Dedicated", "Dedicated")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 20;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.sellPrice(gold: 3);
            Item.accessory = true;
        }

        public override void AddRecipes()
        {
            if (ModContent.GetInstance<ItemConfig>().DedicatedItems)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Gel, 100)
                .AddIngredient(ItemID.FallenStar, 50)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.GetModPlayer<QoLCPlayer>().sillySlapper = true;
        }
    }
}
