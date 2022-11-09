using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Model
{
    public class Sheet
    {
        public int Sheet_Id { get; set; }
        [Display(Name = "Firstname")]
        [Column(TypeName = "nvarchar(500)")]
        public string Firstname { get; set; }
        [Display(Name = "Lastname")]
        [Column(TypeName = "nvarchar(500)")]
        public string Lastname { get; set; }
        [Display(Name = "Department")]
        [Column(TypeName = "nvarchar(500)")]
        public string Department { get; set; }
        public DateTime Invoice_Date { get; set; }
        public DateTime Payment_Date { get; set; }
        [Display(Name = "Supplier")]
        [Column(TypeName = "nvarchar(500)")]
        public string Supplier { get; set; }
        [Display(Name = "Bank Details")]
        [Column(TypeName = "nvarchar(500)")]
        public string Bank_Details { get; set; }
        [Display(Name = "Invoice Description")]
        [Column(TypeName = "nvarchar(500)")]
        public string Invoice_Desc { get; set; }
        [Display(Name = "Fullname")]
        [Column(TypeName = "nvarchar(500)")]
        public string Fullname { get; set; }
        [Display(Name = "Manager")]
        [Column(TypeName = "nvarchar(500)")]
        public string Manager { get; set; }
        [Display(Name = "Supplier Invoice")]
        [Column(TypeName = "nvarchar(500)")]
        public string Supplier_Invoice { get; set; }
        [Display(Name = "Proof of Payment")]
        [Column(TypeName = "nvarchar(500)")]
        public string Proof_of_Payment { get; set; }
    }
}
