using System;
using System.Collections.Generic;
using System.Linq;

namespace NP.Core.Catalogs
{
    public static class ObjectTypeCatalog
    {
        public static List<string> GetTypes()
        {
            return Enum
                .GetNames(typeof(ObjectType))
                .ToList();
        }
    }
}