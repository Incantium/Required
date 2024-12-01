namespace Incantium.Attributes
{
    /// <summary>
    /// Enum for different statuses of the <see cref="Attributes.Required"/> attribute to show.
    /// </summary>
    public enum RequireStatus
    {
        /// <summary>
        /// The required field has been set.
        /// </summary>
        Found,
        
        /// <summary>
        /// The required field has not been set.
        /// </summary>
        Missing,
        
        /// <summary>
        /// The required field is non-referencable and cannot be set.
        /// </summary>
        Unable
    }
}