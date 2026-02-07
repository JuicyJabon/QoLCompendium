using SpiritMod;

namespace QoLCompendium.Core.Changes.ModChanges.ModWorldChanges
{
    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class SpiritClassicMysticMoonAlways : ModSystem
    {
        public override void PreUpdateTime()
        {
            if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<QoLCPlayer>().mysticMoonPedestal)
            {
                MyWorld.blueMoon = true;
            }
        }
    }
}
