using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Magnets
{
    public class Magnet : BaseMagnet, ILocalizedModType
    {
        public override bool Enabled { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("MagnetEnabled", Enabled);
        }

        public override void LoadData(TagCompound tag)
        {
            Enabled = tag.GetBool("MagnetEnabled");
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Magnets, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
