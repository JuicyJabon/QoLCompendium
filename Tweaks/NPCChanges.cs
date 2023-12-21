using Mono.Cecil.Cil;
using MonoMod.Cil;
using QoLCompendium.Items.InformationAccessories;
using QoLCompendium.NPCs;
using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Tweaks
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
    
    public class HappinessOverride : ModSystem
    {
        public override void Load()
        {
            IL_Chest.VanillaSetupShop += il =>
            {
                ILCursor c = new(il);

                if (!c.TryGotoNext(MoveType.Before, x => x.MatchStloc(0)))
                {
                    return;
                }
                c.EmitDelegate((bool flag) => flag || QoLCompendium.mainConfig.ToggleHappiness);
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

    public sealed class NoBreakDoors : ModSystem
    {
        public override void Load()
        {
            IL_NPC.AI_003_Fighters += PreventDoorInteractions;
        }

        /// <summary>
        /// Changes the following check in NPC.AI_003_Fighters:
        ///
        /// WorldGen.KillTile(num178, num179 - 1, fail: true);
        /// if ((Main.netMode != 1 || !flag23) && flag23 && Main.netMode != 1) {
        /// 	if (type == 26) {
        ///			WorldGen.KillTile(num178, num179 - 1);
        ///
        /// to:
        ///
        /// WorldGen.KillTile(num178, num179 - 1, fail: true);
        /// if ((Main.netMode != 1 || !flag23) && flag23 && !ModContent.GetInstance<DoorOptionsConfig>().StopOpeningDoors && Main.netMode != 1) {
        /// 	if (type == int.MinValue) {
        ///			WorldGen.KillTile(num178, num179 - 1);
        ///
        /// </summary>
        private void PreventDoorInteractions(ILContext il)
        {
            ILCursor c = new(il);

            #region Opening Door Change

            // Match (C#):
            //	if (type == 460) { flag = true; }
            // Match (IL):
            //	ldarg.0
            //	ldfld int32 Terraria.NPC::'type'
            //	ldc.i4 460
            //	bne.un.s LABEL
            //	ldc.i4.1
            //	stloc LOCAL
            // Need LOCAL for code below.
            int localIndex = -1;
            if (!c.TryGotoNext(MoveType.Before,
                i => i.MatchLdarg(0),
                i => i.MatchLdfld<NPC>(nameof(NPC.type)),
                i => i.MatchLdcI4(NPCID.Butcher),
                i => i.MatchBneUn(out _),
                i => i.MatchLdcI4(1), // true
                i => i.MatchStloc(out localIndex)
                ))
            {
                throw new Exception("Unable to patch Terraria.NPC.AI_003_Fighters: Could not match IL (Finding Local Index).");
            }

            // Match (C#):
            //	WorldGen.KillTile(num194, num195 - 1, fail: true);
            // Change to:
            //	WorldGen.KillTile(num194, num195 - 1, fail: true);
            //	LOCAL &= !ModContent.GetInstance<DoorOptionsConfig>().StopOpeningDoors;
            // LOCAL is whether any NPC should try hitting doors. By and-ing the config option, NPCs won't hit doors if they're disallwoed by this mod.
            if (!c.TryGotoNext(MoveType.After,
                // Match the five params for KillTile
                i => true,
                i => true,
                i => true,
                i => true,
                i => true,
                i => i.MatchCall<WorldGen>(nameof(WorldGen.KillTile))
            ))
            {
                throw new Exception("Unable to patch Terraria.NPC.AI_003_Fighters: Could not match IL (Finding Local Index).");
            }

            c.Emit(OpCodes.Ldloc, localIndex);
            c.EmitDelegate(() => QoLCompendium.mainConfig.StopOpeningDoors);
            c.Emit(OpCodes.And);
            c.Emit(OpCodes.Stloc, localIndex);

            #endregion Opening Door Change

            #region Peon Change

            /// Match the following IL:
            ///		IL_B6B4: ldarg.0
            ///		IL_B6B5: ldfld     int32 Terraria.NPC::'type'
            ///		IL_B6BA: ldc.i4.s  26
            ///		IL_B6BC: bne.un.s  IL_B707
            /// This places the cursor on ldarg.0.

            if (!c.TryGotoNext(MoveType.Before,
                    i => i.MatchLdarg(0),
                    i => i.MatchLdfld<NPC>(nameof(NPC.type)),
                    i => i.MatchLdcI4(NPCID.GoblinPeon)
                ))
            {
                throw new Exception("Unable to patch Terraria.NPC.AI_003_Fighters: Could not match IL (Peon Change).");
            }

            // Move the cursor to the instruction loading the Goblin Peon's ID (26).
            c.Index += 2;

            // Replace 26 with NPCID.None. The code now checks if npc.type == NPCID.None.
            // The OpCode here is ldc.i4.s, so I'm constrained to the range of an sbyte.
            c.Next.Operand = NPCID.None;

            #endregion Peon Change

            MonoModHooks.DumpIL(Mod, il);
        }
    }

    public class NPCDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Harpy && QoLCompendium.itemConfig.InformationAccessories)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WingTimer>(), 5));
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
                ModConditions.downedDreadnautilus = true;
            }
            if (npc.type == NPCID.MartianSaucerCore || npc.type == NPCID.MartianSaucer)
            {
                ModConditions.downedMartianSaucer = true;
            }

            if (ModConditions.afkpetsLoaded)
            {
                if (ModConditions.afkpetsMod.TryFind("SlayerofEvil", out ModNPC SlayerofEvil) && npc.type == SlayerofEvil.Type)
                {
                    ModConditions.downedSlayerOfEvil = true;
                }
                if (ModConditions.afkpetsMod.TryFind("SATLA001", out ModNPC SATLA001) && npc.type == SATLA001.Type)
                {
                    ModConditions.downedSATLA = true;
                }
                if (ModConditions.afkpetsMod.TryFind("DrFetusThirdPhase", out ModNPC DrFetusThirdPhase) && npc.type == DrFetusThirdPhase.Type)
                {
                    ModConditions.downedDrFetus = true;
                }
                if (ModConditions.afkpetsMod.TryFind("MechanicalSlime", out ModNPC MechanicalSlime) && npc.type == MechanicalSlime.Type)
                {
                    ModConditions.downedSlimesHope = true;
                }
                if (ModConditions.afkpetsMod.TryFind("PoliticianSlime", out ModNPC PoliticianSlime) && npc.type == PoliticianSlime.Type)
                {
                    ModConditions.downedPoliticianSlime = true;
                }
                if (ModConditions.afkpetsMod.TryFind("FlagCarrier", out ModNPC FlagCarrier) && npc.type == FlagCarrier.Type)
                {
                    ModConditions.downedAncientTrio = true;
                }
                if (ModConditions.afkpetsMod.TryFind("LavalGolem", out ModNPC LavalGolem) && npc.type == LavalGolem.Type)
                {
                    ModConditions.downedLavalGolem = true;
                }
                if (ModConditions.afkpetsMod.TryFind("NecromancerDummy", out ModNPC NecromancerDummy) && npc.type == NecromancerDummy.Type)
                {
                    ModConditions.downedAntony = true;
                }
                if (ModConditions.afkpetsMod.TryFind("BunnyZepplin", out ModNPC BunnyZepplin) && npc.type == BunnyZepplin.Type)
                {
                    ModConditions.downedBunnyZeppelin = true;
                }
                if (ModConditions.afkpetsMod.TryFind("Okiku", out ModNPC Okiku) && npc.type == Okiku.Type)
                {
                    ModConditions.downedOkiku = true;
                }
                if (ModConditions.afkpetsMod.TryFind("StormTinkererH", out ModNPC StormTinkererH) && npc.type == StormTinkererH.Type)
                {
                    ModConditions.downedHarpyAirforce = true;
                }
                if (ModConditions.afkpetsMod.TryFind("DemonIsaac", out ModNPC DemonIsaac) && npc.type == DemonIsaac.Type)
                {
                    ModConditions.downedIsaac = true;
                }
                if (ModConditions.afkpetsMod.TryFind("AncientGuardian", out ModNPC AncientGuardian) && npc.type == AncientGuardian.Type)
                {
                    ModConditions.downedAncientGuardian = true;
                }
                if (ModConditions.afkpetsMod.TryFind("HeroicSlime", out ModNPC HeroicSlime) && npc.type == HeroicSlime.Type)
                {
                    ModConditions.downedHeroicSlime = true;
                }
                if (ModConditions.afkpetsMod.TryFind("HolographicSlime", out ModNPC HolographicSlime) && npc.type == HolographicSlime.Type)
                {
                    ModConditions.downedHoloSlime = true;
                }
                if (ModConditions.afkpetsMod.TryFind("SecurityBot", out ModNPC SecurityBot) && npc.type == SecurityBot.Type)
                {
                    ModConditions.downedSecurityBot = true;
                }
                if (ModConditions.afkpetsMod.TryFind("UndeadChef", out ModNPC UndeadChef) && npc.type == UndeadChef.Type)
                {
                    ModConditions.downedUndeadChef = true;
                }
                if (ModConditions.afkpetsMod.TryFind("IceGuardian", out ModNPC IceGuardian) && npc.type == IceGuardian.Type)
                {
                    ModConditions.downedGuardianOfFrost = true;
                }
            }

            if (ModConditions.assortedCrazyThingsLoaded)
            {
                if (ModConditions.assortedCrazyThingsMod.TryFind("HarvesterBoss", out ModNPC HarvesterBoss) && npc.type == HarvesterBoss.Type)
                {
                    ModConditions.downedSoulHarvester = true;
                }
            }

            if (ModConditions.calamityLoaded)
            {
                if (ModConditions.calamityMod.TryFind("CragmawMire", out ModNPC CragmawMire) && npc.type == CragmawMire.Type)
                {
                    ModConditions.downedCragmawMire = true;
                }
                if (ModConditions.calamityMod.TryFind("NuclearTerror", out ModNPC NuclearTerror) && npc.type == NuclearTerror.Type)
                {
                    ModConditions.downedNuclearTerror = true;
                }
                if (ModConditions.calamityMod.TryFind("Mauler", out ModNPC Mauler) && npc.type == Mauler.Type)
                {
                    ModConditions.downedMauler = true;
                }
            }

            if (ModConditions.catalystLoaded)
            {
                if (ModConditions.catalystMod.TryFind("Astrageldon", out ModNPC Astrageldon) && npc.type == Astrageldon.Type)
                {
                    ModConditions.downedAstrageldon = true;
                }
            }

            if (ModConditions.clamityAddonLoaded)
            {
                if (ModConditions.clamityAddonMod.TryFind("ClamitasBoss", out ModNPC ClamitasBoss) && npc.type == ClamitasBoss.Type)
                {
                    ModConditions.downedClamitas = true;
                }
            }

            if (ModConditions.consolariaLoaded)
            {
                if (ModConditions.consolariaMod.TryFind("Lepus", out ModNPC Lepus) && npc.type == Lepus.Type)
                {
                    ModConditions.downedLepus = true;
                }
                if (ModConditions.consolariaMod.TryFind("TurkortheUngrateful", out ModNPC TurkortheUngrateful) && npc.type == TurkortheUngrateful.Type)
                {
                    ModConditions.downedTurkor = true;
                }
                if (ModConditions.consolariaMod.TryFind("Ocram", out ModNPC Ocram) && npc.type == Ocram.Type)
                {
                    ModConditions.downedOcram = true;
                }
            }

            if (ModConditions.depthsLoaded)
            {
                if (ModConditions.depthsMod.TryFind("ChasmeHeart", out ModNPC ChasmeHeart) && npc.type == ChasmeHeart.Type)
                {
                    ModConditions.downedChasme = true;
                }
            }

            if (ModConditions.echoesOfTheAncientsLoaded)
            {
                if (ModConditions.echoesOfTheAncientsMod.TryFind("Galahis", out ModNPC Galahis) && npc.type == Galahis.Type)
                {
                    ModConditions.downedGalahis = true;
                }
                if (ModConditions.echoesOfTheAncientsMod.TryFind("AquaWormHead", out ModNPC AquaWormHead) && npc.type == AquaWormHead.Type)
                {
                    ModConditions.downedCreation = true;
                }
                if (ModConditions.echoesOfTheAncientsMod.TryFind("PumpkinWormHead", out ModNPC PumpkinWormHead) && npc.type == PumpkinWormHead.Type)
                {
                    ModConditions.downedDestruction = true;
                }
            }

            if (ModConditions.edorbisLoaded)
            {
                if (ModConditions.edorbisMod.TryFind("BlightKing", out ModNPC BlightKing) && npc.type == BlightKing.Type)
                {
                    ModConditions.downedBlightKing = true;
                }
                if (ModConditions.edorbisMod.TryFind("TheGardener", out ModNPC TheGardener) && npc.type == TheGardener.Type)
                {
                    ModConditions.downedGardener = true;
                }
                if (ModConditions.edorbisMod.TryFind("GlaciationHead", out ModNPC GlaciationHead) && npc.type == GlaciationHead.Type)
                {
                    ModConditions.downedGlaciation = true;
                }
                if (ModConditions.edorbisMod.TryFind("HandofCthulhu", out ModNPC HandofCthulhu) && npc.type == HandofCthulhu.Type)
                {
                    ModConditions.downedHandOfCthulhu = true;
                }
                if (ModConditions.edorbisMod.TryFind("CursedLord", out ModNPC CursedLord) && npc.type == CursedLord.Type)
                {
                    ModConditions.downedCursePreacher = true;
                }
            }

            if (ModConditions.exaltLoaded)
            {
                if (ModConditions.exaltMod.TryFind("Effulgence", out ModNPC Effulgence) && npc.type == Effulgence.Type)
                {
                    ModConditions.downedEffulgence = true;
                }
                if (ModConditions.exaltMod.TryFind("IceLich", out ModNPC IceLich) && npc.type == IceLich.Type)
                {
                    ModConditions.downedIceLich = true;
                }
            }

            if (ModConditions.fargosSoulsLoaded)
            {
                if (ModConditions.fargosSoulsMod.TryFind("TrojanSquirrel", out ModNPC TrojanSquirrel) && npc.type == TrojanSquirrel.Type)
                {
                    ModConditions.downedTrojanSquirrel = true;
                }
                if (ModConditions.fargosSoulsMod.TryFind("DeviBoss", out ModNPC DeviBoss) && npc.type == DeviBoss.Type)
                {
                    ModConditions.downedDeviantt = true;
                }
                if (ModConditions.fargosSoulsMod.TryFind("BanishedBaron", out ModNPC BanishedBaron) && npc.type == BanishedBaron.Type)
                {
                    ModConditions.downedBanishedBaron = true;
                }
                if (ModConditions.fargosSoulsMod.TryFind("LifeChallenger", out ModNPC LifeChallenger) && npc.type == LifeChallenger.Type)
                {
                    ModConditions.downedLifelight = true;
                }
                if (ModConditions.fargosSoulsMod.TryFind("CosmosChampion", out ModNPC CosmosChampion) && npc.type == CosmosChampion.Type)
                {
                    ModConditions.downedEridanus = true;
                }
                if (ModConditions.fargosSoulsMod.TryFind("AbomBoss", out ModNPC AbomBoss) && npc.type == AbomBoss.Type)
                {
                    ModConditions.downedAbominationn = true;
                }
                if (ModConditions.fargosSoulsMod.TryFind("MutantBoss", out ModNPC MutantBoss) && npc.type == MutantBoss.Type)
                {
                    ModConditions.downedMutant = true;
                }
            }

            if (ModConditions.fracturesOfPenumbraLoaded)
            {
                if (ModConditions.fracturesOfPenumbraMod.TryFind("AlphaFrostjawHead", out ModNPC AlphaFrostjawHead) && npc.type == AlphaFrostjawHead.Type)
                {
                    ModConditions.downedAlphaFrostjaw = true;
                }
                if (ModConditions.fracturesOfPenumbraMod.TryFind("SanguineElemental", out ModNPC SanguineElemental) && npc.type == SanguineElemental.Type)
                {
                    ModConditions.downedSanguineElemental = true;
                }
            }

            if (ModConditions.gameTerrariaLoaded)
            {
                if (ModConditions.gameTerrariaMod.TryFind("Lad", out ModNPC Lad) && npc.type == Lad.Type)
                {
                    ModConditions.downedLad = true;
                }
                if (ModConditions.gameTerrariaMod.TryFind("Hornlitz", out ModNPC Hornlitz) && npc.type == Hornlitz.Type)
                {
                    ModConditions.downedHornlitz = true;
                }
                if (ModConditions.gameTerrariaMod.TryFind("SnowDonCore", out ModNPC SnowDonCore) && npc.type == SnowDonCore.Type)
                {
                    ModConditions.downedSnowDon = true;
                }
                if (ModConditions.gameTerrariaMod.TryFind("Stoffie", out ModNPC Stoffie) && npc.type == Stoffie.Type)
                {
                    ModConditions.downedStoffie = true;
                }
            }

            if (ModConditions.gensokyoLoaded)
            {
                if (ModConditions.gensokyoMod.TryFind("LilyWhite", out ModNPC LilyWhite) && npc.type == LilyWhite.Type)
                {
                    ModConditions.downedLilyWhite = true;
                }
                if (ModConditions.gensokyoMod.TryFind("Rumia", out ModNPC Rumia) && npc.type == Rumia.Type)
                {
                    ModConditions.downedRumia = true;
                }
                if (ModConditions.gensokyoMod.TryFind("EternityLarva", out ModNPC EternityLarva) && npc.type == EternityLarva.Type)
                {
                    ModConditions.downedEternityLarva = true;
                }
                if (ModConditions.gensokyoMod.TryFind("Nazrin", out ModNPC Nazrin) && npc.type == Nazrin.Type)
                {
                    ModConditions.downedNazrin = true;
                }
                if (ModConditions.gensokyoMod.TryFind("HinaKagiyama", out ModNPC HinaKagiyama) && npc.type == HinaKagiyama.Type)
                {
                    ModConditions.downedHinaKagiyama = true;
                }
                if (ModConditions.gensokyoMod.TryFind("Sekibanki", out ModNPC Sekibanki) && npc.type == Sekibanki.Type)
                {
                    ModConditions.downedSekibanki = true;
                }
                if (ModConditions.gensokyoMod.TryFind("Seiran", out ModNPC Seiran) && npc.type == Seiran.Type)
                {
                    ModConditions.downedSeiran = true;
                }
                if (ModConditions.gensokyoMod.TryFind("NitoriKawashiro", out ModNPC NitoriKawashiro) && npc.type == NitoriKawashiro.Type)
                {
                    ModConditions.downedNitoriKawashiro = true;
                }
                if (ModConditions.gensokyoMod.TryFind("MedicineMelancholy", out ModNPC MedicineMelancholy) && npc.type == MedicineMelancholy.Type)
                {
                    ModConditions.downedMedicineMelancholy = true;
                }
                if (ModConditions.gensokyoMod.TryFind("Cirno", out ModNPC Cirno) && npc.type == Cirno.Type)
                {
                    ModConditions.downedCirno = true;
                }
                if (ModConditions.gensokyoMod.TryFind("MinamitsuMurasa", out ModNPC MinamitsuMurasa) && npc.type == MinamitsuMurasa.Type)
                {
                    ModConditions.downedMinamitsuMurasa = true;
                }
                if (ModConditions.gensokyoMod.TryFind("AliceMargatroid", out ModNPC AliceMargatroid) && npc.type == AliceMargatroid.Type)
                {
                    ModConditions.downedAliceMargatroid = true;
                }
                if (ModConditions.gensokyoMod.TryFind("SakuyaIzayoi", out ModNPC SakuyaIzayoi) && npc.type == SakuyaIzayoi.Type)
                {
                    ModConditions.downedSakuyaIzayoi = true;
                }
                if (ModConditions.gensokyoMod.TryFind("SeijaKijin", out ModNPC SeijaKijin) && npc.type == SeijaKijin.Type)
                {
                    ModConditions.downedSeijaKijin = true;
                }
                if (ModConditions.gensokyoMod.TryFind("MayumiJoutouguu", out ModNPC MayumiJoutouguu) && npc.type == MayumiJoutouguu.Type)
                {
                    ModConditions.downedMayumiJoutouguu = true;
                }
                if (ModConditions.gensokyoMod.TryFind("ToyosatomimiNoMiko", out ModNPC ToyosatomimiNoMiko) && npc.type == ToyosatomimiNoMiko.Type)
                {
                    ModConditions.downedToyosatomimiNoMiko = true;
                }
                if (ModConditions.gensokyoMod.TryFind("KaguyaHouraisan", out ModNPC KaguyaHouraisan) && npc.type == KaguyaHouraisan.Type)
                {
                    ModConditions.downedKaguyaHouraisan = true;
                }
                if (ModConditions.gensokyoMod.TryFind("UtsuhoReiuji", out ModNPC UtsuhoReiuji) && npc.type == UtsuhoReiuji.Type)
                {
                    ModConditions.downedUtsuhoReiuji = true;
                }
                if (ModConditions.gensokyoMod.TryFind("TenshiHinanawi", out ModNPC TenshiHinanawi) && npc.type == TenshiHinanawi.Type)
                {
                    ModConditions.downedTenshiHinanawi = true;
                }
                if (ModConditions.gensokyoMod.TryFind("Kisume", out ModNPC Kisume) && npc.type == Kisume.Type)
                {
                    ModConditions.downedKisume = true;
                }
            }

            if (ModConditions.gerdsLabLoaded)
            {
                if (ModConditions.gerdsLabMod.TryFind("Trerios", out ModNPC Trerios) && npc.type == Trerios.Type)
                {
                    ModConditions.downedTrerios = true;
                }
                if (ModConditions.gerdsLabMod.TryFind("MagmaEye", out ModNPC MagmaEye) && npc.type == MagmaEye.Type)
                {
                    ModConditions.downedMagmaEye = true;
                }
                if (ModConditions.gerdsLabMod.TryFind("Jack", out ModNPC Jack) && npc.type == Jack.Type)
                {
                    ModConditions.downedJack = true;
                }
                if (ModConditions.gerdsLabMod.TryFind("Acheron", out ModNPC Acheron) && npc.type == Acheron.Type)
                {
                    ModConditions.downedAcheron = true;
                }
            }

            if (ModConditions.homewardJourneyLoaded)
            {
                if (ModConditions.homewardJourneyMod.TryFind("MarquisMoonsquid", out ModNPC MarquisMoonsquid) && npc.type == MarquisMoonsquid.Type)
                {
                    ModConditions.downedMarquisMoonsquid = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("PriestessRod", out ModNPC PriestessRod) && npc.type == PriestessRod.Type)
                {
                    ModConditions.downedPriestessRod = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Diver", out ModNPC Diver) && npc.type == Diver.Type)
                {
                    ModConditions.downedDiver = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheMotherbrain", out ModNPC TheMotherbrain) && npc.type == TheMotherbrain.Type)
                {
                    ModConditions.downedMotherbrain = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("WallofShadow", out ModNPC WallofShadow) && npc.type == WallofShadow.Type)
                {
                    ModConditions.downedWallOfShadow = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("SlimeGod", out ModNPC SlimeGod) && npc.type == SlimeGod.Type)
                {
                    ModConditions.downedSunSlimeGod = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheOverwatcher", out ModNPC TheOverwatcher) && npc.type == TheOverwatcher.Type)
                {
                    ModConditions.downedOverwatcher = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheLifebringerHead", out ModNPC TheLifebringerHead) && npc.type == TheLifebringerHead.Type)
                {
                    ModConditions.downedLifebringer = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheMaterealizer", out ModNPC TheMaterealizer) && npc.type == TheMaterealizer.Type)
                {
                    ModConditions.downedMaterealizer = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Cave", out ModNPC Trial_Cave) && npc.type == Trial_Cave.Type)
                {
                    ModConditions.downedCaveOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Corruption", out ModNPC Trial_Corruption) && npc.type == Trial_Corruption.Type)
                {
                    ModConditions.downedCorruptOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Crimson", out ModNPC Trial_Crimson) && npc.type == Trial_Crimson.Type)
                {
                    ModConditions.downedCrimsonOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Desert", out ModNPC Trial_Desert) && npc.type == Trial_Desert.Type)
                {
                    ModConditions.downedDesertOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Forest", out ModNPC Trial_Forest) && npc.type == Trial_Forest.Type)
                {
                    ModConditions.downedForestOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Hallow", out ModNPC Trial_Hallow) && npc.type == Trial_Hallow.Type)
                {
                    ModConditions.downedHallowOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Jungle", out ModNPC Trial_Jungle) && npc.type == Trial_Jungle.Type)
                {
                    ModConditions.downedJungleOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Pure", out ModNPC Trial_Pure) && npc.type == Trial_Pure.Type)
                {
                    ModConditions.downedSkyOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Snow", out ModNPC Trial_Snow) && npc.type == Trial_Snow.Type)
                {
                    ModConditions.downedSnowOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("Trial_Underworld", out ModNPC Trial_Underworld) && npc.type == Trial_Underworld.Type)
                {
                    ModConditions.downedUnderworldOrdeal = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("ScarabBelief", out ModNPC ScarabBelief) && npc.type == ScarabBelief.Type)
                {
                    ModConditions.downedScarabBelief = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("WorldsEndEverlastingFallingWhale", out ModNPC WorldsEndEverlastingFallingWhale) && npc.type == WorldsEndEverlastingFallingWhale.Type)
                {
                    ModConditions.downedWorldsEndWhale = true;
                }
                if (ModConditions.homewardJourneyMod.TryFind("TheSon", out ModNPC TheSon) && npc.type == TheSon.Type)
                {
                    ModConditions.downedSon = true;
                }
            }

            if (ModConditions.huntOfTheOldGodLoaded)
            {
                if (ModConditions.huntOfTheOldGodMod.TryFind("Goozma", out ModNPC Goozma) && npc.type == Goozma.Type)
                {
                    ModConditions.downedGoozma = true;
                }
            }

            if (ModConditions.infernumLoaded)
            {
                if (ModConditions.infernumMod.TryFind("BereftVassal", out ModNPC BereftVassal) && npc.type == BereftVassal.Type)
                {
                    SubworldModConditions.downedBereftVassal = true;
                }
            }

            if (ModConditions.lunarVeilLoaded)
            {
                if (ModConditions.lunarVeilMod.TryFind("CommanderGintzia", out ModNPC CommanderGintzia) && npc.type == CommanderGintzia.Type)
                {
                    ModConditions.downedCommanderGintzia = true;
                    ModConditions.downedGintzeArmy = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("SunStalker", out ModNPC SunStalker) && npc.type == SunStalker.Type)
                {
                    ModConditions.downedSunStalker = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("Jack", out ModNPC Jack) && npc.type == Jack.Type)
                {
                    ModConditions.downedPumpkinJack = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("Daedus", out ModNPC Daedus) && npc.type == Daedus.Type)
                {
                    ModConditions.downedForgottenPuppetDaedus = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("DreadMire", out ModNPC DreadMire) && npc.type == DreadMire.Type)
                {
                    ModConditions.downedDreadMire = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("SingularityFragment", out ModNPC SingularityFragment) && npc.type == SingularityFragment.Type)
                {
                    ModConditions.downedSingularityFragment = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("VerliaB", out ModNPC VerliaB) && npc.type == VerliaB.Type)
                {
                    ModConditions.downedVerliaB = true;
                }
                if (ModConditions.lunarVeilMod.TryFind("Gothiviab", out ModNPC Gothiviab) && npc.type == Gothiviab.Type)
                {
                    ModConditions.downedGothivia = true;
                }
            }

            if (ModConditions.mechReworkLoaded)
            {
                if (ModConditions.mechReworkMod.TryFind("Mechclops", out ModNPC Mechclops) && npc.type == Mechclops.Type)
                {
                    ModConditions.downedSt4sys = true;
                }
                if (ModConditions.mechReworkMod.TryFind("TheTerminator", out ModNPC TheTerminator) && npc.type == TheTerminator.Type)
                {
                    ModConditions.downedTerminator = true;
                }
                if (ModConditions.mechReworkMod.TryFind("Caretaker", out ModNPC Caretaker) && npc.type == Caretaker.Type)
                {
                    ModConditions.downedCaretaker = true;
                }
                if (ModConditions.mechReworkMod.TryFind("SiegeEngine", out ModNPC SiegeEngine) && npc.type == SiegeEngine.Type)
                {
                    ModConditions.downedSiegeEngine = true;
                }
            }

            if (ModConditions.metroidLoaded)
            {
                if (ModConditions.metroidMod.TryFind("Torizo", out ModNPC Torizo) && npc.type == Torizo.Type)
                {
                    ModConditions.downedTorizo = true;
                }
                if (ModConditions.metroidMod.TryFind("Serris_Head", out ModNPC Serris_Head) && npc.type == Serris_Head.Type)
                {
                    ModConditions.downedSerris = true;
                }
                if (ModConditions.metroidMod.TryFind("Kraid_Head", out ModNPC Kraid_Head) && npc.type == Kraid_Head.Type)
                {
                    ModConditions.downedKraid = true;
                }
                if (ModConditions.metroidMod.TryFind("Phantoon", out ModNPC Phantoon) && npc.type == Phantoon.Type)
                {
                    ModConditions.downedPhantoon = true;
                }
                if (ModConditions.metroidMod.TryFind("OmegaPirate", out ModNPC OmegaPirate) && npc.type == OmegaPirate.Type)
                {
                    ModConditions.downedOmegaPirate = true;
                }
                if (ModConditions.metroidMod.TryFind("Nightmare", out ModNPC Nightmare) && npc.type == Nightmare.Type)
                {
                    ModConditions.downedNightmare = true;
                }
                if (ModConditions.metroidMod.TryFind("GoldenTorizo", out ModNPC GoldenTorizo) && npc.type == GoldenTorizo.Type)
                {
                    ModConditions.downedGoldenTorizo = true;
                }
            }

            if (ModConditions.polaritiesLoaded)
            {
                if (ModConditions.polaritiesMod.TryFind("StormCloudfish", out ModNPC StormCloudfish) && npc.type == StormCloudfish.Type)
                {
                    ModConditions.downedStormCloudfish = true;
                }
                if (ModConditions.polaritiesMod.TryFind("StarConstruct", out ModNPC StarConstruct) && npc.type == StarConstruct.Type)
                {
                    ModConditions.downedStarConstruct = true;
                }
                if (ModConditions.polaritiesMod.TryFind("Gigabat", out ModNPC Gigabat) && npc.type == Gigabat.Type)
                {
                    ModConditions.downedGigabat = true;
                }
                if (ModConditions.polaritiesMod.TryFind("SunPixie", out ModNPC SunPixie) && npc.type == SunPixie.Type)
                {
                    ModConditions.downedSunPixie = true;
                }
                if (ModConditions.polaritiesMod.TryFind("Esophage", out ModNPC Esophage) && npc.type == Esophage.Type)
                {
                    ModConditions.downedEsophage = true;
                }
                if (ModConditions.polaritiesMod.TryFind("ConvectiveWanderer", out ModNPC ConvectiveWanderer) && npc.type == ConvectiveWanderer.Type)
                {
                    ModConditions.downedConvectiveWanderer = true;
                }
            }

            if (ModConditions.qwertyLoaded)
            {
                if (ModConditions.qwertyMod.TryFind("PolarBear", out ModNPC PolarBear) && npc.type == PolarBear.Type)
                {
                    ModConditions.downedPolarExterminator = true;
                }
                if (ModConditions.qwertyMod.TryFind("FortressBoss", out ModNPC FortressBoss) && npc.type == FortressBoss.Type)
                {
                    ModConditions.downedDivineLight = true;
                }
                if (ModConditions.qwertyMod.TryFind("AncientMachine", out ModNPC AncientMachine) && npc.type == AncientMachine.Type)
                {
                    ModConditions.downedAncientMachine = true;
                }
                if (ModConditions.qwertyMod.TryFind("CloakedDarkBoss", out ModNPC CloakedDarkBoss) && npc.type == CloakedDarkBoss.Type)
                {
                    ModConditions.downedNoehtnap = true;
                }
                if (ModConditions.qwertyMod.TryFind("Hydra", out ModNPC Hydra) && npc.type == Hydra.Type)
                {
                    ModConditions.downedHydra = true;
                }
                if (ModConditions.qwertyMod.TryFind("Imperious", out ModNPC Imperious) && npc.type == Imperious.Type)
                {
                    ModConditions.downedImperious = true;
                }
                if (ModConditions.qwertyMod.TryFind("RuneGhost", out ModNPC RuneGhost) && npc.type == RuneGhost.Type)
                {
                    ModConditions.downedRuneGhost = true;
                }
                if (ModConditions.qwertyMod.TryFind("InvaderBattleship", out ModNPC InvaderBattleship) && npc.type == InvaderBattleship.Type)
                {
                    ModConditions.downedInvaderBattleship = true;
                }
                if (ModConditions.qwertyMod.TryFind("InvaderNoehtnap", out ModNPC InvaderNoehtnap) && npc.type == InvaderNoehtnap.Type)
                {
                    ModConditions.downedInvaderNoehtnap = true;
                    ModConditions.downedInvaders = true;
                }
                if (ModConditions.qwertyMod.TryFind("OLORDv2", out ModNPC OLORDv2) && npc.type == OLORDv2.Type)
                {
                    ModConditions.downedOLORD = true;
                }
                if (ModConditions.qwertyMod.TryFind("TheGreatTyrannosaurus", out ModNPC TheGreatTyrannosaurus) && npc.type == TheGreatTyrannosaurus.Type)
                {
                    ModConditions.downedGreatTyrannosaurus = true;
                    ModConditions.downedDinoMilitia = true;
                }
            }

            if (ModConditions.redemptionLoaded)
            {
                if (ModConditions.redemptionMod.TryFind("FowlEmperor", out ModNPC FowlEmperor) && npc.type == FowlEmperor.Type)
                {
                    ModConditions.downedFowlEmperor = true;
                }
                if (ModConditions.redemptionMod.TryFind("Thorn", out ModNPC Thorn) && npc.type == Thorn.Type)
                {
                    ModConditions.downedThorn = true;
                }
                if (ModConditions.redemptionMod.TryFind("Erhan", out ModNPC Erhan) && npc.type == Erhan.Type)
                {
                    ModConditions.downedErhan = true;
                }
                if (ModConditions.redemptionMod.TryFind("Keeper", out ModNPC Keeper) && npc.type == Keeper.Type)
                {
                    ModConditions.downedKeeper = true;
                }
                if (ModConditions.redemptionMod.TryFind("SoI", out ModNPC SoI) && npc.type == SoI.Type)
                {
                    ModConditions.downedSeedOfInfection = true;
                }
                if (ModConditions.redemptionMod.TryFind("KS3", out ModNPC KS3) && npc.type == KS3.Type)
                {
                    ModConditions.downedKingSlayerIII = true;
                }
                if (ModConditions.redemptionMod.TryFind("OmegaCleaver", out ModNPC OmegaCleaver) && npc.type == OmegaCleaver.Type)
                {
                    ModConditions.downedOmegaCleaver = true;
                }
                if (ModConditions.redemptionMod.TryFind("Gigapora", out ModNPC Gigapora) && npc.type == Gigapora.Type)
                {
                    ModConditions.downedOmegaGigapora = true;
                }
                if (ModConditions.redemptionMod.TryFind("OO", out ModNPC OO) && npc.type == OO.Type)
                {
                    ModConditions.downedOmegaObliterator = true;
                }
                if (ModConditions.redemptionMod.TryFind("PZ", out ModNPC PZ) && npc.type == PZ.Type)
                {
                    ModConditions.downedPatientZero = true;
                }
                if (ModConditions.redemptionMod.TryFind("Akka", out ModNPC Akka) && npc.type == Akka.Type)
                {
                    ModConditions.downedAkka = true;
                }
                if (ModConditions.redemptionMod.TryFind("Ukko", out ModNPC Ukko) && npc.type == Ukko.Type)
                {
                    ModConditions.downedUkko = true;
                }
                if (ModConditions.redemptionMod.TryFind("Nebuleus", out ModNPC Nebuleus) && npc.type == Nebuleus.Type)
                {
                    ModConditions.downedNebuleus = true;
                }
                if (ModConditions.redemptionMod.TryFind("Nebuleus2", out ModNPC Nebuleus2) && npc.type == Nebuleus2.Type)
                {
                    ModConditions.downedNebuleus = true;
                }
                if (ModConditions.redemptionMod.TryFind("Basan", out ModNPC Basan) && npc.type == Basan.Type)
                {
                    ModConditions.downedFowlMorning = true;
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
                        ModConditions.downedRaveyard = true;
                    }
                }
            }

            if (ModConditions.secretsOfTheShadowsLoaded)
            {
                if (ModConditions.secretsOfTheShadowsMod.TryFind("Glowmoth", out ModNPC Glowmoth) && npc.type == Glowmoth.Type)
                {
                    ModConditions.downedGlowmoth = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PutridPinkyPhase2", out ModNPC PutridPinkyPhase2) && npc.type == PutridPinkyPhase2.Type)
                {
                    ModConditions.downedPutridPinky = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PharaohsCurse", out ModNPC PharaohsCurse) && npc.type == PharaohsCurse.Type)
                {
                    ModConditions.downedPharaohsCurse = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("TheAdvisorHead", out ModNPC TheAdvisorHead) && npc.type == TheAdvisorHead.Type)
                {
                    ModConditions.downedAdvisor = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("Polaris", out ModNPC Polaris) && npc.type == Polaris.Type)
                {
                    ModConditions.downedPolaris = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("Lux", out ModNPC Lux) && npc.type == Lux.Type)
                {
                    ModConditions.downedLux = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("SubspaceSerpentHead", out ModNPC SubspaceSerpentHead) && npc.type == SubspaceSerpentHead.Type)
                {
                    ModConditions.downedSubspaceSerpent = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("NatureConstruct", out ModNPC NatureConstruct) && npc.type == NatureConstruct.Type)
                {
                    ModConditions.downedNatureConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EarthenConstruct", out ModNPC EarthenConstruct) && npc.type == EarthenConstruct.Type)
                {
                    ModConditions.downedEarthenConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PermafrostConstruct", out ModNPC PermafrostConstruct) && npc.type == PermafrostConstruct.Type)
                {
                    ModConditions.downedPermafrostConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("TidalConstruct", out ModNPC TidalConstruct) && npc.type == TidalConstruct.Type)
                {
                    ModConditions.downedTidalConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("OtherworldlyConstructHead", out ModNPC OtherworldlyConstructHead) && npc.type == OtherworldlyConstructHead.Type)
                {
                    ModConditions.downedOtherworldlyConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("OtherworldlyConstructHead2", out ModNPC OtherworldlyConstructHead2) && npc.type == OtherworldlyConstructHead2.Type)
                {
                    ModConditions.downedOtherworldlyConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EvilConstruct", out ModNPC EvilConstruct) && npc.type == EvilConstruct.Type)
                {
                    ModConditions.downedEvilConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("InfernoConstruct", out ModNPC InfernoConstruct) && npc.type == InfernoConstruct.Type)
                {
                    ModConditions.downedInfernoConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("ChaosConstruct", out ModNPC ChaosConstruct) && npc.type == ChaosConstruct.Type)
                {
                    ModConditions.downedChaosConstruct = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("NatureSpirit", out ModNPC NatureSpirit) && npc.type == NatureSpirit.Type)
                {
                    ModConditions.downedNatureSpirit = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EarthenSpirit", out ModNPC EarthenSpirit) && npc.type == EarthenSpirit.Type)
                {
                    ModConditions.downedEarthenSpirit = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("PermafrostSpirit", out ModNPC PermafrostSpirit) && npc.type == PermafrostSpirit.Type)
                {
                    ModConditions.downedPermafrostSpirit = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("TidalSpirit", out ModNPC TidalSpirit) && npc.type == TidalSpirit.Type)
                {
                    ModConditions.downedTidalSpirit = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("EvilSpirit", out ModNPC EvilSpirit) && npc.type == EvilSpirit.Type)
                {
                    ModConditions.downedEvilSpirit = true;
                }
                if (ModConditions.secretsOfTheShadowsMod.TryFind("InfernoSpirit", out ModNPC InfernoSpirit) && npc.type == InfernoSpirit.Type)
                {
                    ModConditions.downedInfernoSpirit = true;
                }
            }

            if (ModConditions.spiritLoaded)
            {
                if (ModConditions.spiritMod.TryFind("Scarabeus", out ModNPC Scarabeus) && npc.type == Scarabeus.Type)
                {
                    ModConditions.downedScarabeus = true;
                }
                if (ModConditions.spiritMod.TryFind("MoonWizard", out ModNPC MoonWizard) && npc.type == MoonWizard.Type)
                {
                    ModConditions.downedMoonJellyWizard = true;
                    ModConditions.downedJellyDeluge = true;
                }
                if (ModConditions.spiritMod.TryFind("ReachBoss", out ModNPC ReachBoss) && npc.type == ReachBoss.Type)
                {
                    ModConditions.downedVinewrathBane = true;
                }
                if (ModConditions.spiritMod.TryFind("AncientFlyer", out ModNPC AncientFlyer) && npc.type == AncientFlyer.Type)
                {
                    ModConditions.downedAncientAvian = true;
                }
                if (ModConditions.spiritMod.TryFind("SteamRaiderHead", out ModNPC SteamRaiderHead) && npc.type == SteamRaiderHead.Type)
                {
                    ModConditions.downedStarplateVoyager = true;
                }
                if (ModConditions.spiritMod.TryFind("Infernon", out ModNPC Infernon) && npc.type == Infernon.Type)
                {
                    ModConditions.downedInfernon = true;
                }
                if (ModConditions.spiritMod.TryFind("Dusking", out ModNPC Dusking) && npc.type == Dusking.Type)
                {
                    ModConditions.downedDusking = true;
                }
                if (ModConditions.spiritMod.TryFind("Atlas", out ModNPC Atlas) && npc.type == Atlas.Type)
                {
                    ModConditions.downedAtlas = true;
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
                        ModConditions.downedJellyDeluge = true;
                    }
                }
                if (ModConditions.spiritMod.TryFind("Rylheian", out ModNPC Rylheian) && npc.type == Rylheian.Type)
                {
                    ModConditions.downedTide = true;
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
                        ModConditions.downedMysticMoon = true;
                    }
                }
            }

            if (ModConditions.spookyLoaded)
            {
                if (ModConditions.spookyMod.TryFind("RotGourd", out ModNPC RotGourd) && npc.type == RotGourd.Type)
                {
                    ModConditions.downedRotGourd = true;
                }
                if (ModConditions.spookyMod.TryFind("SpookySpirit", out ModNPC SpookySpirit) && npc.type == SpookySpirit.Type)
                {
                    ModConditions.downedSpookySpirit = true;
                }
                if (ModConditions.spookyMod.TryFind("Moco", out ModNPC Moco) && npc.type == Moco.Type)
                {
                    ModConditions.downedMoco = true;
                }
                if (ModConditions.spookyMod.TryFind("DaffodilEye", out ModNPC DaffodilEye) && npc.type == DaffodilEye.Type)
                {
                    ModConditions.downedDaffodil = true;
                }
                if (ModConditions.spookyMod.TryFind("OrroHead", out ModNPC OrroHead) && npc.type == OrroHead.Type)
                {
                    ModConditions.downedOrro = true;
                }
                if (ModConditions.spookyMod.TryFind("BoroHead", out ModNPC BoroHead) && npc.type == BoroHead.Type)
                {
                    ModConditions.downedBoro = true;
                }
                if (ModConditions.spookyMod.TryFind("BigBone", out ModNPC BigBone) && npc.type == BigBone.Type)
                {
                    ModConditions.downedBigBone = true;
                }
            }

            if (ModConditions.starlightRiverLoaded)
            {
                if (ModConditions.starlightRiverMod.TryFind("SquidBoss", out ModNPC SquidBoss) && npc.type == SquidBoss.Type)
                {
                    ModConditions.downedAuroracle = true;
                }
                if (ModConditions.starlightRiverMod.TryFind("VitricBoss", out ModNPC VitricBoss) && npc.type == VitricBoss.Type)
                {
                    ModConditions.downedCeiros = true;
                }
                if (ModConditions.starlightRiverMod.TryFind("Glassweaver", out ModNPC Glassweaver) && npc.type == Glassweaver.Type)
                {
                    ModConditions.downedGlassweaver = true;
                }
            }

            if (ModConditions.stormsAdditionsLoaded)
            {
                if (ModConditions.stormsAdditionsMod.TryFind("AridBoss", out ModNPC AridBoss) && npc.type == AridBoss.Type)
                {
                    ModConditions.downedAncientHusk = true;
                }
                if (ModConditions.stormsAdditionsMod.TryFind("StormBoss", out ModNPC StormBoss) && npc.type == StormBoss.Type)
                {
                    ModConditions.downedOverloadedScandrone = true;
                }
                if (ModConditions.stormsAdditionsMod.TryFind("TheUltimateBoss", out ModNPC TheUltimateBoss) && npc.type == TheUltimateBoss.Type)
                {
                    ModConditions.downedPainbringer = true;
                }
            }

            if (ModConditions.supernovaLoaded)
            {
                if (ModConditions.supernovaMod.TryFind("HarbingerOfAnnihilation", out ModNPC HarbingerOfAnnihilation) && npc.type == HarbingerOfAnnihilation.Type)
                {
                    ModConditions.downedHarbingerOfAnnihilation = true;
                }
                if (ModConditions.supernovaMod.TryFind("FlyingTerror", out ModNPC FlyingTerror) && npc.type == FlyingTerror.Type)
                {
                    ModConditions.downedFlyingTerror = true;
                }
                if (ModConditions.supernovaMod.TryFind("StoneMantaRay", out ModNPC StoneMantaRay) && npc.type == StoneMantaRay.Type)
                {
                    ModConditions.downedStoneMantaRay = true;
                }
            }

            if (ModConditions.terrorbornLoaded)
            {
                if (ModConditions.terrorbornMod.TryFind("InfectedIncarnate", out ModNPC InfectedIncarnate) && npc.type == InfectedIncarnate.Type)
                {
                    ModConditions.downedInfectedIncarnate = true;
                }
                if (ModConditions.terrorbornMod.TryFind("TidalTitan", out ModNPC TidalTitan) && npc.type == TidalTitan.Type)
                {
                    ModConditions.downedTidalTitan = true;
                }
                if (ModConditions.terrorbornMod.TryFind("Dunestock", out ModNPC Dunestock) && npc.type == Dunestock.Type)
                {
                    ModConditions.downedDunestock = true;
                }
                if (ModConditions.terrorbornMod.TryFind("Shadowcrawler", out ModNPC Shadowcrawler) && npc.type == Shadowcrawler.Type)
                {
                    ModConditions.downedShadowcrawler = true;
                }
                if (ModConditions.terrorbornMod.TryFind("HexedConstructor", out ModNPC HexedConstructor) && npc.type == HexedConstructor.Type)
                {
                    ModConditions.downedHexedConstructor = true;
                }
                if (ModConditions.terrorbornMod.TryFind("PrototypeI", out ModNPC PrototypeI) && npc.type == PrototypeI.Type)
                {
                    ModConditions.downedPrototypeI = true;
                }
            }

            if (ModConditions.traeLoaded)
            {
                if (ModConditions.traeMod.TryFind("GraniteOvergrowthNPC", out ModNPC GraniteOvergrowthNPC) && npc.type == GraniteOvergrowthNPC.Type)
                {
                    ModConditions.downedGraniteOvergrowth = true;
                }
                if (ModConditions.traeMod.TryFind("BeholderNPC", out ModNPC BeholderNPC) && npc.type == BeholderNPC.Type)
                {
                    ModConditions.downedBeholder = true;
                }
            }

            if (ModConditions.uhtricLoaded)
            {
                if (ModConditions.uhtricMod.TryFind("Dredger", out ModNPC Dredger) && npc.type == Dredger.Type)
                {
                    ModConditions.downedDredger = true;
                }
                if (ModConditions.uhtricMod.TryFind("CharcoolSnowman", out ModNPC CharcoolSnowman) && npc.type == CharcoolSnowman.Type)
                {
                    ModConditions.downedCharcoolSnowman = true;
                }
                if (ModConditions.uhtricMod.TryFind("CosmicMenace", out ModNPC CosmicMenace) && npc.type == CosmicMenace.Type)
                {
                    ModConditions.downedCosmicMenace = true;
                }
            }

            if (ModConditions.universeOfSwordsLoaded)
            {
                if (ModConditions.universeOfSwordsMod.TryFind("SwordBossNPC", out ModNPC SwordBossNPC) && npc.type == SwordBossNPC.Type)
                {
                    ModConditions.downedEvilFlyingBlade = true;
                }
            }

            if (ModConditions.valhallaLoaded)
            {
                if (ModConditions.valhallaMod.TryFind("Emperor", out ModNPC Emperor) && npc.type == Emperor.Type)
                {
                    ModConditions.downedYurnero = true;
                }
                if (ModConditions.valhallaMod.TryFind("PirateSquid", out ModNPC PirateSquid) && npc.type == PirateSquid.Type)
                {
                    ModConditions.downedColossalCarnage = true;
                }
            }

            if (ModConditions.vitalityLoaded)
            {
                if (ModConditions.vitalityMod.TryFind("StormCloudBoss", out ModNPC StormCloudBoss) && npc.type == StormCloudBoss.Type)
                {
                    ModConditions.downedStormCloud = true;
                }
                if (ModConditions.vitalityMod.TryFind("GrandAntlionBoss", out ModNPC GrandAntlionBoss) && npc.type == GrandAntlionBoss.Type)
                {
                    ModConditions.downedGrandAntlion = true;
                }
                if (ModConditions.vitalityMod.TryFind("GemstoneElementalBoss", out ModNPC GemstoneElementalBoss) && npc.type == GemstoneElementalBoss.Type)
                {
                    ModConditions.downedGemstoneElemental = true;
                }
                if (ModConditions.vitalityMod.TryFind("MoonlightDragonflyBoss", out ModNPC MoonlightDragonflyBoss) && npc.type == MoonlightDragonflyBoss.Type)
                {
                    ModConditions.downedMoonlightDragonfly = true;
                }
                if (ModConditions.vitalityMod.TryFind("DreadnaughtBoss", out ModNPC DreadnaughtBoss) && npc.type == DreadnaughtBoss.Type)
                {
                    ModConditions.downedDreadnaught = true;
                }
                if (ModConditions.vitalityMod.TryFind("AnarchulesBeetleBoss", out ModNPC AnarchulesBeetleBoss) && npc.type == AnarchulesBeetleBoss.Type)
                {
                    ModConditions.downedAnarchulesBeetle = true;
                }
                if (ModConditions.vitalityMod.TryFind("ChaosbringerBoss", out ModNPC ChaosbringerBoss) && npc.type == ChaosbringerBoss.Type)
                {
                    ModConditions.downedChaosbringer = true;
                }
                if (ModConditions.vitalityMod.TryFind("PaladinSpiritBoss", out ModNPC PaladinSpiritBoss) && npc.type == PaladinSpiritBoss.Type)
                {
                    ModConditions.downedPaladinSpirit = true;
                }
            }

            if (ModConditions.wayfairContentLoaded)
            {
                if (ModConditions.wayfairContentMod.TryFind("Lifebloom", out ModNPC Lifebloom) && npc.type == Lifebloom.Type)
                {
                    ModConditions.downedManaflora = true;
                }
            }
        }
    }
}
