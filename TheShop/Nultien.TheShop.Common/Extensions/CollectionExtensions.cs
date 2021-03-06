using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static bool SafeHasItems<T>(this ICollection<T> collection)
        {
            return collection != null && collection.Count > 0;
        }

        public static bool NullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }

        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items,
                                                            int maxItems)
        {
            return items.Select((item, inx) => new { item, inx })
                        .GroupBy(x => x.inx / maxItems)
                        .Select(g => g.Select(x => x.item));
        }
    }
}