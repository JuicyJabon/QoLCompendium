namespace QoLCompendium.Content.Items.Weapons.Ammo
{
    public abstract class BaseAmmo : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EndlessAmmo;

        public new string LocalizationCategory => "Items.Weapons.Ammo";

        public abstract int AmmunitionItem { get; }

        public int IngredientStackCount = 3996;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(AmmunitionItem);
            Item.width = 26;
            Item.height = 26;
            Item.consumable = false;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1);
            if (Item.rare < ItemRarityID.Green)
                Item.rare = ItemRarityID.Green;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EndlessAmmo);

            TooltipLine ammo = tooltips.Find(l => l.Name == "Ammo");
            TooltipLine material = tooltips.Find(l => l.Name == "Material");
            
            if (AmmunitionItem < ItemID.Count)
            {
                for (int i = 0; i < Lang.GetTooltip(AmmunitionItem).Lines; i++)
                {
                    TooltipLine text = new(Mod, "AmmoDescription", Lang.GetTooltip(AmmunitionItem).GetLine(i));
                    
                    if (material != null && text.Text.Length > 0)
                        tooltips.Insert(tooltips.IndexOf(material) + 1 + i, text);
                    else if (ammo != null && text.Text.Length > 0)
                        tooltips.Insert(tooltips.IndexOf(ammo) + 1 + i, text);
                }
            }
            else
            {
                TooltipLine text = new(Mod, "AmmoDescription", ItemLoader.GetItem(AmmunitionItem).Tooltip.ToString());
                
                if (material != null && text.Text.Length > 0)
                    tooltips.AddAfter(material, text);
                else if (ammo != null && text.Text.Length > 0)
                    tooltips.AddAfter(ammo, text);
            }
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(AmmunitionItem, IngredientStackCount);
            r.AddTile(TileID.Solidifier);
            r.Register();
        }
    }
}
