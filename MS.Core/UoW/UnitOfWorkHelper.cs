using MS.Core.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.Core.UoW
{
    public class UnitOfWorkHelper
    {
        public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }

        public static bool IsRepositoryClass(Type type)
        {
            return typeof(IRepository).IsAssignableFrom(type);
        }
    }
}
