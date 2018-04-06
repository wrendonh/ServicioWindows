namespace RC.FacElecCol.Comun
{
    using Microsoft.Practices.Unity;

    public class CustomUnityServiceLocator : DependencyInjectionServiceLocator<IUnityContainer>
    {
        public CustomUnityServiceLocator(IUnityContainer container) : base(container)
        {

        }

        protected override T Get<T>(IUnityContainer container)
        {
            return Container.Resolve<T>();
        }
    }
}
