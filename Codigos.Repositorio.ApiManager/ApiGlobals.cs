using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigos.Repositorio.ApiManager
{
    public class ApiGlobals
    {
        private readonly IConfiguration configuration;

        public ApiGlobals(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
