namespace RC.FacElecCol.Repositorio.UnitOfWork
{
    using Interfaz;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class;

        void Commit();

        int Save();

        void BeginTransaction();

        void RollBack();
    }
}
