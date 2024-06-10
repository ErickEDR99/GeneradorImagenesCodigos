using Codigos.Modelo.Entidades.Colaboradores;
using Codigos.Modelo.Entidades.Despachos;
using Codigos.Negocio.Contratos.Colaboradores;
using Codigos.Negocio.Negocios.Common;
using Codigos.Repositorio.Contratos.Colaboradores;
using Codigos.Repositorio.Contratos.Common;

namespace Codigos.Negocio.Negocios.Colaboradores
{
    public class ColaboradorBusiness : GenericBusiness<Colaborador>, IColaboradorBusiness
    {
        private readonly IColaboradorRepositorio _repo;

        public ColaboradorBusiness(IGenericRepository<Colaborador> iGenericRepository, IColaboradorRepositorio repo) : base() 
        {
            _repo = repo;
        }

        public List<Colaborador> ObtenerTodos() {
            return _repo.GetAll();
        }

        /// <summary>
        /// Método para obtener los registros creados el dia actual
        /// </summary>
        /// <param name="fechaValidacioninicial"></param>
        /// <returns></returns>
        public List<Colaborador> ObtenerTodosHoy(DateTime fechaValidacioninicial)
        {
            //Variables para crear parametros SP
            DateTime fechaValidacionFin = new DateTime();
            fechaValidacionFin = fechaValidacioninicial.AddDays(1);
            string fechaInicio = fechaValidacioninicial.ToString("yyyy-MM-ddT00:00:00");
            string fechaFin = fechaValidacionFin.ToString("yyyy-MM-ddT00:00:00");
            //--Tipo consulta:
            //--Despacho: 1
            //--Ticket: 2
            //--Vehiculo: 3
            //--Colaborador: 4
            return _repo.GetAllToday(4, fechaInicio, fechaFin);
        }
    }
}
