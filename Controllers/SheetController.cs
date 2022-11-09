using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlatinumLifeSheet.App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheetController : ControllerBase
    {
        private readonly IConfiguration _configurration;
        private readonly IWebHostEnvironment _env;

        public SheetController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configurration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             select Sheet_Id, Firstname, Lastname, Department,Invoice_Date, Payment_Date, Supplier, Bank_Details,Invoice_Desc, Fullname, Manager, Supplier_Invoice, Proof_of_Payment from dbo.Sheet
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Sheet st)
        {
            string query = @"
                             insert into dbo.Sheet 
                             (Firstname, Lastname, Department,Invoice_Date, Payment_Date, Supplier, Bank_Details, Invoice_Desc, Fullname, Manager, Supplier_Invoice, Proof_of_Payment )
                      values (@Firstname, @Lastname, @Department, @Invoice_Date, @Payment_Date, @Supplier, @Bank_Details, @Invoice_Desc, @Fullname, @Manager, @Supplier_Invoice, @Proof_of_Payment )
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    if (String.IsNullOrEmpty(st.Firstname))
                    {
                        myCommand.Parameters.AddWithValue("@Firstname", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Firstname", st.Firstname);
                    }
                    if (String.IsNullOrEmpty(st.Lastname))
                    {
                        myCommand.Parameters.AddWithValue("@Lastname", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Lastname", st.Lastname);
                    }
                    if (String.IsNullOrEmpty(st.Department))
                    {
                        myCommand.Parameters.AddWithValue("@Department", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Department", st.Department);
                    }
                    myCommand.Parameters.AddWithValue("@Invoice_Date", st.Invoice_Date);
                    myCommand.Parameters.AddWithValue("@Payment_Date", st.Payment_Date);
                    if (String.IsNullOrEmpty(st.Supplier))
                    {
                        myCommand.Parameters.AddWithValue("@Supplier", st.Supplier);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Supplier", st.Supplier);
                    }
                    if (String.IsNullOrEmpty(st.Bank_Details))
                    {
                        myCommand.Parameters.AddWithValue("@Bank_Details", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Bank_Details", st.Bank_Details);
                    }
                    if (String.IsNullOrEmpty(st.Invoice_Desc))
                    {
                        myCommand.Parameters.AddWithValue("@Invoice_Desc", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Invoice_Desc", st.Invoice_Desc);
                    }
                    if (String.IsNullOrEmpty(st.Fullname))
                    {
                        myCommand.Parameters.AddWithValue("@Fullname", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Fullname", st.Fullname);
                    }
                    if (String.IsNullOrEmpty(st.Manager))
                    {
                        myCommand.Parameters.AddWithValue("@Manager", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Manager", st.Manager);
                    }
                    if (String.IsNullOrEmpty(st.Supplier_Invoice))
                    {
                        myCommand.Parameters.AddWithValue("@Supplier_Invoice", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Supplier_Invoice", st.Supplier_Invoice);
                    }
                    if (String.IsNullOrEmpty(st.Proof_of_Payment))
                    {
                        myCommand.Parameters.AddWithValue("@Proof_of_Payment", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Proof_of_Payment", st.Proof_of_Payment);
                    }
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Sheet st)
        {
            string query = @"
                             update dbo.Sheet 
                             set Firstname = @Firstname,
                                 Lastname = @Lastname,
                                 Department = @Department,
                                 Invoice_Date = @Invoice_Date,
                                 Payment_Date = @Payment_Date,
                                 Supplier = @Supplier,
                                 Bank_Details = @Bank_Details,
                                 Invoice_Desc = @Invoice_Desc,
                                 Fullname = @Fullname,
                                 Manager = @Manager,
                                 Supplier_Invoice = @Supplier_Invoice,
                                 Proof_of_Payment = @Proof_of_Payment
                              where Sheet_Id = @Sheet_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Sheet_Id", st.Sheet_Id);
                    if (String.IsNullOrEmpty(st.Firstname))
                    {
                        myCommand.Parameters.AddWithValue("@Firstname", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Firstname", st.Firstname);
                    }
                    if (String.IsNullOrEmpty(st.Lastname))
                    {
                        myCommand.Parameters.AddWithValue("@Lastname", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Lastname", st.Lastname);
                    }
                    if (String.IsNullOrEmpty(st.Department))
                    {
                        myCommand.Parameters.AddWithValue("@Department", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Department", st.Department);
                    }
                    myCommand.Parameters.AddWithValue("@Invoice_Date", st.Invoice_Date);
                    myCommand.Parameters.AddWithValue("@Payment_Date", st.Payment_Date);
                    if (String.IsNullOrEmpty(st.Supplier))
                    {
                        myCommand.Parameters.AddWithValue("@Supplier", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Supplier", st.Supplier);
                    }
                    if (String.IsNullOrEmpty(st.Bank_Details))
                    {
                        myCommand.Parameters.AddWithValue("@Bank_Details", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Bank_Details", st.Bank_Details);

                    }
                    if (String.IsNullOrEmpty(st.Invoice_Desc))
                    {
                        myCommand.Parameters.AddWithValue("@Invoice_Desc", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Invoice_Desc", st.Invoice_Desc);
                    }
                    if (String.IsNullOrEmpty(st.Fullname))
                    {
                        myCommand.Parameters.AddWithValue("@Fullname", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Fullname", st.Fullname);
                    }
                    if (String.IsNullOrEmpty(st.Manager))
                    {
                        myCommand.Parameters.AddWithValue("@Manager", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Manager", st.Manager);
                    }
                    if (String.IsNullOrEmpty(st.Supplier_Invoice))
                    {
                        myCommand.Parameters.AddWithValue("@Supplier_Invoice", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Supplier_Invoice", st.Supplier_Invoice);
                    }
                    if (String.IsNullOrEmpty(st.Proof_of_Payment))
                    {
                        myCommand.Parameters.AddWithValue("@Proof_of_Payment", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Proof_of_Payment", st.Proof_of_Payment);
                    }
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                             delete from dbo.Sheet 
                              where Sheet_Id = @Sheet_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Sheet_Id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Proof_Of_Payment" + filename;
            }
            catch (Exception)
            {

                throw;
            }
            return new JsonResult("ProofOfPayment.Pdf");
        }
    }
}
