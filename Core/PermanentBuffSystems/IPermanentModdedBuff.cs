namespace QoLCompendium.Core.PermanentBuffSystems
{
    public abstract class IPermanentModdedBuff : IComparable
    {
        public int index = 44;

        public ModBuff buffToApply = null;

        public int CompareTo(object obj) => GetType().Name.CompareTo(obj.GetType().Name);

        internal abstract void ApplyEffect(PermanentBuffPlayer player);
    }
}
