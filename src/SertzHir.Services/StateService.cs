using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SertzHir.Core;
using SertzHir.Core.EntityMaps;
using SertzHir.Core.Interfaces;
using SertzHir.Core.Interfaces.Services;
using SertzHir.Core.Models;

namespace SertzHir.Services
{
    public class StateService:IStateService
    {
        private readonly ISertzHirDataUow _sertzHirDataUow;
        private readonly IUtility _utility;


        public StateService(ISertzHirDataUow sertzHirDataUow, IUtility utility)
        {
            _sertzHirDataUow = sertzHirDataUow;
            _utility = utility;

        }

        public Result AddState(StateModel stateModel)
        {
            throw new NotImplementedException();
        }

        public Result UpdateState(StateModel stateModel)
        {
            throw new NotImplementedException();
        }

        public Result GetStates()
        {
            try
            {
                
                //Get all states
                using (SertzHirDataDbContext context = new SertzHirDataDbContext())
                {
                    var results = context.Database.SqlQuery<StateEntityMap>(
                            "EXEC uspStatesList;")
                        .Select(q => new StateModel()
                        {
                            StateId=q.state_id
                            ,StateCode = q.state_code

                        }).ToList();


                    return new Result
                    {
                        Successful = true,
                        ObjectValue = results
                    };
                }


            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
