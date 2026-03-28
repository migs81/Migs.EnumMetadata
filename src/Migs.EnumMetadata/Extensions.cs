using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using Migs.EnumMetadata.Exceptions;

namespace Migs.EnumMetadata
{
    /// <summary>
    /// Extension methods for enum attributes
    /// </summary>
    public static class Extensions
    {
        //private static readonly Hashtable _cache = new Hashtable();
        private static readonly ConcurrentDictionary<Enum, EnumMetadataAttribute>  _cache = new();

        /// <summary>
        /// Gets the attribute for the given enum considering the requested attribute type.
        /// </summary>
        /// <typeparam name="TAttr">The type of the enum attribute.</typeparam>
        /// <param name="source">The source enum.</param>
        /// <returns></returns>
        /// <exception>
        ///     <cref>EnumAttributeNotFoundException</cref>
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TAttr GetAttribute<TAttr>([DisallowNull] this Enum source) where TAttr : EnumMetadataAttribute
        {
            if (EnumMetadataConfig.UseCache)
            {
                if (_cache.TryGetValue(source, out var attr))
                    return (TAttr)attr;

                TAttr attribute = GetAttribute<TAttr>(ref source);
                _cache.TryAdd(source, attribute);
                return attribute;
            }

            return GetAttribute<TAttr>(ref source);
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <typeparam name="TAttr">The type of the attribute.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception>
        ///     <cref>EnumAttributeNotFoundException</cref>
        /// </exception>
        private static TAttr GetAttribute<TAttr>(ref Enum source) where TAttr : EnumMetadataAttribute
        {
            var type = source.GetType();
            var name = Enum.GetName(type, source) ?? throw new EnumDataNotFoundException(typeof(TAttr), source);

            return type.GetField(name)?.GetCustomAttribute<TAttr>() ?? throw new EnumDataNotFoundException(typeof(TAttr), source);
        }
    }
}