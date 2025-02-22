﻿using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.Chat;
using Terraria.GameContent.Events;

namespace QoLCompendium.Core.Changes
{
    public class AlwaysEvents : ModSystem
    {
        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            if (Main.LocalPlayer.TryGetModPlayer(out QoLCPlayer mPlayer) && mPlayer.pausePedestal && Main.LocalPlayer.active && !Main.dedServ && !Main.gameMenu)
            {
                timeRate = 0.0;
            }
        }

        public override void PreUpdateTime()
        {
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().sunPedestal == true)
            {
                if (!Main.dayTime)
                {
                    Main.dayTime = true;
                    Main.time = 0.0;
                }
            }

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().moonPedestal == true)
            {
                if (Main.dayTime)
                {
                    Main.dayTime = false;
                    Main.time = 0.0;
                }
            }

            if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().bloodMoonPedestal == true)
            {
                Main.bloodMoon = true;
            }

            if (Main.dayTime && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().eclipsePedestal == true)
            {
                Main.eclipse = true;
            }
        }

        public override void PostUpdateWorld()
        {
            if (QoLCompendium.mainConfig.HalloweenActive)
                Main.halloween = true;
            if (QoLCompendium.mainConfig.ChristmasActive)
                Main.xMas = true;
        }
    }

    public class DisableEvilSpread : ModSystem
    {
        public override void Load()
        {
            IL_WorldGen.UpdateWorld_Inner += new ILContext.Manipulator(WorldGen_UpdateWorld_Inner);
        }

        public override void Unload()
        {
            IL_WorldGen.UpdateWorld_Inner -= WorldGen_UpdateWorld_Inner;
        }

        private void WorldGen_UpdateWorld_Inner(ILContext il)
        {
            ILCursor ilcursor = new(il);
            ILCursor ilcursor2 = ilcursor;
            MoveType moveType = 0;
            Func<Instruction, bool>[] array = new Func<Instruction, bool>[2];
            array[0] = (Instruction i) => ILPatternMatchingExt.MatchLdcI4(i, 3);
            array[1] = (Instruction i) => ILPatternMatchingExt.MatchStloc(i, 1);
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
            CorruptionSpreadDisabled = QoLCompendium.mainConfig.DisableEvilBiomeSpread;
        }

#pragma warning disable CA2211
        public static bool CorruptionSpreadDisabled;
#pragma warning restore CA2211
    }

    public class DisableMeteors : ModSystem
    {
        public override void Load() => On_WorldGen.dropMeteor += StopMeteor;

        public override void Unload() => On_WorldGen.dropMeteor -= StopMeteor;

        private void StopMeteor(On_WorldGen.orig_dropMeteor orig)
        {
            if (!QoLCompendium.mainConfig.NoMeteorSpawns)
            {
                orig();
                return;
            }

            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.QoLCompendium.Messages.MeteorStopped"), Color.White);

            int activePlayerCount = Main.player.Where(player => player.active).ToArray().Length;

            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                if (!player.active) continue;

                int amount = Main.rand.Next(400, 500) / activePlayerCount;
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemID.Meteorite, amount);

                ChatHelper.SendChatMessageToClient(NetworkText.FromKey("Mods.QoLCompendium.Messages.MeteoriteGiven", amount), Color.White, i);
            }
        }
    }

    public class DisableCredits : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("VanillaQoL", out Mod VanillaQoL);
            return VanillaQoL == null;
        }

        public override void Load()
        {
            if (QoLCompendium.mainConfig.DisableCredits)
                IL_NPC.OnGameEventClearedForTheFirstTime += NoCredits;
        }

        public override void Unload()
        {
            IL_NPC.OnGameEventClearedForTheFirstTime -= NoCredits;
        }

        public void NoCredits(ILContext il)
        {
            var c = new ILCursor(il);
            c.GotoNext(MoveType.Before, i => i.MatchCall<CreditsRollEvent>("TryStartingCreditsRoll"));
            c.Remove();
        }
    }

    public class MapTeleporting : ModSystem
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
            if (QoLCompendium.mainConfig.MapTeleporting)
                TryToTeleportPlayerOnMap();
        }
    }

    public class StarFallSystem : ModSystem
    {
        public override void PostUpdateWorld()
        {
            Star.starfallBoost = QoLCompendium.mainConfig.MoreFallenStars;
        }
    }

    public class MoreCombatTexts : ModSystem
    {
        public override void Load()
        {
            int maximumTexts = QoLCompendium.mainClientConfig.CombatTextLimit;
            Array.Resize(ref Main.combatText, maximumTexts);
            for (int i = 0; i < maximumTexts; i++)
            {
                Main.combatText[i] = new CombatText();
            }
            On_CombatText.UpdateCombatText += delegate
            {
                for (int k = 0; k < maximumTexts; k++)
                {
                    if (Main.combatText[k].active)
                    {
                        Main.combatText[k].Update();
                    }
                }
            };
            On_CombatText.clearAll += delegate
            {
                for (int j = 0; j < maximumTexts; j++)
                {
                    Main.combatText[j].active = false;
                }
            };
            IL_CombatText.NewText_Rectangle_Color_string_bool_bool += delegate (ILContext il)
            {
                ILCursor val2 = new(il);
                while (val2.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
                {
                (Instruction x) => ILPatternMatchingExt.Match<sbyte>(x, OpCodes.Ldc_I4_S, 100)
                }))
                {
                    val2.EmitDelegate((int _) => maximumTexts);
                }
            };
            IL_Main.DoDraw += delegate (ILContext il)
            {
                ILCursor val = new ILCursor(il);
                while (val.TryGotoNext((MoveType)2, new Func<Instruction, bool>[1]
                {
                (Instruction x) => ILPatternMatchingExt.Match<sbyte>(x, OpCodes.Ldc_I4_S, 100)
                }))
                {
                    val.EmitDelegate((int _) => maximumTexts);
                }
            };
        }
    }
}
