using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Catalyst
{
    public class AstracolaEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.catalystLoaded)
                return;

            if (!player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.Astracola])
            {
                new AstraJellyEffect().ApplyEffect(player);
                new MagicPowerEffect().ApplyEffect(player);
                new ManaRegenerationEffect().ApplyEffect(player);
            }
        }
    }
}
