using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class RespawnPlayer : ModPlayer
    {
        private (int type, int time)[] buffCache;

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (QoLCompendium.mainConfig.InstantRespawn && Main.netMode == NetmodeID.SinglePlayer)
            {
                for (int k = 0; k < Main.maxNPCs; k++)
                {
                    if (!Main.npc[k].friendly && Main.npc[k].active && !Common.LunarPillarIDs.Contains(Main.npc[k].type))
                        DespawnNPC(k);
                    Player.respawnTimer = 60;
                }
            }

            if (QoLCompendium.mainConfig.KeepBuffsOnDeath)
            {
                buffCache ??= new (int, int)[Player.MaxBuffs];
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    buffCache[i] = (Player.buffType[i], Player.buffTime[i]);
                }
            }
        }

        public override void OnRespawn()
        {
            if (QoLCompendium.mainConfig.FullHealthRespawn)
            {
                Player.statLife = Player.statLifeMax2;
                Player.statMana = Player.statManaMax2;
            }

            if (QoLCompendium.mainConfig.KeepBuffsOnDeath)
            {
                (int, int)[] array = buffCache;
                for (int i = 0; i < array.Length; i++)
                {
                    var (num, num2) = array[i];
                    if ((QoLCompendium.mainConfig.KeepDebuffsOnDeath || !Main.debuff[num]) && num > 0 && !Main.persistentBuff[num] && num2 > 2)
                    {
                        int num3 = (int)(float)num2;
                        Player.AddBuff(num, num3, false, false);
                    }
                }
            }
        }

        public static void DespawnNPC(int npc)
        {
            Main.npc[npc].life = 0;
            Main.npc[npc].active = false;
            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc, 0f, 0f, 0f, 0, 0, 0);
        }
    }
}
