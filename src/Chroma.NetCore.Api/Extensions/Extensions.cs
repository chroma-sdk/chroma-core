using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Chroma.NetCore.Api.Attributes;

namespace Chroma.NetCore.Api.Extensions
{
    public static class Extensions
    {
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetRuntimeField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] stringValueAttributes = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return stringValueAttributes?.Length > 0 ? stringValueAttributes[0].StringValue : null;
        }

    }
}
