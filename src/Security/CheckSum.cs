﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using RaveNetLibrary.Reflection;

namespace RaveNetLibrary.Security;

    public static class CheckSum
    {
        public static string CreateCheckSum(object payParams, string secretKey)
        {
            var inputTypeInfo = payParams.GetType().GetTypeInfo();
            var props = inputTypeInfo.GetProperties();

            var propNames = props.Select(prop => prop.Name).ToList();

            propNames.Sort();
            if (propNames.Contains("PbfPubKey"))
            {
                propNames.Remove("PbfPubKey");
                propNames.Insert(0, "PbfPubKey"); // this feels weird to me
            }

            var hashString = "";

            foreach (var propName in propNames)
            {
                hashString = hashString + SanitizeNumbers(ReflectionUtil.GetObjectPropValues(payParams, propName));
            }

            return Hashing.GenerateSHA256String(hashString + secretKey);
        }

        private static string SanitizeNumbers(string inputStr)
        {
            if (inputStr.StartsWith("0") && inputStr.Length == 2 && int.TryParse(inputStr.Substring(1, 1), out var o))
            {
                //This is a poor man's approach to checking if the string represents a card expiry lol 🥲🥲🥲
                // First checks if the string starts with a zero
                // Then checks if the string length is 2
                // and then checks if second variable is an integer
                // Todo just return as is
                return inputStr;
            }
            if (decimal.TryParse(inputStr, out var sample))
            {
                return string.Format("{0:G29}", decimal.Parse(inputStr));
            }

            return inputStr;
        }
    }

