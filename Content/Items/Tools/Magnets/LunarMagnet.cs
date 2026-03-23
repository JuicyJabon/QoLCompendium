using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class LunarMagnet : BaseMagnet, ILocalizedModType
    {
        public override bool Enabled { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.buyPrice(0, 8, 0, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("LunarMagnetEnabled", Enabled);
        }

        public override void LoadData(TagCompound tag)
        {
            Enabled = tag.GetBool("LunarMagnetEnabled");
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<SpectreMagnet>());
            r.AddIngredient(ItemID.LunarBar, 10);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
