using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class BottomlessLiquidBucket : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.BottomlessBuckets;

        public int Mode = 0;

        internal enum LiquidTypes : byte
        {
            Water,
            Lava,
            Honey,
            Shimmer
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.autoReuse = true;
            Item.width = 15;
            Item.height = 14;
            Item.SetShopValues(ItemRarityColor.Yellow8, Item.sellPrice(0, 20, 0, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag["BottomlessLiquidBucketMode"] = Mode;
        }

        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("BottomlessLiquidBucketMode");
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 3)
            {
                Mode = 0;
            }
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override bool? UseItem(Player player)
        {
            if (Mode == 0)
            {
                UseBucket(player, LiquidTypes.Water);
            }
            if (Mode == 1)
            {
                UseBucket(player, LiquidTypes.Lava);
            }
            if (Mode == 2)
            {
                UseBucket(player, LiquidTypes.Honey);
            }
            if (Mode == 3)
            {
                UseBucket(player, LiquidTypes.Shimmer);
            }
            return true;
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.BottomlessLiquidBucket.Liquid" + Mode.ToString()));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.BottomlessBuckets);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BottomlessBuckets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.BottomlessBucket);
            r.AddIngredient(ItemID.BottomlessLavaBucket);
            r.AddIngredient(ItemID.BottomlessHoneyBucket);
            r.AddIngredient(ItemID.BottomlessShimmerBucket);
            r.AddTile(TileID.HeavyWorkBench);
            r.Register();
        }

        internal static bool PlaceLiquid(int x, int y, LiquidTypes type)
        {
            Tile tileSafely = Framing.GetTileSafely(x, y);
            if (tileSafely.LiquidAmount < 230 && (!tileSafely.HasUnactuatedTile || !Main.tileSolid[tileSafely.TileType] || Main.tileSolidTop[tileSafely.TileType]) && (tileSafely.LiquidAmount == 0 || tileSafely.LiquidType == (int)type))
            {
                tileSafely.LiquidType = (int)type;
                tileSafely.LiquidAmount = byte.MaxValue;
                WorldGen.SquareTileFrame(x, y, true);
                if (Main.netMode != NetmodeID.SinglePlayer)
                {
                    NetMessage.sendWater(x, y);
                }
                return true;
            }
            return false;
        }

        internal static bool UseBucket(Player player, LiquidTypes type)
        {
            if (player.whoAmI == Main.myPlayer && !player.noBuilding && PlaceLiquid(Player.tileTargetX, Player.tileTargetY, type))
                SoundEngine.PlaySound(SoundID.Item19, player.Center);
            return true;
        }
    }
}
