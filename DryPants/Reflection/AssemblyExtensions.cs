using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DryPants.Exceptions;

namespace DryPants.Reflection
{
    public static class AssemblyExtensions
    {
        public static Type[] GetInstantiableTypes(this Assembly assembly)
        {
            Throw.IfArgumentNull(() => assembly);

            IEnumerable<Type> types;

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                types = ex.Types;
            }

            return types.Where(type => type != null && type.IsPublic && !type.IsAbstract).ToArray();
        }
    }
}
