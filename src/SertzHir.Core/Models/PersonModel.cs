using System;
using System.Collections.Generic;
using System.Text;

namespace SertzHir.Core.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StateId { get; set; }
        public string StateCode { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
