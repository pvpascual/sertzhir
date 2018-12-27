using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SertzHir.Core;
using SertzHir.Core.Interfaces.Services;
using SertzHir.Core.Models;
using SertzHir.Core.Routes;

namespace SertzHir.Api.Controllers
{
    [RoutePrefix(ApiRoutes.PeopleApiPrefixRoute)]
    public class PeopleController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly IStateService _stateService;

        public PeopleController(IPersonService personService, IStateService stateService)
        {
            _personService = personService;
            _stateService = stateService;
        }

        public PeopleController()
        {
          
        }


        /// <summary>
        /// Get list of people based on search criteria
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.PeopleApiGetListRoute,Name=ApiRoutes.PeopleApiGetListRouteName)]
        public IHttpActionResult GetList(string lastName, string firstName)
        {
            try
            {
                var result = _personService.GetPeople(lastName,firstName);

                return Ok(result.ObjectValue);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Get all people list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.PeopleApiGetAllListRoute, Name = ApiRoutes.PeopleApiGetAllListRouteName)]
        public IHttpActionResult GetAllList()
        {
            try
            {
                var result = _personService.GetPeopleList();

                return Ok(result.ObjectValue);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// Get person record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiRoutes.PersonApiGetByIdRoute, Name = ApiRoutes.PersonApiGetByIdRouteName)]
        public IHttpActionResult GetPersonById(int id)
        {
            try
            {
                var result = _personService.GetPersonById(id);

                return Ok(result.ObjectValue);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Add a person record
        /// </summary>
        /// <param name="personModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.PersonApiAddRoute, Name = ApiRoutes.PersonApiAddRouteName)]
        public IHttpActionResult AddPerson([FromBody]PersonModel personModel)
        {
            try
            {
                var result=_personService.AddPerson(personModel);
                return Ok(result);


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

        /// <summary>
        /// Update a person record
        /// </summary>
        /// <param name="personModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route(ApiRoutes.PersonApiUpdateRoute, Name = ApiRoutes.PersonApiUpdateRouteName)]
        public IHttpActionResult UpdatePerson([FromBody]PersonModel personModel)
        {
            try
            {
                var result = _personService.UpdatePerson(personModel);
                return Ok(result);


            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }
    }
}
