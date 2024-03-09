using Terraria.GameContent.Events;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class MiniSundial : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = new SoundStyle?(SoundID.MenuTick);
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.value = Item.sellPrice(silver: 90);
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.MiniSundial)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Obsidian, 12)
                .AddIngredient(ItemID.SunplateBlock, 12)
                .AddTile(TileID.SkyMill)
                .Register();
            }
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
