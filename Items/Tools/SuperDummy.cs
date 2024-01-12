﻿namespace QoLCompendium.Items.Tools
{
    public class SuperDummy : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                if (player.altFunctionUse == ItemAlternativeFunctionID.ActivatedAndUsed)
                {
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<NPCs.SuperDummy>())
                            {
                                NPC npc = Main.npc[i];
                                npc.life = 0;
                                npc.HitEffect();
                                Main.npc[i].SimpleStrikeNPC(int.MaxValue, 0, false, 0, null, false, 0, true);
                            }
                        }
                    }
                    else if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        var netMessage = Mod.GetPacket();
                        netMessage.Write((byte)5);
                        netMessage.Send();
                    }
                }
                else if (NPC.CountNPCS(ModContent.NPCType<NPCs.SuperDummy>()) < 100)
                {
                    Vector2 pos = new((int)Main.MouseWorld.X - 9, (int)Main.MouseWorld.Y - 20);
                    int dummy = NPC.NewNPC(NPC.GetBossSpawnSource(Main.myPlayer), (int)pos.X, (int)pos.Y, ModContent.NPCType<NPCs.SuperDummy>());
                    if (dummy != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: dummy);
                }
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TargetDummy)
                .AddIngredient(RecipeGroupID.IronBar, 3)
                .AddIngredient(ItemID.FallenStar)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
