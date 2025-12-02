using QoLCompendium.Core.UI.Panels;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class EntityManipulator : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EntityManipulator;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.MenuOpen;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Green2, Item.buyPrice(0, 5, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EntityManipulator);
        }

        public override bool? UseItem(Player player)
        {
            if (!EntityManipulatorUI.visible) EntityManipulatorUI.timeStart = Main.GameUpdateCount;
            EntityManipulatorUI.visible = true;

            return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.EntityManipulator, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.BattlePotion, 10);
            r.AddIngredient(ItemID.WaterCandle, 3);
            r.AddIngredient(ItemID.CalmingPotion, 10);
            r.AddIngredient(ItemID.PeaceCandle, 3);
            r.AddTile(TileID.Anvils);
            r.Register();
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.EntityManipulator.SpawnModifier" + player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier.ToString()));

            if (Item.favorited)
            {
                player.GetModPlayer<QoLCPlayer>().activeItems.Add(Item.type);

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 1)
                    player.GetModPlayer<QoLCPlayer>().increasedSpawns = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 2)
                    player.GetModPlayer<QoLCPlayer>().decreasedSpawns = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 3)
                    player.GetModPlayer<QoLCPlayer>().noSpawns = true;

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 4)
                    Common.DisableEvents();

                if (player.GetModPlayer<QoLCPlayer>().selectedSpawnModifier == 5)
                {
                    player.GetModPlayer<QoLCPlayer>().noSpawns = true;
                    Common.DisableEvents();
                }
            }
        }
    }
}
