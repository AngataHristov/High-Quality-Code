
namespace Empires.Models.Resources
{
    using System;

    using Enumerations;
    using Interfaces;

    public abstract class Resource : IResource
    {
        private int quantity;

        protected Resource(ResourceTypes type, int quantity)
        {
            this.Type = type;
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Quantity cannot be negative!");
                }

                this.quantity = value;
            }
        }

        public ResourceTypes Type { get; }
    }
}
