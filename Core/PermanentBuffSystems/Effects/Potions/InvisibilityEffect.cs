﻿namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Potions
{
    public class InvisibilityEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!player.Player.buffImmune[BuffID.Invisibility] && !PermanentBuffPlayer.PermanentBuffsBools[(int)PermanentBuffPlayer.PermanentBuffs.Invisibility])
            {
                player.Player.invis = true;
                player.Player.buffImmune[BuffID.Invisibility] = true;
            }
        }
    }
}
