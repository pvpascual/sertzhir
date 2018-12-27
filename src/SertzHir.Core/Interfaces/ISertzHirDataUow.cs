using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SertzHir.Core.Entities;

namespace SertzHir.Core.Interfaces
{
    public interface ISertzHirDataUow:IDisposable
    {
        IPersonRepository People { get; }
        IStateRepository States { get; }
      


        int SaveChanges();
    }
}
