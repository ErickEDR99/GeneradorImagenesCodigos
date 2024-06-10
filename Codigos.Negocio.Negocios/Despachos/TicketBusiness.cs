using Codigos.Modelo.Entidades.Despachos;
using Codigos.Negocio.Contratos.Despachos;
using Codigos.Negocio.Negocios.Common;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Despachos;

namespace Codigos.Negocio.Negocios.Despachos
{
    public class TicketBusiness : GenericBusiness<Ticket>, ITicketBusiness
    {
        private readonly ITicketRepositorio _repo;

        public TicketBusiness(IGenericRepository<Ticket> iGenericRepository, ITicketRepositorio repo) : base()
        {
            _repo = repo;
        }

        public List<Ticket> ObtenerTodos()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Método para obtener los registros creados el dia actual
        /// </summary>
        /// <param name="fechaValidacioninicial"></param>
        /// <returns></returns>
        public List<Ticket> ObtenerTodosHoy(DateTime fechaValidacioninicial)
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
            return _repo.GetAllToday(2, fechaInicio, fechaFin);
        }
    }
}
