using Microsoft.Xna.Framework;
using QoLCompendium.Items.InformationAccessories;
using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Items.Mirrors
{
    public class MosaicMirror : ModItem
    {
        public int Mode { get; private set; }

        public string MirrorName { get; private set; }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.MagicMirror);
            Item.rare = ItemRarityID.Cyan;
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override void SaveData(TagCompound tag)
        {
            tag["MosaicMirrorMode"] = Mode;
            tag["MosaicMirrorName"] = MirrorName;
        }
            

        public override void LoadData(TagCompound tag)
        {
            Mode = tag.GetInt("MosaicMirrorMode");
            MirrorName = tag.GetString("MosaicMirrorName");
        }

        public override void UpdateInventory(Player player)
        {
            Item.SetNameOverride(MirrorName);
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

        public override bool? UseItem(Player player)
        {
            //cursed mirror
            if (Mode == 0)
            {
                return base.UseItem(player);
            }
            //mirror of return
            if (Mode == 1)
            {
                return base.UseItem(player);
            }
            //teleportation mirror
            if (Mode == 2)
            {
                return base.UseItem(player);
            }
            //dungeon mirror
            if (Mode == 3)
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    TeleportClass.HandleTeleport(0);
                    return true;
                }
            }
            //temple mirror
            if (Mode == 4)
            {
                if (Main.myPlayer == player.whoAmI)
                {
                    TeleportClass.HandleTeleport(1);
                    return true;
                }
            }
            return false;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            Mode++;
            if (Mode > 4)
            {
                Mode = 0;
            }
            if (Mode == 0)
            {
                //Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.CursedMirror"));
                MirrorName = Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.CursedMirror");
            }
            if (Mode == 1)
            {
                //Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.MirrorOfReturn"));
                MirrorName = Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.MirrorOfReturn");
            }
            if (Mode == 2)
            {
                //Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.TeleportationMirror"));
                MirrorName = Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.TeleportationMirror");
            }
            if (Mode == 3)
            {
                //Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.DungeonMirror"));
                MirrorName = Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.DungeonMirror");
            }
            if (Mode == 4)
            {
                //Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.TempleMirror"));
                MirrorName = Language.GetTextValue("Mods.QoLCompendium.ItemNames.MosaicMirror.TempleMirror");
            }
        }

        public override void UpdateInfoAccessory(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().battalionLog = true;
            player.GetModPlayer<QoLCPlayer>().harmInducer = true;
            player.GetModPlayer<QoLCPlayer>().headCounter = true;
            player.GetModPlayer<QoLCPlayer>().kettlebell = true;
            player.GetModPlayer<QoLCPlayer>().luckyDie = true;
            player.GetModPlayer<QoLCPlayer>().metallicClover = true;
            player.GetModPlayer<QoLCPlayer>().plateCracker = true;
            player.GetModPlayer<QoLCPlayer>().regenerator = true;
            player.GetModPlayer<QoLCPlayer>().reinforcedPanel = true;
            player.GetModPlayer<QoLCPlayer>().replenisher = true;
            player.GetModPlayer<QoLCPlayer>().trackingDevice = true;
            player.GetModPlayer<QoLCPlayer>().wingTimer = true;
        }

        public override void AddRecipes()
        {
            if (QoLCompendium.itemConfig.Mirrors && QoLCompendium.itemConfig.InformationAccessories)
            {
                CreateRecipe()
                .AddIngredient(ModContent.ItemType<IAH>(), 1)
                .AddIngredient(ModContent.ItemType<CursedMirror>(), 1)
                .AddIngredient(ModContent.ItemType<MirrorOfReturn>(), 1)
                .AddIngredient(ModContent.ItemType<TeleportationMirror>(), 1)
                .AddIngredient(ModContent.ItemType<DungeonMirror>(), 1)
                .AddIngredient(ModContent.ItemType<TempleMirror>(), 1)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
            }
        }
    }
}
