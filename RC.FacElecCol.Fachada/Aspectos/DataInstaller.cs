namespace RC.FacElecCol.Fachada.Aspectos
{
    using Aspecto;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Implementacion;
    using Interfaz;

    public class DataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container.ResolveAll(typeof(ExcepcionAttribute)).Length == 0)
            {
                container.Register(Component.For<ExcepcionAttribute>());
            }
            
            InstallSpecificAspect(container);
        }

        public void InstallSpecificAspect(IWindsorContainer container)
        {
            container.Register(Component.For<IActividadesFachada>().ImplementedBy<ActividadesFachada>().Interceptors(typeof(ExcepcionAttribute)));
            container.Register(Component.For<IActividadesPeriodicasFachada>().ImplementedBy<ActividadesPeriodicasFachada>().Interceptors(typeof(ExcepcionAttribute)));           
        }
    }
}
