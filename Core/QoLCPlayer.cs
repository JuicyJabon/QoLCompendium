using Humanizer;
using QoLCompendium.Content.Items.Accessories.Fishing;
using QoLCompendium.Content.Items.Tools.Fishing;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Core.UI.Panels;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core
{
    public class QoLCPlayer : ModPlayer
    {
        //Pedestals
        public bool sunPedestal = false;
        public bool moonPedestal = false;
        public bool bloodMoonPedestal = false;
        public bool eclipsePedestal = false;
        public bool pausePedestal = false;

        //Spawns
        public bool increasedSpawns = false;
        public bool decreasedSpawns = false;
        public bool noSpawns = false;
        public int selectedSpawnModifier = 0;
        public int spawnRate;
        public int spawnRateUpdateTimer;
        static FieldInfo spawnRateFieldInfo;
        public int bossToSpawn = 0;
        public bool bossSpawn = false;
        public int eventToSpawn = 0;
        public bool eventSpawn = false;

        //Items
        public int flaskEffectMode = 0;
        public int thoriumCoatingMode = 0;
        public bool sillySlapper = false;
        public bool warpMirror = false;
        public bool HasGoldenLockpick = false;
        public List<int> activeItems = [];
        public List<int> activeBuffItems = [];
        public List<int> activeBuffs = [];

        //Biomes
        public int selectedBiome = 0;

        public override void Load()
        {
            On_ItemSlot.RightClick_ItemArray_int_int += ItemSlot_RightClick;
        }

        public override void Unload()
        {
            On_ItemSlot.RightClick_ItemArray_int_int -= ItemSlot_RightClick;
        }

        public override void ResetEffects() { Reset(); }

        public override void UpdateDead() { Reset(); }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("flaskEffectMode", flaskEffectMode);
            tag.Add("thoriumCoatingMode", thoriumCoatingMode);
            tag.Add("SelectedBiome", selectedBiome);
            tag.Add("SelectedSpawnModifier", selectedSpawnModifier);
            tag.Add("bossToSpawn", bossToSpawn);
            tag.Add("bossSpawn", bossSpawn);
            tag.Add("eventToSpawn", eventToSpawn);
            tag.Add("eventSpawn", eventSpawn);
        }

        public override void LoadData(TagCompound tag)
        {
            flaskEffectMode = tag.GetInt("flaskEffectMode");
            thoriumCoatingMode = tag.GetInt("thoriumCoatingMode");
            selectedBiome = tag.GetInt("SelectedBiome");
            selectedSpawnModifier = tag.GetInt("SelectedSpawnModifier");
            bossToSpawn = tag.GetInt("bossToSpawn");
            bossSpawn = tag.GetBool("bossSpawn");
            eventToSpawn = tag.GetInt("eventToSpawn");
            eventSpawn = tag.GetBool("eventSpawn");
        }

        public override void PreUpdate()
        {
            if (spawnRateUpdateTimer > 0)
            {
                spawnRateUpdateTimer--;
            }
        }

        public override void PostUpdate()
        {
            if (ModConditions.reforgedLoaded && ModAccessorySlot.Player.equippedWings.social != true)
            {
                ModConditions.reforgedMod.Call("PostUpdateModPlayer", Main.LocalPlayer.whoAmI, ModAccessorySlot.Player.equippedWings);
            }
        }

        public override void PostUpdateMiscEffects()
        {
            if (spawnRateUpdateTimer <= 0)
            {
                spawnRateUpdateTimer = 60;

                spawnRateFieldInfo = typeof(NPC).GetField("spawnRate", BindingFlags.Static | BindingFlags.NonPublic);

                spawnRate = (int)spawnRateFieldInfo.GetValue(null);
            }

            if (Player.whoAmI != Main.myPlayer || !Main.mapFullscreen || !Main.mouseLeft || !Main.mouseLeftRelease || !warpMirror)
                return;
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

        public override void AnglerQuestReward(float rareMultiplier, List<Item> rewardItems)
        {
            if (!QoLCompendium.itemConfig.FishingAccessories)
                return;

            if (Player.anglerQuestsFinished == 1)
            {
                Item item = new(ModContent.ItemType<AnglerRadar>());
                item.stack = 1;
                rewardItems.Add(item);
            }
            else
            {
                if (Player.anglerQuestsFinished >= 1 && Main.rand.NextBool(10))
                {
                    Item item = new(ModContent.ItemType<AnglerRadar>());
                    item.stack = 1;
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

        public override void OnHurt(Player.HurtInfo info)
        {
            if (sillySlapper)
                Player.KillMe(PlayerDeathReason.ByCustomReason(NetworkText.FromKey(Language.GetTextValue("Mods.QoLCompendium.Messages.SillySlapper").FormatWith(Player.name))), int.MaxValue, 0);
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
            sunPedestal = false;
            moonPedestal = false;
            bloodMoonPedestal = false;
            eclipsePedestal = false;
            pausePedestal = false;
            increasedSpawns = false;
            decreasedSpawns = false;
            noSpawns = false;
            sillySlapper = false;
            warpMirror = false;
            HasGoldenLockpick = false;
            activeItems.Clear();
            activeBuffItems.Clear();
            activeBuffs.Clear();
            Common.Reset();

            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.player[Main.myPlayer].talkNPC == -1)
                {
                    if (ModLoader.TryGetMod("terraguardians", out Mod terraguardians))
                    {
                        if (!(bool)terraguardians.Call("IsPC", Main.LocalPlayer))
                        {
                            return;
                        }
                    }
                    BlackMarketDealerNPCUI.visible = false;
                    EtherealCollectorNPCUI.visible = false;
                }
            }
        }
    }
}
