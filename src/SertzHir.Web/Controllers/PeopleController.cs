using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchzHir.Web.ViewModels;
using SertzHir.Core;
using SertzHir.Core.Interfaces;
using SertzHir.Core.Interfaces.Services;
using SertzHir.Core.Models;
using SertzHir.Core.Routes;


namespace SearchzHir.Web.Controllers
{
    [Authorize]
    [RoutePrefix(MvcRoutes.PeoplePrefixRoute)]
    public class PeopleController : Controller
    {
       
        private readonly IApiHandler _apiHandler;


        public PeopleController(IApiHandler apiHandler)
        {
           _apiHandler = apiHandler;
        }
        
        /// <summary>
        /// Shows the list of all people on a page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(MvcRoutes.PeopleIndexRoute, Name=MvcRoutes.PeopleIndexRouteName)]
        public ActionResult Index()
        {

            try
            {
                var result = _apiHandler.GetAsync<List<PersonModel>>(ApiRoutes.PeopleApiPrefixRoute, ApiRoutes.PeopleApiGetAllListRoute);

                var peopleResult = result.Result.ToList();

                var peopleModelList = new List<PersonViewModel>();

                foreach (var item in peopleResult)
                {
                    peopleModelList.Add(new PersonViewModel
                    {
                        PersonId = item.PersonId
                        ,LastName=item.LastName
                        ,FirstName = item.FirstName
                        ,Gender=item.Gender
                        ,DateOfBirth = item.DateOfBirth
                        ,StateCode = item.StateCode
                    });
                }

                return View(peopleModelList);

            }
            catch (Exception e)
            {
               
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Get people list based on criteria
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(MvcRoutes.PeopleListRoute, Name = MvcRoutes.PeopleListRouteName)]
        public ActionResult GetPeopleList(string lastName, string firstName)
        {

            try
            {
                var urlParameters = new Dictionary<string, string>(){
                    {"lastName",lastName}
                    ,{"firstName",firstName}
                };

                var result = _apiHandler.GetAsync<List<PersonModel>>(ApiRoutes.PeopleApiPrefixRoute, ApiRoutes.PeopleApiGetListRoute,urlParameters);

                var peopleResult = result.Result.ToList();

                var peopleModelList = new List<PersonViewModel>();

                foreach (var item in peopleResult)
                {
                    peopleModelList.Add(new PersonViewModel
                    {
                        PersonId = item.PersonId
                        ,
                        LastName = item.LastName
                        ,
                        FirstName = item.FirstName
                        ,
                        Gender = item.Gender
                        ,
                        DateOfBirth = item.DateOfBirth
                        ,StateCode = item.StateCode
                    });
                }

                return Json(peopleModelList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Add a person
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(MvcRoutes.PersonAddRoute, Name = MvcRoutes.PersonAddRouteName)]
        public ActionResult AddPerson(PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _apiHandler.PostAsync<Result>(ApiRoutes.PeopleApiPrefixRoute, ApiRoutes.PersonApiAddRoute, model);


                    return RedirectToAction(MvcRoutes.PeopleIndexRoute, MvcRoutes.PeoplePrefixRoute);
                }
                else
                {
                    return View(model);
                }
               
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        /// <summary>
        /// Get the person record by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(MvcRoutes.PersonGetByIdRoute, Name = MvcRoutes.PersonGetByIdRouteName)]
        public ActionResult GetPersonById(int id)
        {
            try
            {
                var urlParameters = new Dictionary<string, string>(){
                    {"id",id.ToString()}
                };
                var result = _apiHandler.GetAsync<PersonModel>(ApiRoutes.PeopleApiPrefixRoute, ApiRoutes.PersonApiGetByIdRoute,urlParameters);

                var peopleResult = result.Result;

                var peopleModelList = new List<PersonViewModel>();

                return Json(peopleResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        
        /// <summary>
        /// Update the person record
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(MvcRoutes.PersonUpdateRoute, Name = MvcRoutes.PersonUpdateRouteName)]
        public ActionResult UpdatePerson(PersonViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _apiHandler.PutAsync<Result>(ApiRoutes.PeopleApiPrefixRoute, ApiRoutes.PersonApiUpdateRoute, model);


                    return RedirectToAction(MvcRoutes.PeopleIndexRoute, MvcRoutes.PeoplePrefixRoute);
                }
                else
                {
                    return View(model);
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


    }
}