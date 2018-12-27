using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SertzHir.Core.Entities;
using SertzHir.Core.Interfaces;
using SertzHir.Services.Repositories;

namespace SertzHir.Services
{
    public class SertzHirDataUow : ISertzHirDataUow
    {
        private readonly SertzHirDataDbContext _sertzHirDataDbContext;

        public SertzHirDataUow()
        {
            _sertzHirDataDbContext = new SertzHirDataDbContext();
        }

        private IPersonRepository _people;
        public IPersonRepository People
        {
            get
            {
                if (this._people == null)
                {
                    this._people = new PersonRepository(_sertzHirDataDbContext);
                }
                return this._people;
            }
        }

        private IStateRepository _states;
        public IStateRepository States
        {
            get
            {
                if (this._states == null)
                {
                    this._states = new StateRepository(_sertzHirDataDbContext);
                }
                return this._states;
            }
        }


        public int SaveChanges()
        {
            return _sertzHirDataDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _sertzHirDataDbContext.Dispose();
        }

        public SertzHirDataDbContext GetDbContext()
        {
            return _sertzHirDataDbContext;
        }
        

    }
}
