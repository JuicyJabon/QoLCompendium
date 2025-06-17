namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class FishingEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Fishing] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Flipper])
            {
                player.Player.fishingSkill += 15;
                player.Player.buffImmune[BuffID.Fishing] = true;
            }
        }
    }
}
