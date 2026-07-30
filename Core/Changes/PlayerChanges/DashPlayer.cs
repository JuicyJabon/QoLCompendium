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
            if (Player.controlLeft && !LeftLastPressed)
            {
                latestXDirPressed = -1;
            }
            if (Player.controlRight && !RightLastPressed)
            {
                latestXDirPressed = 1;
            }
            if (!Player.controlLeft && !Player.releaseLeft)
            {
                latestXDirReleased = -1;
            }
            if (!Player.controlRight && !Player.releaseRight)
            {
                latestXDirReleased = 1;
            }
            LeftLastPressed = Player.controlLeft;
            RightLastPressed = Player.controlRight;
        }
    }
}
