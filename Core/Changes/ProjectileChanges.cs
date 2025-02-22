﻿using System.Reflection;
using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes
{
    public class ExtraLuresProjectile : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.bobber && projectile.owner == Main.myPlayer && QoLCompendium.mainConfig.ExtraLures > 1 && source is EntitySource_ItemUse)
            {
                int split = QoLCompendium.mainConfig.ExtraLures;
                /*
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
                    case ProjectileID.FishingBobber:
                    case ProjectileID.FishingBobberGlowingArgon:
                    case ProjectileID.FishingBobberGlowingKrypton:
                    case ProjectileID.FishingBobberGlowingLava:
                    case ProjectileID.FishingBobberGlowingRainbow:
                    case ProjectileID.FishingBobberGlowingStar:
                    case ProjectileID.FishingBobberGlowingViolet:
                    case ProjectileID.FishingBobberGlowingXenon:
                        split = 5;
                        break;
                }

                if (projectile.type == Common.GetModProjectile(ModConditions.aequusMod, "RadonFishingBobberProj")
                    || projectile.type == Common.GetModProjectile(ModConditions.depthsMod, "MercuryMossFishingBobber"))
                {
                    split = 5;
                }
                */

                if (Main.player[projectile.owner].HasBuff(BuffID.Fishing))
                    split++;

                if (split > 0)
                    SplitProj(projectile, split + 1);
            }
        }

        public static void SplitProj(Projectile projectile, int number)
        {
            Projectile split;

            double spread = 0.2 / number;

            for (int i = 0; i < number / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    int factor = j == 0 ? 1 : -1;
                    split = NewProjectileDirectSafe(projectile.GetSource_FromThis(), projectile.Center, projectile.velocity.RotatedBy(factor * spread * (i + 1)), projectile.type, projectile.damage, projectile.knockBack, projectile.owner, projectile.ai[0], projectile.ai[1]);

                    if (split != null)
                        split.friendly = true;
                }
            }

            if (number % 2 == 0)
                projectile.active = false;
        }

        public static Projectile NewProjectileDirectSafe(IEntitySource source, Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(source, pos, vel, type, damage, knockback, owner, ai0, ai1);
            return p < Main.maxProjectiles ? Main.projectile[p] : null;
        }
    }

    public class NoSandDamage : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.SandBallFalling || entity.type == ProjectileID.EbonsandBallFalling || entity.type == ProjectileID.CrimsandBallFalling
                || entity.type == ProjectileID.PearlSandBallFalling || entity.type == ProjectileID.SiltBall || entity.type == ProjectileID.SlushBall;
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

    public class RemoveTombstones : ModSystem
    {
        public override void Load()
        {
            if (QoLCompendium.mainConfig.NoTombstoneDrops)
            {
                On_Player.DropTombstone += NoTombstones;
            }
        }

        public override void Unload()
        {
            On_Player.DropTombstone -= NoTombstones;
        }

        private void NoTombstones(On_Player.orig_DropTombstone orig, Player self, long coinsOwned, NetworkText deathText, int hitDirection)
        {
            if (!QoLCompendium.mainConfig.NoTombstoneDrops)
            {
                orig(self, coinsOwned, deathText, hitDirection);
            }
        }
    }

    public class NoAuraEffects : ModSystem
    {
        public const string TeslaTexturePath = @"Projectiles\Typeless\TeslaAura";

        private static TimeSpan NextTextureUpdate = TimeSpan.Zero;

        public static Asset<Texture2D> EmptyTexture => Common.GetAsset("Projectiles", "Invisible");
        public static Asset<Texture2D> OrigFlameRing;
        public static Asset<Texture2D> OrigTesla;

        public static List<int> OriginalTeslaProjectiles = new();

        public static bool WasTeslaEnabled = false;

        public override void Load()
        {
            Main.OnPreDraw += UpdateTextures;
        }
        public override void Unload()
        {
            if (OrigFlameRing != null && TextureAssets.FlameRing == EmptyTexture) TextureAssets.FlameRing = OrigFlameRing;

            if (OrigTesla != null)
                foreach (var Index in OriginalTeslaProjectiles)
                    TextureAssets.Projectile[Index] = OrigTesla;

            Main.OnPreDraw -= UpdateTextures;
        }

        private static void UpdateTextures(GameTime Time)
        {
            if (!Main.gameMenu && Time.TotalGameTime > NextTextureUpdate)
            {
                NextTextureUpdate = Time.TotalGameTime.Add(TimeSpan.FromSeconds(1));

                if (QoLCompendium.mainClientConfig.NoAuraVisuals && TextureAssets.FlameRing != EmptyTexture)
                {
                    if (OrigFlameRing == null) OrigFlameRing = TextureAssets.FlameRing;

                    TextureAssets.FlameRing = EmptyTexture;
                }
                else if (!QoLCompendium.mainClientConfig.NoAuraVisuals && OrigFlameRing != null && TextureAssets.FlameRing != OrigFlameRing)
                    TextureAssets.FlameRing = OrigFlameRing;

                if (ModConditions.calamityLoaded)
                {
                    var AssetField = typeof(AssetRepository).GetField("_assets", BindingFlags.Instance | BindingFlags.NonPublic);

                    Dictionary<string, IAsset> Assets = (Dictionary<string, IAsset>)AssetField.GetValue(ModConditions.calamityMod.Assets);

                    if (AssetField != null && Assets != null && Assets.ContainsKey(TeslaTexturePath))
                    {
                        if (QoLCompendium.mainClientConfig.NoAuraVisuals && !WasTeslaEnabled)
                        {
                            if (OrigTesla == null) OrigTesla = (Asset<Texture2D>)Assets[TeslaTexturePath];

                            for (int Index = TextureAssets.Projectile.Length - 1; Index >= 0; Index--)
                            {
                                var Texture = TextureAssets.Projectile[Index];

                                if (Texture == OrigTesla)
                                {
                                    WasTeslaEnabled = true; // Only set to true if the texture was found

                                    if (!OriginalTeslaProjectiles.Contains(Index))
                                        OriginalTeslaProjectiles.Add(Index);

                                    TextureAssets.Projectile[Index] = EmptyTexture;
                                }
                            }
                        }
                        else if (!QoLCompendium.mainClientConfig.NoAuraVisuals && OrigTesla != null && WasTeslaEnabled)
                        {
                            WasTeslaEnabled = false;

                            foreach (var Index in OriginalTeslaProjectiles)
                                TextureAssets.Projectile[Index] = OrigTesla;
                        }
                    }
                }
            }
        }
    }

    public class FixMinionDamage : GlobalProjectile
    {
        public StatModifier originalDamage = new(1f, 1f);
        public override bool InstancePerEntity => true;

        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.minion || entity.sentry || entity.ContinuouslyUpdateDamageStats;
        }

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is IEntitySource_WithStatsFromItem statsSource)
            {
                Player player = Main.player[projectile.owner];
                CombinedHooks.ModifyWeaponDamage(player, statsSource.Item, ref originalDamage);
            }
        }

        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            StatModifier finalModifier = originalDamage.CombineWith(player.GetTotalDamage(projectile.DamageType));
            projectile.damage = (int)finalModifier.ApplyTo(projectile.originalDamage);
            return true;
        }
    }
}
