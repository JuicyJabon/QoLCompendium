namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Thorium
{
    public class FishRepellentEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "FishRepellentBuff")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.FishRepellent])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.thoriumMod, "FishRepellentBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.thoriumMod, "FishRepellentBuff")] = true;
            }
        }
    }
}
