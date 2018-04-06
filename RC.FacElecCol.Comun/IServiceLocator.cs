namespace RC.FacElecCol.Comun
{
    public interface IServiceLocator
    {
        T Get<T>();
    }
}
