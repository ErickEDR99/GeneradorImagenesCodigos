using Codigos.Modelo.Entidades.Despachos;
using Codigos.Negocio.Contratos.Despachos;
using Codigos.Negocio.Negocios.Common;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Despachos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Negocio.Negocios.Despachos
{
    public class DespachoBusiness : GenericBusiness<Despacho>, IDespachoBusiness
    {
        private readonly IDespachoRepositorio _repo;

        public DespachoBusiness(IGenericRepository<Despacho> iGenericRepository, IDespachoRepositorio repo) : base()
        { 
            _repo = repo;
        }

        public List<Despacho> ObtenerTodos() {
            return _repo.GetAll();
        }

        /// <summary>
        /// Método para obtener los registros creados el dia actual
        /// </summary>
        /// <param name="fechaValidacioninicial"></param>
        /// <returns></returns>
        public List<Despacho> ObtenerTodosHoy(DateTime fechaValidacioninicial)
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
            return _repo.GetAllToday(1, fechaInicio, fechaFin);
        }
    }
}
