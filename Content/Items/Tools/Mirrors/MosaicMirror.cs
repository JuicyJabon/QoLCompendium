using QoLCompendium.Core.UI.Other;
using Terraria.Enums;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Content.Items.Tools.Mirrors
{
    public class MosaicMirror : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.Mirrors;

        public new string LocalizationCategory => "Items.Tools.Mirrors";

        public int Mode = 0;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.SetShopValues(ItemRarityColor.Lime7, Item.buyPrice(0, 10, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.Mirrors);
            if (!QoLCompendium.itemConfig.InformationAccessories)
            {
                TooltipLine tip1 = tooltips.Find(l => l.Name == "Tooltip1");
                tip1.Text += " " + Language.GetTextValue("Mods.QoLCompendium.CommonItemTooltips.Disabled");
                tip1.OverrideColor = Color.Red;
            }
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void SaveData(TagCompound tag)
        {
            tag["MosaicMirrorMode"] = Mode;
        }


        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("MosaicMirrorMode");
        }

        public override void UpdateInventory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().warpMirror = true;
            Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.Mirror" + Mode.ToString()));
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            //cursed mirror
            if (Mode == 0)
            {
                if (Main.rand.NextBool())
                {
                    Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Yellow, 1.1f);
                }
                if (player.itemTime == 0)
                {
                    player.ApplyItemTime(Item, 1f, default);
                    return;
                }
                if (player.itemTime == player.itemTimeMax / 2)
                {
                    for (int i = 0; i < 70; i++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.5f);
                    }
                    player.grappling[0] = -1;
                    player.grapCount = 0;
                    for (int j = 0; j < 1000; j++)
                    {
                        if (Main.projectile[j].active && Main.projectile[j].owner == player.whoAmI && Main.projectile[j].aiStyle == 7)
                        {
                            Main.projectile[j].Kill();
                        }
                    }
                    if (player.lastDeathPostion.X != 0f && player.lastDeathPostion.Y != 0f)
                    {
                        Vector2 vector = new(player.lastDeathPostion.X - 16f, player.lastDeathPostion.Y - 24f);
                        player.Teleport(vector, 0, 0);
                    }
                    else if (player == Main.player[Main.myPlayer])
                    {
                        Main.NewText("No sign of recent death appears in the mirror", byte.MaxValue, byte.MaxValue, byte.MaxValue);
                    }
                    for (int k = 0; k < 70; k++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.5f);
                    }
                }
            }
            //mirror of return
            if (Mode == 1)
            {
                // Make dust each frame
                if (Main.rand.NextBool())
                {
                    Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.1f);
                    d.velocity *= 0.5f;
                }

                // Set up itemTime correctly
                if (player.ItemTimeIsZero)
                {
                    player.ApplyItemTime(Item);
                }

                if (player.itemTime == player.itemTimeMax / 2)
                {
                    // Dust where the player starts
                    for (int i = 0; i < 70; i++)
                    {
                        Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.5f);
                        d.velocity *= 0.5f;
                    }

                    // Release grappling hooks
                    player.grappling[0] = -1;
                    player.grapCount = 0;
                    for (int i = 0; i < Main.projectile.Length; i++)
                    {
                        if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
                        {
                            Main.projectile[i].Kill();
                        }
                    }

                    // Teleport the player
                    player.DoPotionOfReturnTeleportationAndSetTheComebackPoint();

                    // Dust where the player appears
                    for (int i = 0; i < 70; i++)
                    {
                        Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.5f);
                        d.velocity *= 0.5f;
                    }
                }
            }
            //teleportation mirror
            if (Mode == 2)
            {
                if (Main.rand.NextBool())
                {
                    Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.1f);
                    d.velocity *= 0.5f;
                }

                // Set up itemTime correctly
                if (player.ItemTimeIsZero)
                {
                    player.ApplyItemTime(Item);
                }

                if (player.itemTime == player.itemTimeMax / 2)
                {
                    // Dust where the player starts
                    for (int i = 0; i < 70; i++)
                    {
                        Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.5f);
                        d.velocity *= 0.5f;
                    }

                    // Release grappling hooks
                    player.grappling[0] = -1;
                    player.grapCount = 0;
                    for (int i = 0; i < Main.projectile.Length; i++)
                    {
                        if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].aiStyle == 7)
                        {
                            Main.projectile[i].Kill();
                        }
                    }

                    // Teleport the player
                    player.TeleportationPotion();

                    // Dust where the player appears
                    for (int i = 0; i < 70; i++)
                    {
                        Dust d = Dust.NewDustDirect(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, Color.Cyan, 1.5f);
                        d.velocity *= 0.5f;
                    }
                }
            }
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 2)
                Mode = 0;
        }

        public override void UpdateInfoAccessory(Player player)
        {
            if (!QoLCompendium.itemConfig.InformationAccessories)
                return;

            player.GetModPlayer<InfoPlayer>().battalionLog = true;
            player.GetModPlayer<InfoPlayer>().harmInducer = true;
            player.GetModPlayer<InfoPlayer>().headCounter = true;
            player.GetModPlayer<InfoPlayer>().kettlebell = true;
            player.GetModPlayer<InfoPlayer>().luckyDie = true;
            player.GetModPlayer<InfoPlayer>().metallicClover = true;
            player.GetModPlayer<InfoPlayer>().plateCracker = true;
            player.GetModPlayer<InfoPlayer>().regenerator = true;
            player.GetModPlayer<InfoPlayer>().reinforcedPanel = true;
            player.GetModPlayer<InfoPlayer>().replenisher = true;
            player.GetModPlayer<InfoPlayer>().trackingDevice = true;
            player.GetModPlayer<InfoPlayer>().wingTimer = true;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.Mirrors, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<CursedMirror>());
            r.AddIngredient(ModContent.ItemType<MirrorOfReturn>());
            r.AddIngredient(ModContent.ItemType<TeleportationMirror>());
            r.AddIngredient(ModContent.ItemType<WarpMirror>());
            r.AddIngredient(ModContent.ItemType<WormholeMirror>());
            r.AddTile(TileID.TinkerersWorkbench);
            r.Register();
        }
    }
}
