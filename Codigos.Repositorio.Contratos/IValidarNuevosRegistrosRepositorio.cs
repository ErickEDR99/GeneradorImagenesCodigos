using Codigos.Modelo.Entidades.Componentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Repositorio.Contratos
{
    public interface IValidarNuevosRegistrosRepositorio
    {
        public bool ValidarNuevosRegistros(out List<ImagenCodigo> objectArray, string ListaJson, int TipoConsulta);
    }
}
