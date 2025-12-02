using QoLCompendium.Content.NPCs;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class ModifyShopPrices : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            Player player = Main.LocalPlayer;
            if (npc.type == ModContent.NPCType<BMDealerNPC>() && player.active && player == Main.LocalPlayer)
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

                        item.shopCustomPrice *= QoLCompendium.shopConfig.BagPriceMultiplier;

                        if (!QoLCompendium.shopConfig.BossScaling) continue;

                        int countBossesDefeated = Common.GetBoolCount(Common.DownedVanillaBosses) + Common.GetBoolCount(ModConditions.DownedBoss);

                        for (int i = 0; i < countBossesDefeated; i++)
                            item.shopCustomPrice += (int)Common.GoldValue * 10;
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

            if (npc.type == ModContent.NPCType<EtherealCollectorNPC>() && player.active && player == Main.LocalPlayer)
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

                        item.shopCustomPrice *= QoLCompendium.shopConfig.BagPriceMultiplier;

                        if (!QoLCompendium.shopConfig.BossScaling) continue;

                        int countBossesDefeated = Common.GetBoolCount(Common.DownedVanillaBosses) + Common.GetBoolCount(ModConditions.DownedBoss);

                        for (int i = 0; i < countBossesDefeated; i++)
                            item.shopCustomPrice += (int)Common.GoldValue * 10;
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

            if ((npc.type == ModContent.NPCType<BMDealerNPC>() || npc.type == ModContent.NPCType<EtherealCollectorNPC>()) && player.active && player == Main.LocalPlayer)
            {
                foreach (Item item in items)
                {
                    if (item == null || item.type == ItemID.None) continue;
                    item.shopCustomPrice *= QoLCompendium.shopConfig.GlobalPriceMultiplier;
                }
            }
        }
    }
}
