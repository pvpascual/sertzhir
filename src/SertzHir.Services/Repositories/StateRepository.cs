using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SertzHir.Core.Entities;
using SertzHir.Core.Interfaces;

namespace SertzHir.Services.Repositories
{
    public class StateRepository : SertzHirRepository<State>, IStateRepository
    {
        public SertzHirDataDbContext context
        {
            get
            {
                return Db as SertzHirDataDbContext;
            }
        }

        public StateRepository(SertzHirDataDbContext sertzHirDataDbContext) : base(sertzHirDataDbContext)
        {

        }
    }
}
