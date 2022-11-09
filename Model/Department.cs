using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Model
{
    public class Department
    {
        public int Department_Id { get; set; }
        [Display(Name = "Department Name")]
        [Column(TypeName = "nvarchar(500)")]
        public string Department_Name { get; set; }
    }
}
