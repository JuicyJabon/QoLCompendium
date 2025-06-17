namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Arena
{
    public class GardenGnomeEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.GardenGnome])
                player.Player.luck += 0.2f;
        }
    }
}
