using Microsoft.Xna.Framework;
using QoLCompendium.Items;
using QoLCompendium.UI;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class QolCPlayer : ModPlayer
    {
        public override void ResetEffects()
        {
            magnetActive = false;
            enemyEraser = false;
            enemyAggressor = false;
            headCounter = false;

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }

        public override void UpdateDead()
        {
            magnetActive = false;
            enemyEraser = false;
            enemyAggressor = false;
            headCounter = false;

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }

        public override void PostUpdateMiscEffects()
        {
            if (ModContent.GetInstance<QoLCConfig>().IncreasePlaceSpeed)
            {
                Player.tileSpeed -= 3f;
                Player.wallSpeed -= 3f;
                Player.tileRangeX += 5;
                Player.tileRangeY += 4;
            }
        }

        public override void OnRespawn(Player player)
        {
            if (ModContent.GetInstance<QoLCConfig>().FullHPRespawn)
            {
                respawnFullHPTimer = 1;
            }
        }

        public override void PostUpdate()
        {
            if (ModContent.GetInstance<QoLCConfig>().FullHPRespawn)
            {
                if (respawnFullHPTimer == 0)
                {
                    respawnFullHPTimer = -1;
                    Player.statLife = Player.statLifeMax2;
                    Player.statMana = Player.statManaMax2;
                }
                respawnFullHPTimer--;
            }
        }

        public override void PreUpdate()
        {
            if (this.magnetActive)
            {
                int num = Main.maxTilesX * 16;
                int num2 = (int)((float)num * 0.5625f);
                Rectangle rectangle = new((int)Player.position.X - num, (int)Player.position.Y - num2, Player.width + num * 2, Player.height + num2 * 2);
                for (int i = 0; i < 400; i++)
                {
                    Item item = Main.item[i];
                    if (item.active && item.noGrabDelay == 0 && !ItemLoader.GrabStyle(item, Player) && ItemLoader.CanPickup(item, Player))
                    {
                        bool flag = true;
                        if (Main.netMode != NetmodeID.SinglePlayer && item.instanced)
                        {
                            flag &= (item.playerIndexTheItemIsReservedFor == Player.whoAmI);
                        }
                        if (flag && rectangle.Intersects(item.getRect()))
                        {
                            item.beingGrabbed = true;
                            float num3 = 80f;
                            Vector2 vector = Player.Center - item.Center;
                            Vector2 vector2 = vector;
                            float num4 = vector.Length();
                            num3 += 2f * (1f - num4 / (float)num);
                            if (num4 > 0f)
                            {
                                vector2 /= num4;
                            }
                            vector2 *= num3;
                            int num5 = 31;
                            item.velocity = (item.velocity * (float)(num5 - 1) + vector2) / (float)num5;
                        }
                    }
                }
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (ModContent.GetInstance<QoLCConfig>().InstantRespawn)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].boss)
                    {
                        Main.npc[i].active = false;
                    }
                }
                Player.respawnTimer = 60;
            }
        }

        public override void PreUpdateBuffs()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod mod);
            ModLoader.TryGetMod("ThoriumMod", out Mod mod2);
            ModLoader.TryGetMod("SOTS", out Mod mod3);
            if (ModContent.GetInstance<QoLCConfig>().EndlessBuffsAndHealing)
            {
                if (Main.GameUpdateCount % 1.5 == 0.0)
                {
                    ItemsToCountForEndlessBuffs.Clear();
                    ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray<Item>(Player.inventory, "Inventory"));
                    InventoryItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                    ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray<Item>(Player.bank.item, "PiggyBank"));
                    PiggyBankItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                    ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray<Item>(Player.bank2.item, "Safe"));
                    SafeItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                    ItemsToCountForEndlessBuffs.AddRange(BuffHelper.FromArray<Item>(Player.bank3.item, "DefendersForge"));
                    DefendersForgeItemsStart = ItemsToCountForEndlessBuffs.Count - 1;
                }
                EndlessBuffSources.Clear();
                foreach (ValueTuple<Item, string> valueTuple in ItemsToCountForEndlessBuffs)
                {
                    Item item = valueTuple.Item1;
                    string item2 = valueTuple.Item2;
                    if (item.buffType > 0 && item.stack >= 30 && !EndlessBuffSources.ContainsKey(item.buffType))
                    {
                        EndlessBuffSources.Add(item.buffType, new EndlessBuffSource(item, item2));
                        Player.AddBuff(item.buffType, 20, true, false);
                        Main.buffNoTimeDisplay[item.buffType] = true;
                    }
                }
                foreach (Item item3 in Player.inventory)
                {
                    if (item3.type == ItemID.CatBast)
                    {
                        Player.AddBuff(215, 20, true, false);
                        Main.buffNoTimeDisplay[215] = true;
                    }
                    if (item3.type == ItemID.Campfire)
                    {
                        Player.AddBuff(87, 20, true, false);
                        Main.buffNoTimeDisplay[87] = true;
                    }
                    if (item3.type == ItemID.HeartLantern)
                    {
                        Player.AddBuff(89, 20, true, false);
                        Main.buffNoTimeDisplay[89] = true;
                    }
                    if (item3.type == ItemID.StarinaBottle)
                    {
                        Player.AddBuff(158, 20, true, false);
                        Main.buffNoTimeDisplay[158] = true;
                    }
                    if (item3.type == ItemID.Sunflower)
                    {
                        Player.AddBuff(146, 20, true, false);
                        Main.buffNoTimeDisplay[146] = true;
                    }
                    if (item3.type == ItemID.AmmoBox)
                    {
                        Player.AddBuff(93, 20, true, false);
                        Main.buffNoTimeDisplay[93] = true;
                    }
                    if (item3.type == ItemID.BewitchingTable)
                    {
                        Player.AddBuff(150, 20, true, false);
                        Main.buffNoTimeDisplay[150] = true;
                    }
                    if (item3.type == ItemID.CrystalBall)
                    {
                        Player.AddBuff(29, 20, true, false);
                        Main.buffNoTimeDisplay[29] = true;
                    }
                    if (item3.type == ItemID.SliceOfCake)
                    {
                        Player.AddBuff(192, 20, true, false);
                        Main.buffNoTimeDisplay[192] = true;
                    }
                    if (item3.type == ItemID.SharpeningStation)
                    {
                        Player.AddBuff(159, 20, true, false);
                        Main.buffNoTimeDisplay[159] = true;
                    }
                    if (item3.type == ItemID.WaterCandle)
                    {
                        Player.AddBuff(86, 20, true, false);
                        Main.buffNoTimeDisplay[86] = true;
                    }
                    if (item3.type == ItemID.PeaceCandle)
                    {
                        Player.AddBuff(157, 20, true, false);
                        Main.buffNoTimeDisplay[157] = true;
                    }
                    if (item3.type == ItemID.HoneyBucket)
                    {
                        Player.AddBuff(48, 20, true, false);
                        Main.buffNoTimeDisplay[48] = true;
                    }
                    if (item3.type == ItemID.GardenGnome)
                    {
                        Player.luck += 0.2f;
                    }
                    if (mod != null)
                    {
                        if (item3.type == mod.Find<ModItem>("WeightlessCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusBlueCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusBlueCandleBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("VigorousCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPinkCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPinkCandleBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("SpitefulCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusYellowCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusYellowCandleBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("ResilientCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("ChaosCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("ChaosCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("ChaosCandleBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("TranquilityCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("TranquilityCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("TranquilityCandleBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("EffigyOfDecay").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("EffigyOfDecayBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("EffigyOfDecayBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("CrimsonEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CrimsonEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CrimsonEffigyBuff").Type] = true;
                        }
                        if (item3.type == mod.Find<ModItem>("CorruptionEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CorruptionEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CorruptionEffigyBuff").Type] = true;
                        }
                    }
                    if (mod2 != null)
                    {
                        if (item3.type == mod2.Find<ModItem>("Altar").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SpiritualConnection").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SpiritualConnection").Type] = true;
                        }
                        if (item3.type == mod2.Find<ModItem>("ConductorsStand").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("ConductorBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("ConductorBuff").Type] = true;
                        }
                        if (item3.type == mod2.Find<ModItem>("NinjaRack").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("NinjaBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("NinjaBuff").Type] = true;
                        }
                        if (item3.type == mod2.Find<ModItem>("Mistletoe").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SeasonsGreeting").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SeasonsGreeting").Type] = true;
                        }
                    }
                    if (mod3 != null && item3.type == mod3.Find<ModItem>("DigitalDisplay").Type)
                    {
                        Player.AddBuff(mod3.Find<ModBuff>("CyberneticEnhancements").Type, 20, true, false);
                        Main.buffNoTimeDisplay[mod3.Find<ModBuff>("CyberneticEnhancements").Type] = true;
                    }
                }
                foreach (Item item4 in Player.bank.item)
                {
                    if (item4.type == ItemID.CatBast)
                    {
                        Player.AddBuff(215, 20, true, false);
                        Main.buffNoTimeDisplay[215] = true;
                    }
                    if (item4.type == ItemID.Campfire)
                    {
                        Player.AddBuff(87, 20, true, false);
                        Main.buffNoTimeDisplay[87] = true;
                    }
                    if (item4.type == ItemID.HeartLantern)
                    {
                        Player.AddBuff(89, 20, true, false);
                        Main.buffNoTimeDisplay[89] = true;
                    }
                    if (item4.type == ItemID.StarinaBottle)
                    {
                        Player.AddBuff(158, 20, true, false);
                        Main.buffNoTimeDisplay[158] = true;
                    }
                    if (item4.type == ItemID.Sunflower)
                    {
                        Player.AddBuff(146, 20, true, false);
                        Main.buffNoTimeDisplay[146] = true;
                    }
                    if (item4.type == ItemID.AmmoBox)
                    {
                        Player.AddBuff(93, 20, true, false);
                        Main.buffNoTimeDisplay[93] = true;
                    }
                    if (item4.type == ItemID.BewitchingTable)
                    {
                        Player.AddBuff(150, 20, true, false);
                        Main.buffNoTimeDisplay[150] = true;
                    }
                    if (item4.type == ItemID.CrystalBall)
                    {
                        Player.AddBuff(29, 20, true, false);
                        Main.buffNoTimeDisplay[29] = true;
                    }
                    if (item4.type == ItemID.SliceOfCake)
                    {
                        Player.AddBuff(192, 20, true, false);
                        Main.buffNoTimeDisplay[192] = true;
                    }
                    if (item4.type == ItemID.SharpeningStation)
                    {
                        Player.AddBuff(159, 20, true, false);
                        Main.buffNoTimeDisplay[159] = true;
                    }
                    if (item4.type == ItemID.WaterCandle)
                    {
                        Player.AddBuff(86, 20, true, false);
                        Main.buffNoTimeDisplay[86] = true;
                    }
                    if (item4.type == ItemID.PeaceCandle)
                    {
                        Player.AddBuff(157, 20, true, false);
                        Main.buffNoTimeDisplay[157] = true;
                    }
                    if (item4.type == ItemID.HoneyBucket)
                    {
                        Player.AddBuff(48, 20, true, false);
                        Main.buffNoTimeDisplay[48] = true;
                    }
                    if (item4.type == ItemID.GardenGnome)
                    {
                        Player.luck += 0.2f;
                    }
                    if (mod != null)
                    {
                        if (item4.type == mod.Find<ModItem>("WeightlessCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusBlueCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusBlueCandleBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("VigorousCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPinkCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPinkCandleBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("SpitefulCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusYellowCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusYellowCandleBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("ResilientCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("ChaosCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("ChaosCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("ChaosCandleBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("TranquilityCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("TranquilityCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("TranquilityCandleBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("EffigyOfDecay").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("EffigyOfDecayBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("EffigyOfDecayBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("CrimsonEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CrimsonEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CrimsonEffigyBuff").Type] = true;
                        }
                        if (item4.type == mod.Find<ModItem>("CorruptionEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CorruptionEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CorruptionEffigyBuff").Type] = true;
                        }
                    }
                    if (mod2 != null)
                    {
                        if (item4.type == mod2.Find<ModItem>("Altar").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SpiritualConnection").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SpiritualConnection").Type] = true;
                        }
                        if (item4.type == mod2.Find<ModItem>("ConductorsStand").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("ConductorBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("ConductorBuff").Type] = true;
                        }
                        if (item4.type == mod2.Find<ModItem>("NinjaRack").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("NinjaBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("NinjaBuff").Type] = true;
                        }
                        if (item4.type == mod2.Find<ModItem>("Mistletoe").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SeasonsGreeting").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SeasonsGreeting").Type] = true;
                        }
                    }
                    if (mod3 != null && item4.type == mod3.Find<ModItem>("DigitalDisplay").Type)
                    {
                        Player.AddBuff(mod3.Find<ModBuff>("CyberneticEnhancements").Type, 20, true, false);
                        Main.buffNoTimeDisplay[mod3.Find<ModBuff>("CyberneticEnhancements").Type] = true;
                    }
                }
                foreach (Item item5 in Player.bank2.item)
                {
                    if (item5.type == ItemID.CatBast)
                    {
                        Player.AddBuff(215, 20, true, false);
                        Main.buffNoTimeDisplay[215] = true;
                    }
                    if (item5.type == ItemID.Campfire)
                    {
                        Player.AddBuff(87, 20, true, false);
                        Main.buffNoTimeDisplay[87] = true;
                    }
                    if (item5.type == ItemID.HeartLantern)
                    {
                        Player.AddBuff(89, 20, true, false);
                        Main.buffNoTimeDisplay[89] = true;
                    }
                    if (item5.type == ItemID.StarinaBottle)
                    {
                        Player.AddBuff(158, 20, true, false);
                        Main.buffNoTimeDisplay[158] = true;
                    }
                    if (item5.type == ItemID.Sunflower)
                    {
                        Player.AddBuff(146, 20, true, false);
                        Main.buffNoTimeDisplay[146] = true;
                    }
                    if (item5.type == ItemID.AmmoBox)
                    {
                        Player.AddBuff(93, 20, true, false);
                        Main.buffNoTimeDisplay[93] = true;
                    }
                    if (item5.type == ItemID.BewitchingTable)
                    {
                        Player.AddBuff(150, 20, true, false);
                        Main.buffNoTimeDisplay[150] = true;
                    }
                    if (item5.type == ItemID.CrystalBall)
                    {
                        Player.AddBuff(29, 20, true, false);
                        Main.buffNoTimeDisplay[29] = true;
                    }
                    if (item5.type == ItemID.SliceOfCake)
                    {
                        Player.AddBuff(192, 20, true, false);
                        Main.buffNoTimeDisplay[192] = true;
                    }
                    if (item5.type == ItemID.SharpeningStation)
                    {
                        Player.AddBuff(159, 20, true, false);
                        Main.buffNoTimeDisplay[159] = true;
                    }
                    if (item5.type == ItemID.WaterCandle)
                    {
                        Player.AddBuff(86, 20, true, false);
                        Main.buffNoTimeDisplay[86] = true;
                    }
                    if (item5.type == ItemID.PeaceCandle)
                    {
                        Player.AddBuff(157, 20, true, false);
                        Main.buffNoTimeDisplay[157] = true;
                    }
                    if (item5.type == ItemID.HoneyBucket)
                    {
                        Player.AddBuff(48, 20, true, false);
                        Main.buffNoTimeDisplay[48] = true;
                    }
                    if (item5.type == ItemID.GardenGnome)
                    {
                        Player.luck += 0.2f;
                    }
                    if (mod != null)
                    {
                        if (item5.type == mod.Find<ModItem>("WeightlessCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusBlueCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusBlueCandleBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("VigorousCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPinkCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPinkCandleBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("SpitefulCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusYellowCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusYellowCandleBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("ResilientCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("ChaosCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("ChaosCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("ChaosCandleBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("TranquilityCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("TranquilityCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("TranquilityCandleBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("EffigyOfDecay").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("EffigyOfDecayBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("EffigyOfDecayBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("CrimsonEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CrimsonEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CrimsonEffigyBuff").Type] = true;
                        }
                        if (item5.type == mod.Find<ModItem>("CorruptionEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CorruptionEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CorruptionEffigyBuff").Type] = true;
                        }
                    }
                    if (mod2 != null)
                    {
                        if (item5.type == mod2.Find<ModItem>("Altar").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SpiritualConnection").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SpiritualConnection").Type] = true;
                        }
                        if (item5.type == mod2.Find<ModItem>("ConductorsStand").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("ConductorBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("ConductorBuff").Type] = true;
                        }
                        if (item5.type == mod2.Find<ModItem>("NinjaRack").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("NinjaBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("NinjaBuff").Type] = true;
                        }
                        if (item5.type == mod2.Find<ModItem>("Mistletoe").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SeasonsGreeting").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SeasonsGreeting").Type] = true;
                        }
                    }
                    if (mod3 != null && item5.type == mod3.Find<ModItem>("DigitalDisplay").Type)
                    {
                        Player.AddBuff(mod3.Find<ModBuff>("CyberneticEnhancements").Type, 20, true, false);
                        Main.buffNoTimeDisplay[mod3.Find<ModBuff>("CyberneticEnhancements").Type] = true;
                    }
                }
                foreach (Item item6 in Player.bank3.item)
                {
                    if (item6.type == ItemID.CatBast)
                    {
                        Player.AddBuff(215, 20, true, false);
                        Main.buffNoTimeDisplay[215] = true;
                    }
                    if (item6.type == ItemID.Campfire)
                    {
                        Player.AddBuff(87, 20, true, false);
                        Main.buffNoTimeDisplay[87] = true;
                    }
                    if (item6.type == ItemID.HeartLantern)
                    {
                        Player.AddBuff(89, 20, true, false);
                        Main.buffNoTimeDisplay[89] = true;
                    }
                    if (item6.type == ItemID.StarinaBottle)
                    {
                        Player.AddBuff(158, 20, true, false);
                        Main.buffNoTimeDisplay[158] = true;
                    }
                    if (item6.type == ItemID.Sunflower)
                    {
                        Player.AddBuff(146, 20, true, false);
                        Main.buffNoTimeDisplay[146] = true;
                    }
                    if (item6.type == ItemID.AmmoBox)
                    {
                        Player.AddBuff(93, 20, true, false);
                        Main.buffNoTimeDisplay[93] = true;
                    }
                    if (item6.type == ItemID.BewitchingTable)
                    {
                        Player.AddBuff(150, 20, true, false);
                        Main.buffNoTimeDisplay[150] = true;
                    }
                    if (item6.type == ItemID.CrystalBall)
                    {
                        Player.AddBuff(29, 20, true, false);
                        Main.buffNoTimeDisplay[29] = true;
                    }
                    if (item6.type == ItemID.SliceOfCake)
                    {
                        Player.AddBuff(192, 20, true, false);
                        Main.buffNoTimeDisplay[192] = true;
                    }
                    if (item6.type == ItemID.SharpeningStation)
                    {
                        Player.AddBuff(159, 20, true, false);
                        Main.buffNoTimeDisplay[159] = true;
                    }
                    if (item6.type == ItemID.WaterCandle)
                    {
                        Player.AddBuff(86, 20, true, false);
                        Main.buffNoTimeDisplay[86] = true;
                    }
                    if (item6.type == ItemID.PeaceCandle)
                    {
                        Player.AddBuff(157, 20, true, false);
                        Main.buffNoTimeDisplay[157] = true;
                    }
                    if (item6.type == ItemID.HoneyBucket)
                    {
                        Player.AddBuff(48, 20, true, false);
                        Main.buffNoTimeDisplay[48] = true;
                    }
                    if (item6.type == ItemID.GardenGnome)
                    {
                        Player.luck += 0.2f;
                    }
                    if (mod != null)
                    {
                        if (item6.type == mod.Find<ModItem>("WeightlessCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusBlueCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusBlueCandleBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("VigorousCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPinkCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPinkCandleBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("SpitefulCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusYellowCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusYellowCandleBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("ResilientCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CirrusPurpleCandleBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("ChaosCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("ChaosCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("ChaosCandleBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("TranquilityCandle").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("TranquilityCandleBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("TranquilityCandleBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("EffigyOfDecay").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("EffigyOfDecayBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("EffigyOfDecayBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("CrimsonEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CrimsonEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CrimsonEffigyBuff").Type] = true;
                        }
                        if (item6.type == mod.Find<ModItem>("CorruptionEffigy").Type)
                        {
                            Player.AddBuff(mod.Find<ModBuff>("CorruptionEffigyBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod.Find<ModBuff>("CorruptionEffigyBuff").Type] = true;
                        }
                    }
                    if (mod2 != null)
                    {
                        if (item6.type == mod2.Find<ModItem>("Altar").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SpiritualConnection").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SpiritualConnection").Type] = true;
                        }
                        if (item6.type == mod2.Find<ModItem>("ConductorsStand").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("ConductorBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("ConductorBuff").Type] = true;
                        }
                        if (item6.type == mod2.Find<ModItem>("NinjaRack").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("NinjaBuff").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("NinjaBuff").Type] = true;
                        }
                        if (item6.type == mod2.Find<ModItem>("Mistletoe").Type)
                        {
                            Player.AddBuff(mod2.Find<ModBuff>("SeasonsGreeting").Type, 20, true, false);
                            Main.buffNoTimeDisplay[mod2.Find<ModBuff>("SeasonsGreeting").Type] = true;
                        }
                    }
                    if (mod3 != null && item6.type == mod3.Find<ModItem>("DigitalDisplay").Type)
                    {
                        Player.AddBuff(mod3.Find<ModBuff>("CyberneticEnhancements").Type, 20, true, false);
                        Main.buffNoTimeDisplay[mod3.Find<ModBuff>("CyberneticEnhancements").Type] = true;
                    }
                }
            }
            if (ModContent.GetInstance<QoLCConfig>().ToggleHappiness)
            {
                Player.currentShoppingSettings.PriceAdjustment = 0.75;
            }
        }

        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<QoLCConfig>().InformationBanks)
            {
                Item[] item = Player.bank.item;
                Item[] item2 = Player.bank2.item;
                Item[] item3 = Player.bank3.item;
                Item[] item4 = Player.bank4.item;
                for (int i = 0; i < item.Length; i++)
                {
                    CheckTrinkets(item[i].type);
                }
                for (int j = 0; j < item2.Length; j++)
                {
                    CheckTrinkets(item2[j].type);
                }
                for (int k = 0; k < item3.Length; k++)
                {
                    CheckTrinkets(item3[k].type);
                }
                for (int l = 0; l < item4.Length; l++)
                {
                    CheckTrinkets(item4[l].type);
                }
            }
        }

        private void CheckTrinkets(int itemType)
        {
            if (itemType == 854 || itemType == 3035)
            {
                Player.discount = true;
                return;
            }
            if (itemType == 3619 || itemType == 3611)
            {
                Player.InfoAccMechShowWires = true;
                return;
            }
            if (itemType == 2799)
            {
                Player.rulerGrid = true;
                return;
            }
            if (itemType == 3624)
            {
                Player.autoActuator = true;
                return;
            }
            if (itemType == 2216 || itemType == 3061)
            {
                Player.autoPaint = true;
                return;
            }
            if (itemType == 3123 || itemType == 3124)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
                return;
            }
            if (itemType == 395)
            {
                Player.accWatch = 3;
                Player.accDepthMeter = 1;
                Player.accCompass = 1;
                return;
            }
            if (itemType == 3122)
            {
                Player.accThirdEye = true;
                Player.accCritterGuide = true;
                Player.accJarOfSouls = true;
                return;
            }
            if (itemType == 3121)
            {
                Player.accOreFinder = true;
                Player.accStopwatch = true;
                Player.accDreamCatcher = true;
                return;
            }
            if (itemType == 3036)
            {
                Player.accFishFinder = true;
                Player.accWeatherRadio = true;
                Player.accCalendar = true;
                return;
            }
            if ((itemType == 15 || itemType == 707) && Player.accWatch < 1)
            {
                Player.accWatch = 1;
                return;
            }
            if ((itemType == 16 || itemType == 708) && Player.accWatch < 2)
            {
                Player.accWatch = 2;
                return;
            }
            if (itemType == 17 || itemType == 709)
            {
                Player.accWatch = 3;
                return;
            }
            if (itemType == 18)
            {
                Player.accDepthMeter = 1;
                return;
            }
            if (itemType == 393)
            {
                Player.accCompass = 1;
                return;
            }
            if (itemType == 3084)
            {
                Player.accThirdEye = true;
                return;
            }
            if (itemType == 3118)
            {
                Player.accCritterGuide = true;
                return;
            }
            if (itemType == 3095)
            {
                Player.accJarOfSouls = true;
                return;
            }
            if (itemType == 3102)
            {
                Player.accOreFinder = true;
                return;
            }
            if (itemType == 3099)
            {
                Player.accStopwatch = true;
                return;
            }
            if (itemType == 3119)
            {
                Player.accDreamCatcher = true;
                return;
            }
            if (itemType == 3120)
            {
                Player.accFishFinder = true;
                return;
            }
            if (itemType == 3037)
            {
                Player.accWeatherRadio = true;
                return;
            }
            if (itemType == 3096)
            {
                Player.accCalendar = true;
                return;
            }
            if (itemType == 407)
            {
                Player.blockRange += 1;
                return;
            }
            if (itemType == 1923)
            {
                Player.blockRange += 1;
                Player.tileRangeX += 1;
                Player.tileRangeY += 1;
                return;
            }
            if (itemType == 2215)
            {
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                return;
            }
            if (itemType == 2217)
            {
                Player.wallSpeed -= 0.5f;
                return;
            }
            if (itemType == 2214)
            {
                Player.tileSpeed -= 0.5f;
                return;
            }
            if (itemType == 3061)
            {
                Player.autoPaint = true;
                Player.wallSpeed -= 0.5f;
                Player.tileSpeed -= 0.5f;
                Player.blockRange += 3;
                Player.tileRangeX += 3;
                Player.tileRangeY += 3;
                return;
            }
            if (itemType == 4056)
            {
                Player.pickSpeed -= 0.25f;
                return;
            }
            if (itemType == 2373)
            {
                Player.accFishingLine = true;
                return;
            }
            if (itemType == 2374)
            {
                Player.fishingSkill += 10;
                return;
            }
            if (itemType == 2375)
            {
                Player.accTackleBox = true;
                return;
            }
            if (itemType == 4881)
            {
                Player.accLavaFishing = true;
                return;
            }
            if (itemType == 3721)
            {
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
                return;
            }
            if (itemType == 5064)
            {
                Player.accLavaFishing = true;
                Player.accFishingLine = true;
                Player.fishingSkill += 10;
                Player.accTackleBox = true;
                return;
            }
            if (itemType == 5010)
            {
                Player.treasureMagnet = true;
                return;
            }
            if (itemType == 3090)
            {
                Player.npcTypeNoAggro[1] = true;
                Player.npcTypeNoAggro[16] = true;
                Player.npcTypeNoAggro[59] = true;
                Player.npcTypeNoAggro[71] = true;
                Player.npcTypeNoAggro[81] = true;
                Player.npcTypeNoAggro[138] = true;
                Player.npcTypeNoAggro[121] = true;
                Player.npcTypeNoAggro[122] = true;
                Player.npcTypeNoAggro[141] = true;
                Player.npcTypeNoAggro[147] = true;
                Player.npcTypeNoAggro[183] = true;
                Player.npcTypeNoAggro[184] = true;
                Player.npcTypeNoAggro[204] = true;
                Player.npcTypeNoAggro[225] = true;
                Player.npcTypeNoAggro[244] = true;
                Player.npcTypeNoAggro[302] = true;
                Player.npcTypeNoAggro[333] = true;
                Player.npcTypeNoAggro[335] = true;
                Player.npcTypeNoAggro[334] = true;
                Player.npcTypeNoAggro[336] = true;
                Player.npcTypeNoAggro[537] = true;
                return;
            }
            if (itemType == 4409)
            {
                Player.CanSeeInvisibleBlocks = true;
                return;
            }
            if (itemType == ModContent.ItemType<HeadCounter>())
            {
                headCounter = true;
                return;
            }
        }

        public bool magnetActive;

        public Dictionary<int, EndlessBuffSource> EndlessBuffSources = new();

        public List<ValueTuple<Item, string>> ItemsToCountForEndlessBuffs = new();

        public int InventoryItemsStart;

        public int PiggyBankItemsStart;

        public int SafeItemsStart;

        public int DefendersForgeItemsStart;

        public bool enemyEraser;

        public bool enemyAggressor;

        public bool headCounter;

        public int respawnFullHPTimer;

        public int selectedBiome = 0;
    }
}
