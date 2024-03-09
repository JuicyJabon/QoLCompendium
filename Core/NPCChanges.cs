using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using QoLCompendium.Content.Items.InformationAccessories;
using QoLCompendium.Content.NPCs;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Config;
using Terraria.ID;

namespace QoLCompendium.Core
{
    public class InvincibleTownies : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(NPC npc)
        {
            bool dontTakeDamageFromHostiles = npc.dontTakeDamageFromHostiles;
            if (npc.type == NPCID.DD2EterniaCrystal && QoLCompendium.mainConfig.FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = false;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
            if (npc.friendly && QoLCompendium.mainConfig.FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = true;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
        }
    }

    public class FastTownieSpawn : ModSystem
    {
        public override void PreUpdateWorld()
        {
            bool rate = false;
            Player player = Main.LocalPlayer;
            if (player.active)
            {
                if (!player.dead && QoLCompendium.mainConfig.FastTownieSpawns)
                {
                    rate = true;
                }
            }

            if (rate)
            {
                Main.checkForSpawns += 81;
            }
        }
    }

    public class TownieSpawns : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (QoLCompendium.mainConfig.TownieSpawn)
            {
                NPC.savedStylist = true;
                NPC.savedAngler = true;
                NPC.savedGolfer = true;
                if (NPC.downedGoblins)
                {
                    NPC.savedGoblin = true;
                }
                if (NPC.downedBoss2)
                {
                    NPC.savedBartender = true;
                }
                if (NPC.downedBoss3)
                {
                    NPC.savedMech = true;
                }
                if (Main.hardMode)
                {
                    NPC.savedWizard = true;
                    NPC.savedTaxCollector = true;
                }
            }
        }
    }

    public class LiveInEvil : ModSystem
    {
        public override void Load()
        {
            ModLoader.TryGetMod("VanillaQoL", out Mod VanillaQoL);
            if (VanillaQoL == null)
            {
                if (QoLCompendium.mainConfig.TowniesLiveInEvil)
                {
                    IL_WorldGen.ScoreRoom += LiveInCorrupt;
                }
            }
        }

        public override void Unload()
        {
            IL_WorldGen.ScoreRoom -= LiveInCorrupt;
        }

        private void LiveInCorrupt(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(
                    MoveType.After,
                    i => i.MatchCall(typeof(WorldGen).GetMethod("GetTileTypeCountByCategory")),
                    i => i.Match(OpCodes.Neg),
                    i => i.Match(OpCodes.Stloc_S),
                    i => i.Match(OpCodes.Ldloc_S),
                    i => i.Match(OpCodes.Ldc_I4_S)))
                return;
            c.EmitDelegate<Func<int, int>>((returnValue) => true ? 114514 : returnValue);
        }

    }

    public class HappinessOverride : ModSystem
    {
        private Hook hook;
        private Hook hook2;

        public override void Load()
        {
            IL_Condition.cctor += il =>
            {
                var c = new ILCursor(il);
                MethodReference troller = null;
                c.GotoNext(x => x.MatchLdstr("Conditions.HappyEnoughForPylons"));
                c.GotoNext(x => x.MatchLdftn(out troller));
                hook = new Hook(troller.ResolveReflection(), TModLoaderTroller);

                c.GotoNext(x => x.MatchLdstr("Conditions.AnotherTownNPCNearby"));
                c.GotoNext(x => x.MatchLdftn(out troller));
                hook2 = new Hook(troller.ResolveReflection(), TModLoaderTroller);
            };

            IL_Main.DrawNPCChatButtons += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.After, x => x.MatchLdstr("UI.NPCCheckHappiness")))
                {
                    return;
                }
                c.EmitDelegate((string text) => !QoLCompendium.mainConfig.ToggleHappiness ? text : "");
            };
        }

        public override void Unload()
        {
            hook?.Dispose();
            hook = null;
            hook2?.Dispose();
            hook2 = null;
        }

        private static bool TModLoaderTroller(Func<object, bool> orig, object self)
        {
            return orig(self) || QoLCompendium.mainConfig.OverridePylon;
        }
    }

    public class CensusSupport : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("Census", out Mod Census))
            {
                Census.Call("TownNPCCondition", ModContent.NPCType<BMDealerNPC>(), ModContent.GetInstance<BMDealerNPC>().GetLocalization("Census.SpawnCondition"));
                Census.Call("TownNPCCondition", ModContent.NPCType<EtherealCollectorNPC>(), ModContent.GetInstance<EtherealCollectorNPC>().GetLocalization("Census.SpawnCondition"));
            }
        }
    }

    public class IncreasedCoinDrop : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            npc.value *= QoLCompendium.mainConfig.MoreCoins;
        }
    }

    public class DisableNaturalBossSpawns : ModSystem
    {
        public override void PostUpdateNPCs()
        {
            if (QoLCompendium.mainConfig.NoNaturalBossSpawns)
            {
                WorldGen.spawnEye = false;
                WorldGen.spawnHardBoss = 0;
            }
        }
    }

    public class DisableNaturalBossSpawnsNPC : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (QoLCompendium.mainConfig.NoNaturalBossSpawns)
            {
                pool.Remove(NPCID.KingSlime);
                pool.Remove(NPCID.Deerclops);
            }
        }
    }

    public class SpawnRateEdits : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (AnyBossAlive() && player.Distance(Main.npc[boss].Center) < 6000f && QoLCompendium.mainConfig.NoSpawns)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QoLCPlayer>().enemyEraser)
            {
                maxSpawns = 0;
            }
            if (player.GetModPlayer<QoLCPlayer>().enemyAggressor)
            {
                spawnRate = (int)(spawnRate * 0.1);
                maxSpawns = (int)(maxSpawns * 10f);
            }
            if (player.GetModPlayer<QoLCPlayer>().enemyCalmer)
            {
                spawnRate = (int)(spawnRate * 2.5);
                maxSpawns = (int)(maxSpawns * 0.3f);
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (npc.boss)
            {
                boss = npc.whoAmI;
            }
            return true;
        }

        public static bool AnyBossAlive()
        {
            if (boss == -1)
            {
                return false;
            }
            NPC npc = Main.npc[boss];
            if (npc.active && npc.type != NPCID.MartianSaucerCore && (npc.boss || npc.type == NPCID.EaterofWorldsHead))
            {
                return true;
            }
            boss = -1;
            return false;
        }
        #pragma warning disable CA2211
        public static int boss = -1;
        #pragma warning restore CA2211
    }

    public class TowerShieldHealth : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (NPC.ShieldStrengthTowerVortex > QoLCompendium.mainConfig.TowerShield)
            {
                NPC.ShieldStrengthTowerVortex = QoLCompendium.mainConfig.TowerShield;
            }

            if (NPC.ShieldStrengthTowerSolar > QoLCompendium.mainConfig.TowerShield)
            {
                NPC.ShieldStrengthTowerSolar = QoLCompendium.mainConfig.TowerShield;
            }

            if (NPC.ShieldStrengthTowerNebula > QoLCompendium.mainConfig.TowerShield)
            {
                NPC.ShieldStrengthTowerNebula = QoLCompendium.mainConfig.TowerShield;
            }

            if (NPC.ShieldStrengthTowerStardust > QoLCompendium.mainConfig.TowerShield)
            {
                NPC.ShieldStrengthTowerStardust = QoLCompendium.mainConfig.TowerShield;
            }
        }
    }

    public class PillarsDropMore : GlobalNPC
    {
        private static readonly int[] LunarPillars = { NPCID.LunarTowerSolar, NPCID.LunarTowerVortex, NPCID.LunarTowerNebula, NPCID.LunarTowerStardust };

        private static void MakeLunarPillarDropRulesBetter(DropOneByOne drop)
        {
            PropertyInfo parametersProperty = typeof(DropOneByOne).GetProperty("parameters", BindingFlags.Public | BindingFlags.Instance);
            DropOneByOne.Parameters newParameters = new()
            {
                MinimumItemDropsCount = 90,
                MaximumItemDropsCount = 110,
                ChanceNumerator = 1,
                ChanceDenominator = 1,
                MinimumStackPerChunkBase = 1,
                MaximumStackPerChunkBase = 1,
                BonusMinDropsPerChunkPerPlayer = 1,
                BonusMaxDropsPerChunkPerPlayer = 1
            };
            parametersProperty.SetValue(drop, newParameters);
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (LunarPillars.Contains(npc.type) && QoLCompendium.mainConfig.MoreFragments)
            {
                foreach (IItemDropRule rule in npcLoot.Get())
                {
                    if (rule is DropBasedOnExpertMode expertRule)
                    {
                        if (expertRule.ruleForNormalMode is DropOneByOne normalDrop)
                        {
                            MakeLunarPillarDropRulesBetter(normalDrop);
                        }

                        if (expertRule.ruleForExpertMode is DropOneByOne expertDrop)
                        {
                            MakeLunarPillarDropRulesBetter(expertDrop);
                        }
                    }
                }
            }
        }
    }

    public class BestiaryUnlock : GlobalNPC
    {
        public override void SetBestiary(NPC npc, BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            if (QoLCompendium.mainConfig.OneKillForBestiary)
            {
                bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[npc.type], true);
            }
        }
    }

    public class NoLavaFromSlimes : ModSystem
    {
        public override void Load()
        {
            IL_NPC.VanillaHitEffect += LavalessLavaSlime;
        }

        private void LavalessLavaSlime(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(
                    MoveType.After,
                    i => i.MatchCall(typeof(Main), "get_expertMode"),
                    i => i.Match(OpCodes.Brfalse),
                    i => i.Match(OpCodes.Ldarg_0),
                    i => i.MatchLdfld(typeof(NPC), nameof(NPC.type)),
                    i => i.Match(OpCodes.Ldc_I4_S, (sbyte)NPCID.LavaSlime)
                ))
                return;

            c.EmitDelegate<Func<int, int>>(returnValue => QoLCompendium.mainConfig.LavaSlimeNoLava ? NPCLoader.NPCCount : returnValue);
        }
    }

    public class NPCDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Harpy && QoLCompendium.itemConfig.InformationAccessories)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WingTimer>(), 20));
            }
        }
    }

    public static class NetcodeBossSpawn
    {
        public static void SpawnBossNetcoded(Player player, int bossType)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
                    NPC.NewNPC(null, (int)spawnPosition.X, (int)spawnPosition.Y, bossType);
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: bossType);
                }
            }
        }
    }

    public class NoTownSlimes : GlobalNPC
    {
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            if (QoLCompendium.mainConfig.NoTownSlimes)
            {
                pool.Remove(NPCID.TownSlimeBlue);
                pool.Remove(NPCID.TownSlimeGreen);
                pool.Remove(NPCID.TownSlimeOld);
                pool.Remove(NPCID.TownSlimePurple);
                pool.Remove(NPCID.TownSlimeRainbow);
                pool.Remove(NPCID.TownSlimeRed);
                pool.Remove(NPCID.TownSlimeYellow);
                pool.Remove(NPCID.TownSlimeCopper);
                pool.Remove(NPCID.BoundTownSlimeOld);
                pool.Remove(NPCID.BoundTownSlimePurple);
                pool.Remove(NPCID.BoundTownSlimeYellow);
            }
        }

        public override void AI(NPC npc)
        {
            if (QoLCompendium.mainConfig.NoTownSlimes)
            {
                if (npc.type == NPCID.TownSlimeBlue)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimeRed)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimeGreen)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimeRainbow)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimeCopper)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimeOld)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimeYellow)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.TownSlimePurple)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.BoundTownSlimeOld)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.BoundTownSlimePurple)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
                if (npc.type == NPCID.BoundTownSlimeYellow)
                {
                    npc.timeLeft = 0;
                    npc.active = false;
                }
            }
        }
    }

    public class NoTownSlimesSystem : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (QoLCompendium.mainConfig.NoTownSlimes)
            {
                NPC.unlockedSlimeBlueSpawn = false;
                NPC.unlockedSlimeCopperSpawn = false;
                NPC.unlockedSlimeGreenSpawn = false;
                NPC.unlockedSlimeOldSpawn = false;
                NPC.unlockedSlimePurpleSpawn = false;
                NPC.unlockedSlimeRainbowSpawn = false;
                NPC.unlockedSlimeRedSpawn = false;
                NPC.unlockedSlimeYellowSpawn = false;

                Main.townNPCCanSpawn[NPCID.TownSlimeBlue] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeGreen] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeOld] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimePurple] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeRainbow] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeRed] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeYellow] = false;
                Main.townNPCCanSpawn[NPCID.TownSlimeCopper] = false;
            }
        }
    }

    public class ModifyShopPrices : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            Player player = Main.LocalPlayer;
            if (npc.type == ModContent.NPCType<BMDealerNPC>() && player.active && player == Main.player[Main.myPlayer])
            {
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Potions")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.PotionPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Flasks, Stations & Foods")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        if (item.buffType > 0)
                        {
                            item.shopCustomPrice *= QoLCompendium.shopConfig.PotionPriceMultiplier;
                        }
                        else
                        {
                            item.shopCustomPrice *= QoLCompendium.shopConfig.StationPriceMultiplier;
                        }
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Materials")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.MaterialPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Movement Accessories")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.AccessoryPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Combat Accessories")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.AccessoryPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Informative/Building Gear")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.AccessoryPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Treasure Bags")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        if (NPC.downedBoss1 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedBoss2 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedBoss3 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (Main.hardMode && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 50000;
                        }
                        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedPlantBoss && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedGolemBoss && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedMoonlord && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        item.shopCustomPrice *= QoLCompendium.shopConfig.BagPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Crates & Grab Bags")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.CratePriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Ores & Bars")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.OrePriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Natural Blocks")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.NaturalBlockPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Building Blocks")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.BuildingBlockPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Herbs & Plants")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.HerbPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Fish & Fishing Gear")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.FishPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Mounts & Hooks")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.MountPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Ammo")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.AmmoPriceMultiplier;
                    }
                }
            }

            if (npc.type == ModContent.NPCType<EtherealCollectorNPC>() && player.active && player == Main.player[Main.myPlayer])
            {
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Potions")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.PotionPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Flasks, Stations & Foods")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        if (item.buffType > 0)
                        {
                            item.shopCustomPrice *= QoLCompendium.shopConfig.PotionPriceMultiplier;
                        }
                        else
                        {
                            item.shopCustomPrice *= QoLCompendium.shopConfig.StationPriceMultiplier;
                        }
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Materials")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.MaterialPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Treasure Bags")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        if (NPC.downedBoss1 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedBoss2 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedBoss3 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (Main.hardMode && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 50000;
                        }
                        if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedPlantBoss && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedGolemBoss && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        if (NPC.downedMoonlord && QoLCompendium.shopConfig.BossScaling)
                        {
                            item.shopCustomPrice += 25000;
                        }
                        item.shopCustomPrice *= QoLCompendium.shopConfig.BagPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Crates & Grab Bags")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.CratePriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Ores & Bars")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.OrePriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Natural Blocks")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.NaturalBlockPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Building Blocks")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.BuildingBlockPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Herbs & Plants")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.HerbPriceMultiplier;
                    }
                }
                if (shopName == NPCLoader.GetNPC(npc.type).FullName + "/Modded Fish & Fishing Gear")
                {
                    foreach (Item item in items)
                    {
                        if (item == null || item.type == ItemID.None) continue;
                        item.shopCustomPrice *= QoLCompendium.shopConfig.FishPriceMultiplier;
                    }
                }
            }

            if ((npc.type == ModContent.NPCType<BMDealerNPC>() || npc.type == ModContent.NPCType<EtherealCollectorNPC>()) && player.active && player == Main.player[Main.myPlayer])
            {
                foreach (Item item in items)
                {
                    if (item == null || item.type == ItemID.None) continue;
                    item.shopCustomPrice *= QoLCompendium.shopConfig.GlobalPriceMultiplier;
                }
            }
        }
    }

    public class AnglerReset : GlobalNPC
    {
        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (QoLCompendium.mainConfig.AnglerQuestInstantReset && Main.anglerQuestFinished)
            {
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.AnglerQuestSwap();
                }
                else if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    // Broadcast swap request to server
                    var netMessage = Mod.GetPacket();
                    netMessage.Write((byte)3);
                    netMessage.Send();
                }
            }
        }
    }

    public class CheckIfNPCIsDead : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            //VANILLA
            if (npc.type == NPCID.BloodNautilus)
            {
                //ModConditions.downedDreadnautilus = true;
                NPC.SetEventFlagCleared(ref ModConditions.downedDreadnautilus, -1);
            }
            if (npc.type == NPCID.MartianSaucerCore || npc.type == NPCID.MartianSaucer)
            {
                //ModConditions.downedMartianSaucer = true;
                NPC.SetEventFlagCleared(ref ModConditions.downedMartianSaucer, -1);
            }

            if (ModConditions.afkpetsLoaded)
            {
                if (ModConditions.afkpetsMod.TryFind("SlayerofEvil", out ModNPC SlayerofEvil) && npc.type == SlayerofEvil.Type)
                {
                    //ModConditions.downedSlayerOfEvil = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSlayerOfEvil, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("SATLA001", out ModNPC SATLA001) && npc.type == SATLA001.Type)
                {
                    //ModConditions.downedSATLA = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSATLA, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("DrFetusThirdPhase", out ModNPC DrFetusThirdPhase) && npc.type == DrFetusThirdPhase.Type)
                {
                    //ModConditions.downedDrFetus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDrFetus, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("MechanicalSlime", out ModNPC MechanicalSlime) && npc.type == MechanicalSlime.Type)
                {
                    //ModConditions.downedSlimesHope = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSlimesHope, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("PoliticianSlime", out ModNPC PoliticianSlime) && npc.type == PoliticianSlime.Type)
                {
                    //ModConditions.downedPoliticianSlime = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPoliticianSlime, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("FlagCarrier", out ModNPC FlagCarrier) && npc.type == FlagCarrier.Type)
                {
                    //ModConditions.downedAncientTrio = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientTrio, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("LavalGolem", out ModNPC LavalGolem) && npc.type == LavalGolem.Type)
                {
                    //ModConditions.downedLavalGolem = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLavalGolem, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("NecromancerDummy", out ModNPC NecromancerDummy) && npc.type == NecromancerDummy.Type)
                {
                    //ModConditions.downedAntony = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAntony, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("BunnyZepplin", out ModNPC BunnyZepplin) && npc.type == BunnyZepplin.Type)
                {
                    //ModConditions.downedBunnyZeppelin = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBunnyZeppelin, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("Okiku", out ModNPC Okiku) && npc.type == Okiku.Type)
                {
                    //ModConditions.downedOkiku = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOkiku, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("StormTinkererH", out ModNPC StormTinkererH) && npc.type == StormTinkererH.Type)
                {
                    //ModConditions.downedHarpyAirforce = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHarpyAirforce, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("DemonIsaac", out ModNPC DemonIsaac) && npc.type == DemonIsaac.Type)
                {
                    //ModConditions.downedIsaac = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedIsaac, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("AncientGuardian", out ModNPC AncientGuardian) && npc.type == AncientGuardian.Type)
                {
                    //ModConditions.downedAncientGuardian = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientGuardian, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("HeroicSlime", out ModNPC HeroicSlime) && npc.type == HeroicSlime.Type)
                {
                    //ModConditions.downedHeroicSlime = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHeroicSlime, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("HolographicSlime", out ModNPC HolographicSlime) && npc.type == HolographicSlime.Type)
                {
                    //ModConditions.downedHoloSlime = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHoloSlime, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("SecurityBot", out ModNPC SecurityBot) && npc.type == SecurityBot.Type)
                {
                    //ModConditions.downedSecurityBot = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSecurityBot, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("UndeadChef", out ModNPC UndeadChef) && npc.type == UndeadChef.Type)
                {
                    //ModConditions.downedUndeadChef = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedUndeadChef, -1);
                }
                if (ModConditions.afkpetsMod.TryFind("IceGuardian", out ModNPC IceGuardian) && npc.type == IceGuardian.Type)
                {
                    //ModConditions.downedGuardianOfFrost = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGuardianOfFrost, -1);
                }
            }

            if (ModConditions.assortedCrazyThingsLoaded)
            {
                if (ModConditions.assortedCrazyThingsMod.TryFind("HarvesterBoss", out ModNPC HarvesterBoss) && npc.type == HarvesterBoss.Type)
                {
                    //ModConditions.downedSoulHarvester = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSoulHarvester, -1);
                }
            }

            if (ModConditions.awfulGarbageLoaded)
            {
                if (ModConditions.awfulGarbageMod.TryFind("TreeToad", out ModNPC TreeToad) && npc.type == TreeToad.Type)
                {
                    //ModConditions.downedTreeToad = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTreeToad, -1);
                }
                if (ModConditions.awfulGarbageMod.TryFind("SeseKitsugai", out ModNPC SeseKitsugai) && npc.type == SeseKitsugai.Type)
                {
                    //ModConditions.downedSeseKitsugai = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeseKitsugai, -1);
                }
                if (ModConditions.awfulGarbageMod.TryFind("EyeOfTheStorm", out ModNPC EyeOfTheStorm) && npc.type == EyeOfTheStorm.Type)
                {
                    //ModConditions.downedEyeOfTheStorm = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEyeOfTheStorm, -1);
                }
                if (ModConditions.awfulGarbageMod.TryFind("FrigidiusHead", out ModNPC FrigidiusHead) && npc.type == FrigidiusHead.Type)
                {
                    //ModConditions.downedFrigidius = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedFrigidius, -1);
                }
            }

            if (ModConditions.calamityLoaded)
            {
                if (ModConditions.calamityMod.TryFind("CragmawMire", out ModNPC CragmawMire) && npc.type == CragmawMire.Type)
                {
                    //ModConditions.downedCragmawMire = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCragmawMire, -1);
                }
                if (ModConditions.calamityMod.TryFind("NuclearTerror", out ModNPC NuclearTerror) && npc.type == NuclearTerror.Type)
                {
                    //ModConditions.downedNuclearTerror = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNuclearTerror, -1);
                }
                if (ModConditions.calamityMod.TryFind("Mauler", out ModNPC Mauler) && npc.type == Mauler.Type)
                {
                    //ModConditions.downedMauler = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMauler, -1);
                }
            }

            if (ModConditions.calamityCommunityRemixLoaded)
            {
                if (ModConditions.calamityCommunityRemixMod.TryFind("WulfwyrmHead", out ModNPC WulfwyrmHead) && npc.type == WulfwyrmHead.Type)
                {
                    //ModConditions.downedWulfrumExcavator = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedWulfrumExcavator, -1);
                }
            }

            if (ModConditions.catalystLoaded)
            {
                if (ModConditions.catalystMod.TryFind("Astrageldon", out ModNPC Astrageldon) && npc.type == Astrageldon.Type)
                {
                    //ModConditions.downedAstrageldon = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAstrageldon, -1);
                }
            }

            if (ModConditions.clamityAddonLoaded)
            {
                if (ModConditions.clamityAddonMod.TryFind("ClamitasBoss", out ModNPC ClamitasBoss) && npc.type == ClamitasBoss.Type)
                {
                    //ModConditions.downedClamitas = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedClamitas, -1);
                }
                if (ModConditions.clamityAddonMod.TryFind("PyrogenBoss", out ModNPC PyrogenBoss) && npc.type == PyrogenBoss.Type)
                {
                    //ModConditions.downedPyrogen = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPyrogen, -1);
                }
                if (ModConditions.clamityAddonMod.TryFind("WallOfBronze", out ModNPC WallOfBronze) && npc.type == WallOfBronze.Type)
                {
                    //ModConditions.downedWallOfBronze = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedWallOfBronze, -1);
                }
            }

            if (ModConditions.consolariaLoaded)
            {
                if (ModConditions.consolariaMod.TryFind("Lepus", out ModNPC Lepus) && npc.type == Lepus.Type)
                {
                    //ModConditions.downedLepus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLepus, -1);
                }
                if (ModConditions.consolariaMod.TryFind("TurkortheUngrateful", out ModNPC TurkortheUngrateful) && npc.type == TurkortheUngrateful.Type)
                {
                    //ModConditions.downedTurkor = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTurkor, -1);
                }
                if (ModConditions.consolariaMod.TryFind("Ocram", out ModNPC Ocram) && npc.type == Ocram.Type)
                {
                    //ModConditions.downedOcram = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOcram, -1);
                }
            }

            if (ModConditions.depthsLoaded)
            {
                if (ModConditions.depthsMod.TryFind("ChasmeHeart", out ModNPC ChasmeHeart) && npc.type == ChasmeHeart.Type)
                {
                    //ModConditions.downedChasme = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedChasme, -1);
                }
            }

            if (ModConditions.echoesOfTheAncientsLoaded)
            {
                if (ModConditions.echoesOfTheAncientsMod.TryFind("Galahis", out ModNPC Galahis) && npc.type == Galahis.Type)
                {
                    //ModConditions.downedGalahis = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGalahis, -1);
                }
                if (ModConditions.echoesOfTheAncientsMod.TryFind("AquaWormHead", out ModNPC AquaWormHead) && npc.type == AquaWormHead.Type)
                {
                    //ModConditions.downedCreation = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCreation, -1);
                }
                if (ModConditions.echoesOfTheAncientsMod.TryFind("PumpkinWormHead", out ModNPC PumpkinWormHead) && npc.type == PumpkinWormHead.Type)
                {
                    //ModConditions.downedDestruction = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDestruction, -1);
                }
            }

            if (ModConditions.edorbisLoaded)
            {
                if (ModConditions.edorbisMod.TryFind("BlightKing", out ModNPC BlightKing) && npc.type == BlightKing.Type)
                {
                    //ModConditions.downedBlightKing = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBlightKing, -1);
                }
                if (ModConditions.edorbisMod.TryFind("TheGardener", out ModNPC TheGardener) && npc.type == TheGardener.Type)
                {
                    //ModConditions.downedGardener = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGardener, -1);
                }
                if (ModConditions.edorbisMod.TryFind("GlaciationHead", out ModNPC GlaciationHead) && npc.type == GlaciationHead.Type)
                {
                    //ModConditions.downedGlaciation = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlaciation, -1);
                }
                if (ModConditions.edorbisMod.TryFind("HandofCthulhu", out ModNPC HandofCthulhu) && npc.type == HandofCthulhu.Type)
                {
                    //ModConditions.downedHandOfCthulhu = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHandOfCthulhu, -1);
                }
                if (ModConditions.edorbisMod.TryFind("CursedLord", out ModNPC CursedLord) && npc.type == CursedLord.Type)
                {
                    //ModConditions.downedCursePreacher = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCursePreacher, -1);
                }
            }

            if (ModConditions.exaltLoaded)
            {
                if (ModConditions.exaltMod.TryFind("Effulgence", out ModNPC Effulgence) && npc.type == Effulgence.Type)
                {
                    //ModConditions.downedEffulgence = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEffulgence, -1);
                }
                if (ModConditions.exaltMod.TryFind("IceLich", out ModNPC IceLich) && npc.type == IceLich.Type)
                {
                    //ModConditions.downedIceLich = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedIceLich, -1);
                }
            }

            if (ModConditions.exxoAvalonOriginsLoaded)
            {
                if (ModConditions.exxoAvalonOriginsMod.TryFind("BacteriumPrime", out ModNPC BacteriumPrime) && npc.type == BacteriumPrime.Type)
                {
                    //ModConditions.downedBacteriumPrime = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBacteriumPrime, -1);
                }
                if (ModConditions.exxoAvalonOriginsMod.TryFind("DesertBeak", out ModNPC DesertBeak) && npc.type == DesertBeak.Type)
                {
                    //ModConditions.downedDesertBeak = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDesertBeak, -1);
                }
                if (ModConditions.exxoAvalonOriginsMod.TryFind("KingSting", out ModNPC KingSting) && npc.type == KingSting.Type)
                {
                    //ModConditions.downedKingSting = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedKingSting, -1);
                }
                if (ModConditions.exxoAvalonOriginsMod.TryFind("Mechasting", out ModNPC Mechasting) && npc.type == Mechasting.Type)
                {
                    //ModConditions.downedMechasting = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMechasting, -1);
                }
                if (ModConditions.exxoAvalonOriginsMod.TryFind("Phantasm", out ModNPC Phantasm) && npc.type == Phantasm.Type)
                {
                    //ModConditions.downedPhantasm = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPhantasm, -1);
                }
            }

            if (ModConditions.fargosSoulsLoaded)
            {
                if (ModConditions.fargosSoulsMod.TryFind("TrojanSquirrel", out ModNPC TrojanSquirrel) && npc.type == TrojanSquirrel.Type)
                {
                    //ModConditions.downedTrojanSquirrel = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTrojanSquirrel, -1);
                }
                if (ModConditions.fargosSoulsMod.TryFind("DeviBoss", out ModNPC DeviBoss) && npc.type == DeviBoss.Type)
                {
                    //ModConditions.downedDeviantt = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDeviantt, -1);
                }
                if (ModConditions.fargosSoulsMod.TryFind("BanishedBaron", out ModNPC BanishedBaron) && npc.type == BanishedBaron.Type)
                {
                    //ModConditions.downedBanishedBaron = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBanishedBaron, -1);
                }
                if (ModConditions.fargosSoulsMod.TryFind("LifeChallenger", out ModNPC LifeChallenger) && npc.type == LifeChallenger.Type)
                {
                    //ModConditions.downedLifelight = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLifelight, -1);
                }
                if (ModConditions.fargosSoulsMod.TryFind("CosmosChampion", out ModNPC CosmosChampion) && npc.type == CosmosChampion.Type)
                {
                    //ModConditions.downedEridanus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEridanus, -1);
                }
                if (ModConditions.fargosSoulsMod.TryFind("AbomBoss", out ModNPC AbomBoss) && npc.type == AbomBoss.Type)
                {
                    //ModConditions.downedAbominationn = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAbominationn, -1);
                }
                if (ModConditions.fargosSoulsMod.TryFind("MutantBoss", out ModNPC MutantBoss) && npc.type == MutantBoss.Type)
                {
                    //ModConditions.downedMutant = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMutant, -1);
                }
            }

            if (ModConditions.fracturesOfPenumbraLoaded)
            {
                if (ModConditions.fracturesOfPenumbraMod.TryFind("AlphaFrostjawHead", out ModNPC AlphaFrostjawHead) && npc.type == AlphaFrostjawHead.Type)
                {
                    //ModConditions.downedAlphaFrostjaw = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAlphaFrostjaw, -1);
                }
                if (ModConditions.fracturesOfPenumbraMod.TryFind("SanguineElemental", out ModNPC SanguineElemental) && npc.type == SanguineElemental.Type)
                {
                    //ModConditions.downedSanguineElemental = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSanguineElemental, -1);
                }
            }

            if (ModConditions.gameTerrariaLoaded)
            {
                if (ModConditions.gameTerrariaMod.TryFind("Lad", out ModNPC Lad) && npc.type == Lad.Type)
                {
                    //ModConditions.downedLad = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLad, -1);
                }
                if (ModConditions.gameTerrariaMod.TryFind("Hornlitz", out ModNPC Hornlitz) && npc.type == Hornlitz.Type)
                {
                    //ModConditions.downedHornlitz = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHornlitz, -1);
                }
                if (ModConditions.gameTerrariaMod.TryFind("SnowDonCore", out ModNPC SnowDonCore) && npc.type == SnowDonCore.Type)
                {
                    //ModConditions.downedSnowDon = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSnowDon, -1);
                }
                if (ModConditions.gameTerrariaMod.TryFind("Stoffie", out ModNPC Stoffie) && npc.type == Stoffie.Type)
                {
                    //ModConditions.downedStoffie = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoffie, -1);
                }
            }

            if (ModConditions.gensokyoLoaded)
            {
                if (ModConditions.gensokyoMod.TryFind("LilyWhite", out ModNPC LilyWhite) && npc.type == LilyWhite.Type)
                {
                    //ModConditions.downedLilyWhite = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLilyWhite, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("Rumia", out ModNPC Rumia) && npc.type == Rumia.Type)
                {
                    //ModConditions.downedRumia = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedRumia, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("EternityLarva", out ModNPC EternityLarva) && npc.type == EternityLarva.Type)
                {
                    //ModConditions.downedEternityLarva = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEternityLarva, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("Nazrin", out ModNPC Nazrin) && npc.type == Nazrin.Type)
                {
                    //ModConditions.downedNazrin = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNazrin, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("HinaKagiyama", out ModNPC HinaKagiyama) && npc.type == HinaKagiyama.Type)
                {
                    //ModConditions.downedHinaKagiyama = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHinaKagiyama, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("Sekibanki", out ModNPC Sekibanki) && npc.type == Sekibanki.Type)
                {
                    //ModConditions.downedSekibanki = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSekibanki, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("Seiran", out ModNPC Seiran) && npc.type == Seiran.Type)
                {
                    //ModConditions.downedSeiran = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeiran, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("NitoriKawashiro", out ModNPC NitoriKawashiro) && npc.type == NitoriKawashiro.Type)
                {
                    //ModConditions.downedNitoriKawashiro = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNitoriKawashiro, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("MedicineMelancholy", out ModNPC MedicineMelancholy) && npc.type == MedicineMelancholy.Type)
                {
                    //ModConditions.downedMedicineMelancholy = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMedicineMelancholy, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("Cirno", out ModNPC Cirno) && npc.type == Cirno.Type)
                {
                    //ModConditions.downedCirno = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCirno, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("MinamitsuMurasa", out ModNPC MinamitsuMurasa) && npc.type == MinamitsuMurasa.Type)
                {
                    //ModConditions.downedMinamitsuMurasa = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMinamitsuMurasa, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("AliceMargatroid", out ModNPC AliceMargatroid) && npc.type == AliceMargatroid.Type)
                {
                    //ModConditions.downedAliceMargatroid = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAliceMargatroid, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("SakuyaIzayoi", out ModNPC SakuyaIzayoi) && npc.type == SakuyaIzayoi.Type)
                {
                    //ModConditions.downedSakuyaIzayoi = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSakuyaIzayoi, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("SeijaKijin", out ModNPC SeijaKijin) && npc.type == SeijaKijin.Type)
                {
                    //ModConditions.downedSeijaKijin = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeijaKijin, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("MayumiJoutouguu", out ModNPC MayumiJoutouguu) && npc.type == MayumiJoutouguu.Type)
                {
                    //ModConditions.downedMayumiJoutouguu = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMayumiJoutouguu, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("ToyosatomimiNoMiko", out ModNPC ToyosatomimiNoMiko) && npc.type == ToyosatomimiNoMiko.Type)
                {
                    //ModConditions.downedToyosatomimiNoMiko = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedToyosatomimiNoMiko, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("KaguyaHouraisan", out ModNPC KaguyaHouraisan) && npc.type == KaguyaHouraisan.Type)
                {
                    //ModConditions.downedKaguyaHouraisan = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedKaguyaHouraisan, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("UtsuhoReiuji", out ModNPC UtsuhoReiuji) && npc.type == UtsuhoReiuji.Type)
                {
                    //ModConditions.downedUtsuhoReiuji = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedUtsuhoReiuji, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("TenshiHinanawi", out ModNPC TenshiHinanawi) && npc.type == TenshiHinanawi.Type)
                {
                    //ModConditions.downedTenshiHinanawi = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTenshiHinanawi, -1);
                }
                if (ModConditions.gensokyoMod.TryFind("Kisume", out ModNPC Kisume) && npc.type == Kisume.Type)
                {
                    //ModConditions.downedKisume = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedKisume, -1);
                }
            }

            if (ModConditions.gerdsLabLoaded)
            {
                if (ModConditions.gerdsLabMod.TryFind("Trerios", out ModNPC Trerios) && npc.type == Trerios.Type)
                {
                    //ModConditions.downedTrerios = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTrerios, -1);
                }
                if (ModConditions.gerdsLabMod.TryFind("MagmaEye", out ModNPC MagmaEye) && npc.type == MagmaEye.Type)
                {
                    //ModConditions.downedMagmaEye = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMagmaEye, -1);
                }
                if (ModConditions.gerdsLabMod.TryFind("Jack", out ModNPC Jack) && npc.type == Jack.Type)
                {
                    //ModConditions.downedJack = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedJack, -1);
                }
                if (ModConditions.gerdsLabMod.TryFind("Acheron", out ModNPC Acheron) && npc.type == Acheron.Type)
                {
                    //ModConditions.downedAcheron = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAcheron, -1);
                }
            }

            if (ModConditions.homewardJourneyLoaded)
            {
                if (ModConditions.homewardJourneyMod.TryFind("MarquisMoonsquid", out ModNPC MarquisMoonsquid) && npc.type == MarquisMoonsquid.Type)
                {
                    //ModConditions.downedMarquisMoonsquid = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMarquisMoonsquid, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("PriestessRod", out ModNPC PriestessRod) && npc.type == PriestessRod.Type)
                {
                    //ModConditions.downedPriestessRod = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPriestessRod, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Diver", out ModNPC Diver) && npc.type == Diver.Type)
                {
                    //ModConditions.downedDiver = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDiver, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheMotherbrain", out ModNPC TheMotherbrain) && npc.type == TheMotherbrain.Type)
                {
                    //ModConditions.downedMotherbrain = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMotherbrain, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("WallofShadow", out ModNPC WallofShadow) && npc.type == WallofShadow.Type)
                {
                    //ModConditions.downedWallOfShadow = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedWallOfShadow, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("SlimeGod", out ModNPC SlimeGod) && npc.type == SlimeGod.Type)
                {
                    //ModConditions.downedSunSlimeGod = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunSlimeGod, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheOverwatcher", out ModNPC TheOverwatcher) && npc.type == TheOverwatcher.Type)
                {
                    //ModConditions.downedOverwatcher = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOverwatcher, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheLifebringerHead", out ModNPC TheLifebringerHead) && npc.type == TheLifebringerHead.Type)
                {
                    //ModConditions.downedLifebringer = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLifebringer, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheMaterealizer", out ModNPC TheMaterealizer) && npc.type == TheMaterealizer.Type)
                {
                    //ModConditions.downedMaterealizer = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMaterealizer, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Cave", out ModNPC Trial_Cave) && npc.type == Trial_Cave.Type)
                {
                    //ModConditions.downedCaveOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCaveOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Corruption", out ModNPC Trial_Corruption) && npc.type == Trial_Corruption.Type)
                {
                    //ModConditions.downedCorruptOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCorruptOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Crimson", out ModNPC Trial_Crimson) && npc.type == Trial_Crimson.Type)
                {
                    //ModConditions.downedCrimsonOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCrimsonOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Desert", out ModNPC Trial_Desert) && npc.type == Trial_Desert.Type)
                {
                    //ModConditions.downedDesertOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDesertOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Forest", out ModNPC Trial_Forest) && npc.type == Trial_Forest.Type)
                {
                    //ModConditions.downedForestOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedForestOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Hallow", out ModNPC Trial_Hallow) && npc.type == Trial_Hallow.Type)
                {
                    //ModConditions.downedHallowOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHallowOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Jungle", out ModNPC Trial_Jungle) && npc.type == Trial_Jungle.Type)
                {
                    //ModConditions.downedJungleOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedJungleOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Pure", out ModNPC Trial_Pure) && npc.type == Trial_Pure.Type)
                {
                    //ModConditions.downedSkyOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSkyOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Snow", out ModNPC Trial_Snow) && npc.type == Trial_Snow.Type)
                {
                    //ModConditions.downedSnowOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSnowOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Underworld", out ModNPC Trial_Underworld) && npc.type == Trial_Underworld.Type)
                {
                    //ModConditions.downedUnderworldOrdeal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedUnderworldOrdeal, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("ScarabBelief", out ModNPC ScarabBelief) && npc.type == ScarabBelief.Type)
                {
                    //ModConditions.downedScarabBelief = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedScarabBelief, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("WorldsEndEverlastingFallingWhale", out ModNPC WorldsEndEverlastingFallingWhale) && npc.type == WorldsEndEverlastingFallingWhale.Type)
                {
                    //ModConditions.downedWorldsEndWhale = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedWorldsEndWhale, -1);
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheSon", out ModNPC TheSon) && npc.type == TheSon.Type)
                {
                    //ModConditions.downedSon = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSon, -1);
                }
            }

            if (ModConditions.huntOfTheOldGodLoaded)
            {
                if (ModConditions.huntOfTheOldGodMod.TryFind("Goozma", out ModNPC Goozma) && npc.type == Goozma.Type)
                {
                    //ModConditions.downedGoozma = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGoozma, -1);
                }
            }

            if (ModConditions.infernumLoaded)
            {
                if (ModConditions.infernumMod.TryFind("BereftVassal", out ModNPC BereftVassal) && npc.type == BereftVassal.Type)
                {
                    SubworldModConditions.downedBereftVassal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBereftVassal, -1);
                }
            }

            if (ModConditions.lunarVeilLoaded)
            {
                if (ModConditions.lunarVeilMod.TryFind("StarrVeriplant", out ModNPC StarrVeriplant) && npc.type == StarrVeriplant.Type)
                {
                    //ModConditions.downedStoneGuardian = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoneGuardian, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("CommanderGintzia", out ModNPC CommanderGintzia) && npc.type == CommanderGintzia.Type)
                {
                    //ModConditions.downedCommanderGintzia = true;
                    //ModConditions.downedGintzeArmy = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCommanderGintzia, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedGintzeArmy, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("SunStalker", out ModNPC SunStalker) && npc.type == SunStalker.Type)
                {
                    //ModConditions.downedSunStalker = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunStalker, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("Jack", out ModNPC Jack) && npc.type == Jack.Type)
                {
                    //ModConditions.downedPumpkinJack = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPumpkinJack, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("DaedusR", out ModNPC DaedusR) && npc.type == DaedusR.Type)
                {
                    //ModConditions.downedForgottenPuppetDaedus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedForgottenPuppetDaedus, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("DreadMire", out ModNPC DreadMire) && npc.type == DreadMire.Type)
                {
                    //ModConditions.downedDreadMire = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDreadMire, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("SingularityFragment", out ModNPC SingularityFragment) && npc.type == SingularityFragment.Type)
                {
                    //ModConditions.downedSingularityFragment = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSingularityFragment, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("VerliaB", out ModNPC VerliaB) && npc.type == VerliaB.Type)
                {
                    //ModConditions.downedVerlia = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedVerlia, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("Gothiviab", out ModNPC Gothiviab) && npc.type == Gothiviab.Type)
                {
                    //ModConditions.downedIrradia = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedIrradia, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("Sylia", out ModNPC Sylia) && npc.type == Sylia.Type)
                {
                    //ModConditions.downedSylia = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSylia, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("Fenix", out ModNPC Fenix) && npc.type == Fenix.Type)
                {
                    //ModConditions.downedFenix = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedFenix, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("BlazingSerpentHead", out ModNPC BlazingSerpentHead) && npc.type == BlazingSerpentHead.Type)
                {
                    //ModConditions.downedBlazingSerpent = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBlazingSerpent, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("Cogwork", out ModNPC Cogwork) && npc.type == Cogwork.Type)
                {
                    //ModConditions.downedCogwork = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCogwork, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("WaterCogwork", out ModNPC WaterCogwork) && npc.type == WaterCogwork.Type)
                {
                    //ModConditions.downedWaterCogwork = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedWaterCogwork, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("WaterJellyfish", out ModNPC WaterJellyfish) && npc.type == WaterJellyfish.Type)
                {
                    //ModConditions.downedWaterJellyfish = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedWaterJellyfish, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("Sparn", out ModNPC Sparn) && npc.type == Sparn.Type)
                {
                    //ModConditions.downedSparn = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSparn, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("PandorasFlamebox", out ModNPC PandorasFlamebox) && npc.type == PandorasFlamebox.Type)
                {
                    //ModConditions.downedPandorasFlamebox = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPandorasFlamebox, -1);
                }
                if (ModConditions.lunarVeilMod.TryFind("STARBOMBER", out ModNPC STARBOMBER) && npc.type == STARBOMBER.Type)
                {
                    //ModConditions.downedSTARBOMBER = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSTARBOMBER, -1);
                }
            }

            if (ModConditions.martainsOrderLoaded)
            {
                if (ModConditions.martainsOrderMod.TryFind("Britzz", out ModNPC Britzz) && npc.type == Britzz.Type)
                {
                    //ModConditions.downedBritzz = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBritzz, -1);
                }
                if (ModConditions.martainsOrderMod.TryFind("Alchemist", out ModNPC Alchemist) && npc.type == Alchemist.Type)
                {
                    //ModConditions.downedTheAlchemist = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTheAlchemist, -1);
                }
                if (ModConditions.martainsOrderMod.TryFind("CarnagePillar", out ModNPC CarnagePillar) && npc.type == CarnagePillar.Type)
                {
                    //ModConditions.downedCarnagePillar = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCarnagePillar, -1);
                }
                if (ModConditions.martainsOrderMod.TryFind("VoidDiggerHead", out ModNPC VoidDiggerHead) && npc.type == VoidDiggerHead.Type)
                {
                    //ModConditions.downedVoidDigger = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedVoidDigger, -1);
                }
                if (ModConditions.martainsOrderMod.TryFind("PrinceSlime", out ModNPC PrinceSlime) && npc.type == PrinceSlime.Type)
                {
                    //ModConditions.downedPrinceSlime = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrinceSlime, -1);
                }
                ModConditions.martainsOrderMod.TryFind("Evocornator", out ModNPC Evocornator);
                ModConditions.martainsOrderMod.TryFind("Retinator", out ModNPC Retinator);
                ModConditions.martainsOrderMod.TryFind("Spazmator", out ModNPC Spazmator);
                if (npc.type == Evocornator.Type && !NPC.AnyNPCs(Retinator.Type) && !NPC.AnyNPCs(Spazmator.Type))
                {
                    //ModConditions.downedTriplets = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Retinator.Type && !NPC.AnyNPCs(Evocornator.Type) && !NPC.AnyNPCs(Spazmator.Type))
                {
                    //ModConditions.downedTriplets = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Spazmator.Type && !NPC.AnyNPCs(Evocornator.Type) && !NPC.AnyNPCs(Retinator.Type))
                {
                    //ModConditions.downedTriplets = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (ModConditions.martainsOrderMod.TryFind("MechPlantera", out ModNPC MechPlantera) && npc.type == MechPlantera.Type)
                {
                    //ModConditions.downedJungleDefenders = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedJungleDefenders, -1);
                }
            }

            if (ModConditions.mechReworkLoaded)
            {
                if (ModConditions.mechReworkMod.TryFind("Mechclops", out ModNPC Mechclops) && npc.type == Mechclops.Type)
                {
                    //ModConditions.downedSt4sys = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSt4sys, -1);
                }
                if (ModConditions.mechReworkMod.TryFind("TheTerminator", out ModNPC TheTerminator) && npc.type == TheTerminator.Type)
                {
                    //ModConditions.downedTerminator = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTerminator, -1);
                }
                if (ModConditions.mechReworkMod.TryFind("Caretaker", out ModNPC Caretaker) && npc.type == Caretaker.Type)
                {
                    //ModConditions.downedCaretaker = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCaretaker, -1);
                }
                if (ModConditions.mechReworkMod.TryFind("SiegeEngine", out ModNPC SiegeEngine) && npc.type == SiegeEngine.Type)
                {
                    //ModConditions.downedSiegeEngine = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSiegeEngine, -1);
                }
            }

            if (ModConditions.medialRiftLoaded)
            {
                if (ModConditions.medialRiftMod.TryFind("SuperVoltaicMotherSlime", out ModNPC SuperVoltaicMotherSlime) && npc.type == SuperVoltaicMotherSlime.Type)
                {
                    //ModConditions.downedSuperVoltaicMotherSlime = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSuperVoltaicMotherSlime, -1);
                }
            }

            if (ModConditions.metroidLoaded)
            {
                if (ModConditions.metroidMod.TryFind("Torizo", out ModNPC Torizo) && npc.type == Torizo.Type)
                {
                    //ModConditions.downedTorizo = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTorizo, -1);
                }
                if (ModConditions.metroidMod.TryFind("Serris_Head", out ModNPC Serris_Head) && npc.type == Serris_Head.Type)
                {
                    //ModConditions.downedSerris = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSerris, -1);
                }
                if (ModConditions.metroidMod.TryFind("Kraid_Head", out ModNPC Kraid_Head) && npc.type == Kraid_Head.Type)
                {
                    //ModConditions.downedKraid = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedKraid, -1);
                }
                if (ModConditions.metroidMod.TryFind("Phantoon", out ModNPC Phantoon) && npc.type == Phantoon.Type)
                {
                    //ModConditions.downedPhantoon = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPhantoon, -1);
                }
                if (ModConditions.metroidMod.TryFind("OmegaPirate", out ModNPC OmegaPirate) && npc.type == OmegaPirate.Type)
                {
                    //ModConditions.downedOmegaPirate = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaPirate, -1);
                }
                if (ModConditions.metroidMod.TryFind("Nightmare", out ModNPC Nightmare) && npc.type == Nightmare.Type)
                {
                    //ModConditions.downedNightmare = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNightmare, -1);
                }
                if (ModConditions.metroidMod.TryFind("GoldenTorizo", out ModNPC GoldenTorizo) && npc.type == GoldenTorizo.Type)
                {
                    //ModConditions.downedGoldenTorizo = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGoldenTorizo, -1);
                }
            }

            if (ModConditions.polaritiesLoaded)
            {
                if (ModConditions.polaritiesMod.TryFind("StormCloudfish", out ModNPC StormCloudfish) && npc.type == StormCloudfish.Type)
                {
                    //ModConditions.downedStormCloudfish = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStormCloudfish, -1);
                }
                if (ModConditions.polaritiesMod.TryFind("StarConstruct", out ModNPC StarConstruct) && npc.type == StarConstruct.Type)
                {
                    //ModConditions.downedStarConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStarConstruct, -1);
                }
                if (ModConditions.polaritiesMod.TryFind("Gigabat", out ModNPC Gigabat) && npc.type == Gigabat.Type)
                {
                    //ModConditions.downedGigabat = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGigabat, -1);
                }
                if (ModConditions.polaritiesMod.TryFind("SunPixie", out ModNPC SunPixie) && npc.type == SunPixie.Type)
                {
                    //ModConditions.downedSunPixie = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunPixie, -1);
                }
                if (ModConditions.polaritiesMod.TryFind("Esophage", out ModNPC Esophage) && npc.type == Esophage.Type)
                {
                    //ModConditions.downedEsophage = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEsophage, -1);
                }
                if (ModConditions.polaritiesMod.TryFind("ConvectiveWanderer", out ModNPC ConvectiveWanderer) && npc.type == ConvectiveWanderer.Type)
                {
                    //ModConditions.downedConvectiveWanderer = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedConvectiveWanderer, -1);
                }
            }

            if (ModConditions.qwertyLoaded)
            {
                if (ModConditions.qwertyMod.TryFind("PolarBear", out ModNPC PolarBear) && npc.type == PolarBear.Type)
                {
                    //ModConditions.downedPolarExterminator = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPolarExterminator, -1);
                }
                if (ModConditions.qwertyMod.TryFind("FortressBoss", out ModNPC FortressBoss) && npc.type == FortressBoss.Type)
                {
                    //ModConditions.downedDivineLight = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDivineLight, -1);
                }
                if (ModConditions.qwertyMod.TryFind("AncientMachine", out ModNPC AncientMachine) && npc.type == AncientMachine.Type)
                {
                    //ModConditions.downedAncientMachine = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientMachine, -1);
                }
                if (ModConditions.qwertyMod.TryFind("CloakedDarkBoss", out ModNPC CloakedDarkBoss) && npc.type == CloakedDarkBoss.Type)
                {
                    //ModConditions.downedNoehtnap = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNoehtnap, -1);
                }
                if (ModConditions.qwertyMod.TryFind("Hydra", out ModNPC Hydra) && npc.type == Hydra.Type)
                {
                    //ModConditions.downedHydra = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHydra, -1);
                }
                if (ModConditions.qwertyMod.TryFind("Imperious", out ModNPC Imperious) && npc.type == Imperious.Type)
                {
                    //ModConditions.downedImperious = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedImperious, -1);
                }
                if (ModConditions.qwertyMod.TryFind("RuneGhost", out ModNPC RuneGhost) && npc.type == RuneGhost.Type)
                {
                    //ModConditions.downedRuneGhost = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedRuneGhost, -1);
                }
                if (ModConditions.qwertyMod.TryFind("InvaderBattleship", out ModNPC InvaderBattleship) && npc.type == InvaderBattleship.Type)
                {
                    //ModConditions.downedInvaderBattleship = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaderBattleship, -1);
                }
                if (ModConditions.qwertyMod.TryFind("InvaderNoehtnap", out ModNPC InvaderNoehtnap) && npc.type == InvaderNoehtnap.Type)
                {
                    //ModConditions.downedInvaderNoehtnap = true;
                    //ModConditions.downedInvaders = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaderNoehtnap, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaders, -1);
                }
                if (ModConditions.qwertyMod.TryFind("OLORDv2", out ModNPC OLORDv2) && npc.type == OLORDv2.Type)
                {
                    //ModConditions.downedOLORD = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOLORD, -1);
                }
                if (ModConditions.qwertyMod.TryFind("TheGreatTyrannosaurus", out ModNPC TheGreatTyrannosaurus) && npc.type == TheGreatTyrannosaurus.Type)
                {
                    //ModConditions.downedGreatTyrannosaurus = true;
                    //ModConditions.downedDinoMilitia = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGreatTyrannosaurus, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedDinoMilitia, -1);
                }
            }

            if (ModConditions.redemptionLoaded)
            {
                if (ModConditions.redemptionMod.TryFind("FowlEmperor", out ModNPC FowlEmperor) && npc.type == FowlEmperor.Type)
                {
                    //ModConditions.downedFowlEmperor = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedFowlEmperor, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Thorn", out ModNPC Thorn) && npc.type == Thorn.Type)
                {
                    //ModConditions.downedThorn = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedThorn, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Erhan", out ModNPC Erhan) && npc.type == Erhan.Type)
                {
                    //ModConditions.downedErhan = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedErhan, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Keeper", out ModNPC Keeper) && npc.type == Keeper.Type)
                {
                    //ModConditions.downedKeeper = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedKeeper, -1);
                }
                if (ModConditions.redemptionMod.TryFind("SoI", out ModNPC SoI) && npc.type == SoI.Type)
                {
                    //ModConditions.downedSeedOfInfection = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeedOfInfection, -1);
                }
                if (ModConditions.redemptionMod.TryFind("KS3", out ModNPC KS3) && npc.type == KS3.Type)
                {
                    //ModConditions.downedKingSlayerIII = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedKingSlayerIII, -1);
                }
                if (ModConditions.redemptionMod.TryFind("OmegaCleaver", out ModNPC OmegaCleaver) && npc.type == OmegaCleaver.Type)
                {
                    //ModConditions.downedOmegaCleaver = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaCleaver, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Gigapora", out ModNPC Gigapora) && npc.type == Gigapora.Type)
                {
                    //ModConditions.downedOmegaGigapora = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaGigapora, -1);
                }
                if (ModConditions.redemptionMod.TryFind("OO", out ModNPC OO) && npc.type == OO.Type)
                {
                    //ModConditions.downedOmegaObliterator = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaObliterator, -1);
                }
                if (ModConditions.redemptionMod.TryFind("PZ", out ModNPC PZ) && npc.type == PZ.Type)
                {
                    //ModConditions.downedPatientZero = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPatientZero, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Akka", out ModNPC Akka) && npc.type == Akka.Type)
                {
                    //ModConditions.downedAkka = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAkka, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Ukko", out ModNPC Ukko) && npc.type == Ukko.Type)
                {
                    //ModConditions.downedUkko = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedUkko, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Nebuleus", out ModNPC Nebuleus) && npc.type == Nebuleus.Type)
                {
                    //ModConditions.downedNebuleus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNebuleus, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Nebuleus2", out ModNPC Nebuleus2) && npc.type == Nebuleus2.Type)
                {
                    //ModConditions.downedNebuleus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNebuleus, -1);
                }
                if (ModConditions.redemptionMod.TryFind("Basan", out ModNPC Basan) && npc.type == Basan.Type)
                {
                    //ModConditions.downedFowlMorning = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedFowlMorning, -1);
                }
                ModConditions.redemptionMod.TryFind("CorpseWalkerPriest", out ModNPC CorpseWalkerPriest);
                ModConditions.redemptionMod.TryFind("DancingSkeleton", out ModNPC DancingSkeleton);
                ModConditions.redemptionMod.TryFind("EpidotrianSkeleton", out ModNPC EpidotrianSkeleton);
                ModConditions.redemptionMod.TryFind("JollyMadman", out ModNPC JollyMadman);
                ModConditions.redemptionMod.TryFind("RaveyardSkeleton", out ModNPC RaveyardSkeleton);
                ModConditions.redemptionMod.TryFind("SkeletonAssassin", out ModNPC SkeletonAssassin);
                ModConditions.redemptionMod.TryFind("SkeletonDuelist", out ModNPC SkeletonDuelist);
                ModConditions.redemptionMod.TryFind("SkeletonFlagbearer", out ModNPC SkeletonFlagbearer);
                ModConditions.redemptionMod.TryFind("SkeletonNoble", out ModNPC SkeletonNoble);
                ModConditions.redemptionMod.TryFind("SkeletonWanderer", out ModNPC SkeletonWanderer);
                ModConditions.redemptionMod.TryFind("SkeletonWarden", out ModNPC SkeletonWarden);
                if (CorpseWalkerPriest != null ||
                    DancingSkeleton != null ||
                    EpidotrianSkeleton != null ||
                    JollyMadman != null ||
                    RaveyardSkeleton != null ||
                    SkeletonAssassin != null ||
                    SkeletonDuelist != null ||
                    SkeletonFlagbearer != null ||
                    SkeletonNoble != null ||
                    SkeletonWanderer != null ||
                    SkeletonWarden != null)
                {
                    if (npc.type == CorpseWalkerPriest.Type
                        || npc.type == DancingSkeleton.Type
                        || npc.type == EpidotrianSkeleton.Type
                        || npc.type == JollyMadman.Type
                        || npc.type == RaveyardSkeleton.Type
                        || npc.type == SkeletonAssassin.Type
                        || npc.type == SkeletonDuelist.Type
                        || npc.type == SkeletonFlagbearer.Type
                        || npc.type == SkeletonNoble.Type
                        || npc.type == SkeletonWanderer.Type
                        || npc.type == SkeletonWarden.Type)
                    {
                        //ModConditions.downedRaveyard = true;
                        NPC.SetEventFlagCleared(ref ModConditions.downedRaveyard, -1);
                    }
                }
            }

            if (ModConditions.secretsOfTheShadowsLoaded)
            {
                if (ModConditions.secretsOfTheShadowsMod.TryFind("Glowmoth", out ModNPC Glowmoth) && npc.type == Glowmoth.Type)
                {
                    //ModConditions.downedGlowmoth = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlowmoth, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PutridPinkyPhase2", out ModNPC PutridPinkyPhase2) && npc.type == PutridPinkyPhase2.Type)
                {
                    //ModConditions.downedPutridPinky = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPutridPinky, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PharaohsCurse", out ModNPC PharaohsCurse) && npc.type == PharaohsCurse.Type)
                {
                    //ModConditions.downedPharaohsCurse = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPharaohsCurse, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("TheAdvisorHead", out ModNPC TheAdvisorHead) && npc.type == TheAdvisorHead.Type)
                {
                    //ModConditions.downedAdvisor = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAdvisor, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("Polaris", out ModNPC Polaris) && npc.type == Polaris.Type)
                {
                    //ModConditions.downedPolaris = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPolaris, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("Lux", out ModNPC Lux) && npc.type == Lux.Type)
                {
                    //ModConditions.downedLux = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedLux, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("SubspaceSerpentHead", out ModNPC SubspaceSerpentHead) && npc.type == SubspaceSerpentHead.Type)
                {
                    //ModConditions.downedSubspaceSerpent = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSubspaceSerpent, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("NatureConstruct", out ModNPC NatureConstruct) && npc.type == NatureConstruct.Type)
                {
                    //ModConditions.downedNatureConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNatureConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EarthenConstruct", out ModNPC EarthenConstruct) && npc.type == EarthenConstruct.Type)
                {
                    //ModConditions.downedEarthenConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEarthenConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PermafrostConstruct", out ModNPC PermafrostConstruct) && npc.type == PermafrostConstruct.Type)
                {
                    //ModConditions.downedPermafrostConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPermafrostConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("TidalConstruct", out ModNPC TidalConstruct) && npc.type == TidalConstruct.Type)
                {
                    //ModConditions.downedTidalConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("OtherworldlyConstructHead", out ModNPC OtherworldlyConstructHead) && npc.type == OtherworldlyConstructHead.Type)
                {
                    //ModConditions.downedOtherworldlyConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlyConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("OtherworldlyConstructHead2", out ModNPC OtherworldlyConstructHead2) && npc.type == OtherworldlyConstructHead2.Type)
                {
                    //ModConditions.downedOtherworldlyConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlyConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EvilConstruct", out ModNPC EvilConstruct) && npc.type == EvilConstruct.Type)
                {
                    //ModConditions.downedEvilConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("InfernoConstruct", out ModNPC InfernoConstruct) && npc.type == InfernoConstruct.Type)
                {
                    //ModConditions.downedInfernoConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernoConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("ChaosConstruct", out ModNPC ChaosConstruct) && npc.type == ChaosConstruct.Type)
                {
                    //ModConditions.downedChaosConstruct = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosConstruct, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("NatureSpirit", out ModNPC NatureSpirit) && npc.type == NatureSpirit.Type)
                {
                    //ModConditions.downedNatureSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedNatureSpirit, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EarthenSpirit", out ModNPC EarthenSpirit) && npc.type == EarthenSpirit.Type)
                {
                    //ModConditions.downedEarthenSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEarthenSpirit, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PermafrostSpirit", out ModNPC PermafrostSpirit) && npc.type == PermafrostSpirit.Type)
                {
                    //ModConditions.downedPermafrostSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPermafrostSpirit, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("TidalSpirit", out ModNPC TidalSpirit) && npc.type == TidalSpirit.Type)
                {
                    //ModConditions.downedTidalSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalSpirit, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EvilSpirit", out ModNPC EvilSpirit) && npc.type == EvilSpirit.Type)
                {
                    //ModConditions.downedEvilSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilSpirit, -1);
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("InfernoSpirit", out ModNPC InfernoSpirit) && npc.type == InfernoSpirit.Type)
                {
                    //ModConditions.downedInfernoSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernoSpirit, -1);
                }
            }

            if (ModConditions.spiritLoaded)
            {
                if (ModConditions.spiritMod.TryFind("Scarabeus", out ModNPC Scarabeus) && npc.type == Scarabeus.Type)
                {
                    //ModConditions.downedScarabeus = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedScarabeus, -1);
                }
                if (ModConditions.spiritMod.TryFind("MoonWizard", out ModNPC MoonWizard) && npc.type == MoonWizard.Type)
                {
                    //ModConditions.downedMoonJellyWizard = true;
                    //ModConditions.downedJellyDeluge = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoonJellyWizard, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedJellyDeluge, -1);
                }
                if (ModConditions.spiritMod.TryFind("ReachBoss", out ModNPC ReachBoss) && npc.type == ReachBoss.Type)
                {
                    //ModConditions.downedVinewrathBane = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedVinewrathBane, -1);
                }
                if (ModConditions.spiritMod.TryFind("AncientFlyer", out ModNPC AncientFlyer) && npc.type == AncientFlyer.Type)
                {
                    //ModConditions.downedAncientAvian = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientAvian, -1);
                }
                if (ModConditions.spiritMod.TryFind("SteamRaiderHead", out ModNPC SteamRaiderHead) && npc.type == SteamRaiderHead.Type)
                {
                    //ModConditions.downedStarplateVoyager = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStarplateVoyager, -1);
                }
                if (ModConditions.spiritMod.TryFind("Infernon", out ModNPC Infernon) && npc.type == Infernon.Type)
                {
                    //ModConditions.downedInfernon = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernon, -1);
                }
                if (ModConditions.spiritMod.TryFind("Dusking", out ModNPC Dusking) && npc.type == Dusking.Type)
                {
                    //ModConditions.downedDusking = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDusking, -1);
                }
                if (ModConditions.spiritMod.TryFind("Atlas", out ModNPC Atlas) && npc.type == Atlas.Type)
                {
                    //ModConditions.downedAtlas = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAtlas, -1);
                }
                ModConditions.spiritMod.TryFind("MoonlightPreserver", out ModNPC MoonlightPreserver);
                ModConditions.spiritMod.TryFind("ExplodingMoonjelly", out ModNPC ExplodingMoonjelly);
                ModConditions.spiritMod.TryFind("MoonjellyGiant", out ModNPC MoonjellyGiant);
                if (MoonlightPreserver != null ||
                    ExplodingMoonjelly != null ||
                    MoonjellyGiant != null)
                {
                    if (npc.type == MoonlightPreserver.Type
                        || npc.type == ExplodingMoonjelly.Type
                        || npc.type == MoonjellyGiant.Type)
                    {
                        //ModConditions.downedJellyDeluge = true;
                        NPC.SetEventFlagCleared(ref ModConditions.downedJellyDeluge, -1);
                    }
                }
                if (ModConditions.spiritMod.TryFind("Rylheian", out ModNPC Rylheian) && npc.type == Rylheian.Type)
                {
                    //ModConditions.downedTide = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTide, -1);
                }
                ModConditions.spiritMod.TryFind("Bloomshroom", out ModNPC Bloomshroom);
                ModConditions.spiritMod.TryFind("Glitterfly", out ModNPC Glitterfly);
                ModConditions.spiritMod.TryFind("GlowToad", out ModNPC GlowToad);
                ModConditions.spiritMod.TryFind("Lumantis", out ModNPC Lumantis);
                ModConditions.spiritMod.TryFind("LunarSlime", out ModNPC LunarSlime);
                ModConditions.spiritMod.TryFind("MadHatter", out ModNPC MadHatter);
                if (Bloomshroom != null ||
                    Glitterfly != null ||
                    GlowToad != null ||
                    Lumantis != null ||
                    LunarSlime != null ||
                    MadHatter != null)
                {
                    if (npc.type == Bloomshroom.Type
                        || npc.type == Glitterfly.Type
                        || npc.type == GlowToad.Type
                        || npc.type == Lumantis.Type
                        || npc.type == LunarSlime.Type
                        || npc.type == MadHatter.Type)
                    {
                        //ModConditions.downedMysticMoon = true;
                        NPC.SetEventFlagCleared(ref ModConditions.downedMysticMoon, -1);
                    }
                }
            }

            if (ModConditions.spookyLoaded)
            {
                if (ModConditions.spookyMod.TryFind("RotGourd", out ModNPC RotGourd) && npc.type == RotGourd.Type)
                {
                    //ModConditions.downedRotGourd = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedRotGourd, -1);
                }
                if (ModConditions.spookyMod.TryFind("SpookySpirit", out ModNPC SpookySpirit) && npc.type == SpookySpirit.Type)
                {
                    //ModConditions.downedSpookySpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedSpookySpirit, -1);
                }
                if (ModConditions.spookyMod.TryFind("Moco", out ModNPC Moco) && npc.type == Moco.Type)
                {
                    //ModConditions.downedMoco = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoco, -1);
                }
                if (ModConditions.spookyMod.TryFind("DaffodilEye", out ModNPC DaffodilEye) && npc.type == DaffodilEye.Type)
                {
                    //ModConditions.downedDaffodil = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDaffodil, -1);
                }
                if (ModConditions.spookyMod.TryFind("OrroHead", out ModNPC OrroHead) && npc.type == OrroHead.Type)
                {
                    //ModConditions.downedOrro = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrro, -1);
                }
                if (ModConditions.spookyMod.TryFind("BoroHead", out ModNPC BoroHead) && npc.type == BoroHead.Type)
                {
                    //ModConditions.downedBoro = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBoro, -1);
                }
                if (ModConditions.spookyMod.TryFind("BigBone", out ModNPC BigBone) && npc.type == BigBone.Type)
                {
                    //ModConditions.downedBigBone = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBigBone, -1);
                }
            }

            if (ModConditions.starlightRiverLoaded)
            {
                if (ModConditions.starlightRiverMod.TryFind("SquidBoss", out ModNPC SquidBoss) && npc.type == SquidBoss.Type)
                {
                    //ModConditions.downedAuroracle = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAuroracle, -1);
                }
                if (ModConditions.starlightRiverMod.TryFind("VitricBoss", out ModNPC VitricBoss) && npc.type == VitricBoss.Type)
                {
                    //ModConditions.downedCeiros = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCeiros, -1);
                }
                if (ModConditions.starlightRiverMod.TryFind("Glassweaver", out ModNPC Glassweaver) && npc.type == Glassweaver.Type)
                {
                    //ModConditions.downedGlassweaver = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlassweaver, -1);
                }
            }

            if (ModConditions.stormsAdditionsLoaded)
            {
                if (ModConditions.stormsAdditionsMod.TryFind("AridBoss", out ModNPC AridBoss) && npc.type == AridBoss.Type)
                {
                    //ModConditions.downedAncientHusk = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientHusk, -1);
                }
                if (ModConditions.stormsAdditionsMod.TryFind("StormBoss", out ModNPC StormBoss) && npc.type == StormBoss.Type)
                {
                    //ModConditions.downedOverloadedScandrone = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedOverloadedScandrone, -1);
                }
                if (ModConditions.stormsAdditionsMod.TryFind("TheUltimateBoss", out ModNPC TheUltimateBoss) && npc.type == TheUltimateBoss.Type)
                {
                    //ModConditions.downedPainbringer = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPainbringer, -1);
                }
            }

            if (ModConditions.supernovaLoaded)
            {
                if (ModConditions.supernovaMod.TryFind("HarbingerOfAnnihilation", out ModNPC HarbingerOfAnnihilation) && npc.type == HarbingerOfAnnihilation.Type)
                {
                    //ModConditions.downedHarbingerOfAnnihilation = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHarbingerOfAnnihilation, -1);
                }
                if (ModConditions.supernovaMod.TryFind("FlyingTerror", out ModNPC FlyingTerror) && npc.type == FlyingTerror.Type)
                {
                    //ModConditions.downedFlyingTerror = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedFlyingTerror, -1);
                }
                if (ModConditions.supernovaMod.TryFind("StoneMantaRay", out ModNPC StoneMantaRay) && npc.type == StoneMantaRay.Type)
                {
                    //ModConditions.downedStoneMantaRay = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoneMantaRay, -1);
                }
                if (ModConditions.supernovaMod.TryFind("Bloodweaver", out ModNPC Bloodweaver) && npc.type == Bloodweaver.Type)
                {
                    //ModConditions.downedBloodweaver = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBloodweaver, -1);
                }
            }

            if (ModConditions.terrorbornLoaded)
            {
                if (ModConditions.terrorbornMod.TryFind("InfectedIncarnate", out ModNPC InfectedIncarnate) && npc.type == InfectedIncarnate.Type)
                {
                    //ModConditions.downedInfectedIncarnate = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfectedIncarnate, -1);
                }
                if (ModConditions.terrorbornMod.TryFind("TidalTitan", out ModNPC TidalTitan) && npc.type == TidalTitan.Type)
                {
                    //ModConditions.downedTidalTitan = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalTitan, -1);
                }
                if (ModConditions.terrorbornMod.TryFind("Dunestock", out ModNPC Dunestock) && npc.type == Dunestock.Type)
                {
                    //ModConditions.downedDunestock = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDunestock, -1);
                }
                if (ModConditions.terrorbornMod.TryFind("Shadowcrawler", out ModNPC Shadowcrawler) && npc.type == Shadowcrawler.Type)
                {
                    //ModConditions.downedShadowcrawler = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedShadowcrawler, -1);
                }
                if (ModConditions.terrorbornMod.TryFind("HexedConstructor", out ModNPC HexedConstructor) && npc.type == HexedConstructor.Type)
                {
                    //ModConditions.downedHexedConstructor = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedHexedConstructor, -1);
                }
                if (ModConditions.terrorbornMod.TryFind("PrototypeI", out ModNPC PrototypeI) && npc.type == PrototypeI.Type)
                {
                    //ModConditions.downedPrototypeI = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrototypeI, -1);
                }
            }

            if (ModConditions.traeLoaded)
            {
                if (ModConditions.traeMod.TryFind("GraniteOvergrowthNPC", out ModNPC GraniteOvergrowthNPC) && npc.type == GraniteOvergrowthNPC.Type)
                {
                    //ModConditions.downedGraniteOvergrowth = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGraniteOvergrowth, -1);
                }
                if (ModConditions.traeMod.TryFind("BeholderNPC", out ModNPC BeholderNPC) && npc.type == BeholderNPC.Type)
                {
                    //ModConditions.downedBeholder = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBeholder, -1);
                }
            }

            if (ModConditions.uhtricLoaded)
            {
                if (ModConditions.uhtricMod.TryFind("Dredger", out ModNPC Dredger) && npc.type == Dredger.Type)
                {
                    //ModConditions.downedDredger = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDredger, -1);
                }
                if (ModConditions.uhtricMod.TryFind("CharcoolSnowman", out ModNPC CharcoolSnowman) && npc.type == CharcoolSnowman.Type)
                {
                    //ModConditions.downedCharcoolSnowman = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCharcoolSnowman, -1);
                }
                if (ModConditions.uhtricMod.TryFind("CosmicMenace", out ModNPC CosmicMenace) && npc.type == CosmicMenace.Type)
                {
                    //ModConditions.downedCosmicMenace = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedCosmicMenace, -1);
                }
            }

            if (ModConditions.universeOfSwordsLoaded)
            {
                if (ModConditions.universeOfSwordsMod.TryFind("SwordBossNPC", out ModNPC SwordBossNPC) && npc.type == SwordBossNPC.Type)
                {
                    //ModConditions.downedEvilFlyingBlade = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilFlyingBlade, -1);
                }
            }

            if (ModConditions.valhallaLoaded)
            {
                if (ModConditions.valhallaMod.TryFind("Emperor", out ModNPC Emperor) && npc.type == Emperor.Type)
                {
                    //ModConditions.downedYurnero = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedYurnero, -1);
                }
                if (ModConditions.valhallaMod.TryFind("PirateSquid", out ModNPC PirateSquid) && npc.type == PirateSquid.Type)
                {
                    //ModConditions.downedColossalCarnage = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedColossalCarnage, -1);
                }
            }

            if (ModConditions.vitalityLoaded)
            {
                if (ModConditions.vitalityMod.TryFind("StormCloudBoss", out ModNPC StormCloudBoss) && npc.type == StormCloudBoss.Type)
                {
                    //ModConditions.downedStormCloud = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedStormCloud, -1);
                }
                if (ModConditions.vitalityMod.TryFind("GrandAntlionBoss", out ModNPC GrandAntlionBoss) && npc.type == GrandAntlionBoss.Type)
                {
                    //ModConditions.downedGrandAntlion = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGrandAntlion, -1);
                }
                if (ModConditions.vitalityMod.TryFind("GemstoneElementalBoss", out ModNPC GemstoneElementalBoss) && npc.type == GemstoneElementalBoss.Type)
                {
                    //ModConditions.downedGemstoneElemental = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedGemstoneElemental, -1);
                }
                if (ModConditions.vitalityMod.TryFind("MoonlightDragonflyBoss", out ModNPC MoonlightDragonflyBoss) && npc.type == MoonlightDragonflyBoss.Type)
                {
                    //ModConditions.downedMoonlightDragonfly = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoonlightDragonfly, -1);
                }
                if (ModConditions.vitalityMod.TryFind("DreadnaughtBoss", out ModNPC DreadnaughtBoss) && npc.type == DreadnaughtBoss.Type)
                {
                    //ModConditions.downedDreadnaught = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedDreadnaught, -1);
                }
                if (ModConditions.vitalityMod.TryFind("AnarchulesBeetleBoss", out ModNPC AnarchulesBeetleBoss) && npc.type == AnarchulesBeetleBoss.Type)
                {
                    //ModConditions.downedAnarchulesBeetle = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedAnarchulesBeetle, -1);
                }
                if (ModConditions.vitalityMod.TryFind("ChaosbringerBoss", out ModNPC ChaosbringerBoss) && npc.type == ChaosbringerBoss.Type)
                {
                    //ModConditions.downedChaosbringer = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosbringer, -1);
                }
                if (ModConditions.vitalityMod.TryFind("PaladinSpiritBoss", out ModNPC PaladinSpiritBoss) && npc.type == PaladinSpiritBoss.Type)
                {
                    //ModConditions.downedPaladinSpirit = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedPaladinSpirit, -1);
                }
            }

            if (ModConditions.wayfairContentLoaded)
            {
                if (ModConditions.wayfairContentMod.TryFind("Lifebloom", out ModNPC Lifebloom) && npc.type == Lifebloom.Type)
                {
                    //ModConditions.downedManaflora = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedManaflora, -1);
                }
            }
        }
    }
}
