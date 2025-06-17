using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;
using Terraria.GameContent.Events;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class MiniSundial : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.MiniSundial;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.useAnimation = 20;
            Item.useTime = 20;

            Item.SetShopValues(ItemRarityColor.Orange3, Item.buyPrice(0, 0, 90, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.MiniSundial);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.MiniSundial, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.Obsidian, 12);
            r.AddIngredient(ItemID.SunplateBlock, 12);
            r.AddTile(TileID.SkyMill);
            r.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return !Main.IsFastForwardingTime();
        }

        public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
            {
                Main.sundialCooldown = 0;
                SoundEngine.PlaySound(SoundID.Item4, player.position);

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.MiscDataSync, number: Main.myPlayer, number2: 3f);
                    return true;
                }

                if (Main.dayTime)
                    Main.fastForwardTimeToDusk = true;
                else
                    Main.fastForwardTimeToDawn = true;
                NetMessage.SendData(MessageID.WorldData);
            }
            else
            {
                int noon = 27000;
                int midnight = 16200;
                if (Main.dayTime && Main.time < noon)
                {
                    Main.time = noon;
                }
                else if (Main.time < midnight)
                {
                    Main.time = midnight;
                }
                else
                {
                    Main.dayTime = !Main.dayTime;
                    Main.time = 0;

                    if (Main.dayTime)
                    {
                        BirthdayParty.CheckMorning();
                        Chest.SetupTravelShop();
                    }
                    else
                    {
                        BirthdayParty.CheckNight();
                        if (!Main.dayTime && ++Main.moonPhase > 7)
                            Main.moonPhase = 0;
                    }
                }
            }

            return true;
        }
    }
}
