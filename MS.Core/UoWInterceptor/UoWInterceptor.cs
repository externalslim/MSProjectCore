using Castle.DynamicProxy;
using MS.Data.Models;
using System;
using System.Reflection;
using MS.Core.UoW;

namespace MS.Core.UoWInterceptor
{
    public class UoWInterceptor : IUoWInterceptor
    {
        public void Intercept(IInvocation invocation)
        {

            if (UnitOfWork.Current != null || !RequiresDbConnection(invocation.MethodInvocationTarget))
            {
                invocation.Proceed();
                return;
            }


            try
            {
                //Yeni instance alacak
                UnitOfWork.Current = new UnitOfWork(new MSContext());

                //aldığı instance'ın transaction'ını başlatacak
                UnitOfWork.Current.BeginTransaction();
                //before logs (optional)

                invocation.Proceed();

                //after logs (optional)

                //var olan transaction'ı commitleyecek
                UnitOfWork.Current.Commit();
            }
            catch (Exception ex)
            {
                //exception log (optional)

                // var olan transaction'ı rollback yapacak.
                UnitOfWork.Current.RollBack();

            }
            finally
            {
                // var olan transaction'ı nullayacak. Aksi takdirde More than 1 instance trying to open hatası verecek.
                UnitOfWork.Current = null;
            }
        }

        private static bool RequiresDbConnection(MethodInfo methodInfo)
        {
            if (UnitOfWorkHelper.HasUnitOfWorkAttribute(methodInfo))
            {
                return true;
            }

            if (UnitOfWorkHelper.IsRepositoryMethod(methodInfo))
            {
                return true;
            }

            return false;
        }
    }
}
