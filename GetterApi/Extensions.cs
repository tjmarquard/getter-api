using System;
using System.Linq;

namespace GetterApi
{
    public static class Extensions
    {
        public static bool HasField(this Type obj, string fieldName)
        {
            return obj.GetFields().Select(fieldInfo => fieldInfo.Name).Where(name => name.Equals(fieldName, StringComparison.OrdinalIgnoreCase)).Count() > 0;
        }
    }
}
