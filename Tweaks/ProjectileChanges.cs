﻿using Microsoft.Xna.Framework;
using QoLCompendium.Projectiles;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class ExtraLuresProjectile : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.bobber && projectile.owner == Main.myPlayer && QoLCompendium.mainConfig.ExtraLures && source is EntitySource_ItemUse)
            {
                int split = 1;

                switch (projectile.type)
                {
                    case ProjectileID.BobberFiberglass:
                    case ProjectileID.BobberFisherOfSouls:
                    case ProjectileID.BobberFleshcatcher:
                    case ProjectileID.BobberBloody:
                    case ProjectileID.BobberScarab:
                        split = 3;
                        break;

                    case ProjectileID.BobberMechanics:
                    case ProjectileID.BobbersittingDuck:
                        split = 4;
                        break;

                    case ProjectileID.BobberHotline:
                    case ProjectileID.BobberGolden:
                        split = 5;
                        break;
                }

                if (Main.player[projectile.owner].HasBuff(BuffID.Fishing))
                    split++;

                if (split > 1)
                    SplitProj(projectile, split);
            }
        }

        public static void SplitProj(Projectile projectile, int number)
        {
            Projectile split;

            double spread = 0.3 / number;

            for (int i = 0; i < number / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = (j == 0) ? 1 : -1;
                    split = NewProjectileDirectSafe(projectile.GetSource_FromThis(), projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    if (split != null)
                    {
                        split.friendly = true;
                    }
                }
            }

            if (number % 2 == 0)
            {
                projectile.active = false;
            }
        }

        public static Projectile NewProjectileDirectSafe(IEntitySource source, Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(source, pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < Main.maxProjectiles) ? Main.projectile[p] : null;
        }
    }

    public class HostileSandBallModifier : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.SandBallFalling;
        }

        public override bool PreKill(Projectile projectile, int timeLeft)
        {
            if (!projectile.friendly && QoLCompendium.mainConfig.NoLittering)
            {
                projectile.noDropItem = true;
            }

            return base.PreKill(projectile, timeLeft);
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (projectile.friendly)
            {
                return;
            }

            if (!QoLCompendium.mainConfig.NoLittering)
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
            if (!QoLCompendium.mainConfig.NoLittering)
            {
                return;
            }

            projectile.noDropItem = true;
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (!QoLCompendium.mainConfig.NoLittering)
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
            if (!QoLCompendium.mainConfig.NoLittering)
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

            if (!QoLCompendium.mainConfig.NoLittering)
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
