/*
 * For compatibility reasons with netstandard 2.0
 */
#if NETSTANDARD2_0
using System;
namespace Migs.EnumMetadata
{
    [AttributeUsage(AttributeTargets.Parameter)]
    sealed class DisallowNullAttribute : Attribute {}
}
#endif