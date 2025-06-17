namespace QoLCompendium.Core.PermanentBuffSystems
{
    public abstract class IPermanentBuff : IComparable
    {
        public int CompareTo(object obj) => GetType().Name.CompareTo(obj.GetType().Name);

        internal abstract void ApplyEffect(PermanentBuffPlayer player);
    }
}
