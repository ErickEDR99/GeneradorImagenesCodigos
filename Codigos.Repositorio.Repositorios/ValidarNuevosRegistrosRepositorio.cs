using Codigos.Modelo.Entidades.Componentes;
using Codigos.Modelo.Entidades.Generales;
using Codigos.Repositorio.ADO;
using Codigos.Repositorio.ADO.Common;
using Codigos.Repositorio.Contratos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Repositorio.Repositorios
{
    public class ValidarNuevosRegistrosRepositorio : IValidarNuevosRegistrosRepositorio
    {
        //public bool ValidarNuevosRegistros(out List<ImagenCodigo> objectArray, string ListaJson, int TipoConsulta)
        //{
        //    objectArray = [];
        //    bool resultado;
        //    MethodsDB methosDB = new();
        //    SqlParameter comandoTipoConsulta = new()
        //    {
        //        ParameterName = "@TipoConsulta",
        //        DbType = System.Data.DbType.Int32,
        //        Value = TipoConsulta
        //    };
        //    SqlParameter comandoListaJson = new()
        //    {
        //        ParameterName = "@ListaJson",
        //        DbType = System.Data.DbType.String,
        //        Value = ListaJson
        //    };

        //    try {
        //        //Unión de parametros
        //        IEnumerable<SqlParameter> parameters = new List<SqlParameter>(new List<SqlParameter> { comandoTipoConsulta, comandoListaJson});
        //        Respuesta respuestaSp = new BaseData().accesor.SpExcuteValidacion(out List<ImagenCodigo> ObjectArray, MethodsDB.QueryObtenerRegistrosaCrear, parameters);
        //    }
        //}
        public bool ValidarNuevosRegistros(out List<ImagenCodigo> objectArray, string ListaJson, int TipoConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
