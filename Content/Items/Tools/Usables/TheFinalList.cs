using QoLCompendium.Core;

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
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Gray;
            Item.UseSound = new SoundStyle?(SoundID.Item29);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(gold: 2);
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
            r.AddIngredient(ItemID.Silk, 6);
            r.AddIngredient(ItemID.BlackInk, 1);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
