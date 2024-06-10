using Codigos.Modelo.Entidades.Despachos;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.Contratos.Despachos;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Codigos.Repositorio.Repositorios.Despachos
{
    public class DespachoRepositorio : IDespachoRepositorio
    {
        public DespachoRepositorio() { }

        public long Create(Despacho item)
        {
            throw new NotImplementedException();
        }

        public long Delete(Despacho item)
        {
            throw new NotImplementedException();
        }

        public List<Despacho> GetAll()
        {
            List<Despacho> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryObtenerBandejaPaginado);
            lista = JsonConvert.DeserializeObject<List<Despacho>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public List<Despacho> GetAllToday(int tipoConsulta, string fechainicio, string fechaFin)
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


            List<Despacho> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryValidarRegistrosNuevos, parameters);
            lista = JsonConvert.DeserializeObject<List<Despacho>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public Despacho GetId(long nId)
        {
            throw new NotImplementedException();
        }

        public long Update(Despacho item)
        {
            throw new NotImplementedException();
        }
    }
}
