using ThoriumRework;
using ThoriumRework.Buffs;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.ThoriumBossRework
{
    [JITWhenModsEnabled(ModConditions.thoriumBossReworkName)]
    [ExtendsFromMod(ModConditions.thoriumBossReworkName)]
    public class DeathsingerEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.thoriumBossReworkLoaded)
                return;
            if (!ModContent.GetInstance<CompatConfig>().extraPotions)
                return;

            if (!player.Player.buffImmune[ModContent.BuffType<Deathsinger>()] && !player.Player.GetModPlayer<PermanentBuffPlayer>().PermanentThoriumBuffsBools[(int)PermanentBuffPlayer.PermanentThoriumBuffs.Deathsinger])
            {
                buffToApply = BuffLoader.GetBuff(ModContent.BuffType<Deathsinger>());
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[ModContent.BuffType<Deathsinger>()] = true;
            }
        }
    }
}
