using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Accessories.Construction
{
    public class CreationClubMembersPass : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.ConstructionAccessories;


        public override void SetDefaults()
        {
            Item.width = 21;
            Item.height = 13;
            Item.maxStack = 1;
            Item.SetShopValues(ItemRarityColor.Lime7, Item.buyPrice(0, 10, 0, 0));
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.tileSpeed += 0.25f; //CONSTRUCTION EMBLEM
            player.wallSpeed += 0.25f; //CONSTRUCTION EMBLEM
            player.pickSpeed -= 0.25f; //MINING EMBLEM

            player.equippedAnyTileSpeedAcc = true; //BRICK LAYER
            player.equippedAnyTileRangeAcc = true; //EXTENDO GRIP
            player.autoPaint = true; //PAINT SPRAYER
            player.equippedAnyWallSpeedAcc = true; //PORTABLE CEMENT MIXER
            player.chiselSpeed = true; //ANCIENT CHISEL
            player.treasureMagnet = true; //TREASURE MAGNET
            player.portableStoolInfo.SetStats(26, 26, 26); //STEP STOOL

            player.autoActuator = true; //PRESSERATOR

            player.blockRange += 1; //TOOLBELT

            Player.tileRangeX += 1; //TOOLBOX
            Player.tileRangeY += 1; //TOOLBOX

            player.CanSeeInvisibleBlocks = true; //SPECTRE GOGGLES
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.ConstructionAccessories);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.ConstructionAccessories, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<MiningEmblem>());
            r.AddIngredient(ModContent.ItemType<ConstructionEmblem>());
            r.AddIngredient(ItemID.HandOfCreation);
            r.AddIngredient(ItemID.Toolbelt);
            r.AddIngredient(ItemID.Toolbox);
            r.AddIngredient(ItemID.ActuationAccessory);
            r.AddIngredient(ItemID.SpectreGoggles);
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }
    }
}
