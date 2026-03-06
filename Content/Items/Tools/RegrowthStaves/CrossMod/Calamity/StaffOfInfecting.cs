using QoLCompendium.Content.Tiles.Other;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.RegrowthStaves.CrossMod.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class StaffOfInfecting : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.RegrowthStaves;

        public new string LocalizationCategory => "Items.Tools.RegrowthStaves";


        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 25;
            Item.useTime = 13;
            Item.autoReuse = true;
            Item.width = 24;
            Item.height = 28;
            Item.damage = 7;
            Item.createTile = ModContent.TileType<NothingTile>();
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 3f;
            Item.SetShopValues(ItemRarityColor.LightRed4, Item.sellPrice(0, 0, 50));
            Item.DamageType = DamageClass.Melee;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine placeable = tooltips.Find(l => l.Name == "Placeable");
            TooltipLine text = new(Mod, "StaffOfInfectingEffect", Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.StaffOfInfectingPlaceable"));
            tooltips.Insert(tooltips.IndexOf(placeable), text);
            tooltips.RemoveAll((x) => x.Name == "Placeable" && x.Mod == "Terraria");

            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.RegrowthStaves);
        }

        public override bool? UseItem(Player player)
        {
            int tileX = Player.tileTargetX;
            int tileY = Player.tileTargetY;
            Tile tile = Framing.GetTileSafely(tileX, tileY);
            if (tile.HasTile && tile.TileType == Common.GetModTile(CrossModSupport.Calamity.Mod, "AstralDirt") && player.IsInTileInteractionRange(tileX, tileY, TileReachCheckSettings.Simple))
            {
                tile.TileType = (ushort)Common.GetModTile(CrossModSupport.Calamity.Mod, "AstralGrass");
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendTileSquare(player.whoAmI, tileX, tileY, TileChangeType.None);
                }
                SoundEngine.PlaySound(SoundID.Dig, player.Center);
                return true;
            }
            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.RegrowthStaves, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralMonolith"), 12);
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "StarblightSoot"), 3);
            r.AddIngredient(Common.GetModItem(CrossModSupport.Calamity.Mod, "AstralGrassSeeds"), 1);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
