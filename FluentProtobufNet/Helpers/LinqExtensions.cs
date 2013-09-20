﻿using System;
using System.Collections.Generic;

namespace FluentProtobufNet.Helpers
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }

        public static T InstantiateUsingParameterlessConstructor<T>(this Type type)
        {
            return (T)type.InstantiateUsingParameterlessConstructor();
        }

        public static object InstantiateUsingParameterlessConstructor(this Type type)
        {
            var constructor = ReflectHelper.GetDefaultConstructor(type);

            if (constructor == null)
                throw new MissingConstructorException(type);

            return constructor.Invoke(null);
        }
    }
}