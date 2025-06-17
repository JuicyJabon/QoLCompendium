namespace QoLCompendium.Core.Changes.ProjectileChanges
{
    public class NoSandLitter : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.SandBallFalling;
        }

        public override bool PreKill(Projectile projectile, int timeLeft)
        {
            if (!projectile.friendly && QoLCompendium.mainConfig.NoLittering)
                projectile.noDropItem = true;

            return base.PreKill(projectile, timeLeft);
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (projectile.friendly)
                return;

            if (!QoLCompendium.mainConfig.NoLittering)
                return;

            if (projectile.owner != Main.myPlayer)
                return;

            int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, ItemID.SandBlock);
            Main.item[itemIndex].noGrabDelay = 0;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
        }
    }

    public class NoSnowLitter : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.SnowBallHostile;
        }

        public override void SetDefaults(Projectile projectile)
        {
            if (!QoLCompendium.mainConfig.NoLittering)
                return;

            projectile.noDropItem = true;
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (!QoLCompendium.mainConfig.NoLittering)
                return;

            if (projectile.owner != Main.myPlayer)
                return;

            int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, ItemID.SnowBlock);
            Main.item[itemIndex].noGrabDelay = 0;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
        }
    }

    public class NoSandGunLitter : GlobalProjectile
    {
        private static readonly Dictionary<int, int> _sandGunProjectileToItem = new()
        {
            { ProjectileID.SandBallGun, ItemID.SandBlock },
            { ProjectileID.EbonsandBallGun, ItemID.EbonsandBlock },
            { ProjectileID.PearlSandBallGun, ItemID.PearlsandBlock },
            { ProjectileID.CrimsandBallGun, ItemID.CrimsandBlock }
        };

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return _sandGunProjectileToItem.ContainsKey(entity.type);
        }

        public override bool PreKill(Projectile projectile, int timeLeft)
        {
            if (!QoLCompendium.mainConfig.NoLittering)
                return base.PreKill(projectile, timeLeft);

            projectile.noDropItem = true;

            int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, _sandGunProjectileToItem[projectile.type]);
            Main.item[itemIndex].noGrabDelay = 0;

            if (Main.netMode == NetmodeID.Server)
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);

            return base.PreKill(projectile, timeLeft);
        }
    }

    public class NoTombstoneLitter : GlobalProjectile
    {
        private static readonly Dictionary<int, int> _graveMarkerProjectileTypeToItemType = new()
        {
            { ProjectileID.Tombstone, ItemID.Tombstone },
            { ProjectileID.GraveMarker, ItemID.GraveMarker },
            { ProjectileID.CrossGraveMarker, ItemID.CrossGraveMarker },
            { ProjectileID.Headstone, ItemID.Headstone },
            { ProjectileID.Gravestone, ItemID.Gravestone },
            { ProjectileID.Obelisk, ItemID.Obelisk },
            { ProjectileID.RichGravestone1, ItemID.RichGravestone1 },
            { ProjectileID.RichGravestone2, ItemID.RichGravestone2 },
            { ProjectileID.RichGravestone3, ItemID.RichGravestone3 },
            { ProjectileID.RichGravestone4, ItemID.RichGravestone4 },
            { ProjectileID.RichGravestone5, ItemID.RichGravestone5 }
        };

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return _graveMarkerProjectileTypeToItemType.ContainsKey(entity.type);
        }

        public override bool PreAI(Projectile projectile)
        {
            if (!QoLCompendium.mainConfig.NoLittering)
                return base.PreAI(projectile);

            if (projectile.owner == Main.myPlayer)
            {
                int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, _graveMarkerProjectileTypeToItemType[projectile.type]);
                Main.item[itemIndex].noGrabDelay = 0;

                if (Main.netMode == NetmodeID.Server)
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
            }

            projectile.Kill();
            return false;
        }
    }
}
