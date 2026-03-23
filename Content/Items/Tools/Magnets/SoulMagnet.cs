using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class SoulMagnet : BaseMagnet, ILocalizedModType
    {
        public override bool Enabled { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.SetShopValues(ItemRarityColor.Pink5, Item.buyPrice(0, 3, 0, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SoulMagnetEnabled", Enabled);
        }

        public override void LoadData(TagCompound tag)
        {
            Enabled = tag.GetBool("SoulMagnetEnabled");
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<HellstoneMagnet>());
            r.AddIngredient(ItemID.SoulofNight, 5);
            r.AddIngredient(ItemID.SoulofLight, 5);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
