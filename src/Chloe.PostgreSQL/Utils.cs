﻿using Chloe.DbExpressions;
using Chloe.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chloe.PostgreSQL
{
    internal static class Utils
    {
        static readonly HashSet<Type> ToStringableNumericTypes;

        static Utils()
        {
            ToStringableNumericTypes = new HashSet<Type>();
            ToStringableNumericTypes.Add(typeof(byte));
            ToStringableNumericTypes.Add(typeof(sbyte));
            ToStringableNumericTypes.Add(typeof(short));
            ToStringableNumericTypes.Add(typeof(ushort));
            ToStringableNumericTypes.Add(typeof(int));
            ToStringableNumericTypes.Add(typeof(uint));
            ToStringableNumericTypes.Add(typeof(long));
            ToStringableNumericTypes.Add(typeof(ulong));
            ToStringableNumericTypes.TrimExcess();
        }

        public static string QuoteName(string name, bool convertToLowercase)
        {
            if (convertToLowercase)
                return string.Concat("\"", name.ToLower(), "\"");

            return string.Concat("\"", name, "\"");
        }

        public static bool IsToStringableNumericType(Type type)
        {
            type = ReflectionExtension.GetUnderlyingType(type);
            return ToStringableNumericTypes.Contains(type);
        }
    }
}
