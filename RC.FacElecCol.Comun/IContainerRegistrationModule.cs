namespace RC.FacElecCol.Comun
{
    public interface IContainerRegistrationModule<in T>
    {
        void Register(T container);
    }
}
