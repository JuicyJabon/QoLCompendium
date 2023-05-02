using System.Runtime.CompilerServices;
using Terraria;

namespace QoLCompendium.UI.ShopExpander
{
    public class LazyObjectConfig<T>
    {
        private readonly ConditionalWeakTable<object, Ref<T>> _config = new();
        private readonly T _defaultConfig;

        public LazyObjectConfig(T defaultConfig = default)
        {
            _defaultConfig = defaultConfig;
        }

        public void SetValue(object obj, T value)
        {
            var valueRef = _config.GetOrCreateValue(obj);
            valueRef.Value = value;
        }

        public T GetValue(object obj)
        {
            if (_config.TryGetValue(obj, out var value))
            {
                return value.Value;
            }

            return _defaultConfig;
        }
    }
}
