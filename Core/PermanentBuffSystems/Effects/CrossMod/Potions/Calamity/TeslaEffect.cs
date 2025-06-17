namespace QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.Calamity
{
    public class TeslaEffect : IPermanentModdedBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            if (!ModConditions.calamityLoaded)
                return;

            if (!player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff")] && !PermanentBuffPlayer.PermanentCalamityBuffsBools[(int)PermanentBuffPlayer.PermanentCalamityBuffs.Tesla])
            {
                buffToApply = BuffLoader.GetBuff(Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff"));
                buffToApply.Update(player.Player, ref index);
                player.Player.buffImmune[Common.GetModBuff(ModConditions.calamityMod, "TeslaBuff")] = true;

                if (player.Player.ownedProjectileCounts[Common.GetModProjectile(ModConditions.calamityMod, "TeslaAura")] < 1)
                {
                    int damage = (int)player.Player.GetBestClassDamage().ApplyTo(10f);
                    Projectile.NewProjectile(player.Player.GetSource_FromAI(), player.Player.Center, Vector2.Zero, Common.GetModProjectile(ModConditions.calamityMod, "TeslaAura"), damage, 0f, player.Player.whoAmI);
                }
            }
        }
    }
}
