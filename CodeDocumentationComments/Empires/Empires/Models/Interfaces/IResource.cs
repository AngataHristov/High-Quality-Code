

namespace Empires.Models.Interfaces
{
    using Enumerations;

    /// <summary>
    /// Abstraction of the resources in the app
    /// </summary>
    public interface IResource
    {
        // Resource's type
        ResourceTypes Type { get; }

        // Resource's quantity
        int Quantity { get; }
    }
}
