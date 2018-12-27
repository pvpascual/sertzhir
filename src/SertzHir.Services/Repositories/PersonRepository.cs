using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using SertzHir.Core.Entities;
using SertzHir.Core.Interfaces;

namespace SertzHir.Services.Repositories
{
    
    public class PersonRepository :SertzHirRepository<Person>, IPersonRepository
    {
       
        public SertzHirDataDbContext context
        {
            get
            {
                return Db as SertzHirDataDbContext;
            }
        }

        public PersonRepository(SertzHirDataDbContext sertzHirDataDbContext) : base(sertzHirDataDbContext)
        {
            
        }


    }
   
}
