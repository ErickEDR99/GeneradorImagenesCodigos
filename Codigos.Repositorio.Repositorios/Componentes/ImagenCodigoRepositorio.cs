using Codigos.Modelo.Entidades.Componentes;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.Contratos.Componentes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codigos.Modelo.Entidades.Generales;
using Microsoft.Data.SqlClient;
using Codigos.Modelo.Entidades.Despachos;
using Azure.Core;

namespace Codigos.Repositorio.Repositorios.Componentes
{
    public class ImagenCodigoRepositorio : IImagenCodigoRepositorio
    {
        public ImagenCodigoRepositorio() { }

        public long Create(ImagenCodigo item)
        {
            // Objeto a devolver al generar la consulta
            Respuesta respuesta = new Respuesta("GuardarRegistro");

            try
            {
                SqlParameter comandoLista = new SqlParameter();

                List<ImagenCodigo> lista = new() { item };
                string listaJson = JsonConvert.SerializeObject(lista);
                comandoLista.ParameterName = "@Lista";
                comandoLista.DbType = System.Data.DbType.String;
                comandoLista.Value = listaJson;


                IEnumerable<SqlParameter> parameters = new List<SqlParameter>(new List<SqlParameter> { comandoLista });


                var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryInsertarActualizarBandejas, parameters);
                if (respuestaSP != null)
                {
                    respuesta.Data = item;
                    respuesta.TotalRows = respuestaSP.TotalRows;
                    respuesta.Message = respuestaSP.Data.ToString();
                    respuesta.PageIndex = null;
                    respuesta.PageSize = null;
                    respuesta.Status = 200;
                    respuesta.Function = "GuardarRegistro";
                    respuesta.timeMeasure.Stop();
                }
                else
                {
                    respuesta.Status = 400;
                    respuesta.Message = "Ha ocurrido un error en la ejecución del SP";
                    respuesta.timeMeasure.Stop();
                }
            }
            catch (Exception e)
            {
                respuesta.Status = 500;
                respuesta.Message = e.Message.ToString();
                throw;
            }
            return item.Id;
        }

        public long Delete(ImagenCodigo item)
        {
            throw new NotImplementedException();
        }

        public List<ImagenCodigo> GetAll()
        {
            List<ImagenCodigo> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryObtenerBandejaPaginado);
            lista = JsonConvert.DeserializeObject<List<ImagenCodigo>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        /// <summary>
        /// Implementación para obtener una lista de registros insertados en el día actual
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="fechainicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public List<ImagenCodigo> GetAllToday(int tipoConsulta, string fechainicio, string fechaFin)
        {
            //Parametros necesarios            
            SqlParameter comandoTipoConsulta = new SqlParameter();
            SqlParameter comandoDateInital = new SqlParameter();
            SqlParameter comandoDateFin = new SqlParameter();

            comandoTipoConsulta.ParameterName = "@tipoConsulta";
            comandoTipoConsulta.DbType = System.Data.DbType.Int32;
            comandoTipoConsulta.Value = tipoConsulta;

            comandoDateInital.ParameterName = "@dateInitial";
            comandoDateInital.DbType = System.Data.DbType.DateTime;
            comandoDateInital.Value = fechainicio;

            comandoDateFin.ParameterName = "@dateFin";
            comandoDateFin.DbType = System.Data.DbType.DateTime;
            comandoDateFin.Value = fechaFin;
            //Unión de parametros
            IEnumerable<SqlParameter> parameters = new List<SqlParameter>(new List<SqlParameter> { comandoTipoConsulta, comandoDateInital, comandoDateFin });


            List<ImagenCodigo> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryValidarRegistrosNuevos, parameters);
            lista = JsonConvert.DeserializeObject<List<ImagenCodigo>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public ImagenCodigo GetId(long nId)
        {
            throw new NotImplementedException();
        }

        public long Update(ImagenCodigo item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementación para insertar actualizar registros
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Respuesta CreateUpdate(Respuesta request) 
        {
            // Objeto a devolver al generar la consulta
            Respuesta respuesta = new Respuesta("GuardarRevivirRegistro");
            //Deserealizamos el objeto recibido        
            try
            {
                SqlParameter comandoLista = new SqlParameter();


                comandoLista.ParameterName = "@Lista";
                comandoLista.Value = request.Data != null ? request.Data.ToString() : null;
                comandoLista.DbType = System.Data.DbType.String;


                IEnumerable<SqlParameter> parameters = new List<SqlParameter>(new List<SqlParameter> { comandoLista });


                var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryInsertarActualizarImagenesCodigos, parameters);
                if (respuestaSP != null)
                {
                    respuesta.Data = request.Data;
                    respuesta.TotalRows = respuestaSP.TotalRows;
                    respuesta.Message = respuestaSP.Data.ToString();
                    respuesta.PageIndex = null;
                    respuesta.PageSize = 1;
                    respuesta.Status = 200;
                    respuesta.Function = "GuardarRevivirRegistro";
                    respuesta.timeMeasure.Stop();
                }
                else
                {
                    respuesta.Status = 400;
                    respuesta.Message = "Ha ocurrido un error en la ejecución del SP";
                    respuesta.timeMeasure.Stop();
                }
            }
            catch (Exception e)
            {
                respuesta.Status = 500;
                respuesta.Message = e.Message.ToString();
                throw;
            }

            // Devuelve el objeto de respuesta
            return respuesta;
        }
    }
}
