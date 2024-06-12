using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using MonoMod.RuntimeDetour;
using MonoMod.Utils;
using QoLCompendium.Content.NPCs;
using System.Reflection;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using static Terraria.NPC;

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

    public class EnemiesBreakDoors : ModSystem
    {
        public override void Load()
        {
            if (QoLCompendium.mainConfig.NoDoorBreaking)
            {
                IL_NPC.AI_003_Fighters += NoDoorBreaking;
            }
        }

        public override void Unload()
        {
            IL_NPC.AI_003_Fighters -= NoDoorBreaking;
        }

        private void NoDoorBreaking(ILContext il)
        {
            var c = new ILCursor(il);
            if (c.TryGotoNext(MoveType.Before, i => i.MatchLdfld<NPC>("type"), i => i.MatchLdcI4(26), i => i.MatchBneUn(out var label)))
            {
                c.Index++;
                c.Next!.Operand = (sbyte)0;
            }
        }
    }

    public class NoLavaFromSlimes : GlobalNPC
    {
        public override void HitEffect(NPC npc, HitInfo hit)
        {
            if (npc.type != NPCID.LavaSlime || Main.netMode == NetmodeID.MultiplayerClient || npc.life > 0)
            {
                return;
            }
            try
            {
                if (QoLCompendium.mainConfig.LavaSlimeNoLava)
                {
                    int num = (int)(npc.Center.X / 16f);
                    int num2 = (int)(npc.Center.Y / 16f);
                    if (!WorldGen.SolidTile(num, num2, false))
                    {
                        Tile val = Main.tile[num, num2];
                        if (val.CheckingLiquid)
                        {
                            Tile val2 = Main.tile[num, num2];
                            val2.LiquidAmount = 0;
                            WorldGen.SquareTileFrame(num, num2, true);
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }

    public class NPCDrops : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            npc.value *= QoLCompendium.mainConfig.MoreCoins;
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.DD2DarkMageT1 && QoLCompendium.mainConfig.DefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 10, 10));
            }

            if (npc.type == NPCID.DD2DarkMageT3 && QoLCompendium.mainConfig.DefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 25, 25));
            }

            if (npc.type == NPCID.DD2OgreT2 && QoLCompendium.mainConfig.DefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 25, 25));
            }

            if (npc.type == NPCID.DD2OgreT3 && QoLCompendium.mainConfig.DefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 30, 30));
            }

            if (npc.type == NPCID.DD2Betsy && QoLCompendium.mainConfig.DefenderMedalDrops)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.DefenderMedal, 1, 50, 50));
            }

            if ((npc.type == NPCID.NebulaHeadcrab || npc.type == NPCID.NebulaBeast || npc.type == NPCID.NebulaBrain || npc.type == NPCID.NebulaSoldier) && QoLCompendium.mainConfig.MoreFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentNebula, 1, 1, 3));
            }

            if ((npc.type == NPCID.SolarCorite || npc.type == NPCID.SolarCrawltipedeHead || npc.type == NPCID.SolarSpearman || npc.type == NPCID.SolarDrakomire || npc.type == NPCID.SolarDrakomireRider || npc.type == NPCID.SolarSolenian || npc.type == NPCID.SolarSroller) && QoLCompendium.mainConfig.MoreFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentSolar, 1, 1, 3));
            }

            if ((npc.type == NPCID.StardustJellyfishBig || npc.type == NPCID.StardustWormHead || npc.type == NPCID.StardustCellBig || npc.type == NPCID.StardustSoldier || npc.type == NPCID.StardustSpiderBig) && QoLCompendium.mainConfig.MoreFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentStardust, 1, 1, 3));
            }

            if ((npc.type == NPCID.VortexHornet || npc.type == NPCID.VortexHornetQueen || npc.type == NPCID.VortexRifleman || npc.type == NPCID.VortexSoldier) && QoLCompendium.mainConfig.MoreFragments)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.FragmentVortex, 1, 1, 3));
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
        public override void AI(NPC npc)
        {
            if (QoLCompendium.mainConfig.NoTownSlimes)
            {
                if (npc.active && Common.TownSlimeIDs.Contains(npc.type))
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
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "SlayerofEvil"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSlayerOfEvil, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "SATLA001"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSATLA, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "DrFetusThirdPhase"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDrFetus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "MechanicalSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSlimesHope, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "PoliticianSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPoliticianSlime, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "FlagCarrier"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientTrio, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "LavalGolem"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLavalGolem, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "NecromancerDummy"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAntony, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "BunnyZepplin"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBunnyZeppelin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "Okiku"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOkiku, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "StormTinkererH"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHarpyAirforce, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "DemonIsaac"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedIsaac, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "AncientGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "HeroicSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHeroicSlime, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "HolographicSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHoloSlime, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "SecurityBot"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSecurityBot, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "UndeadChef"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUndeadChef, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.afkpetsMod, "IceGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGuardianOfFrost, -1);
                }
            }

            if (ModConditions.assortedCrazyThingsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.assortedCrazyThingsMod, "HarvesterBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSoulHarvester, -1);
                }
            }

            if (ModConditions.awfulGarbageLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "TreeToad"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTreeToad, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "SeseKitsugai"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeseKitsugai, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "EyeOfTheStorm"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEyeOfTheStorm, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.awfulGarbageMod, "FrigidiusHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFrigidius, -1);
                }
            }

            if (ModConditions.blocksCoreBossLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.blocksCoreBossMod, "CoreBoss") || npc.type == Common.GetModNPC(ModConditions.blocksCoreBossMod, "CoreBossCrim"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCoreBoss, -1);
                }
            }

            if (ModConditions.calamityLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "CragmawMire"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCragmawMire, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "NuclearTerror"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNuclearTerror, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.calamityMod, "Mauler"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMauler, -1);
                }
            }

            if (ModConditions.calamityCommunityRemixLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.calamityCommunityRemixMod, "WulfwyrmHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWulfrumExcavator, -1);
                }
            }

            if (ModConditions.catalystLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.catalystMod, "Astrageldon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAstrageldon, -1);
                }
            }

            if (ModConditions.clamityAddonLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.clamityAddonMod, "ClamitasBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedClamitas, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.clamityAddonMod, "PyrogenBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPyrogen, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.clamityAddonMod, "WallOfBronze"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWallOfBronze, -1);
                }
            }

            if (ModConditions.consolariaLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "Lepus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLepus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "TurkortheUngrateful"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTurkor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.consolariaMod, "Ocram"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOcram, -1);
                }
            }

            if (ModConditions.coraliteLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "Rediancie"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRediancie, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "BabyIceDragon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBabyIceDragon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "SlimeEmperor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSlimeEmperor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "Bloodiancie"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBloodiancie, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "ThunderveinDragon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedThunderveinDragon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.coraliteMod, "NightmarePlantera"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNightmarePlantera, -1);
                }
            }

            if (ModConditions.depthsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.depthsMod, "ChasmeHeart"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedChasme, -1);
                }
            }

            /*
            if (ModConditions.dormantDawnLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "LifeGuard"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLifeGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "StarGuard"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedManaGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "MeteorDigger_Head"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMeteorExcavator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "MeteorAnnihilator"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMeteorAnnihilator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.dormantDawnMod, "????"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHellfireSerpent, -1);
                }
            }
            */

            if (ModConditions.echoesOfTheAncientsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.echoesOfTheAncientsMod, "Galahis"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGalahis, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.echoesOfTheAncientsMod, "AquaWormHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCreation, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.echoesOfTheAncientsMod, "PumpkinWormHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDestruction, -1);
                }
            }

            if (ModConditions.edorbisLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "BlightKing"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBlightKing, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "TheGardener"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGardener, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "GlaciationHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlaciation, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "HandofCthulhu"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHandOfCthulhu, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.edorbisMod, "CursedLord"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCursePreacher, -1);
                }
            }

            if (ModConditions.exaltLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.exaltMod, "Effulgence"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEffulgence, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.exaltMod, "IceLich"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedIceLich, -1);
                }
            }

            if (ModConditions.excelsiorLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.excelsiorMod, "Niflheim"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNiflheim, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.excelsiorMod, "StellarStarship"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStellarStarship, -1);
                }
            }

            if (ModConditions.exxoAvalonOriginsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "BacteriumPrime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBacteriumPrime, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "DesertBeak"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDesertBeak, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "KingSting"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKingSting, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "Mechasting"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMechasting, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.exxoAvalonOriginsMod, "Phantasm"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPhantasm, -1);
                }
            }

            if (ModConditions.fargosSoulsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "TrojanSquirrel"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTrojanSquirrel, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "DeviBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDeviantt, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "BanishedBaron"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBanishedBaron, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "LifeChallenger"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLifelight, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "CosmosChampion"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEridanus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "AbomBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAbominationn, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fargosSoulsMod, "MutantBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMutant, -1);
                }
            }

            if (ModConditions.fracturesOfPenumbraLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.fracturesOfPenumbraMod, "AlphaFrostjawHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAlphaFrostjaw, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.fracturesOfPenumbraMod, "SanguineElemental"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSanguineElemental, -1);
                }
            }

            if (ModConditions.gameTerrariaLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "Lad"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLad, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "Hornlitz"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHornlitz, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "SnowDonCore"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSnowDon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gameTerrariaMod, "Stoffie"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoffie, -1);
                }
            }

            if (ModConditions.gensokyoLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "LilyWhite"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLilyWhite, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Rumia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRumia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "EternityLarva"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEternityLarva, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Nazrin"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNazrin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "HinaKagiyama"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHinaKagiyama, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Sekibanki"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSekibanki, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Seiran"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeiran, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "NitoriKawashiro"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNitoriKawashiro, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MedicineMelancholy"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMedicineMelancholy, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Cirno"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCirno, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MinamitsuMurasa"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMinamitsuMurasa, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "AliceMargatroid"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAliceMargatroid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "SakuyaIzayoi"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSakuyaIzayoi, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "SeijaKijin"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeijaKijin, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "MayumiJoutouguu"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMayumiJoutouguu, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "ToyosatomimiNoMiko"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedToyosatomimiNoMiko, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "KaguyaHouraisan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKaguyaHouraisan, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "UtsuhoReiuji"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUtsuhoReiuji, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "TenshiHinanawi"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTenshiHinanawi, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gensokyoMod, "Kisume"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKisume, -1);
                }
            }

            if (ModConditions.gerdsLabLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Trerios"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTrerios, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "MagmaEye"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMagmaEye, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Jack"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJack, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.gerdsLabMod, "Acheron"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAcheron, -1);
                }
            }

            if (ModConditions.homewardJourneyLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "MarquisMoonsquid"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMarquisMoonsquid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "PriestessRod"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPriestessRod, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Diver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDiver, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMotherbrain"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMotherbrain, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WallofShadow"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWallOfShadow, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "SlimeGod"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunSlimeGod, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheOverwatcher"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOverwatcher, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheLifebringerHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLifebringer, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheMaterealizer"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMaterealizer, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedScarabBelief, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "WorldsEndEverlastingFallingWhale"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWorldsEndWhale, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "TheSon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Cave"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCaveOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Corruption"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCorruptOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Crimson"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCrimsonOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Desert"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDesertOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Forest"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedForestOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Hallow"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHallowOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Jungle"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJungleOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Pure"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSkyOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Snow"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSnowOrdeal, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.homewardJourneyMod, "Trial_Underworld"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUnderworldOrdeal, -1);
                }
            }

            if (ModConditions.huntOfTheOldGodLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.huntOfTheOldGodMod, "Goozma"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGoozma, -1);
                }
            }

            if (ModConditions.infernumLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.infernumMod, "BereftVassal"))
                {
                    SubworldModConditions.downedBereftVassal = true;
                    NPC.SetEventFlagCleared(ref ModConditions.downedBereftVassal, -1);
                }
            }

            if (ModConditions.lunarVeilLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "StarrVeriplant"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoneGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "CommanderGintzia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCommanderGintzia, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedGintzeArmy, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "SunStalker"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunStalker, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Jack"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPumpkinJack, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "DaedusR"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedForgottenPuppetDaedus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "DreadMire"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDreadMire, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "SingularityFragment"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSingularityFragment, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "VerliaB"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVerlia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Gothiviab"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedIrradia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Sylia"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSylia, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Fenix"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFenix, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "BlazingSerpentHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBlazingSerpent, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Cogwork"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCogwork, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "WaterCogwork"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWaterCogwork, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "WaterJellyfish"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedWaterJellyfish, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "Sparn"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSparn, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "PandorasFlamebox"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPandorasFlamebox, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.lunarVeilMod, "STARBOMBER"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSTARBOMBER, -1);
                }
            }

            if (ModConditions.martainsOrderLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Britzz"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBritzz, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "Alchemist"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTheAlchemist, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "CarnagePillar"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCarnagePillar, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "VoidDiggerHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVoidDigger, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "PrinceSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrinceSlime, -1);
                }
                ModConditions.martainsOrderMod.TryFind("Evocornator", out ModNPC Evocornator);
                ModConditions.martainsOrderMod.TryFind("Retinator", out ModNPC Retinator);
                ModConditions.martainsOrderMod.TryFind("Spazmator", out ModNPC Spazmator);
                if (npc.type == Evocornator.Type && !NPC.AnyNPCs(Retinator.Type) && !NPC.AnyNPCs(Spazmator.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Retinator.Type && !NPC.AnyNPCs(Evocornator.Type) && !NPC.AnyNPCs(Spazmator.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Spazmator.Type && !NPC.AnyNPCs(Evocornator.Type) && !NPC.AnyNPCs(Retinator.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTriplets, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.martainsOrderMod, "MechPlantera"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedJungleDefenders, -1);
                }
            }

            if (ModConditions.mechReworkLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "Mechclops"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSt4sys, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "TheTerminator"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTerminator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "Caretaker"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCaretaker, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.mechReworkMod, "SiegeEngine"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSiegeEngine, -1);
                }
            }

            if (ModConditions.medialRiftLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.medialRiftMod, "SuperVoltaicMotherSlime"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSuperVoltaicMotherSlime, -1);
                }
            }

            if (ModConditions.metroidLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Torizo"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTorizo, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Serris_Head"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSerris, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Kraid_Head"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKraid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Phantoon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPhantoon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "OmegaPirate"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaPirate, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "Nightmare"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNightmare, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.metroidMod, "GoldenTorizo"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGoldenTorizo, -1);
                }
            }

            if (ModConditions.ophioidLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "OphiopedeHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOphiopede, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "Ophiocoon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOphiocoon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.ophioidMod, "Ophiofly"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOphiofly, -1);
                }
            }

            if (ModConditions.polaritiesLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "StormCloudfish"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStormCloudfish, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "StarConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStarConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Gigabat"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGigabat, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "SunPixie"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSunPixie, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "Esophage"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEsophage, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.polaritiesMod, "ConvectiveWanderer"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedConvectiveWanderer, -1);
                }
            }

            if (ModConditions.projectZeroLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "ForestGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedForestGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "CryoGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCryoGuardian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "PrimordialWormHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrimordialWorm, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "HellGuardian"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTheGuardianOfHell, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "Void"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVoid, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.projectZeroMod, "ArmagemHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedArmagem, -1);
                }
            }

            if (ModConditions.qwertyLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "PolarBear"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPolarExterminator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "FortressBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDivineLight, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "AncientMachine"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientMachine, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "CloakedDarkBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNoehtnap, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Hydra"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHydra, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "Imperious"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedImperious, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "RuneGhost"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRuneGhost, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "InvaderBattleship"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaderBattleship, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "InvaderNoehtnap"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaderNoehtnap, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedInvaders, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "OLORDv2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOLORD, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.qwertyMod, "TheGreatTyrannosaurus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGreatTyrannosaurus, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedDinoMilitia, -1);
                }
            }

            if (ModConditions.redemptionLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "FowlEmperor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFowlEmperor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Thorn"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedThorn, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Erhan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedErhan, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Keeper"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKeeper, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "SoI"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSeedOfInfection, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "KS3"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedKingSlayerIII, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OmegaCleaver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaCleaver, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Gigapora"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaGigapora, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "OO"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOmegaObliterator, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "PZ"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPatientZero, -1);
                }
                ModConditions.redemptionMod.TryFind("Akka", out ModNPC Akka);
                ModConditions.redemptionMod.TryFind("Ukko", out ModNPC Ukko);
                if (npc.type == Akka.Type && !NPC.AnyNPCs(Ukko.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAkka, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientDeityDuo, -1);
                }
                if (npc.type == Ukko.Type && !NPC.AnyNPCs(Akka.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedUkko, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientDeityDuo, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNebuleus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Nebuleus2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNebuleus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.redemptionMod, "Basan"))
                {
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
                        NPC.SetEventFlagCleared(ref ModConditions.downedRaveyard, -1);
                    }
                }
            }

            if (ModConditions.secretsOfTheShadowsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Glowmoth"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlowmoth, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PutridPinkyPhase2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPutridPinky, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PharaohsCurse"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPharaohsCurse, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TheAdvisorHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAdvisor, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlySpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Polaris") || npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NewPolaris"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPolaris, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "Lux"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedLux, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "SubspaceSerpentHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSubspaceSerpent, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NatureConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNatureConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EarthenConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEarthenConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PermafrostConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPermafrostConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TidalConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "OtherworldlyConstructHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlyConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "OtherworldlyConstructHead2"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOtherworldlyConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EvilConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "InfernoConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernoConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "ChaosConstruct"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosConstruct, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "NatureSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedNatureSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EarthenSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEarthenSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "PermafrostSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPermafrostSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "TidalSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "EvilSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilSpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.secretsOfTheShadowsMod, "InfernoSpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernoSpirit, -1);
                }
            }

            if (ModConditions.sloomeLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.sloomeMod, "ExoSlimeGod"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedExodygen, -1);
                }
            }

            if (ModConditions.spiritLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Scarabeus"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedScarabeus, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "MoonWizard"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoonJellyWizard, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedJellyDeluge, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "ReachBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedVinewrathBane, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "AncientFlyer"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientAvian, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "SteamRaiderHead"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStarplateVoyager, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Infernon"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfernon, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Dusking"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDusking, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Atlas"))
                {
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
                        NPC.SetEventFlagCleared(ref ModConditions.downedJellyDeluge, -1);
                    }
                }
                if (npc.type == Common.GetModNPC(ModConditions.spiritMod, "Rylheian"))
                {
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
                        NPC.SetEventFlagCleared(ref ModConditions.downedMysticMoon, -1);
                    }
                }
            }

            if (ModConditions.spookyLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "RotGourd"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedRotGourd, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "SpookySpirit"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedSpookySpirit, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "Moco"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoco, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "DaffodilEye"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDaffodil, -1);
                }
                ModConditions.spookyMod.TryFind("OrroHead", out ModNPC OrroHead);
                ModConditions.spookyMod.TryFind("BoroHead", out ModNPC BoroHead);
                if (npc.type == OrroHead.Type && !NPC.AnyNPCs(BoroHead.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrro, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrroBoro, -1);
                }
                if (npc.type == BoroHead.Type && !NPC.AnyNPCs(OrroHead.Type))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBoro, -1);
                    NPC.SetEventFlagCleared(ref ModConditions.downedOrroBoro, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.spookyMod, "BigBone"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBigBone, -1);
                }
            }

            if (ModConditions.starlightRiverLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "SquidBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAuroracle, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "VitricBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCeiros, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.starlightRiverMod, "Glassweaver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGlassweaver, -1);
                }
            }

            if (ModConditions.stormsAdditionsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "AridBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAncientHusk, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "StormBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedOverloadedScandrone, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.stormsAdditionsMod, "TheUltimateBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPainbringer, -1);
                }
            }

            if (ModConditions.supernovaLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "HarbingerOfAnnihilation"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHarbingerOfAnnihilation, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "FlyingTerror"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedFlyingTerror, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "StoneMantaRay"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStoneMantaRay, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.supernovaMod, "Bloodweaver"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBloodweaver, -1);
                }
            }

            if (ModConditions.terrorbornLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "InfectedIncarnate"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedInfectedIncarnate, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "TidalTitan"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedTidalTitan, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "Dunestock"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDunestock, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "Shadowcrawler"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedShadowcrawler, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "HexedConstructor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedHexedConstructor, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.terrorbornMod, "PrototypeI"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPrototypeI, -1);
                }
            }

            if (ModConditions.traeLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.traeMod, "GraniteOvergrowthNPC"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGraniteOvergrowth, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.traeMod, "BeholderNPC"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedBeholder, -1);
                }
            }

            if (ModConditions.uhtricLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "Dredger"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDredger, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CharcoolSnowman"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCharcoolSnowman, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.uhtricMod, "CosmicMenace"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedCosmicMenace, -1);
                }
            }

            if (ModConditions.universeOfSwordsLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.universeOfSwordsMod, "SwordBossNPC"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedEvilFlyingBlade, -1);
                }
            }

            if (ModConditions.valhallaLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.valhallaMod, "Emperor"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedYurnero, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.valhallaMod, "PirateSquid"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedColossalCarnage, -1);
                }
            }

            if (ModConditions.vitalityLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "StormCloudBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedStormCloud, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GrandAntlionBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGrandAntlion, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "GemstoneElementalBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedGemstoneElemental, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MoonlightDragonflyBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMoonlightDragonfly, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "DreadnaughtBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedDreadnaught, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "MosquitoMonarchBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedMosquitoMonarch, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "AnarchulesBeetleBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedAnarchulesBeetle, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "ChaosbringerBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedChaosbringer, -1);
                }
                if (npc.type == Common.GetModNPC(ModConditions.vitalityMod, "PaladinSpiritBoss"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedPaladinSpirit, -1);
                }
            }

            if (ModConditions.wayfairContentLoaded)
            {
                if (npc.type == Common.GetModNPC(ModConditions.wayfairContentMod, "Lifebloom"))
                {
                    NPC.SetEventFlagCleared(ref ModConditions.downedManaflora, -1);
                }
            }
        }
    }
}
