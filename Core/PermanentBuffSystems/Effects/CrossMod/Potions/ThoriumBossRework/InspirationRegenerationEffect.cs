using ThoriumRework;
using ThoriumRework.Buffs;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.ThoriumBossRework
{
    [JITWhenModsEnabled("ThoriumRework")]
    [ExtendsFromMod("ThoriumRework")]
    public class InspirationRegenerationEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumBossReworkLoaded)
                return;
            if (!ModContent.GetInstance<CompatConfig>().extraPotions)
                return;

            if (!player.Player.buffImmune[ModContent.BuffType<Inspired>()] && !PermanentBuffPlayer.PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.InspirationRegeneration])
            {
                buffToApply = BuffLoader.GetBuff(ModContent.BuffType<Inspired>());
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[ModContent.BuffType<Inspired>()] = true;
            }
        }
    }
}
