namespace RC.FacElecCol.Repositorio.UnitOfWork
{
    using Implementacion;
    using Interfaz;
    using ModeloDatos;
    using System;
    using System.Data.Entity;

    public class RentingUnitOfWork : IUnitOfWork
    {
        private readonly RentingModel _myDbContext = new RentingModel();
        private DbContextTransaction _myDbContextTransaction;
        private bool _myDisposed;
        
        public IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_myDbContext);
        }

        public void BeginTransaction()
        {
            _myDbContextTransaction = _myDbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            _myDbContextTransaction.Commit();
        }

        protected void Dispose(bool disposing)
        {
            if (!_myDisposed && disposing)
            {
                _myDbContext.Dispose();
                _myDbContextTransaction?.Dispose();
            }
            _myDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void RollBack()
        {
            _myDbContextTransaction.Rollback();
        }

        public int Save()
        {
            return _myDbContext.SaveChanges();
        }

       
    }
}
