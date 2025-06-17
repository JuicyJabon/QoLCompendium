using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Calamity
{
    public class CalamityAbyssEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            new AnechoicCoatingEffect().ApplyEffect(player);
            new OmniscienceEffect().ApplyEffect(player);
            new SulphurskinEffect().ApplyEffect(player);
        }
    }
}
