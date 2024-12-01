using System;
using UnityEngine;

namespace Incantium.Attributes
{
    /// <summary>
    /// Attribute for object reference fields that requires to be set in the Unity Inspector. Failing to do so will
    /// result in the game not playing. Fields in Prefab Mode are exempt.
    /// </summary>
    /// <remarks>This attribute only works for classes that implement <see cref="UnityEngine.Object"/> or those that
    /// implement <see cref="IRequireable"/>.</remarks>
    /// <seealso href="https://github.com/Incantium/Incantium-Core/blob/main/Documentation~/Attributes/Required.md">
    /// Required</seealso>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class Required : PropertyAttribute {}
}