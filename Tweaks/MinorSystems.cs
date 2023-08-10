using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class AlwaysBloodMoonSystem : ModSystem
    {
        public override void PreUpdateWorld()
        {
            Player p = Main.LocalPlayer;
            if (!Main.dayTime && p.GetModPlayer<QoLCPlayer>().bloodIdol == true)
            {
                Main.bloodMoon = true;
            }
        }
    }

    public class DisableEvilSpread : ModSystem
    {
        public override void Load()
        {
            IL_WorldGen.UpdateWorld_Inner += new ILContext.Manipulator(WorldGen_UpdateWorld_Inner);
        }

        private void WorldGen_UpdateWorld_Inner(ILContext il)
        {
            ILCursor ilcursor = new(il);
            ILCursor ilcursor2 = ilcursor;
            MoveType moveType = 0;
            Func<Instruction, bool>[] array = new Func<Instruction, bool>[2];
            array[0] = ((Instruction i) => ILPatternMatchingExt.MatchLdcI4(i, 3));
            array[1] = ((Instruction i) => ILPatternMatchingExt.MatchStloc(i, 1));
            ilcursor2.GotoNext(moveType, array);
            ilcursor.MoveAfterLabels();
            ilcursor.EmitDelegate(delegate ()
            {
                if (CorruptionSpreadDisabled)
                {
                    WorldGen.AllowedToSpreadInfections = false;
                }
            });
        }

        public override void ClearWorld()
        {
            CorruptionSpreadDisabled = ModContent.GetInstance<QoLCConfig>().DisableEvilSpread;
        }

        public static bool CorruptionSpreadDisabled;
    }

    public class SeasonalActivation : ModSystem
    {
        public override void PostUpdateWorld()
        {
            if (ModContent.GetInstance<QoLCConfig>().Halloween)
            {
                Main.halloween = true;
            }

            if (ModContent.GetInstance<QoLCConfig>().Christmas)
            {
                Main.xMas = true;
            }
        }
    }

    public class TownieSpawns : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (ModContent.GetInstance<QoLCConfig>().TownieSpawn)
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

    public class TowerShieldHealth : ModSystem
    {
        public override void PreUpdateWorld()
        {
            if (NPC.ShieldStrengthTowerVortex > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerVortex = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }

            if (NPC.ShieldStrengthTowerSolar > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerSolar = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }

            if (NPC.ShieldStrengthTowerNebula > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerNebula = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }

            if (NPC.ShieldStrengthTowerStardust > ModContent.GetInstance<QoLCConfig>().TowerShield)
            {
                NPC.ShieldStrengthTowerStardust = ModContent.GetInstance<QoLCConfig>().TowerShield;
            }
        }
    }

    public class MapSystem : ModSystem
    {
        public static void TryToTeleportPlayerOnMap()
        {
            if (Main.mouseRight && Main.keyState.IsKeyUp((Microsoft.Xna.Framework.Input.Keys)162))
            {
                int num = Main.maxTilesX * 16;
                int num2 = Main.maxTilesY * 16;
                Vector2 vector = new(Main.mouseX, Main.mouseY);
                vector.X -= Main.screenWidth / 2;
                vector.Y -= Main.screenHeight / 2;
                Vector2 vector2 = Main.mapFullscreenPos;
                vector /= 16f;
                vector *= 16f / Main.mapFullscreenScale;
                vector2 += vector;
                vector2 *= 16f;
                vector2.Y -= Main.LocalPlayer.height;
                if (vector2.X < 0f)
                {
                    vector2.X = 0f;
                }
                else if (vector2.X + Main.LocalPlayer.width > num)
                {
                    vector2.X = num - Main.LocalPlayer.width;
                }
                if (vector2.Y < 0f)
                {
                    vector2.Y = 0f;
                }
                else if (vector2.Y + Main.LocalPlayer.height > num2)
                {
                    vector2.Y = num2 - Main.LocalPlayer.height;
                }
                if (Main.LocalPlayer.position != vector2)
                {
                    Main.LocalPlayer.Teleport(vector2, 1, 0);
                    Main.LocalPlayer.position = vector2;
                    Main.LocalPlayer.velocity = Vector2.Zero;
                    Main.LocalPlayer.fallStart = (int)(Main.LocalPlayer.position.Y / 16f);
                    NetMessage.SendData(MessageID.TeleportEntity, -1, -1, null, 0, Main.myPlayer, vector2.X, vector2.Y, 1, 0, 0);
                }
            }
        }

        public override void PostDrawFullscreenMap(ref string mouseText)
        {
            if (MapTeleport && ModContent.GetInstance<QoLCConfig>().MapPorting)
            {
                TryToTeleportPlayerOnMap();
            }
        }

        internal static bool MapTeleport = true;
    }
}
