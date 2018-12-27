using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Routes
{
    public class ApiRoutes
    {
        public const string PeopleApiPrefixRoute = "api/people";
        public const string PeopleApiPrefixRouteName = "Api-People-Prefix";

        public const string PersonApiAddRoute = "add-person";
        public const string PersonApiAddRouteName = "Api-Person-Add";

        public const string PersonApiUpdateRoute = "update-person";
        public const string PersonApiUpdateRouteName = "Api-Person-Update";

        public const string PersonApiGetByIdRoute = "get-person";
        public const string PersonApiGetByIdRouteName = "Api-Person-Get";

        public const string PeopleApiGetListRoute = "list";
        public const string PeopleApiGetListRouteName = "Api-People-List";

        public const string PeopleApiGetAllListRoute = "list-all";
        public const string PeopleApiGetAllListRouteName = "Api-People-List-All";

        public const string StatesApiPrefixRoute = "api/states";
        public const string StatesApiPrefixRouteName = "Api-States-Prefix";

        public const string StatesApiGetListRoute = "list";
        public const string StatesApiGetListRouteName = "Api-States-List";


    }
}
