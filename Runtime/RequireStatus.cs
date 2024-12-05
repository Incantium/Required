namespace Incantium.Attributes
{
    /// <summary>
    /// Enum for different statuses of the <see cref="Required"/> attribute to show.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Required/blob/main/API~/RequireStatus.md">RequireStatus</seealso>
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