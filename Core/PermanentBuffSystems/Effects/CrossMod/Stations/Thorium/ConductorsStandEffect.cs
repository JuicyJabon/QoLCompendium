namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Stations.Thorium
{
    public class ConductorsStandEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "ConductorsStandBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.ConductorsStand])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "ConductorsStandBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "ConductorsStandBuff")] = true;
            }
        }
    }
}
