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
            if (QoLCompendium.itemConfig.TheFinalList)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Wood, 12)
                .AddIngredient(ItemID.RichMahogany, 12)
                .AddIngredient(ItemID.Ebonwood, 12)
                .AddIngredient(ItemID.Shadewood, 12)
                .AddIngredient(ItemID.Pearlwood, 12)
                .AddIngredient(ItemID.BorealWood, 12)
                .AddIngredient(ItemID.PalmWood, 12)
                .AddIngredient(ItemID.DynastyWood, 12)
                .AddIngredient(ItemID.AshWood, 12)
                .AddIngredient(ItemID.StoneBlock, 12)
                .AddIngredient(ItemID.Granite, 12)
                .AddIngredient(ItemID.Marble, 12)
                .AddIngredient(ItemID.Cloud, 12)
                .AddIngredient(ItemID.Silk, 6)
                .AddIngredient(ItemID.BlackInk, 1)
                .AddTile(TileID.Anvils)
                .Register();
            }
        }
    }
}
