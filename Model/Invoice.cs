using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Model
{
    public class Invoice
    {
        public int Invoice_Id { get; set; }
        [Display(Name = "Invoice Date")]
        [Column(TypeName = "nvarchar(500)")]
        public string Invoice_Date  { get; set; }
        [Display(Name = "Invoice Description")]
        [Column(TypeName = "nvarchar(500)")]
        public string Invoice_Desc { get; set; }
        [Display(Name = "Department")]
        [Column(TypeName = "nvarchar(500)")]
        public string Department { get; set; }
        [Display(Name = "Supplier")]
        [Column(TypeName = "nvarchar(500)")]
        public string Supplier { get; set; }
        [Display(Name = "Total Balance")]
        [Column(TypeName = "nvarchar(500)")]
        public decimal Total_Balance { get; set; }
        [Display(Name = "Supplier Invoice")]
        [Column(TypeName = "nvarchar(500)")]
        public string Supplier_Invoice { get; set; }
    }
}
