using Codigos.Modelo.Entidades.Componentes;
using Codigos.Modelo.Entidades.Generales;
using Codigos.Negocio.Contratos.Componentes;
using Codigos.Negocio.Negocios.Common;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Componentes;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Codigos.Negocio.Negocios.Componentes
{
    public class ImagenCodigoBusiness : GenericBusiness<ImagenCodigo>, IImagenCodigoBusiness
    {
        private readonly IImagenCodigoRepositorio _repo;

        public ImagenCodigoBusiness(IGenericRepository<ImagenCodigo> iGenericRepository, IImagenCodigoRepositorio repo) : base() 
        { 
            _repo = repo;
        }

        public List<ImagenCodigo> ObtenerTodos()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Método para obtener los registros creados el dia actual
        /// </summary>
        /// <param name="fechaValidacioninicial"></param>
        /// <returns></returns>
        public List<ImagenCodigo> ObtenerTodosHoy(DateTime fechaValidacioninicial)
        {
            //Variables para crear parametros SP
            DateTime fechaValidacionFin = new DateTime();
            fechaValidacionFin = fechaValidacioninicial.AddDays(2);
            string fechaInicio = fechaValidacioninicial.ToString("dd-MM-yyyy 00:00:00");
            string fechaFin = fechaValidacionFin.ToString("dd-MM-yyyy 00:00:00");
            //--Tipo consulta:
            //--Despacho: 1
            //--Ticket: 2
            //--Vehiculo: 3
            //--Colaborador: 4
            return _repo.GetAllToday(0, fechaInicio, fechaFin);
        }

        /// <summary>
        /// Método para crear o actualizar un registro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Respuesta GuardarRevivirRegistro(List<ImagenCodigo> lstImgCod)
        {
            Respuesta req = new Respuesta();
            string Json = JsonConvert.SerializeObject(lstImgCod);
            req.Data = Json;

            return _repo.CreateUpdate(req);
        }

    }
}
