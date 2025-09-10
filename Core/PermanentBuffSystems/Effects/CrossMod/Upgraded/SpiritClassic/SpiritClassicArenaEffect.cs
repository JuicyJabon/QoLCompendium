using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.SpiritClassic;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.SpiritClassic
{
    public class SpiritClassicArenaEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritClassicLoaded)
                return;

            new CoiledEnergizerEffect().ApplyEffect(player);
            new KoiTotemEffect().ApplyEffect(player);
            new SunPotEffect().ApplyEffect(player);
            new TheCouchEffect().ApplyEffect(player);
        }
    }
}
