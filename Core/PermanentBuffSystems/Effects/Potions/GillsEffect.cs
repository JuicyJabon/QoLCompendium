namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class GillsEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Gills] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Gills])
            {
                player.Player.gills = true;
                player.Player.buffImmune[BuffID.Gills] = true;
            }
        }
    }
}
