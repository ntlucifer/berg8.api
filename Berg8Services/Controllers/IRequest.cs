using System;
namespace api.Controllers
{
    public interface IUIAction<T>
    {
        T Initialized(IFilter filter);
        T Add(IFilter filter);
        T Update(IFilter filter);
        T Delete(IFilter filter);
    }
    public interface IFilter
    {
        
    }
}
