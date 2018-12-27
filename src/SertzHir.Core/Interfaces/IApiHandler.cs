using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Interfaces
{
    public interface IApiHandler
    {
        Task<T> GetAsync<T>(string routePrefix, string route, Dictionary<string, string> urlParameters, string personId);
        Task<T> GetAsync<T>(string routePrefix, string route, Dictionary<string, string> urlParameters);

        Task<T> GetAsync<T>(string routePrefix, string route);

        Task<T> PostAsync<T>(string routePrefix, string route, Object obj);
        Task<T> PutAsync<T>(string routePrefix, string route, Object obj);


    }
}
