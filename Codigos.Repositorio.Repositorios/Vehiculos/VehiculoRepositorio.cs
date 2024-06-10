using Codigos.Modelo.Entidades.Despachos;
using Codigos.Modelo.Entidades.Vehiculos;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.Contratos.Common;
using Codigos.Repositorio.Contratos.Vehiculos;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Codigos.Repositorio.Repositorios.Vehiculos
{
    public class VehiculoRepositorio : IVehiculoRepositorio
    {
        public VehiculoRepositorio() { }

        public long Create(Vehiculo item)
        {
            throw new NotImplementedException();
        }

        public long Delete(Vehiculo item)
        {
            throw new NotImplementedException();
        }

        public List<Vehiculo> GetAll()
        {
            List<Vehiculo> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryObtenerBandejaPaginado);
            lista = JsonConvert.DeserializeObject<List<Vehiculo>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public List<Vehiculo> GetAllToday(int tipoConsulta, string fechainicio, string fechaFin)
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


            List<Vehiculo> lista = [];
            var respuestaSP = new BaseData().accesor.SpExcuteJson(MethodsDB.QueryValidarRegistrosNuevos, parameters);
            lista = JsonConvert.DeserializeObject<List<Vehiculo>>((string)respuestaSP.Data) ?? [];
            return lista;
        }

        public Vehiculo GetId(long nId)
        {
            throw new NotImplementedException();
        }

        public long Update(Vehiculo item)
        {
            throw new NotImplementedException();
        }
    }
}
