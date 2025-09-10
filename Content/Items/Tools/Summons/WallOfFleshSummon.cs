using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Summons
{
    public class WallOfFleshSummon : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.BossSummons;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 6;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 14;
            Item.maxStack = Item.CommonMaxStack;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.SetShopValues(ItemRarityColor.Orange3, Item.sellPrice(0, 0, 0, 0));
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.WallofFlesh);
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnWOF(player.Center);
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.BossSummons);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.SpicyPepper);
            r.AddIngredient(ItemID.Bone, 5);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
