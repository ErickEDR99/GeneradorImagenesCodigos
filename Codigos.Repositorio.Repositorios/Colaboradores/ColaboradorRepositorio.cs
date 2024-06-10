using Codigos.Modelo.Entidades.Colaboradores;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.Contratos.Colaboradores;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Codigos.Repositorio.Repositorios.Colaboradores
{
    public class ColaboradorRepositorio : IColaboradorRepositorio
    {
        public ColaboradorRepositorio() { }

        public long Create(Colaborador item)
        {
            throw new NotImplementedException();
        }

        public long Delete(Colaborador item)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> GetAll()
        {
            List<Colaborador> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryObtenerBandejaPaginado);
            lista = JsonConvert.DeserializeObject<List<Colaborador>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public List<Colaborador> GetAllToday(int tipoConsulta, string fechainicio, string fechaFin)
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


            List<Colaborador> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryValidarRegistrosNuevos, parameters);
            lista = JsonConvert.DeserializeObject<List<Colaborador>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public Colaborador GetId(long nId)
        {
            throw new NotImplementedException();
        }

        public long Update(Colaborador item)
        {
            throw new NotImplementedException();
        }
    }
}
