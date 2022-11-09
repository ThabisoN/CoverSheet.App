using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Model
{
    public class Manager
    {
        public int Manager_Id { get; set; }
        [Display(Name = "Firstname")]
        [Column(TypeName = "nvarchar(500)")]
        public string Firstname { get; set; }
        [Display(Name = "Lastname")]
        [Column(TypeName = "nvarchar(500)")]
        public string Lastname { get; set; }
        [Display(Name = "Department ")]
        [Column(TypeName = "nvarchar(500)")]
        public string Department { get; set; }
        [Display(Name = "Department ")]
        [Column(TypeName = "nvarchar(500)")]
        public string Manager_Signature { get; set; }
    }
}
