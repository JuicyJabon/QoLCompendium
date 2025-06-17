namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Catalyst
{
    public class AstraJellyEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.catalystLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff")] && !PermanentBuffPlayer.PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.AstraJelly])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.catalystMod, "AstralJellyBuff")] = true;
            }
        }
    }
}
