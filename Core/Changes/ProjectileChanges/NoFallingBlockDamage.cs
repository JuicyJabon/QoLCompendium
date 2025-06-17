namespace QoLCompendium.Core.Changes.ProjectileChanges
{
    public class NoFallingBlockDamage : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return Common.FallingBlocks.Contains(entity.type);
        }

        public override void SetDefaults(Projectile entity)
        {
            if (QoLCompendium.mainConfig.NoFallingSandDamage)
            {
                entity.friendly = true;
                entity.hostile = false;
            }
        }
    }
}
