using System.Collections.Generic;
using System.Linq;

namespace QoLCompendium.Tweaks
{
	public static class BuffHelper
	{
		public static List<(T, string)> FromArray<T>(T[] items, string key)
		{
			return items.Select((T t) => (t, key)).ToList();
		}
	}
}
