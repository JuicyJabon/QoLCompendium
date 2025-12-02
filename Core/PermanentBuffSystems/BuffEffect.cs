namespace QoLCompendium.Core.PermanentBuffSystems
{
    [Autoload(false)]
    public class BuffEffect(int buff, int type = 0) : ILoadable
    {
        public int index = 44;

        private int buff = buff;

        public int EffectType = type;

        public void ApplyEffect(NewPermanentBuffPlayer player)
        {
            if (player.Player.buffImmune[buff])
                return;

            if (buff > BuffID.Count - 1)
                BuffLoader.GetBuff(buff).Update(player.Player, ref index);
            else
                Common.VanillaBuffHandler(buff, player.Player);
        }

        public void Load(Mod mod)
        {
            
        }

        public void Unload()
        {

        }
    }
}
