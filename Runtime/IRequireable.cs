namespace Incantium.Attributes
{
    /// <summary>
    /// Interface for classes that can be <see cref="Attributes.Required"/> through the Unity Editor, but do not
    /// implement <see cref="UnityEngine.Object"/>.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Required/blob/main/API~/IRequireable.md">IRequireable</seealso>
    public interface IRequireable
    {
        /// <summary>
        /// The status of the required field.
        /// </summary>
        RequireStatus status { get; }
    }
}