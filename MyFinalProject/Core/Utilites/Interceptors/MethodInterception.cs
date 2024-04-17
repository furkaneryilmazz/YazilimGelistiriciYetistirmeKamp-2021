using Castle.DynamicProxy;
using System;

namespace Core.Utilites.Interceptors
{
    public abstract class MethodInterception : Attribute, IInterceptor
    {
        //Bu metodları virtual yapmamızın sebebi, isteyen istediği zaman bu metotları ezerek istediği işlemi yapabilir.
        //Bu metotlar bizim için hook (kancalar) görevi görecek. Yani bu metotlar bizim için birer hook görevi görecek.
        //interceptorlarımızın çalışma sırasını belirleyebilmemiz için bu metotları virtual yaptık.
        //invocation: Business method demek. Yani bu metotlar bizim business metodlarımızın önünde çalışacaklar.
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
