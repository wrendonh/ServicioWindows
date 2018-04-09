namespace RC.FacElecCol.Dependencia
{
    using Comun;
    using Fachada.Implementacion;
    using Fachada.Interfaz;
    using Microsoft.Practices.Unity;
    using ReglasNegocio.Implementacion;
    using ReglasNegocio.Interfaz;
    using Repositorio.UnitOfWork;

    public class UnityRegistrationModule : IContainerRegistrationModule<IUnityContainer>
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IServiceLocator, CustomUnityServiceLocator>();
            
            container.RegisterType<IActividadesFachada, ActividadesFachada>();
            container.RegisterType<IActividadesRn, ActividadesRn>();
                        
            container.RegisterType<IUnitOfWorkFactory, RentingUnitOfWorkFactory>();
        }
    }
}
