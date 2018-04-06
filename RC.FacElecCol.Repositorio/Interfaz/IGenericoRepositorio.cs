namespace RC.FacElecCol.Repositorio.Interfaz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<TEntity>
    {
        TEntity Get(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        void Insert(TEntity item);

        void InsertAndSave(TEntity item);

        void InsertRange(IEnumerable<TEntity> item);

        void UpdateAndSave(TEntity item);

        void Update(TEntity item);

        void Update(TEntity current, TEntity modified);

        void Delete(TEntity item);

        void DeleteRange(Expression<Func<TEntity, bool>> predicate);

        IQueryable<T> GetRepository<T>() where T : class;

        IQueryable<TEntity> GetWithRawSql(string query, params object[] parameters);

        int ExecuteSqlCommand(string query, params object[] parameters);

        IEnumerable<T> ExecuteCustomStoredProc<T>(string commandName, params object[] parameters);

        int Save();
    }
}
