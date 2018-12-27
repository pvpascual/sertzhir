using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SertzHir.Core.Interfaces.Services;
using SertzHir.Core.Routes;

namespace SertzHir.Api.Controllers
{
    [RoutePrefix(ApiRoutes.StatesApiPrefixRoute)]
    public class StateController : ApiController
    {
        
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
           _stateService = stateService;
        }

        public StateController()
        {

        }

        /// <summary>
        /// Get all states list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.StatesApiGetListRoute, Name = ApiRoutes.StatesApiGetListRouteName)]
        public IHttpActionResult GetStates()
        {
            try
            {
                var result = _stateService.GetStates();

                return Ok(result.ObjectValue);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
