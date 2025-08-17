namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Arena.SpiritClassic
{
    public class TheCouchEffect : IPermanentModdedBuff
    {
        //Item Name = TheCouch
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.spiritLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "CouchPotato")] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools[(int)PermanentBuffPlayer.PermanentSpiritClassicBuffs.TheCouch])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.spiritMod, "CouchPotato"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.spiritMod, "CouchPotato")] = true;
            }
        }
    }
}
