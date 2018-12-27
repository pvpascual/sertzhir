using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchzHir.Web.ViewModels;
using SertzHir.Core.Interfaces;
using SertzHir.Core.Routes;

namespace SearchzHir.Web.Controllers
{
    [Authorize]
    [RoutePrefix(MvcRoutes.StatesPrefixRoute)]
    public class StateController : Controller
    {
        private readonly IApiHandler _apiHandler;

        public StateController(IApiHandler apiHandler)
        {
            _apiHandler = apiHandler;

        }
        
        /// <summary>
        /// Get states list and show the page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(MvcRoutes.StatesListIndexRoute,Name=MvcRoutes.StatesListIndexRouteName)]
        public ActionResult Index()
        {
            try
            {
                var result = _apiHandler.GetAsync<List<StateViewModel>>(ApiRoutes.StatesApiPrefixRoute, ApiRoutes.StatesApiGetListRoute);

                var stateResult = result.Result.ToList();

                var stateModelList = new List<StateViewModel>();

                foreach (var item in stateResult)
                {
                    stateModelList.Add(new StateViewModel
                    {
                        StateId = item.StateId
                        ,
                        StateCode = item.StateCode

                    });
                }

                return View(stateModelList);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// Get state list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(MvcRoutes.StatesListAllRoute,Name=MvcRoutes.StatesListAllRouteName)]
        public ActionResult GetStatesList()
        {
            try
            {
                var result = _apiHandler.GetAsync<List<StateViewModel>>(ApiRoutes.StatesApiPrefixRoute, ApiRoutes.StatesApiGetListRoute);

                var stateResult = result.Result.ToList();

                var stateModelList = new List<StateViewModel>();

                foreach (var item in stateResult)
                {
                    stateModelList.Add(new StateViewModel
                    {
                      StateId = item.StateId
                        ,StateCode=item.StateCode
                   
                    });
                }

                return Json(stateModelList, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}