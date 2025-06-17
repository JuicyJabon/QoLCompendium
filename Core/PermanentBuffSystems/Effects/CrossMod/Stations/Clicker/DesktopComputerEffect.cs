namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Stations.Clicker
{
    public class DesktopComputerEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.clickerClassLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.clickerClassMod, "DesktopComputerBuff")])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.clickerClassMod, "DesktopComputerBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.clickerClassMod, "DesktopComputerBuff")] = true;
            }
        }
    }
}
