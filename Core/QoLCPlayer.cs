using QoLCompendium.Content.Items.Accessories.Fishing;
using QoLCompendium.Content.Items.Dedicated;
using QoLCompendium.Content.Items.Tools.Fishing;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Core.UI;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core
{
    public class QoLCPlayer : ModPlayer
    {
        public static QoLCPlayer Get(Player player) => player.GetModPlayer<QoLCPlayer>();

        //Spawn Manipulators
        public bool[] selectedSpawnRateManipulators = new bool[5];

        //Biomes
        public bool[] selectedBiomes = new bool[9];

        //Time Manipulators
        public bool[] selectedTimeManipulators = new bool[6];

        public int spawnRate;
        public int spawnRateUpdateTimer;
        static FieldInfo spawnRateFieldInfo;
        public int bossToSpawn = -1;
        public bool bossSpawn = false;
        public int eventToSpawn = -1;
        public bool eventSpawn = false;

        //Items
        public bool warpMirror = false;
        public bool HasGoldenLockpick = false;
        public bool duplicationBobber = false;
        public List<int> activeItems = [];
        public List<int> activeBuffItems = [];
        public List<int> activeBannerItems = [];
        public List<int> activeBuffs = [];

        //dedicated
        public bool glassCannon = false;

        //shops
        public bool[] ItemHasBeenOwned;

        public override void Load()
        {
            On_ItemSlot.RightClick_ItemArray_int_int += ItemSlot_RightClick;
        }

        public override void Unload()
        {
            On_ItemSlot.RightClick_ItemArray_int_int -= ItemSlot_RightClick;
        }

        public override void Initialize()
        {
            ItemHasBeenOwned = ItemID.Sets.Factory.CreateBoolSet(false);
        }

        public override void ResetEffects() { Reset(); }

        public override void UpdateDead() { Reset(); }

        public override void SaveData(TagCompound tag)
        {
            //biomes
            tag.Add("QoLCSelectedBiomes", selectedBiomes);

            //spawns
            tag.Add("QoLCSelectedSpawnRateManipulators", selectedSpawnRateManipulators);

            //time
            tag.Add("QoLCSelectedTimeManipulators", selectedTimeManipulators);

            //bosses
            tag.Add("QoLCBossToSpawn", bossToSpawn);
            tag.Add("QoLCBossSpawn", bossSpawn);
            tag.Add("QoLCEventToSpawn", eventToSpawn);
            tag.Add("QoLCEventSpawn", eventSpawn);

            List<string> ownedItemsData = [];
            for (int i = 0; i < ItemHasBeenOwned.Length; i++)
            {
                if (ItemHasBeenOwned[i])
                {
                    if (i >= ItemID.Count) // modded item, add name instead
                    {
                        if (ItemLoader.GetItem(i) is ModItem modItem && modItem != null)
                            ownedItemsData.Add($"{modItem.FullName}");
                    }
                    else // vanilla item
                    {
                        ownedItemsData.Add($"{i}");
                    }
                }
            }
            tag.Add("QoLCOwnedItems", ownedItemsData);
        }

        public override void LoadData(TagCompound tag)
        {
            //biomes
            selectedBiomes = tag.Get<bool[]>("QoLCSelectedBiomes");
            if (selectedBiomes.Length < Enum.GetValues(typeof(UIEnums.BiomeTypes)).Length)
                Array.Resize(ref selectedBiomes, Enum.GetValues(typeof(UIEnums.BiomeTypes)).Length);

            //spawns
            selectedSpawnRateManipulators = tag.Get<bool[]>("QoLCSelectedSpawnRateManipulators");
            if (selectedSpawnRateManipulators.Length < Enum.GetValues(typeof(UIEnums.SpawnRateManipulators)).Length)
                Array.Resize(ref selectedSpawnRateManipulators, Enum.GetValues(typeof(UIEnums.SpawnRateManipulators)).Length);

            //time
            selectedTimeManipulators = tag.Get<bool[]>("QoLCSelectedTimeManipulators");
            if (selectedTimeManipulators.Length < Enum.GetValues(typeof(UIEnums.TimeManipulators)).Length)
                Array.Resize(ref selectedTimeManipulators, Enum.GetValues(typeof(UIEnums.TimeManipulators)).Length);

            //bosses
            bossToSpawn = tag.GetInt("QoLCBossToSpawn");
            bossSpawn = tag.GetBool("QoLCBossSpawn");
            eventToSpawn = tag.GetInt("QoLCEventToSpawn");
            eventSpawn = tag.GetBool("QoLCEventSpawn");

            ItemHasBeenOwned = ItemID.Sets.Factory.CreateBoolSet(false);
            var ownedItemsData = tag.GetList<string>("QoLCOwnedItems");
            foreach (var entry in ownedItemsData)
            {
                if (int.TryParse(entry, out int type) && type < ItemID.Count)
                {
                    ItemHasBeenOwned[type] = true;
                }
                else
                {
                    if (ModContent.TryFind(entry, out ModItem item))
                        ItemHasBeenOwned[item.Type] = true;
                }
            }
        }

        public override void PreUpdate()
        {
            #region Info Displays
            if (spawnRateUpdateTimer > 0)
                spawnRateUpdateTimer--;
            #endregion
        }

        public override void PostUpdateBuffs()
        {
            if (THEButton.used)
            {
                Player.forcedGravity = 1;
                Player.gravDir = -1f;
            }
        }

        public override void PostUpdateMiscEffects()
        {
            #region Spawn Rate Info
            if (spawnRateUpdateTimer <= 0)
            {
                spawnRateUpdateTimer = 60;
                spawnRateFieldInfo = typeof(NPC).GetField("spawnRate", BindingFlags.Static | BindingFlags.NonPublic);
                spawnRate = (int)spawnRateFieldInfo.GetValue(null);
            }
            #endregion

            #region Entity Manipulator
            if (selectedSpawnRateManipulators.Any(c => c == true))
                activeItems.Add(ModContent.ItemType<EntityManipulator>());

            if (selectedSpawnRateManipulators[(int)UIEnums.SpawnRateManipulators.NoEvents])
                NPCsUtils.DisableEvents();
            #endregion

            #region Destination Globe
            if (selectedBiomes.Any(c => c == true))
                activeItems.Add(ModContent.ItemType<DestinationGlobe>());

            if (selectedBiomes[(int)UIEnums.BiomeTypes.Purity])
                Player.ZonePurity = true;
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Desert])
            {
                Player.ZoneDesert = true;
                if (Player.ZoneDirtLayerHeight || Player.ZoneRockLayerHeight)
                    Player.ZoneUndergroundDesert = true;
            }
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Snow])
                Player.ZoneSnow = true;
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Jungle])
                Player.ZoneJungle = true;
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Glowshroom])
                Player.ZoneGlowshroom = true;
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Corruption])
                Player.ZoneCorrupt = true;
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Crimson])
                Player.ZoneCrimson = true;
            if (selectedBiomes[(int)UIEnums.BiomeTypes.Hallow] && Main.hardMode)
                Player.ZoneHallow = true;
            #endregion

            #region Time Wrinkler
            if (selectedTimeManipulators.Any(c => c == true))
                activeItems.Add(ModContent.ItemType<TimeWrinkler>());
            #endregion

            #region Mirrors
            if (warpMirror && Player.whoAmI == Main.myPlayer  && Main.mapFullscreen && Main.mouseLeft && Main.mouseLeftRelease)
            {
                PlayerInput.SetZoom_Unscaled();
                float scale = 16f / Main.mapFullscreenScale;
                float minX = Main.mapFullscreenPos.X * 16f - 10f;
                float minY = Main.mapFullscreenPos.Y * 16f - 21f;
                float mouseX = Main.mouseX - Main.screenWidth / 2;
                float mouseY = Main.mouseY - Main.screenHeight / 2;
                float cursorOnMapX = minX + mouseX * scale;
                float cursorOnMapY = minY + mouseY * scale;

                //CLICKED NEAR TOWN NPC
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC teleportNPC = Main.npc[i];
                    if (teleportNPC.active && teleportNPC.townNPC)
                    {
                        float minClickX = teleportNPC.position.X - 14f * scale;
                        float minClickY = teleportNPC.position.Y - 14f * scale;
                        float maxClickX = teleportNPC.position.X + 14f * scale;
                        float maxClickY = teleportNPC.position.Y + 14f * scale;
                        if (cursorOnMapX >= minClickX && cursorOnMapX <= maxClickX && cursorOnMapY >= minClickY && cursorOnMapY <= maxClickY)
                        {
                            Main.mouseLeftRelease = false;
                            Main.mapFullscreen = false;
                            Player.Teleport(teleportNPC.position + new Vector2(0f, -6f));
                            PlayerInput.SetZoom_Unscaled();
                            return;
                        }
                    }
                }
            }
            #endregion
        }

        public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
        {
            if (!QoLCompendium.itemConfig.FishingAccessories)
                return;

            if (Player.anglerQuestsFinished == 1)
            {
                Item item = new(ModContent.ItemType<AnglerRadar>())
                {
                    stack = 1
                };
                rewardItems.Add(item);
            }
            else
            {
                if (Player.anglerQuestsFinished >= 1 && Main.rand.NextBool(10))
                {
                    Item item = new(ModContent.ItemType<AnglerRadar>())
                    {
                        stack = 1
                    };
                    rewardItems.Add(item);
                }
            }
        }

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            bool inWater = !attempt.inLava && !attempt.inHoney;
            if (inWater && Main.bloodMoon && attempt.crate && QoLCompendium.itemConfig.BottomlessBuckets)
            {
                if (!attempt.uncommon && !attempt.rare && (attempt.veryrare || attempt.legendary) && Main.rand.NextBool())
                {
                    itemDrop = ModContent.ItemType<BottomlessChumBucket>();
                    return;
                }
            }
        }

        public override void ModifyCaughtFish(Item fish)
        {
            if (duplicationBobber && Main.rand.NextBool() && fish.createTile == -1 && !fish.accessory && fish.damage == -1 && fish.mountType == -1 && fish.maxStack > 1 && fish.rare != ItemRarityID.Gray)
                fish.stack += 1;
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            if (glassCannon)
            {
                modifiers.DisableSound();
                SoundStyle sfx = new($"{nameof(QoLCompendium)}/Assets/Sounds/Griefing");
                SoundEngine.PlaySound(sfx, Player.Center);
            }
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (QoLCompendium.itemConfig.StarterBag)
                return [new Item(ModContent.ItemType<StarterBag>())];
            else
                return [];
        }

        private static void ItemSlot_RightClick(On_ItemSlot.orig_RightClick_ItemArray_int_int orig, Item[] inv, int context, int slot)
        {
            if (Main.mouseRight && Main.mouseRightRelease)
            {
                var player = Main.LocalPlayer;
                player.TryGetModPlayer(out QoLCPlayer qPlayer);
                if (Main.mouseItem.ModItem is Common.IRightClickOverrideWhenHeld rightClickOverride && rightClickOverride.RightClickOverrideWhileHeld(ref Main.mouseItem, inv, context, slot, player, qPlayer))
                {
                    return;
                }

                if (context == ItemSlot.Context.InventoryItem)
                {
                    if (GoldenLockpick.UseKey(inv, slot, player, qPlayer))
                    {
                        return;
                    }
                }
            }
            orig(inv, context, slot);
        }

        public void Reset()
        {
            warpMirror = false;
            HasGoldenLockpick = false;
            duplicationBobber = false;
            glassCannon = false;
            activeItems.Clear();
            activeBuffItems.Clear();
            activeBannerItems.Clear();
            activeBuffs.Clear();
            Common.Reset();
        }
    }
}
