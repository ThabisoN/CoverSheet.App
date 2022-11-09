using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlatinumLifeSheet.App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlatinumLifeSheet.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IConfiguration _configurration;
        private readonly IWebHostEnvironment _env;

        public InvoiceController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configurration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                string query = @"
                             select Invoice_Id, Invoice_Date, Invoice_Desc,Department, Supplier,Total_Balance,Supplier_Invoice from dbo.Invoice
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
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public JsonResult Post(Invoice Inv)
        {
            try
            {
                string query = @"
                             insert into dbo.Invoice 
                             (Invoice_Date, Invoice_Desc, Department,Supplier, Total_Balance, Supplier_Invoice)
                      values (@Invoice_Date, @Invoice_Desc, @Department,@Supplier, @Total_Balance, @Supplier_Invoice)
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {

                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        if (String.IsNullOrEmpty(Inv.Invoice_Date))
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Date", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Date", Inv.Invoice_Date);
                        }
                        if (String.IsNullOrEmpty(Inv.Invoice_Desc))
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Desc", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Desc", Inv.Invoice_Desc);
                        }
                        if (String.IsNullOrEmpty(Inv.Department))
                        {
                            myCommand.Parameters.AddWithValue("@Department", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Department", Inv.Department);
                        }
                        if (String.IsNullOrEmpty(Inv.Supplier))
                        {
                            myCommand.Parameters.AddWithValue("@Supplier", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Supplier", Inv.Supplier);
                        }
                        myCommand.Parameters.AddWithValue("@Total_Balance", Inv.Total_Balance);
                        if (String.IsNullOrEmpty(Inv.Supplier_Invoice))
                        {
                            myCommand.Parameters.AddWithValue("@Supplier_Invoice", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Supplier_Invoice", Inv.Supplier_Invoice);
                        }
                        
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Added Successfully");
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPut]
        public JsonResult Put(Invoice Inv)
        {
            try
            {
                 string query = @"
                             update dbo.Invoice 
                              set Invoice_Date = @Invoice_Date,
                                  Invoice_Desc = @Invoice_Desc,
                                  Department = @Department,
                                  Supplier=@Supplier,
                                  Total_Balance = @Total_Balance,
                                  Supplier_Invoice = @Supplier_Invoice
                              where Invoice_Id = @Invoice_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Invoice_Id", Inv.Invoice_Id);
                        if (String.IsNullOrEmpty(Inv.Invoice_Date))
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Date", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Date", Inv.Invoice_Date);
                        }
                        if (String.IsNullOrEmpty(Inv.Invoice_Desc))
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Desc", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Invoice_Desc", Inv.Invoice_Desc);
                        }
                        if (String.IsNullOrEmpty(Inv.Department))
                        {
                            myCommand.Parameters.AddWithValue("@Department", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Department", Inv.Department);
                        }
                        if (String.IsNullOrEmpty(Inv.Supplier))
                        {
                            myCommand.Parameters.AddWithValue("@Supplier", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Supplier", Inv.Supplier);
                        }
                        myCommand.Parameters.AddWithValue("@Total_Balance", Inv.Total_Balance);
                        if (String.IsNullOrEmpty(Inv.Supplier_Invoice))
                        {
                            myCommand.Parameters.AddWithValue("@Supplier_Invoice", DBNull.Value);
                        }
                        else
                        {
                            myCommand.Parameters.AddWithValue("@Supplier_Invoice", Inv.Supplier_Invoice);
                        }

                        myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                              delete from dbo.Invoice 
                              where Invoice_Id = @Invoice_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Invoice_Id", id);
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
                var physicalPath = _env.ContentRootPath + "/Supplier_Invoice/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.Pdf");
            }

        }
    }
}
