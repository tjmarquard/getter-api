namespace GetterApi.Extensions
{
    using System;
    using System.Linq;

    public static class TypeExtension
    {
        public static bool HasField(this Type obj, string fieldName)
        {
            return obj.GetFields().Select(fieldInfo => fieldInfo.Name).Where(name => name.Equals(fieldName, StringComparison.OrdinalIgnoreCase)).Count() > 0;
        }
    }
}
