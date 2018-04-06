namespace RC.FacElecCol.Aspecto
{
    using Castle.DynamicProxy;
    using System;
    using System.Linq;

    public abstract class AspectAttribute : Attribute, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!CanIntercept(invocation, GetType()) && invocation != null)
            {
                //method is NOT decorated with the proper aspect, continue as normal
                invocation.Proceed();
                return;
            }

            ProcessInvocation(invocation);
        }

        private static bool CanIntercept(IInvocation invocation, Type type)
        {
            return invocation.TargetType.CustomAttributes.Any(x => x.AttributeType == type) ||
                   invocation.MethodInvocationTarget.CustomAttributes.Any(x => x.AttributeType == type);
        }

        public abstract void ProcessInvocation(IInvocation invocation);
    }
}
