using Terraria.DataStructures;
using static Terraria.Player;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class InfernoEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Inferno] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Inferno])
            {
                player.Player.inferno = true;
                Lighting.AddLight((int)player.Player.Center.X >> 4, (int)player.Player.Center.Y >> 4, 0.65f, 0.4f, 0.1f);
                bool flag = player.Player.infernoCounter % 60 == 0;
                int damage = 20;
                if (player.Player.whoAmI == Main.myPlayer)
                {
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        NPC nPC = Main.npc[i];
                        if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[BuffID.OnFire3] && Vector2.DistanceSquared(player.Player.Center, nPC.Center) <= 40000f)
                        {
                            if (nPC.FindBuffIndex(BuffID.OnFire3) == -1)
                            {
                                nPC.AddBuff(BuffID.OnFire3, 120);
                            }
                            if (flag)
                            {
                                player.Player.ApplyDamageToNPC(nPC, damage, 0f, 0, false);
                            }
                        }
                    }
                    if (Main.netMode != NetmodeID.SinglePlayer && player.Player.hostile)
                    {
                        for (int j = 0; j < 255; j++)
                        {
                            Player target = Main.player[j];
                            if (target != player.Player && target.active && !target.dead && target.hostile && !target.buffImmune[BuffID.OnFire3] && (target.team != player.Player.team || target.team == 0) && Vector2.DistanceSquared(player.Player.Center, target.Center) <= 40000f)
                            {
                                if (target.FindBuffIndex(BuffID.OnFire3) == -1)
                                    target.AddBuff(BuffID.OnFire3, 120);
                                if (flag)
                                {
                                    HurtInfo info = new();
                                    target.Hurt(PlayerDeathReason.LegacyEmpty(), damage, 0, pvp: true);
                                    PlayerDeathReason reason = PlayerDeathReason.ByOther(16);
                                    info.DamageSource = reason;
                                    info.Damage = damage;
                                    info.PvP = true;
                                    info.Knockback = 120f;
                                    NetMessage.SendPlayerHurt(j, info);
                                }
                            }
                        }
                    }
                }
                player.Player.buffImmune[BuffID.Inferno] = true;
            }
        }
    }
}
