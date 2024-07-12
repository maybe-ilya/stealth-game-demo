using System.Collections.Generic;
using URandom = UnityEngine.Random;

namespace MIG.Extensions
{
    public static class CollectionsExtensions
    {
        public static T PickRandomElement<T>(this T[] list)
        {
            var count = list.Length;
            var index = URandom.Range(0, count);
            return list[index];
        }

        public static T PickRandomElement<T>(this IList<T> list)
        {
            var count = list.Count;
            var index = URandom.Range(0, count);
            return list[index];
        }

        public static T PickRandomElement<T>(this IReadOnlyList<T> list)
        {
            var count = list.Count;
            var index = URandom.Range(0, count);
            return list[index];
        }
    }
}