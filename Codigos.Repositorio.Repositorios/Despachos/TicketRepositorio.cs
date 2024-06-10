using Codigos.Modelo.Entidades.Despachos;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.Contratos.Despachos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Codigos.Repositorio.Repositorios.Despachos
{
    public class TicketRepositorio : ITicketRepositorio
    {
        public TicketRepositorio() { }

        public long Create(Ticket item)
        {
            throw new NotImplementedException();
        }

        public long Delete(Ticket item)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ticket GetId(long nId)
        {
            throw new NotImplementedException();
        }

        public long Update(Ticket item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementación para obtener una lista de registros insertados en el día actual
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="fechainicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>
        public List<Ticket> GetAllToday(int tipoConsulta, string fechainicio, string fechaFin) {
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


            List<Ticket> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryValidarRegistrosNuevos, parameters);
            lista = JsonConvert.DeserializeObject<List<Ticket>>((string)respuestaSP.Data) ?? [];
            return lista;
        }
    }
}
