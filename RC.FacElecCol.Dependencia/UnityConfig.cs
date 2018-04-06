namespace RC.FacElecCol.Dependencia
{
    using Comun;
    using Microsoft.Practices.Unity;
    using System;
    using System.Configuration;

    public static class UnityConfig
    {
        public static IUnityContainer GetUnityContainer()
        {
            return Container.Value;
        }

        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            UnityContainer container;
            using (container = new UnityContainer())
            {
                RegisterTypes(container);
            }
            return container;
        });

        public static void RegisterTypes(IUnityContainer container)
        {
            var registrationModuleAssemblyName = ConfigurationManager.AppSettings["UnityRegistrationModule"];

            var type = Type.GetType(registrationModuleAssemblyName);

            var module = (IContainerRegistrationModule<IUnityContainer>)Activator.CreateInstance(type);

            module.Register(container);
        }
    }
}
