using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using tModPorter;

namespace QoLCompendium.Tweaks
{
    public class InvincibleTownies : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void SetDefaults(NPC npc)
        {
            bool dontTakeDamageFromHostiles = npc.dontTakeDamageFromHostiles;
            if (npc.type == NPCID.DD2EterniaCrystal && ModContent.GetInstance<QoLCConfig>().FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = false;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
            if (npc.friendly && ModContent.GetInstance<QoLCConfig>().FriendliesDontDie)
            {
                npc.dontTakeDamageFromHostiles = true;
                return;
            }
            npc.dontTakeDamageFromHostiles = dontTakeDamageFromHostiles;
        }
    }

    public class TownieSpawns : ModSystem
    {
        private static Action VanillaSpawnTownNPCs;

        public override void OnModLoad()
        {
            MethodInfo method = typeof(Main).GetMethod("UpdateTime_SpawnTownNPCs", BindingFlags.Static | BindingFlags.NonPublic);
            VanillaSpawnTownNPCs = (Delegate.CreateDelegate(typeof(Action), method) as Action);


            IL_Main.UpdateTime += PermitNighttimeTownNPCSpawning;
            On_Main.UpdateTime_SpawnTownNPCs += AlterTownNPCSpawnRate;
        }

        public override void OnModUnload()
        {
            VanillaSpawnTownNPCs = null;
        }

        public override void PreUpdateWorld()
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

        private static void PermitNighttimeTownNPCSpawning(ILContext il)
        {
            ILCursor ilcursor = new(il);
            ilcursor.EmitDelegate(delegate ()
            {
                if (Main.dayTime)
                {
                    VanillaSpawnTownNPCs();
                }
            });
            ILCursor ilcursor2 = ilcursor;
            MoveType moveType = 0;
            Func<Instruction, bool>[] array = new Func<Instruction, bool>[1];
            array[0] = ((Instruction i) => ILPatternMatchingExt.MatchCallOrCallvirt<Main>(i, "UpdateTime_SpawnTownNPCs"));
            if (!ilcursor2.TryGotoNext(moveType, array))
            {
                return;
            }
            ilcursor.Emit(OpCodes.Ret);
        }

        private static void AlterTownNPCSpawnRate(On_Main.orig_UpdateTime_SpawnTownNPCs orig)
        {
            double desiredWorldTilesUpdateRate = Main.desiredWorldTilesUpdateRate;
            Main.desiredWorldTilesUpdateRate *= ModContent.GetInstance<QoLCConfig>().TownieSpawnRate;
            orig.Invoke();
            Main.desiredWorldTilesUpdateRate = desiredWorldTilesUpdateRate;
        }
    }
}
