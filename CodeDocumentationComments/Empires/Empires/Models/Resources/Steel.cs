
namespace Empires.Models.Resources
{
    using Enumerations;

    public class Steel : Resource
    {
        private const int QuantityDefault = 10;
        private const ResourceTypes Type = ResourceTypes.Steel;

        public Steel()
            : base(Type, QuantityDefault)
        {

        }
    }
}
