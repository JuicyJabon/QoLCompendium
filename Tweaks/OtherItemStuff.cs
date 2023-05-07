using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class OtherItemStuff : GlobalItem
    {
        public override void Load()
        {
            if (ModContent.GetInstance<QoLCConfig>().FastTools)
            {
                Terraria.IL_Player.ItemCheck_UseMiningTools_ActuallyUseMiningTool += ActuallyUseMiningTool;
                Terraria.IL_Player.ItemCheck_UseMiningTools_TryHittingWall += TryHittingWall;
            }
        }

        public override void SetDefaults(Item item)
        {
            if (ModContent.GetInstance<QoLCConfig>().IncreasedStackSize && item.maxStack > 10 && item.maxStack != 100)
            {
                item.maxStack = 9999;
                if (item.type == ItemID.PlatinumCoin && item.maxStack > 2000)
                {
                    item.maxStack = 2000;
                }
            }

            if (ModContent.GetInstance<QoLCConfig>().NoDevs && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (ModContent.GetInstance<QoLCConfig>().FastExtractor)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        private void ActuallyUseMiningTool(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Ldarg_0),
                    i => i.Match(OpCodes.Ldarg_1),
                    i => i.Match(OpCodes.Ldloc_0)))
                return;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Action<Player>>((player) =>
            {
                player.SetItemTime((int)MathHelper.Max(1, MathF.Round(player.itemTime * (1f - 8f))));
            });
        }

        private void TryHittingWall(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(MoveType.After,
                    i => i.Match(OpCodes.Div),
                    i => i.Match(OpCodes.Stfld)))
                return;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Action<Player>>((player) =>
            {
                player.SetItemTime((int)MathHelper.Max(1, MathF.Round(player.itemTime * (1f - 8f))));
            });
        }
    }
}
