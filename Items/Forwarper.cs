using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items
{
    // Token: 0x02000023 RID: 35
    public class Forwarper : ModItem
    {
        // Token: 0x060000DB RID: 219 RVA: 0x0000FDA4 File Offset: 0x0000DFA4
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().Forwarper;
        }

        // Token: 0x060000DC RID: 220 RVA: 0x0000FDB0 File Offset: 0x0000DFB0
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Switches the time from day to night, and vise-versa");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0000FDD8 File Offset: 0x0000DFD8
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
        }

        // Token: 0x060000DE RID: 222 RVA: 0x0000FE5E File Offset: 0x0000E05E
        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<Forwarper>(), 1).AddIngredient(ItemID.Obsidian, 4).AddIngredient(ItemID.Sapphire, 4).AddIngredient(ItemID.Amber, 4).AddTile(TileID.Anvils).Register();
        }

        // Token: 0x060000DF RID: 223 RVA: 0x0000FE9C File Offset: 0x0000E09C
        public override bool? UseItem(Player player)
        {
            if (Main.dayTime)
            {
                Main.dayTime = false;
                Main.time = 0.0;
                BirthdayParty.CheckMorning();
                Chest.SetupTravelShop();
            }
            else
            {
                Main.dayTime = true;
                Main.time = 0.0;
                BirthdayParty.CheckNight();
                if (!Main.dayTime && ++Main.moonPhase > 7)
                {
                    Main.moonPhase = 0;
                }
            }
            return new bool?(true);
        }
    }
}
