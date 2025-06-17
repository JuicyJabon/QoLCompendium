using QoLCompendium.Core.PermanentBuffSystems.Effects.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Catalyst
{
    public class AstracolaEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.catalystLoaded)
                return;

            if (!PermanentBuffPlayer.PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.Astracola])
            {
                new AstraJellyEffect().ApplyEffect(player);
                new MagicPowerEffect().ApplyEffect(player);
                new ManaRegenerationEffect().ApplyEffect(player);
            }
        }
    }
}
