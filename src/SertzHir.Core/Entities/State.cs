using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SertzHir.Core.Entities
{
    public class State
    {
        [Key]
        [Column("state_id")]
        public int StateId { get; set; }
        [Column("state_code", TypeName = "char")]
        [StringLength(2)]
        public string StateCode { get; set; }
    }
}
