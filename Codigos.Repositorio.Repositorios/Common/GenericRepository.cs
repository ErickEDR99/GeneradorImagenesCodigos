using Codigos.Modelo.Entidades.Generales;
using Codigos.Repositorio.Contratos.Common;
using System;
using System.Collections.Generic;

namespace Codigos.Repositorio.Repositorios.Common
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable
                where T : class, IEntidadBase
    {
        public GenericRepository()
        {
        }

        public long Create(T item)
        {
            throw new NotImplementedException();
        }

        public long Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAllToday(int tipoConsulta, string fechainicio, string fechaFin)
        {
            throw new NotImplementedException();
        }

        public T GetId(long nId)
        {
            throw new NotImplementedException();
        }

        public long Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
