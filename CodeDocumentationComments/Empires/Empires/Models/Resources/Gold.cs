
namespace Empires.Models.Resources
{
    using Enumerations;

    public class Gold : Resource
    {
        private const int QuantityDefault = 5;
        private const ResourceTypes Type = ResourceTypes.Gold;

        public Gold()
            : base(Type, QuantityDefault)
        {
        }
    }
}
