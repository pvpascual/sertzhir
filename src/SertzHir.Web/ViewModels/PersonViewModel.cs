using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchzHir.Web.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        [Required()]
        public string FirstName { get; set; }
        [Required()]
        public string LastName { get; set; }
        [Required(ErrorMessage = "State ID is required")]
        public int StateId { get; set; }
        public string StateCode { get; set; }
        [Required()]
        public string Gender { get; set; }
        [Required()]
        public DateTime DateOfBirth { get; set; }
    }
}