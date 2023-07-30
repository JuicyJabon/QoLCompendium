using Terraria;
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
}
