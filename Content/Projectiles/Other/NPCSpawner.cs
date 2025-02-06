namespace QoLCompendium.Content.Projectiles.Other
{
    public class NPCSpawner : ModProjectile
    {
        public override string Texture => "QoLCompendium/Assets/Projectiles/Invisible";

        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 2;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hide = true;
        }

        public override bool? CanDamage()
        {
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            int npc = NPC.NewNPC(NPC.GetBossSpawnSource(Projectile.owner), (int)Projectile.Center.X, (int)Projectile.Center.Y, (int)Projectile.ai[0]);
            if (npc != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, npc);
        }
    }
}
