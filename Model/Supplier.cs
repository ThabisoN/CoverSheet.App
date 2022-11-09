using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Model
{
    public class Supplier
    {
        public int Supplier_Id { get; set; }
        [Display(Name = "Supplier Name")]
        [Column(TypeName = "nvarchar(500)")]
        public string Supplier_Name { get; set; }
        [Display(Name = "Supplier Description")]
        [Column(TypeName = "nvarchar(500)")]
        public string Supplier_Desc { get; set; }
        [Display(Name = "Bank Details")]
        [Column(TypeName = "nvarchar(500)")]
        public string Bank_Details { get; set; }

    }
}
