namespace Incantium.Attributes
{
    /// <summary>
    /// Interface for classes that can be <see cref="Attributes.Required"/> through the Unity Editor, but do not
    /// implement <see cref="UnityEngine.Object"/>.
    /// </summary>
    public interface IRequireable
    {
        /// <summary>
        /// The status of the required field.
        /// </summary>
        RequireStatus status { get; }
    }
}