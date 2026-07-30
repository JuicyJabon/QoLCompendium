using Terraria.GameContent.Events;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core
{
    public class QoLCSystem : ModSystem
    {
        public static bool setNextNightLantern = false;
        public static bool isLanternNight = false;

        public override void PostUpdateWorld()
        {
            if (setNextNightLantern)
                LanternNight.NextNightIsLanternNight = true;

            if (LanternNight.LanternsUp)
                isLanternNight = true;

            if (isLanternNight && Main.dayTime)
                setNextNightLantern = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag.Add("QoLCLanternNight", setNextNightLantern);
        }

        public override void LoadWorldData(TagCompound tag)
        {
            setNextNightLantern = tag.GetBool("QoLCLanternNight");
        }

        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(setNextNightLantern);
        }

        public override void NetReceive(BinaryReader reader)
        {
            setNextNightLantern = reader.ReadBoolean();
        }

        public override void OnWorldLoad() => ResetFlags();

        public override void OnWorldUnload() => ResetFlags();

        public void ResetFlags()
        {
            setNextNightLantern = false;
            isLanternNight = false;
        }
    }
}
