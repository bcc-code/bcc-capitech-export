using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BCC.Capitech.Extensions
{
    public static class TypeExtensions
    {
        #region PropertyInfo Cache
        private static ConcurrentDictionary<Type, PropertyInfo[]> _simplePropertyTypeCache = new ConcurrentDictionary<Type, PropertyInfo[]>();
        private static ConcurrentDictionary<Type, PropertyInfo[]> _complexPropertyTypeCache = new ConcurrentDictionary<Type, PropertyInfo[]>();
        private static ConcurrentDictionary<Type, Type> _enumerableTypeCache = new ConcurrentDictionary<Type, Type>();
        #endregion

        /// <summary>
        /// Returns simple properties on the type, including primatives and strings
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetSimpleProperties(this Type type)
        {
            if (_simplePropertyTypeCache.ContainsKey(type))
            {
                return _simplePropertyTypeCache[type];
            }

            var properties = type.GetTypeInfo().GetInterfaces().Union(new[] { type }).SelectMany(t => t.GetTypeInfo().GetProperties()).Where(c =>
            {
                if (!c.CanRead) return false;
                if (c.PropertyType == typeof(string)) return true;
                var inf = c.PropertyType.GetTypeInfo();
                return !inf.IsInterface && (!inf.IsClass || inf.IsPrimitive);
            }).ToArray();
            var propertiesDict = new Dictionary<string, PropertyInfo>();
            foreach (var prop in properties)
            {
                if (!propertiesDict.ContainsKey(prop.Name))
                {
                    propertiesDict[prop.Name] = prop;
                }
            }
            _simplePropertyTypeCache[type] = propertiesDict.Values.ToArray();
            return properties;

        }




        /// <summary>
        /// Returns complex types on property including classes, structs, lists, arrays etc.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetComplexProperties(this Type type)
        {
            if (_complexPropertyTypeCache.ContainsKey(type))
            {
                return _complexPropertyTypeCache[type];
            }
            var properties = type.GetTypeInfo().GetInterfaces().Union(new[] { type }).SelectMany(t => t.GetTypeInfo().GetProperties()).Where(c =>
            {
                if (!c.CanRead) return false;
                if (c.PropertyType == typeof(string)) return false;
                var inf = c.PropertyType.GetTypeInfo();
                return (inf.IsInterface || inf.IsClass) && !inf.IsPrimitive;

            }).ToArray();
            var propertiesDict = new Dictionary<string, PropertyInfo>();
            foreach (var prop in properties)
            {
                if (!propertiesDict.ContainsKey(prop.Name))
                {
                    propertiesDict[prop.Name] = prop;
                }
            }
            _complexPropertyTypeCache[type] = propertiesDict.Values.ToArray();
            return properties;

        }

        /// <summary>
        /// Returns the item type of the specified type (which must be, or implement IEnumerable<>)
        /// </summary>
        /// <param name="enumerableType"></param>
        /// <returns></returns>
        public static Type GetIEnumerableItemType(this Type enumerableType)
        {
            if (enumerableType == null)
            {
                return null;
            }
            if (_enumerableTypeCache.ContainsKey(enumerableType))
            {
                return _enumerableTypeCache[enumerableType];
            }
            var typeInfo = enumerableType.GetTypeInfo();
            var itemType = typeof(object);
            if (typeInfo.IsGenericType)
            {
                var genericArguments = typeInfo.GenericTypeArguments.ToArray();
                if (genericArguments.Length == 1) // List, Hashset etc.
                {
                    itemType = typeInfo.GetGenericArguments().FirstOrDefault() ?? typeof(object);
                }
                else if (genericArguments.Length > 1) // Possibly Dictionary or similar
                {
                    // Inspect other interfaces
                    itemType = typeInfo.GetInterfaces().Where(i => i.GetGenericTypeDefinition() == typeof(IEnumerable<>)).Select(t => t.GenericTypeArguments.FirstOrDefault()).FirstOrDefault() ?? typeof(object);
                }
            }
            _enumerableTypeCache[enumerableType] = itemType;
            return itemType;
        }

    }
}