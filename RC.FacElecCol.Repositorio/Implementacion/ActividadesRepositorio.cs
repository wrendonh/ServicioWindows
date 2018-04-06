namespace RC.FacElecCol.Repositorio.Implementacion
{
    using System.Collections.Generic;
    using System.Linq;
    using Modelo.Entidades;
    using Modelo.Entidades.RentingModel;
    using Interfaz;

    public static class ActividadesRepositorio
    {
        public static List<FeCActividades> CargarTodo(this IGenericRepository<FeCActividades> repository)
        {
            IEnumerable<FeCActividades> actividades = from act in repository.GetAll()
                                                       select act;

            return actividades.ToList();
        }
    }
}
