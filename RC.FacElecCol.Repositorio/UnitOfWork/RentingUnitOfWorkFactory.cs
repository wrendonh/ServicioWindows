namespace RC.FacElecCol.Repositorio.UnitOfWork
{
    public class RentingUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork GetUnitOfWork()
        {
            return new RentingUnitOfWork();
        }
    }
}
