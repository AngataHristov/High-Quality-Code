using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Core.Factories
{
    using Models.Interfaces;
    using Models.Resources;

    public static class ResourceFactory
    {
        public static IResource Create(string resourceType)
        {
            switch (resourceType)
            {
                case "Gold":
                    return new Gold();
                case "Steel":
                    return new Steel();
                default:
                    throw new NotSupportedException("Invalid type supplied");
            }
        }
    }
}
