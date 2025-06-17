using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.DataStructures;
using static MonoMod.Cil.ILContext;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class AutofishPlayer : ModPlayer
    {
        internal bool Lockcast;

        internal Point CastPosition;

        internal int PullTimer;

        internal bool ActivatedByMod;

        internal bool Autocast;

        internal int AutocastDelay;

        public override void PreUpdate()
        {
            if (Player.whoAmI != Main.myPlayer || !QoLCompendium.mainConfig.AutoFishing)
            {
                return;
            }
            ActivatedByMod = false;
            if (PullTimer > 0)
            {
                PullTimer--;
                if (PullTimer == 0)
                {
                    Player.controlUseItem = true;
                    Player.releaseUseItem = true;
                    ActivatedByMod = true;
                    Player.ItemCheck();
                }
            }
            if (!Autocast)
            {
                return;
            }
            AutocastDelay--;
            if (Player.HeldItem.fishingPole == 0)
            {
                Autocast = false;
            }
            else if (AutocastDelay <= 0 && !CheckBobbersActive(Player.whoAmI))
            {
                int mouseX = Main.mouseX;
                int mouseY = Main.mouseY;
                if (Lockcast)
                {
                    Main.mouseX = CastPosition.X - (int)Main.screenPosition.X;
                    Main.mouseY = CastPosition.Y - (int)Main.screenPosition.Y;
                }
                Player.controlUseItem = true;
                Player.releaseUseItem = true;
                ActivatedByMod = true;
                Player.ItemCheck();
                AutocastDelay = 10;
                if (Lockcast)
                {
                    Main.mouseX = mouseX;
                    Main.mouseY = mouseY;
                }
            }
        }

        public static bool CheckBobbersActive(int whoAmI)
        {
            using IEnumerator<Projectile> enumerator = Main.projectile.Where((p) => p.active && p.owner == whoAmI && p.bobber).GetEnumerator();
            if (enumerator.MoveNext())
            {
                _ = enumerator.Current;
                return true;
            }
            return false;
        }

        public override void OnEnterWorld()
        {
            Lockcast = false;
            CastPosition = default;
            Autocast = false;
        }

        public override void Load()
        {
            if (QoLCompendium.mainConfig.AutoFishing)
            {
                On_Player.ItemCheck_CheckFishingBobbers += new On_Player.hook_ItemCheck_CheckFishingBobbers(Player_ItemCheck_CheckFishingBobbers);
                On_Player.ItemCheck_Shoot += new On_Player.hook_ItemCheck_Shoot(Player_ItemCheck_Shoot);
                IL_Projectile.FishingCheck += new Manipulator(Projectile_FishingCheck);
            }
        }

        private bool Player_ItemCheck_CheckFishingBobbers(On_Player.orig_ItemCheck_CheckFishingBobbers orig, Player player, bool canUse)
        {
            bool num = orig.Invoke(player, canUse);
            if (!num && player.whoAmI == Main.myPlayer && player.TryGetModPlayer(out AutofishPlayer autofishPlayer) && !autofishPlayer.ActivatedByMod)
            {
                autofishPlayer.Autocast = false;
            }
            return num;
        }

        private void Player_ItemCheck_Shoot(On_Player.orig_ItemCheck_Shoot orig, Player player, int i, Item sItem, int weaponDamage)
        {
            if (player.whoAmI == Main.myPlayer && player.TryGetModPlayer(out AutofishPlayer autofishPlayer) && !autofishPlayer.ActivatedByMod && sItem.fishingPole > 0)
            {
                autofishPlayer.Autocast = true;
            }
            orig.Invoke(player, i, sItem, weaponDamage);
        }

        private void Projectile_FishingCheck(ILContext il)
        {
            ILCursor val = new(il);
            if (!val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
            {
            (i) => i.MatchLdfld(typeof(FishingAttempt), "rolledItemDrop")
            }))
            {
                throw new Exception("Hook location not found, if (fisher.rolledItemDrop > 0)");
            }
            val.Emit(OpCodes.Ldarg_0);
            val.EmitDelegate(delegate (int caughtType, Projectile projectile)
            {
                if (projectile.owner != Main.myPlayer || !Main.player[projectile.owner].active || Main.player[projectile.owner].dead)
                {
                    return caughtType;
                }
                AutofishPlayer modPlayer2 = Main.player[projectile.owner].GetModPlayer<AutofishPlayer>();
                if (modPlayer2.PullTimer == 0 && caughtType > 0)
                {
                    modPlayer2.PullTimer = (int)(0.5 * 60f + 1f);
                    return caughtType;
                }
                return caughtType;
            });
            val = new ILCursor(il);
            if (!val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
            {
            (i) => i.MatchLdfld(typeof(FishingAttempt), "rolledEnemySpawn")
            }))
            {
                throw new Exception("Hook location not found, if (fisher.rolledEnemySpawn > 0)");
            }
            val.Emit(OpCodes.Ldarg_0);
            val.EmitDelegate(delegate (int caughtType, Projectile projectile)
            {
                if (projectile.owner != Main.myPlayer || !Main.player[projectile.owner].active || Main.player[projectile.owner].dead)
                {
                    return caughtType;
                }
                AutofishPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<AutofishPlayer>();
                if (caughtType > 0 && modPlayer.PullTimer == 0)
                {
                    modPlayer.PullTimer = (int)(0.5f * 60f + 1f);
                }
                return caughtType;
            });
        }
    }
}
