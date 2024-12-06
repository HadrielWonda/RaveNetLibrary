﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;


namespace RaveNetLibrary.Reflection;

    internal static class ReflectionUtil
    {
        internal static string RequestQueryBuilder(object input)
        {
            var serializedData = GetAllJsonAttributes(input);
            var resultString = "?";
            var attrData = serializedData.AllKeys.SelectMany(serializedData.GetValues, (s, i) => new {key = s, value = i});
            foreach (var obj in attrData)
            {
                if (resultString == "?")
                {
                    resultString = resultString + $"{obj.key}={obj.value}";
                    continue;
                }

                resultString = resultString + $"&{obj.key}={obj.value}";
            }
            return resultString;
        }

        internal static string GetObjectPropValues(object inputObj, string propName)
        {
            var propValue = inputObj.GetType().GetProperty(propName).GetValue(inputObj, null);

            if (IsValueType(propValue) && !IsDefaultValue(propValue))
            {
                return propValue.ToString();
            }

            return ""; // Should throw exception in this case
        }
        private static NameValueCollection GetAllJsonAttributes(object input)
        {
            var result = new NameValueCollection();
            var inputTypeInfo = input.GetType().GetTypeInfo();
            var props = inputTypeInfo.GetProperties();

            foreach (var prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    if (attr is JsonPropertyAttribute jsonProperty)
                    {
                        var sttrValue = jsonProperty.PropertyName;
                        var value = prop.GetValue(input);
                        if (IsValueType(value) && !IsDefaultValue(value))
                        {
                            result.Add(sttrValue, value.ToString());
                            // For now we can only serialize value types
                        }
                      
                    }
                }

            }

            return result;
        }

        private static bool IsDefaultValue(object value)
        {
            if (value.GetType().IsValueType)
            {
                var valDef = Activator.CreateInstance(value.GetType());
                return value.Equals(valDef);
            }

            return value == null;
        }

        private static bool IsValueType(object obj)
        {
            return obj != null && (obj.GetType().IsValueType || obj is string); // check if given object is a value type or a string
        }
    }

