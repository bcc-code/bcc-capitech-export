using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCC.Capitech.Extensions
{
    public static class ObjectComparisonExtensions
    {
        /// <summary>
        /// Returns true if two objects of the specified type have equal properties (including nested properties to the specified level)
        /// If the type is an interface, only the properties defined on the interface will be inspected.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public static bool EqualsByInterface<T>(this T obj, T otherObject, HashSet<string> excludeProperties = null)
        {
            return EqualByInterface(typeof(T), obj, otherObject, 1, 0, excludeProperties);
        }

        /// <summary>
        /// Returns true if two objects of the specified type have equal properties (including nested properties to the specified level)
        /// If the type is an interface, only the properties defined on the interface will be inspected.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="otherObject"></param>
        /// <returns></returns>
        public static bool EqualsByInterface<T>(this T obj, T otherObject, int maxNesting = 5, HashSet<string> excludeProperties = null)
        {
            return EqualByInterface(typeof(T), obj, otherObject, maxNesting, 0, excludeProperties);
        }

        public static bool EqualByInterface(Type type, object obj, object otherObject, int maxNesting = 5, int nestingLevel = 0, HashSet<string> excludeProperties = null)
        {
            // Skip if deep nesting (typically object loops)
            if (nestingLevel >= maxNesting)
            {
                return true;
            }

            // Null objects
            if (obj == null && otherObject == null) return true;
            if (obj == null || otherObject == null) return false;


            // Generic enumerables (List, Dictionary, Collection etc)
            if (type != typeof(string) && obj is IEnumerable)
            {
                Type itemType = type.GetIEnumerableItemType();
                bool isTyped = itemType != typeof(object);
                var listA = new List<object>(((IEnumerable)obj).Cast<object>().SortBySignature(itemType));
                var listB = new List<object>(((IEnumerable)otherObject).Cast<object>().SortBySignature(itemType));
                if (listA.Count != listB.Count) return false;
                for (var i = 0; i < listA.Count; i++)
                {
                    // Implementation which does not rquire strict ordering. Turns out to be quite slow!
                    //var valA = listA[i];
                    //if (!listB.Any(valB => EqualByInterface(isTyped ? itemType : listA.GetType(), valA, valB, maxNesting, nestingLevel + 1)))
                    //{
                    //    return false;
                    //}

                    // Alternative implementation - more efficient, but requires same ordering of elements.
                    // which is usually not required for database type scenarios.
                    if (listA[i] == null && listB[i] == null) continue;
                    if (!isTyped && listA[i].GetType() != listB[i].GetType()) return false;
                    if (!EqualByInterface(isTyped ? itemType : listA[i].GetType(), listA[i], listB[i], maxNesting, nestingLevel + 1)) return false;
                }
                return true;
            }

            // Single objects
            var simpleProperties = type.GetSimpleProperties();
            var complexProperties = type.GetComplexProperties();
            object a = null;
            object b = null;
            foreach (var property in simpleProperties)
            {
                if (excludeProperties.Contains(property.Name))
                {
                    continue;
                }
                a = property.GetValue(obj);
                b = property.GetValue(otherObject);
                if (a == b) continue;
                if (a == null || b == null)
                {
                    return false;
                }
                if (a.Equals(b))
                {
                    continue;
                }
                return false;
            }
            foreach (var property in complexProperties)
            {
                if (excludeProperties.Contains(property.Name))
                {
                    continue;
                }

                a = property.GetValue(obj);
                b = property.GetValue(otherObject);

                // Avoid object loops
                if (EqualByInterface(property.PropertyType, a, b, maxNesting, nestingLevel + 1)) continue;
                return false;
            }

            return true;
        }

        public static IEnumerable<T> SortBySignature<T>(this IEnumerable<T> values) where T : class
        {
            return SortBySignature(values, typeof(T)) as IEnumerable<T>;
        }
        public static IEnumerable<object> SortBySignature(this IEnumerable<object> values, Type type)
        {
            if (values == null) return null;
            var list = values.ToList();
            list.Sort((a, b) => a.GetSortSignature(type).CompareTo(b.GetSortSignature(type)));
            return list;
        }
        public static string GetSortSignature<T>(this T obj) where T : class
        {
            return GetSortSignature(obj, typeof(T));
        }
        public static string GetSortSignature(this object obj, Type type)
        {
            var properties = type.GetSimpleProperties();
            if (properties.Length > 0)
            {
                return properties.Select(p => p.GetValue(obj)?.ToString() ?? "").Aggregate((c, n) => $"{c}|{n}");
            }
            return "";
        }
    }
}