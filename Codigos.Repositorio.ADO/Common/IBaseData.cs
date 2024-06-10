

namespace Codigos.Repositorio.ADO.Common
{
    public interface IBaseData : IDisposable
    {
        IAccessor accesor { get; }
    }
}
