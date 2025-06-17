using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.Thorium;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Stations.Thorium;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium
{
    public class ThoriumStationsEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            new AltarEffect().ApplyEffect(player);
            new ConductorsStandEffect().ApplyEffect(player);
            new MistletoeEffect().ApplyEffect(player);
            new NinjaRackEffect().ApplyEffect(player);
        }
    }
}
