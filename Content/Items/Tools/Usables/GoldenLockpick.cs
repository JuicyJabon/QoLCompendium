using QoLCompendium.Core;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class GoldenLockpick : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GoldenKey);
            Item.value = Item.sellPrice(gold: 1, silver: 75);
            Item.rare = ItemRarityID.White;
            Item.maxStack = 1;
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().HasGoldenLockpick = true;
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
            if (type != TileID.Containers || (Main.tile[i, j].TileFrameX < 72 || Main.tile[i, j].TileFrameX > 108) || !Main.LocalPlayer.GetModPlayer<QoLCPlayer>().HasGoldenLockpick)
            {
                return;
            }

            i -= Main.tile[i, j].TileFrameX % 36 / 18;
            j -= Main.tile[i, j].TileFrameY % 36 / 18;
            Chest.Unlock(i, j);
        }
    }
}