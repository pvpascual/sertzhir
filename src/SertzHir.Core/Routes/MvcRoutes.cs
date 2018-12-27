using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Routes
{
    public class MvcRoutes
    {
        public const string PeoplePrefixRoute = "people";
        
        public const string PeopleIndexRoute = "index";
        public const string PeopleIndexRouteName = "People-Index";

        public const string PersonAddRoute = "add";
        public const string PersonAddRouteName = "Person-Add";

        public const string PersonEditRoute = "edit";
        public const string PersonEditRouteName = "Person-Edit";
        
        public const string PersonUpdateRoute = "update";
        public const string PersonUpdateRouteName = "Person-Update";

        public const string PeopleListRoute = "list";
        public const string PeopleListRouteName = "People-List";

        public const string PeopleListAllRoute = "list-all";
        public const string PeopleListAllRouteName = "People-List-All";

        public const string PersonGetByIdRoute = "get-by-id";
        public const string PersonGetByIdRouteName = "Person-Get-By-Id";

        public const string StatesPrefixRoute = "states";
        public const string StatesListAllRoute = "list-all";
        public const string StatesListAllRouteName = "State-List-All";
        public const string StatesListIndexRoute = "index";
        public const string StatesListIndexRouteName = "States-Index";

    }
}
