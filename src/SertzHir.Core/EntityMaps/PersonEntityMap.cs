using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.EntityMaps
{
    public class PersonEntityMap
    {
        public int person_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }

        public DateTime dob { get; set; }
        public int state_id { get; set; }
        public string state_code { get; set; }

    }
}
