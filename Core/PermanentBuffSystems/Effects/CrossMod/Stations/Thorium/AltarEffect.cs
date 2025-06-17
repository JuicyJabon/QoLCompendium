namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Stations.Thorium
{
    public class AltarEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "AltarBuff")] && !PermanentBuffPlayer.PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.Altar])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "AltarBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "AltarBuff")] = true;
            }
        }
    }
}
