namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class NoLavaFromLavaSlimes : GlobalNPC
    {
        public override void HitEffect(NPC npc, NPC.HitInfo hit)
        {
            if (npc.type != NPCID.LavaSlime || Main.netMode == NetmodeID.MultiplayerClient || npc.life > 0)
            {
                return;
            }
            try
            {
                if (QoLCompendium.mainConfig.LavaSlimesDontDropLava)
                {
                    int num = (int)(npc.Center.X / 16f);
                    int num2 = (int)(npc.Center.Y / 16f);
                    if (!WorldGen.SolidTile(num, num2, false))
                    {
                        Tile val = Main.tile[num, num2];
                        if (val.CheckingLiquid)
                        {
                            Tile val2 = Main.tile[num, num2];
                            val2.LiquidAmount = 0;
                            WorldGen.SquareTileFrame(num, num2, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
