using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Interfaces
{
    public interface IUtility
    {
        bool IsClearFromSqlInjection(string param);
    }
}
