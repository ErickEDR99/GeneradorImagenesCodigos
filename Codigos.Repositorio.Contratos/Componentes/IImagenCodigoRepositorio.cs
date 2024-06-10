using Codigos.Modelo.Entidades.Componentes;
using Codigos.Modelo.Entidades.Generales;
using Codigos.Repositorio.Contratos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Repositorio.Contratos.Componentes
{
    public interface IImagenCodigoRepositorio : IGenericRepository<ImagenCodigo>
    {
       public Respuesta CreateUpdate(Respuesta res);
    }
}
