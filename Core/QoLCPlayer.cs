using QoLCompendium.Content.Items.Dedicated;
using QoLCompendium.Content.Items.Tools.Usables;
using QoLCompendium.Core.UI;
using System.Reflection;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core
{
    public class QoLCPlayer : ModPlayer
    {
        public bool sunPedestal = false;

        public bool moonPedestal = false;

        public bool bloodMoonPedestal = false;

        public bool eclipsePedestal = false;

        public bool enemyAggressor = false;

        public bool enemyCalmer = false;

        public bool enemyEraser = false;

        public bool sillySlapper = false;

        public int selectedBiome = 0;

        public int selectedSpawnModifier = 5;

        public int spawnRate;
        public int spawnRateUpdateTimer;
        static FieldInfo spawnRateFieldInfo; 

        public int bossToSpawn = 0;
        public bool bossSpawn = false;
        public int eventToSpawn = 0;
        public bool eventSpawn = false;

        public override void ResetEffects()
        {
            Reset();
        }

        public override void UpdateDead()
        {
            Reset();
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("SelectedBiome", selectedBiome);
            tag.Add("SelectedSpawnModifier", selectedSpawnModifier);
        }

        public override void LoadData(TagCompound tag)
        {
            selectedBiome = tag.GetInt("SelectedBiome");
            selectedSpawnModifier = tag.GetInt("SelectedSpawnModifier");
        }

        public override void PreUpdate()
        {
            if (spawnRateUpdateTimer > 0)
            {
                spawnRateUpdateTimer--;
            }
        }

        public override void PreUpdateBuffs()
        {
            if (Player.HeldItem.type == ModContent.ItemType<SillySlapper>())
            {
                Player.GetDamage(DamageClass.Generic) *= 2;
                sillySlapper = true;
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
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (sillySlapper)
            {
                Player.KillMe(PlayerDeathReason.ByCustomReason(Player.name + " was slapped too silly"), 666666, 0);
            }
        }

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (QoLCompendium.itemConfig.StarterBag)
            {
                return new[] {
                new Item(ModContent.ItemType<StarterBag>())
                };
            }
            else
            {
                return Enumerable.Empty<Item>();
            }
        }

        public void Reset()
        {
            sunPedestal = false;
            moonPedestal = false;
            bloodMoonPedestal = false;
            eclipsePedestal = false;
            enemyAggressor = false;
            enemyCalmer = false;
            enemyEraser = false;
            sillySlapper = false;

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
                    BMNPCUI.visible = false;
                    ECNPCUI.visible = false;
                }
            }
        }
    }
}
