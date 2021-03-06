using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfGridControlTest01.Classes
{
    public static class Extensions
    {
        public static List<T> Clone<T>(this List<T> source)
        {
            return source.GetRange(0, source.Count);
        }

        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        //public static IList<T> Equals<T>(this IList<T> list) where T : IEquatable<T>
        //{
        //    return list.Select(item => (T)item.Equals(T)).ToList();
        //}

        public static Dictionary<int, T> ToDictionary<T>(this IEnumerable<T> array)
        {
            return array.Select((v, i) => new { Key = i, Value = v })
                .ToDictionary(o => o.Key, o => o.Value);
        }


        public static string[] strTypes = new string[] {
                    "ProductType1", "ProductType2", "ProductType3", "ProductType4", "ProductType5"
                };
    }
}
