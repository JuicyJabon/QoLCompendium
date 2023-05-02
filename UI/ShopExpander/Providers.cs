using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace QoLCompendium.UI.ShopExpander
{
    public static class ProviderPriority
    {
        public const int BeforeVanilla = -500;
        public const int Vanilla = 0;
        public const int AfterVanilla = 500;
        public const int Buyback = 1000;
        public const int AfterBuyback = 1500;
    }

    public interface IShopPageProvider
    {
        string Name { get; }
        int Priority { get; }
        int NumPages { get; }
        IEnumerable<Item> GetPage(int pageNum);
    }

    public class DynamicPageProvider : ArrayProvider
    {
        private readonly List<ProvisionedSegment> provisions = new();
        private readonly Item[] vanillaShop;
        private readonly Item[] vanillaShopCopy;

        public DynamicPageProvider(string name, int priority) : this(new Item[0], name, priority) { }

        public DynamicPageProvider(Item[] vanillaShop, string name, int priority) : base(name, priority, new Item[0])
        {
            this.vanillaShop = vanillaShop;
            vanillaShopCopy = vanillaShop.Where(x => !x.IsAir).Select(x => x.Clone()).ToArray();
            FixNumPages();
        }

        public Item[] Provision(int capacity, bool noDistinct, bool vanillaCopy)
        {
            var items = new ProvisionedSegment(capacity, noDistinct);
            if (vanillaCopy)
            {
                for (var i = 0; i < vanillaShopCopy.Length; i++)
                {
                    items.items[i] = vanillaShopCopy[i].Clone();
                }
            }

            provisions.Add(items);
            return items.items;
        }

        public void UnProvision(Item[] items)
        {
            provisions.RemoveAll(x => x.items == items);
        }

        public void Compose()
        {
            ExtendedItems = ExtendedItems.Concat(
                    vanillaShop.Where(x => !x.IsAir))
                .Concat(
                    provisions.Where(x => !x.noDistinct)
                        .SelectMany(x => x.items.Where(y => !y.IsAir)))
                .Distinct(new ItemSameType())
                .Concat(
                    provisions.Where(x => x.noDistinct)
                        .SelectMany(x => x.items.Where(y => !y.IsAir)))
                .ToArray();

            FixNumPages();
            provisions.Clear();
        }

        private struct ProvisionedSegment
        {
            public readonly Item[] items;
            public readonly bool noDistinct;

            public ProvisionedSegment(int size, bool noDistinct)
            {
                items = new Item[size];
                for (var i = 0; i < size; i++)
                {
                    items[i] = new Item();
                }

                this.noDistinct = noDistinct;
            }
        }

        private class ItemSameType : IEqualityComparer<Item>
        {
            public bool Equals(Item x, Item y)
            {
                return x.Name == y.Name && x.type == y.type;
            }

            public int GetHashCode(Item obj)
            {
                return obj.Name.GetHashCode() ^ obj.type.GetHashCode();
            }
        }
    }

    public class ArrayProvider : IShopPageProvider
    {
        public Item[] ExtendedItems { get; protected set; }

        public ArrayProvider(string name, int priority, Item[] items)
        {
            Name = name;
            Priority = priority;
            ExtendedItems = items;
            FixNumPages();
        }

        public string Name { get; set; }
        public int Priority { get; set; }
        public int NumPages { get; private set; }

        public IEnumerable<Item> GetPage(int pageNum)
        {
            var offset = pageNum * 38;

            for (var i = 0; i < ShopAggregator.FrameCapacity; i++)
            {
                var sourceIndex = i + offset;
                if (sourceIndex >= ExtendedItems.Length)
                {
                    yield break;
                }

                yield return ExtendedItems[sourceIndex];
            }
        }

        protected void FixNumPages()
        {
            if (ExtendedItems.Length > 0)
            {
                NumPages = ((ExtendedItems.Length - 1) / ShopAggregator.FrameCapacity) + 1;
            }
            else
            {
                NumPages = 0;
            }
        }
    }

    public class CircularBufferProvider : IShopPageProvider
    {
        private readonly Item[] items = new Item[ShopAggregator.FrameCapacity];
        private int nextSlot;
        private bool show;

        public CircularBufferProvider(string name, int priority)
        {
            Name = name;
            Priority = priority;
            for (var i = 0; i < items.Length; i++)
            {
                items[i] = new Item();
            }
        }

        public string Name { get; set; }
        public int Priority { get; set; }
        public int NumPages => show ? 1 : 0;

        public IEnumerable<Item> GetPage(int pageNum)
        {
            return items;
        }

        public void AddItem(Item item)
        {
            show = true;

            for (var i = 0; i < items.Length; i++)
            {
                if (items[i].IsAir)
                {
                    items[i] = item;
                    nextSlot = 0;
                    return;
                }
            }

            items[nextSlot++] = item;
            if (nextSlot >= items.Length)
            {
                nextSlot = 0;
            }
        }
    }

}
