using CalamityMod.Buffs.Potions;
using CalamityMod.Projectiles.Typeless;
using ContinentOfJourney.Buffs;
using SOTS;
using SOTS.Buffs;
using SpiritMod.Items.Consumable.Potion;
using SpiritReforged.Content.Forest.Misc;
using SpiritReforged.Content.Snow.Frostbite;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core.PermanentBuffSystems
{
    public class NewPermanentBuffPlayer : ModPlayer
    {
        public List<int> InfBuffDisabledVanilla = [];
        public List<string> InfBuffDisabledMod = [];

        public static NewPermanentBuffPlayer Get(Player player) => player.GetModPlayer<NewPermanentBuffPlayer>();

        public override void PreUpdateBuffs()
        {
            CheckForBuffs(Common.GetAllInventoryItemsList(Player).ToArray());
        }

        public override void PostUpdateBuffs()
        {
            foreach (int buff in QoLCPlayer.Get(Player).activeBuffs)
                Player.buffImmune[buff] = CheckImmune(buff);
        }

        public void CheckForBuffs(Item[] inventory)
        {
            foreach (Item item in inventory)
            {
                if (!item.IsAir && item.ModItem is BuffItem buffItem)
                {
                    if (!CheckImmune(buffItem.BuffType))
                        buffItem.effect.ApplyEffect(this);
                    if (!QoLCPlayer.Get(Player).activeBuffs.Contains(buffItem.BuffType))
                        QoLCPlayer.Get(Player).activeBuffs.Add(buffItem.BuffType);
                }

                if (!item.IsAir && item.ModItem is CombinedBuffItem combinedBuffItem)
                {
                    foreach (KeyValuePair<BuffEffect, int> effect in combinedBuffItem.BuffTypes)
                    {
                        if (!CheckImmune(effect.Value))
                            effect.Key.ApplyEffect(this);
                        if (!QoLCPlayer.Get(Player).activeBuffs.Contains(effect.Value))
                            QoLCPlayer.Get(Player).activeBuffs.Add(effect.Value);
                    }
                }
            }
        }

        public bool CheckImmune(int buffID)
        {
            if (InfBuffDisabledVanilla.Contains(buffID))
                return true;

            if ((buffID == BuffID.WellFed || buffID == BuffID.WellFed2) && QoLCPlayer.Get(Player).activeBuffs.Contains(BuffID.WellFed3))
                return true;
            if (buffID == BuffID.WellFed && (QoLCPlayer.Get(Player).activeBuffs.Contains(BuffID.WellFed2) || QoLCPlayer.Get(Player).activeBuffs.Contains(BuffID.WellFed3)))
                return true;

            if (buffID > BuffID.Count - 1)
            {
                ModBuff modBuff = BuffLoader.GetBuff(buffID);
                string fullName = $"{modBuff.Mod.Name}/{modBuff.Name}";
                if (InfBuffDisabledMod.Contains(fullName))
                    return true;
            }

            return false;
        }

        public void ToggleInfiniteBuff(int buffType)
        {
            ModBuff modBuff = BuffLoader.GetBuff(buffType);
            if (modBuff is null)
            {
                if (!InfBuffDisabledVanilla.Contains(buffType))
                {
                    InfBuffDisabledVanilla.Add(buffType);
                }
                else
                {
                    InfBuffDisabledVanilla.Remove(buffType);
                }
            }
            else
            {
                string fullName = $"{modBuff.Mod.Name}/{modBuff.Name}";
                if (!InfBuffDisabledMod.Contains(fullName))
                {
                    InfBuffDisabledMod.Add(fullName);
                }
                else
                {
                    InfBuffDisabledMod.Remove(fullName);
                }
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("InfBuffDisabledVanilla", InfBuffDisabledVanilla);
            tag.Add("InfBuffDisabledMod", InfBuffDisabledMod);
        }

        public override void LoadData(TagCompound tag)
        {
            InfBuffDisabledVanilla = tag.Get<List<int>>("InfBuffDisabledVanilla");
            InfBuffDisabledMod = tag.Get<List<string>>("InfBuffDisabledMod");
        }
    }

    /*
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class CalamityTeslaEffect : ModPlayer
    {
        public override void PostUpdateBuffs()
        {
            if (Player.buffImmune[ModContent.BuffType<TeslaBuff>()])
                return;

            string fullName = $"{BuffLoader.GetBuff(ModContent.BuffType<TeslaBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<TeslaBuff>()).Name}";
            if (QoLCPlayer.Get(Player).activeBuffs.Contains(ModContent.BuffType<TeslaBuff>()) && !NewPermanentBuffPlayer.Get(Player).InfBuffDisabledMod.Contains(fullName))
            {
                if (Player.ownedProjectileCounts[ModContent.ProjectileType<TeslaAura>()] < 1)
                {
                    int damage = (int)Player.GetBestClassDamage().ApplyTo(10f);
                    Projectile.NewProjectile(Player.GetSource_FromAI(), Player.Center, Vector2.Zero, ModContent.ProjectileType<TeslaAura>(), damage, 0f, Player.whoAmI);
                }
            }
        }
    }
    */

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyFluorescentBerryEffect : GlobalWall
    {
        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            if (Main.LocalPlayer.buffImmune[ModContent.BuffType<FluorescentBerryBuff>()])
                return;

            string fullName = $"{BuffLoader.GetBuff(ModContent.BuffType<FluorescentBerryBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<FluorescentBerryBuff>()).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(ModContent.BuffType<FluorescentBerryBuff>()) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                r = Utils.Clamp(r + 0.7f, 0f, 1f);
                g = Utils.Clamp(g + 0.7f, 0f, 1f);
                b = Utils.Clamp(b + 0.7f, 0f, 1f);
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class HomewardJourneyYinYangEffect : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            string fullName = $"{BuffLoader.GetBuff(ModContent.BuffType<NerveFibreBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<NerveFibreBuff>()).Name}";
            string fullName2 = $"{BuffLoader.GetBuff(ModContent.BuffType<YangPotionBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<YangPotionBuff>()).Name}";

            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(ModContent.BuffType<NerveFibreBuff>()) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                if (!Main.LocalPlayer.buffImmune[ModContent.BuffType<NerveFibreBuff>()])
                {
                    spawnRate *= 10;
                    maxSpawns /= 5;
                }
            }
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(ModContent.BuffType<YangPotionBuff>()) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName2))
            {
                if (!Main.LocalPlayer.buffImmune[ModContent.BuffType<YangPotionBuff>()])
                {
                    spawnRate = (int)(spawnRate * 0.08f);
                    maxSpawns = (int)(maxSpawns * 2.4f);
                }
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.SecretsOfTheShadows.Name)]
    [ExtendsFromMod(CrossModSupport.SecretsOfTheShadows.Name)]
    public class SOTSRippleEffect : ModPlayer
    {
        public override void PostUpdateBuffs()
        {
            if (Player.buffImmune[ModContent.BuffType<RippleBuff>()])
                return;

            string fullName = $"{BuffLoader.GetBuff(ModContent.BuffType<RippleBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<RippleBuff>()).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(ModContent.BuffType<RippleBuff>()) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                SOTSPlayer modPlayer = SOTSPlayer.ModPlayer(Player);
                modPlayer.rippleBonusDamage += 2;
                modPlayer.rippleEffect = true;
                modPlayer.rippleTimer++;
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class SpiritClassicEffects : ModPlayer
    {
        public override void PostUpdateBuffs()
        {
            if (Player.buffImmune[ModContent.BuffType<MirrorCoatBuff>()])
                return;

            string fullName = $"{BuffLoader.GetBuff(ModContent.BuffType<MirrorCoatBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<MirrorCoatBuff>()).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(ModContent.BuffType<MirrorCoatBuff>()) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                Player.buffImmune[BuffID.Stoned] = true;
            }
        }
    }

    [JITWhenModsEnabled(CrossModSupport.SpiritReforged.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritReforged.Name)]
    public class SpiritReforgedEffects : ModPlayer
    {
        public override void PostUpdateBuffs()
        {
            if (Player.buffImmune[ModContent.BuffType<RemedyPotionBuff>()])
                return;

            string fullName = $"{BuffLoader.GetBuff(ModContent.BuffType<RemedyPotionBuff>()).Mod.Name}/{BuffLoader.GetBuff(ModContent.BuffType<RemedyPotionBuff>()).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(ModContent.BuffType<RemedyPotionBuff>()) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                Player.buffImmune[BuffID.Poisoned] = true;
                Player.buffImmune[BuffID.Rabies] = true;
                Player.buffImmune[BuffID.Venom] = true;
                Player.buffImmune[BuffID.Weak] = true;
                Player.buffImmune[BuffID.Bleeding] = true;
            }
        }

        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Player.buffImmune[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")])
                return;

            string fullName = $"{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Mod.Name}/{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                if (item.CountsAsClass(DamageClass.Melee))
                    target.AddBuff(ModContent.BuffType<Frozen>(), 60 * Main.rand.Next(3, 7), false);
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Player.buffImmune[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")])
                return;

            string fullName = $"{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Mod.Name}/{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                if ((proj.CountsAsClass(DamageClass.Melee) || ProjectileID.Sets.IsAWhip[proj.type]) && !proj.noEnchantments)
                    target.AddBuff(ModContent.BuffType<Frozen>(), 60 * Main.rand.Next(3, 7), false);
            }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (Player.buffImmune[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")])
                return;

            string fullName = $"{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Mod.Name}/{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                if (item.DamageType.CountsAsClass(DamageClass.Melee) && !item.noMelee && !item.noUseGraphic && Utils.NextBool(Main.rand, 5))
                    Dust.NewDustDirect(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GemSapphire, 0f, 0f, 0, default, 1f).noGravity = true;
            }
        }

        public override void EmitEnchantmentVisualsAt(Projectile projectile, Vector2 boxPosition, int boxWidth, int boxHeight)
        {
            if (Player.buffImmune[Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")])
                return;

            string fullName = $"{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Mod.Name}/{BuffLoader.GetBuff(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")).Name}";
            if (QoLCPlayer.Get(Main.LocalPlayer).activeBuffs.Contains(Common.GetModBuff(CrossModSupport.SpiritReforged.Mod, "FlaskOfFrost_Buff")) && !NewPermanentBuffPlayer.Get(Main.LocalPlayer).InfBuffDisabledMod.Contains(fullName))
            {
                if ((projectile.DamageType.CountsAsClass<MeleeDamageClass>() || ProjectileID.Sets.IsAWhip[projectile.type]) && !projectile.noEnchantments && Utils.NextBool(Main.rand, 5))
                    Dust.NewDustDirect(boxPosition, boxWidth, boxHeight, DustID.GemSapphire, 0f, 0f, 0, default, 1f).noGravity = true;
            }
        }
    }
}
