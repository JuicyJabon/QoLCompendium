using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class SpectreMagnet : BaseMagnet, ILocalizedModType
    {
        public override bool Enabled { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.SetShopValues(ItemRarityColor.Yellow8, Item.buyPrice(0, 4, 0, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SpectreMagnetEnabled", Enabled);
        }

        public override void LoadData(TagCompound tag)
        {
            Enabled = tag.GetBool("SpectreMagnetEnabled");
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<SoulMagnet>());
            r.AddIngredient(ItemID.SpectreBar, 10);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
