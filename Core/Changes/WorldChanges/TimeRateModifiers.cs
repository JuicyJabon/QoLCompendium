using QoLCompendium.Core.UI;
using Terraria.GameContent.Creative;

namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class TimeRateModifiers : ModSystem
    {
        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            if (Main.LocalPlayer.TryGetModPlayer(out QoLCPlayer mPlayer) && mPlayer.selectedTimeManipulators[(int)UIEnums.TimeManipulators.TimePaused] && Main.LocalPlayer.active && !Main.dedServ && !Main.gameMenu)
            {
                if (CreativePowerManager.Instance.GetPower<CreativePowers.FreezeTime>().Enabled)
                    return;

                timeRate = 0.0;
            }
        }

        public override void PreUpdateTime()
        {
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysDay])
            {
                if (!Main.dayTime)
                {
                    Main.dayTime = true;
                    Main.time = 0.0;
                }
            }

            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysNight])
            {
                if (Main.dayTime)
                {
                    Main.dayTime = false;
                    Main.time = 0.0;
                }
            }

            if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysBloodMoon])
            {
                Main.bloodMoon = true;
            }

            if (Main.dayTime && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().selectedTimeManipulators[(int)UIEnums.TimeManipulators.AlwaysEclipse])
            {
                Main.eclipse = true;
            }
        }
    }
}
