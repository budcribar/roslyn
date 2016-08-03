using System;
using System.IO;
using System.Collections.Generic;

namespace System
{
    public class Registry
    {
        private static Dictionary<Type, Stack<Type>> dictionary = new Dictionary<Type, Stack<Type>>();

        public static void Add(Type i, Type c)
        {
            if (i == null)
                throw new ArgumentException("Null Interface Type");

            if (c == null)
                throw new ArgumentException("Null Class Type");

            if (!dictionary.ContainsKey(i))
                dictionary[i] = new Stack<Type>();

            dictionary[i].Push(c);
        }

        public static void Pop(Type i)
        {
            if (i == null) throw new ArgumentException("Null Interface Type");
            dictionary[i].Pop();
        }

        public static object GetInstance(Type i)
        {
            if (i == null)
                throw new ArgumentException("Null Interface Type");

            if (dictionary.ContainsKey(i) && dictionary[i].Count > 0)
            {
                object instance = dictionary[i].Peek().GetConstructor(new Type[] { }).Invoke(new object[] { });

                if (instance == null)
                    throw new ArgumentException($"{dictionary[i].Peek().Name} does not implement {i.Name}");

                return instance;
            }
               
            throw new Exception($"No mapping for interface '{i.Name}' found.");
        }
     
    }

}
