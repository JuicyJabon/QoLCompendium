using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class HellstoneMagnet : BaseMagnet, ILocalizedModType
    {
        public override bool Enabled { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 2, 0, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("HellstoneMagnetEnabled", Enabled);
        }

        public override void LoadData(TagCompound tag)
        {
            Enabled = tag.GetBool("HellstoneMagnetEnabled");
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<Magnet>());
            r.AddIngredient(ItemID.HellstoneBar, 10);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
