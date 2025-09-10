using ThoriumRework;
using ThoriumRework.Buffs;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.ThoriumBossRework
{
    [JITWhenModsEnabled(ModConditions.thoriumBossReworkName)]
    [ExtendsFromMod(ModConditions.thoriumBossReworkName)]
    public class InspirationRegenerationEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumBossReworkLoaded)
                return;
            if (!ModContent.GetInstance<CompatConfig>().extraPotions)
                return;

            if (!player.Player.buffImmune[ModContent.BuffType<Inspired>()] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.InspirationRegeneration])
            {
                buffToApply = BuffLoader.GetBuff(ModContent.BuffType<Inspired>());
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[ModContent.BuffType<Inspired>()] = true;
            }
        }
    }
}
