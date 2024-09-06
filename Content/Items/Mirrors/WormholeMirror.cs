using QoLCompendium.Core;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Mirrors
{
    public class WormholeMirror : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 2, 0, 0));
        }

        public override bool CanUseItem(Player player) => false;

        public override void Load()
        {
            On_Player.HasUnityPotion += Player_HasUnityPotion;
            On_Player.TakeUnityPotion += Player_TakeUnityPotion;
        }

        private static void Player_TakeUnityPotion(On_Player.orig_TakeUnityPotion orig, Player self)
        {
            if (self.HasItem(ModContent.ItemType<WormholeMirror>()) || self.HasItem(ModContent.ItemType<MosaicMirror>()))
                return;
            orig(self);
        }

        private static bool Player_HasUnityPotion(On_Player.orig_HasUnityPotion orig, Player self)
        {
            if (self.HasItem(ModContent.ItemType<WormholeMirror>()) || self.HasItem(ModContent.ItemType<MosaicMirror>()))
                return true;
            return orig(self);
        }

        /*
        public override void UpdateInventory(Player player)
        {
            if (player.whoAmI != Main.myPlayer || !Main.mapFullscreen || !Main.mouseLeft || !Main.mouseLeftRelease)
                return;

            PlayerInput.SetZoom_Unscaled();
            float scale = 16f / Main.mapFullscreenScale;
            Vector2 mapPos = new(Main.mapFullscreenPos.X * 16f - 10f, Main.mapFullscreenPos.Y * 16f - 21f);
            Vector2 mousePos = new(Main.mouseX - Main.screenWidth / 2, Main.mouseY - Main.screenHeight / 2);
            Vector2 destination = new(mapPos.X + mousePos.X * scale, mapPos.Y + mousePos.Y * scale);
            for (int i = 0; i < Main.player.Length; i++)
            {
                Player teleportPlayer = Main.player[i];
                if (teleportPlayer.whoAmI != Main.myPlayer && teleportPlayer.active && !teleportPlayer.dead && player.team == teleportPlayer.team && !teleportPlayer.hostile)
                {
                    Vector2 negativeBounds = new(teleportPlayer.position.X - 14f * scale, teleportPlayer.position.Y - 14f * scale);
                    Vector2 positiveBounds = new(teleportPlayer.position.X + 14f * scale, teleportPlayer.position.Y + 14f * scale);
                    if (destination.X >= negativeBounds.X && destination.X <= positiveBounds.X && destination.Y >= negativeBounds.Y && destination.Y <= positiveBounds.Y)
                    {
                        Main.mouseLeftRelease = false;
                        Main.mapFullscreen = false;
                        player.UnityTeleport(teleportPlayer.position);
                        PlayerInput.SetZoom_Unscaled();
                        return;
                    }
                }
            }
            for (int j = 0; j < Main.npc.Length; j++)
            {
                NPC teleportNPC = Main.npc[j];
                if (teleportNPC.active && teleportNPC.townNPC)
                {
                    Vector2 withinHeadSprite = new(TextureAssets.NpcHead[NPC.TypeToDefaultHeadIndex(teleportNPC.type)].Value.Width / 2, TextureAssets.NpcHead[NPC.TypeToDefaultHeadIndex(teleportNPC.type)].Value.Height / 2);
                    Vector2 negativeBounds = new(teleportNPC.position.X - withinHeadSprite.X * scale, teleportNPC.position.Y - withinHeadSprite.Y * scale);
                    Vector2 positiveBounds = new(teleportNPC.position.X + withinHeadSprite.X * scale, teleportNPC.position.Y + withinHeadSprite.Y * scale);
                    if (destination.X >= negativeBounds.X && destination.X <= positiveBounds.X && destination.Y >= negativeBounds.Y && destination.Y <= positiveBounds.Y)
                    {
                        Main.mouseLeftRelease = false;
                        Main.mapFullscreen = false;
                        player.Teleport(teleportNPC.position + new Vector2(0f, -6f));
                        PlayerInput.SetZoom_Unscaled();
                        return;
                    }
                }
            }
        }
        */

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.Mirrors, Type);
            r.AddIngredient(ItemID.Glass, 10);
            r.AddRecipeGroup(RecipeGroupID.IronBar, 8);
            r.AddIngredient(ItemID.WormholePotion, 3);
            r.AddTile(TileID.Furnaces);
            r.Register();
        }
    }
}
