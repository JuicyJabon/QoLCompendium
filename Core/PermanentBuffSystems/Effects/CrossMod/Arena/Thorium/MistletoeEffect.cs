namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.Thorium
{
    public class MistletoeEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "MistletoeBuff")] && !PermanentBuffPlayer.PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.Mistletoe])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "MistletoeBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "MistletoeBuff")] = true;
            }
        }
    }
}
