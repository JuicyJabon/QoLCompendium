using QoLCompendium.Core.PermanentBuffSystems;

namespace QoLCompendium.Core.QoLCUtils
{
    public static class BuffUtils
    {
        public static void VanillaBuffHandler(int buff, Player player)
        {
            if (player.HasBuff(buff))
                return;

            switch (buff)
            {
                case BuffID.AmmoBox:
                    player.ammoBox = true;
                    break;
                case BuffID.AmmoReservation:
                    player.ammoPotion = true;
                    break;
                case BuffID.Archery:
                    player.archery = true;
                    player.arrowDamage *= CrossModSupport.Calamity.Loaded ? 1.05f : 1.1f;
                    break;
                case BuffID.Battle:
                    player.enemySpawns = true;
                    break;
                case BuffID.Bewitched:
                    player.maxMinions += 1;
                    break;
                case BuffID.BiomeSight:
                    player.biomeSight = true;
                    break;
                case BuffID.Builder:
                    player.tileSpeed += 0.25f;
                    player.wallSpeed += 0.25f;
                    player.blockRange++;
                    break;
                case BuffID.Calm:
                    player.calmed = true;
                    break;
                case BuffID.Campfire:
                    player.lifeRegen++;
                    break;
                case BuffID.CatBast:
                    player.statDefense += 5;
                    break;
                case BuffID.Clairvoyance:
                    player.GetDamage(DamageClass.Magic) += CrossModSupport.Calamity.Loaded ? 0.03f : 0.05f;
                    if (!CrossModSupport.Calamity.Loaded)
                        player.GetCritChance(DamageClass.Magic) += 2f;
                    player.statManaMax2 += 20;
                    player.manaCost -= 0.02f;
                    break;
                case BuffID.Crate:
                    player.cratePotion = true;
                    break;
                case BuffID.Dangersense:
                    player.dangerSense = true;
                    break;
                case BuffID.Endurance:
                    player.endurance += 0.1f;
                    break;
                case BuffID.Featherfall:
                    player.slowFall = true;
                    break;
                case BuffID.Fishing:
                    player.fishingSkill += 15;
                    break;
                case BuffID.Flipper:
                    player.ignoreWater = true;
                    player.accFlipper = true;
                    break;
                case BuffID.Gills:
                    player.gills = true;
                    break;
                case BuffID.Gravitation:
                    player.gravControl = true;
                    break;
                case BuffID.Lucky:
                    player.luckPotion = 3;
                    break;
                case BuffID.HeartLamp:
                    player.lifeRegen += 2;
                    break;
                case BuffID.Heartreach:
                    player.lifeMagnet = true;
                    break;
                case BuffID.Honey:
                    player.lifeRegenTime += 2f;
                    player.lifeRegen += 2;
                    break;
                case BuffID.Hunter:
                    player.detectCreature = true;
                    break;
                case BuffID.Inferno:
                    player.inferno = true;
                    Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.65f, 0.4f, 0.1f);
                    int num2 = 323;
                    float num3 = 200f;
                    bool flag = player.infernoCounter % 60 == 0;
                    int damage = 20;
                    for (int k = 0; k < 200; k++)
                    {
                        NPC nPC = Main.npc[k];
                        if (nPC.active && !nPC.friendly && nPC.damage > 0 && !nPC.dontTakeDamage && !nPC.buffImmune[num2] && player.CanNPCBeHitByPlayerOrPlayerProjectile(nPC) && Vector2.Distance(player.Center, nPC.Center) <= num3)
                        {
                            if (nPC.FindBuffIndex(num2) == -1)
                                nPC.AddBuff(num2, 120);

                            if (flag)
                                player.ApplyDamageToNPC(nPC, damage, 0f, 0, crit: false);
                        }
                    }
                    break;
                case BuffID.Invisibility:
                    player.invis = true;
                    break;
                case BuffID.Ironskin:
                    player.statDefense += 8;
                    break;
                case BuffID.Lifeforce:
                    player.lifeForce = true;
                    player.statLifeMax2 += player.statLifeMax / 5 / 20 * 20;
                    break;
                case BuffID.MagicPower:
                    player.GetDamage(DamageClass.Magic) += CrossModSupport.Calamity.Loaded ? 0.1f : 0.2f;
                    break;
                case BuffID.ManaRegeneration:
                    player.manaRegenBuff = true;
                    break;
                case BuffID.Mining:
                    player.pickSpeed -= CrossModSupport.Calamity.Loaded ? 0.15f : 0.25f;
                    break;
                case BuffID.NightOwl:
                    player.nightVision = true;
                    break;
                case BuffID.ObsidianSkin:
                    player.lavaImmune = true;
                    player.fireWalk = true;
                    player.buffImmune[BuffID.OnFire] = true;
                    break;
                case BuffID.PeaceCandle:
                    player.ZonePeaceCandle = true;
                    if (Main.myPlayer == player.whoAmI)
                        Main.SceneMetrics.PeaceCandleCount = 0;
                    break;
                case BuffID.Rage:
                    player.GetCritChance(DamageClass.Generic) += 10f;
                    break;
                case BuffID.Regeneration:
                    player.lifeRegen += 4;
                    break;
                case BuffID.ShadowCandle:
                    player.ZoneShadowCandle = true;
                    if (Main.myPlayer == player.whoAmI)
                        Main.SceneMetrics.ShadowCandleCount = 0;
                    break;
                case BuffID.Sharpened:
                    player.GetArmorPenetration(DamageClass.Melee) += 12;
                    break;
                case BuffID.Shine:
                    Lighting.AddLight((int)(player.position.X + player.width / 2) / 16, (int)(player.position.Y + player.height / 2) / 16, 0.8f, 0.95f, 1f);
                    break;
                case BuffID.Sonar:
                    player.sonarPotion = true;
                    break;
                case BuffID.Spelunker:
                    player.findTreasure = true;
                    break;
                case BuffID.StarInBottle:
                    player.manaRegenDelayBonus += 0.5f;
                    player.manaRegenBonus += 10;
                    break;
                case BuffID.SugarRush:
                    player.pickSpeed -= CrossModSupport.Calamity.Loaded ? 0.1f : 0.2f;
                    player.moveSpeed += CrossModSupport.Calamity.Loaded ? 0.1f : 0.2f;
                    break;
                case BuffID.Summoning:
                    player.maxMinions += 1;
                    break;
                case BuffID.Sunflower:
                    player.moveSpeed += 0.1f;
                    player.moveSpeed *= 1.1f;
                    player.sunflower = true;
                    break;
                case BuffID.Swiftness:
                    player.moveSpeed += CrossModSupport.Calamity.Loaded ? 0.15f : 0.25f;
                    break;
                case BuffID.Thorns:
                    player.thorns = 1f;
                    break;
                case BuffID.Tipsy:
                    if (player.HeldItem.CountsAsClass(DamageClass.Melee) || player.HeldItem.CountsAsClass(DamageClass.MeleeNoSpeed))
                    {
                        player.tipsy = true;
                        player.statDefense -= 4;
                        player.GetCritChance(DamageClass.Melee) += 2f;
                        player.GetDamage(DamageClass.Melee) += 0.1f;
                        player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                    }
                    break;
                case BuffID.Titan:
                    player.kbBuff = true;
                    break;
                case BuffID.Warmth:
                    player.resistCold = true;
                    break;
                case BuffID.WarTable:
                    player.maxTurrets += 1;
                    break;
                case BuffID.WaterCandle:
                    player.ZoneWaterCandle = true;
                    if (Main.myPlayer == player.whoAmI)
                        Main.SceneMetrics.WaterCandleCount = 0;
                    break;
                case BuffID.WaterWalking:
                    player.waterWalk = true;
                    break;
                case BuffID.WeaponImbueConfetti:
                    player.meleeEnchant = 7;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueCursedFlames:
                    player.meleeEnchant = 2;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueFire:
                    player.meleeEnchant = 3;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueGold:
                    player.meleeEnchant = 4;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueIchor:
                    player.meleeEnchant = 5;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueNanites:
                    player.meleeEnchant = 6;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbuePoison:
                    player.meleeEnchant = 8;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WeaponImbueVenom:
                    player.meleeEnchant = 1;
                    HandleFlaskBuffs(player);
                    break;
                case BuffID.WellFed:
                    player.wellFed = true;
                    player.statDefense += 2;
                    player.GetCritChance(DamageClass.Generic) += 2f;
                    if (!CrossModSupport.Calamity.Loaded)
                        player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
                    player.GetDamage(DamageClass.Generic) += 0.05f;
                    player.GetKnockback(DamageClass.Summon) += 0.5f;
                    player.moveSpeed += CrossModSupport.Calamity.Loaded ? 0.05f : 0.2f;
                    player.pickSpeed -= 0.05f;
                    break;
                case BuffID.WellFed2:
                    player.wellFed = true;
                    player.statDefense += 3;
                    player.GetCritChance(DamageClass.Generic) += 3f;
                    if (!CrossModSupport.Calamity.Loaded)
                        player.GetAttackSpeed(DamageClass.Melee) += 0.075f;
                    player.GetDamage(DamageClass.Generic) += 0.075f;
                    player.GetKnockback(DamageClass.Summon) += 0.75f;
                    player.moveSpeed += CrossModSupport.Calamity.Loaded ? 0.075f : 0.3f;
                    player.pickSpeed -= 0.1f;
                    break;
                case BuffID.WellFed3:
                    player.wellFed = true;
                    player.statDefense += 4;
                    player.GetCritChance(DamageClass.Generic) += 4f;
                    if (!CrossModSupport.Calamity.Loaded)
                        player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                    player.GetKnockback(DamageClass.Summon) += 1f;
                    player.moveSpeed += CrossModSupport.Calamity.Loaded ? 0.1f : 0.4f;
                    player.pickSpeed -= 0.15f;
                    break;
                case BuffID.Wrath:
                    player.GetDamage(DamageClass.Generic) += 0.1f;
                    break;
                default:
                    break;
            }
        }

        public static void HandleFlaskBuffs(Player player)
        {
            foreach (int buff in Constants.FlaskBuffs)
                player.buffImmune[buff] = true;
        }

        public static void HandleCoatingBuffs(Player player)
        {
            foreach (int buff in Constants.ThoriumCoatings)
                player.buffImmune[buff] = true;
        }

        public static string BuffAsset(int buffType)
        {
            if (buffType > BuffID.Count && BuffLoader.GetBuff(buffType) != null)
                return BuffLoader.GetBuff(buffType).Texture;
            else
                return "Terraria/Images/Buff_" + buffType;
        }

        public static void ReplaceBuffTexture(this Item item)
        {
            if (item.ModItem is BuffItem buffItem)
            {
                TextureAssets.Item[item.type] = TextureAssets.Buff[buffItem.BuffType];
            }
        }
    }
}
