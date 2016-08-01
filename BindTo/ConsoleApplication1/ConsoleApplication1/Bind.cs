using System;
using System.IO;
using System.Collections.Generic;

namespace System
{
    public class Bind
    {
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        public static void Add(Type i, Type c)
        {
            if (dictionary.ContainsKey(i))
                dictionary.Remove(i);

            dictionary[i] = c;
        }

        public static Type Get(Type i)
        {
            if (dictionary.ContainsKey(i))
                return dictionary[i];

            throw new Exception($"No mapping for interface '{i.Name}' found.");
        }
     
    }

}
