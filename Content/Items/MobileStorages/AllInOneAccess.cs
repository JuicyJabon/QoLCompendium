using QoLCompendium.Content.Projectiles.MobileStorages;
using QoLCompendium.Core;
using QoLCompendium.Core.UI.Panels;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.MobileStorages
{
    public class AllInOneAccess : ModItem
    {
        public int Mode = 0;

        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 8));
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 24;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 10, 0, 0));
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            SoundEngine.PlaySound(SoundID.Item130, player.Center);
            Mode++;
            if (Mode > 1)
            {
                Mode = 0;
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag["AllInOneAccessMode"] = Mode;
        }

        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("AllInOneAccessMode");
        }

        public override void UpdateInventory(Player player)
        {
            if (Mode == 0)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.AllInOneAccess.Open"));
                player.IsVoidVaultEnabled = true;
            }
            if (Mode == 1)
            {
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.AllInOneAccess.Closed"));
                player.IsVoidVaultEnabled = false;
            }
        }

        public override bool? UseItem(Player player)
        {
            if (!AllInOneAccessUI.visible)
                AllInOneAccessUI.visible = true;
            return base.UseItem(player);
        }

        public override bool CanUseItem(Player player)
        {
            if (AllInOneAccessUI.visible)
                return false;
            else
                return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MobileStorages, Type);
            r.AddIngredient(ItemID.MoneyTrough);
            r.AddIngredient(ModContent.ItemType<EtherianConstruct>());
            r.AddIngredient(ModContent.ItemType<FlyingSafe>());
            r.AddIngredient(ItemID.VoidLens);
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }
    }
}
