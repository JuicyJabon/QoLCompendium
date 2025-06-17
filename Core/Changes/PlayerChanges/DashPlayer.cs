using Terraria.GameInput;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class DashPlayer : ModPlayer
    {
        public int latestXDirPressed = 0;
        public int latestXDirReleased = 0;
        public bool LeftLastPressed = false;
        public bool RightLastPressed = false;

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Main.LocalPlayer.controlLeft && !LeftLastPressed)
            {
                latestXDirPressed = -1;
            }
            if (Main.LocalPlayer.controlRight && !RightLastPressed)
            {
                latestXDirPressed = 1;
            }
            if (!Main.LocalPlayer.controlLeft && !Main.LocalPlayer.releaseLeft)
            {
                latestXDirReleased = -1;
            }
            if (!Main.LocalPlayer.controlRight && !Main.LocalPlayer.releaseRight)
            {
                latestXDirReleased = 1;
            }
            LeftLastPressed = Main.LocalPlayer.controlLeft;
            RightLastPressed = Main.LocalPlayer.controlRight;
        }
    }
}
