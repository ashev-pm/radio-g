using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Feed.Domain
{
    internal static class BusinessUtilsModule
    {
        internal static Option<IEnumerable<T>> AppendUnique<T>(this Option<IEnumerable<T>> maybeCollection, T newElement)
            where T : IEquatable<T>
        {
            if (maybeCollection.Reduce(Array.Empty<T>).Contains(newElement))
            {
                return maybeCollection;
            }
            return maybeCollection
                .Reduce(Array.Empty<T>)
                .Append(newElement)
                .ToArray();
        }

        internal static Option<IEnumerable<T>> ConcatDistinct<T>(this Option<IEnumerable<T>> maybeCollection, IEnumerable<T> newElement)
            where T : IEquatable<T>
        {
            var existElements = maybeCollection.Reduce(Array.Empty<T>);
            var newUniqueElements = newElement.Except(existElements);
            return existElements.Concat(newUniqueElements).ToArray();
        }
    }
}
