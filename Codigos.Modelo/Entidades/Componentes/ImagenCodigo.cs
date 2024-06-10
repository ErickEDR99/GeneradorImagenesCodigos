using Codigos.Modelo.Entidades.Generales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Modelo.Entidades.Componentes
{
    public class ImagenCodigo : EntidadBase
    {
        public int? Tipo { get; set; }

        public string? Elemento { get; set; }

        public string? URL { get; set; }

        public string? Usuario { get; set; }
    }
}
