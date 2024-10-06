using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class TheFinalList : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 15;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.TrashMinus1, Item.buyPrice(0, 0, 0, 0));
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < NPCLoader.NPCCount; i++)
            {
                string persistentId = ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[i];
                Main.BestiaryTracker.Kills.SetKillCountDirectly(persistentId, 50);
                Main.BestiaryTracker.Sights.SetWasSeenDirectly(persistentId);
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.TheFinalList, Type);
            r.AddIngredient(ItemID.LunarBar, 12);
            r.AddIngredient(ItemID.Wood, 12);
            r.AddIngredient(ItemID.RichMahogany, 12);
            r.AddIngredient(ItemID.Ebonwood, 12);
            r.AddIngredient(ItemID.Shadewood, 12);
            r.AddIngredient(ItemID.Pearlwood, 12);
            r.AddIngredient(ItemID.BorealWood, 12);
            r.AddIngredient(ItemID.PalmWood, 12);
            r.AddIngredient(ItemID.DynastyWood, 12);
            r.AddIngredient(ItemID.AshWood, 12);
            r.AddIngredient(ItemID.StoneBlock, 12);
            r.AddIngredient(ItemID.Granite, 12);
            r.AddIngredient(ItemID.Marble, 12);
            r.AddIngredient(ItemID.Cloud, 12);
            r.AddIngredient(ItemID.Silk, 8);
            r.AddIngredient(ItemID.BlackDye, 1);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
