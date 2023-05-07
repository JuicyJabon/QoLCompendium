using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    // Token: 0x02000009 RID: 9
    public static class AutoSwing
    {
        // Token: 0x06000048 RID: 72 RVA: 0x000024E0 File Offset: 0x000006E0
        public static bool ShouldForceAutoSwing(Item item)
        {
            return ModContent.GetInstance<QoLCConfig>().AutoSwingin && ShouldForceAutoSwingDefault(item);
        }

        // Token: 0x06000049 RID: 73 RVA: 0x000024F8 File Offset: 0x000006F8
        private static bool ShouldForceAutoSwingDefault(Item item)
        {
            Projectile projectile = new();
            projectile.SetDefaults(item.shoot);
            return item.damage > 0 && item.DamageType != DamageClass.Summon && !item.sentry && !item.channel && projectile.aiStyle != 9;
        }

        // Token: 0x0200002D RID: 45
        private class SwingGlobalItem : GlobalItem
        {
            // Token: 0x0600010D RID: 269 RVA: 0x000106A4 File Offset: 0x0000E8A4
            public override bool? CanAutoReuseItem(Item item, Player player)
            {
                if (ShouldForceAutoSwing(item))
                {
                    return true;
                }
                return default;
            }
        }

        // Token: 0x0200002E RID: 46
        private class SwingGlobalProjectile : GlobalProjectile
        {
            // Token: 0x0600010F RID: 271 RVA: 0x000106CC File Offset: 0x0000E8CC
            public override void AI(Projectile projectile)
            {
                if ((projectile.aiStyle == 19 || projectile.aiStyle == 699) && ShouldForceAutoSwing(Main.player[projectile.owner].HeldItem) && projectile.timeLeft > Main.player[projectile.owner].itemAnimation)
                {
                    projectile.timeLeft = Main.player[projectile.owner].itemAnimation;
                    projectile.netUpdate = true;
                }
            }
        }
    }
}
