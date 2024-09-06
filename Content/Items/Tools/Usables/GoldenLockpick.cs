using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class GoldenLockpick : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ShimmerTransformToItem[ItemID.GoldenKey] = ModContent.ItemType<GoldenLockpick>();
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GoldenKey);
            Item.SetShopValues(ItemRarityColor.White0, Item.buyPrice(0, 1, 75, 0));
        }

        public override void UpdateInventory(Player player)
        {
            player.GetQoLCPlayer().HasGoldenLockpick = true;
        }

        public static bool UseKey(Item[] inv, int slot, Player player, QoLCPlayer qPlayer)
        {
            if (inv[slot].type == ItemID.LockBox && qPlayer.HasGoldenLockpick)
            {
                if (ItemLoader.ConsumeItem(inv[slot], player))
                {
                    inv[slot].stack--;
                }
                if (inv[slot].stack < 0)
                {
                    inv[slot].SetDefaults();
                }
                SoundEngine.PlaySound(SoundID.Unlock);
                Main.stackSplit = 30;
                Main.mouseRightRelease = false;
                player.OpenLockBox(inv[slot].type);
                Recipe.FindRecipes();
                return true;
            }
            return false;
        }
    }

    public class GoldenLockpickGlobalTile : GlobalTile
    {
        public override void RightClick(int i, int j, int type)
        {
            if (type != TileID.Containers || (Main.tile[i, j].TileFrameX < 72 || Main.tile[i, j].TileFrameX > 108) || !Main.LocalPlayer.GetQoLCPlayer().HasGoldenLockpick)
            {
                return;
            }

            i -= Main.tile[i, j].TileFrameX % 36 / 18;
            j -= Main.tile[i, j].TileFrameY % 36 / 18;
            Chest.Unlock(i, j);
        }
    }
}