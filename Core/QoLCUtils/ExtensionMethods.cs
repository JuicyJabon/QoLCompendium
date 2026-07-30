namespace QoLCompendium.Core.QoLCUtils
{
    public static class ExtensionMethods
    {
        public static void AddRangeNotZero(this List<int> list, IEnumerable<int> collection)
        {
            foreach (var item in collection)
            {
                if (item != 0 && item != -1)
                    list.Add(item);
            }
        }

        public static void AddRangeModActive(this List<Mod> list, IEnumerable<Mod> collection)
        {
            foreach (var item in collection)
            {
                if (item != null)
                    list.Add(item);
            }
        }

        public static void AddRangeNotGenericOrDefault(this List<DamageClass> list, IEnumerable<DamageClass> collection)
        {
            foreach (var item in collection)
            {
                if (item != DamageClass.Generic && item != DamageClass.Default)
                    list.Add(item);
            }
        }
    }
}
