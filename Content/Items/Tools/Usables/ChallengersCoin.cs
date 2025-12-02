using Terraria.Chat;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Usables
{
    public class ChallengersCoin : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.ChallengersCoin;

        public new string LocalizationCategory => "Items.Tools.Usables";

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item4;
            Item.consumable = false;
            Item.SetShopValues(ItemRarityColor.TrashMinus1, Item.buyPrice(0, 2, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.ChallengersCoin);
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].boss)
                {
                    return false;
                }
            }
            return true;
        }

        public override bool? UseItem(Player player)
        {
            string text;
            if (player.altFunctionUse == 2)
            {
                if (Main.GameMode == 3)
                {
                    Main.GameMode = 1;
                    ChangeAllPlayerDifficulty(0);
                    text = Language.GetTextValue("Mods.QoLCompendium.Messages.WorldExpert");
                }
                else
                {
                    Main.GameMode = 3;
                    ChangeAllPlayerDifficulty(3);
                    text = Language.GetTextValue("Mods.QoLCompendium.Messages.WorldJourney");
                }
            }
            else
            {
                switch (Main.GameMode)
                {
                    case 0:
                        Main.GameMode = 1;
                        ChangeAllPlayerDifficulty(0);
                        text = Language.GetTextValue("Mods.QoLCompendium.Messages.WorldExpert");
                        break;
                    case 1:
                        Main.GameMode = 2;
                        ChangeAllPlayerDifficulty(0);
                        text = Language.GetTextValue("Mods.QoLCompendium.Messages.WorldMaster");
                        break;
                    default:
                        Main.GameMode = 0;
                        ChangeAllPlayerDifficulty(0);
                        text = Language.GetTextValue("Mods.QoLCompendium.Messages.WorldNormal");
                        break;
                }
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText(text, new Color(175, 75, 255));
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), new Color(175, 75, 255), -1);
                NetMessage.SendData(MessageID.WorldData);
            }
            SoundEngine.PlaySound(SoundID.Roar, player.Center, null);
            return true;
        }

        private static void ChangeAllPlayerDifficulty(byte diff)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (player.active)
                {
                    player.difficulty = diff;
                    NetMessage.SendData(MessageID.SyncPlayer, -1, -1, null, player.whoAmI, 0f, 0f, 0f, 0, 0, 0);
                }
            }
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.ChallengersCoin.Difficulty" + Main.GameMode.ToString()));
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D coin = (Texture2D)ModContent.Request<Texture2D>($"QoLCompendium/Assets/Items/ChallengersCoin_{Main.GameMode}", (AssetRequestMode)2);
            spriteBatch.Draw(coin, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Texture2D coin = (Texture2D)ModContent.Request<Texture2D>($"QoLCompendium/Assets/Items/ChallengersCoin_{Main.GameMode}", (AssetRequestMode)2);
            Vector2 position = Item.position - Main.screenPosition + new Vector2(16f, 16f);
            Rectangle hitbox = new(0, 0, 32, 32);
            spriteBatch.Draw(coin, position, hitbox, lightColor, rotation, new Vector2(16f, 16f), scale, SpriteEffects.None, 0f);
            return false;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.ChallengersCoin, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 16);
            r.AddIngredient(ItemID.GoldCoin);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
