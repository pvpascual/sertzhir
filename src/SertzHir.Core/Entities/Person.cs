using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Entities
{
    public class Person
    {
        [Key]
        [Column("person_id")]
        public int PersonId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("gender", TypeName = "char")]
        [StringLength(1)]
        public string Gender { get; set; }
        [Column("dob")]
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("State")]
        [Column("state_id")]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
