using Codigos.Modelo.Entidades.Despachos;
using Codigos.Modelo.Entidades.Vehiculos;
using Codigos.Negocio.Contratos.Vehiculos;
using Codigos.Negocio.Negocios.Common;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Vehiculos;

namespace Codigos.Negocio.Negocios.Vehiculos
{
    public class VehiculoBusiness : GenericBusiness<Vehiculo>, IVehiculoBusiness
    {
        private readonly IVehiculoRepositorio _repo;

        public VehiculoBusiness(IGenericRepository<Vehiculo> iGenericRepository, IVehiculoRepositorio repo) : base() 
        {
            _repo = repo;
        }

        public List<Vehiculo> ObtenerTodos() 
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Método para obtener los registros creados el dia actual
        /// </summary>
        /// <param name="fechaValidacioninicial"></param>
        /// <returns></returns>
        public List<Vehiculo> ObtenerTodosHoy(DateTime fechaValidacioninicial)
        {
            //Variables para crear parametros SP
            DateTime fechaValidacionFin = new DateTime();
            fechaValidacionFin = fechaValidacioninicial.AddDays(1);
            string fechaInicio = fechaValidacioninicial.ToString("dd-MM-yyyy 00:00:00");
            string fechaFin = fechaValidacionFin.ToString("dd-MM-yyyy 00:00:00");
            //--Tipo consulta:
            //--Despacho: 1
            //--Ticket: 2
            //--Vehiculo: 3
            //--Colaborador: 4
            return _repo.GetAllToday(3, fechaInicio, fechaFin);
        }
    }
}
