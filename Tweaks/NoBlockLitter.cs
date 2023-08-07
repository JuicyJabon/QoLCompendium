using QoLCompendium;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NoSnowLitter.Common.GlobalProjectiles
{
    public class HostileSandBallModifier : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.SandBallFalling;
        }

        public override bool PreKill(Projectile projectile, int timeLeft)
        {
            if (!projectile.friendly && ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                projectile.noDropItem = true;
            }

            return base.PreKill(projectile, timeLeft);
        }

        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (projectile.friendly)
            {
                return;
            }

            if (!ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                return;
            }

            if (projectile.owner != Main.myPlayer)
            {
                return;
            }

            int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, ItemID.SandBlock);
            Main.item[itemIndex].noGrabDelay = 0;

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
            }
        }
    }

    public class HostileSnowballModifier : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.SnowBallHostile;
        }

        public override void SetDefaults(Projectile projectile)
        {
            if (!ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                return;
            }

            projectile.noDropItem = true;
        }

        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (!ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                return;
            }

            if (projectile.owner != Main.myPlayer)
            {
                return;
            }

            int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, ItemID.SnowBlock);
            Main.item[itemIndex].noGrabDelay = 0;

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
            }
        }
    }

    public class SandGunProjectileModifier : GlobalProjectile
    {
        private static readonly IReadOnlyDictionary<int, int> _sandGunProjectileToItem = new Dictionary<int, int>()
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
            if (!ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                return base.PreKill(projectile, timeLeft);
            }

            projectile.noDropItem = true;

            int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, _sandGunProjectileToItem[projectile.type]);
            Main.item[itemIndex].noGrabDelay = 0;

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
            }

            return base.PreKill(projectile, timeLeft);
        }
    }

    public class TombstoneModifier : GlobalProjectile
    {
        private static readonly IReadOnlyDictionary<int, int> _graveMarkerProjectileTypeToItemType = new Dictionary<int, int>()
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

            if (!ModContent.GetInstance<QoLCConfig>().NoLittering)
            {
                return base.PreAI(projectile);
            }

            if (projectile.owner == Main.myPlayer)
            {
                int itemType = _graveMarkerProjectileTypeToItemType[projectile.type];
                int itemIndex = Item.NewItem(projectile.GetSource_DropAsItem(), projectile.Hitbox, itemType);
                Main.item[itemIndex].noGrabDelay = 0;

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncItem, -1, -1, null, itemIndex, 1f);
                }
            }

            projectile.Kill();

            return false;
        }
    }
}