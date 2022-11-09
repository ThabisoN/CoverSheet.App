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
    public class SupplierController : ControllerBase
    {
        private readonly IConfiguration _configurration;

        public SupplierController(IConfiguration configuration)
        {
            _configurration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             select Supplier_Id, Supplier_Name, Supplier_Desc, Bank_Details from dbo.Supplier
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
        public JsonResult Post(Supplier Sup)
        {
            string query = @"
                             insert into dbo.Supplier 
                             (Supplier_Name, Supplier_Desc, Bank_Details)
                      values (@Supplier_Name, @Supplier_Desc, @Bank_Details)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Supplier_Name", Sup.Supplier_Name);
                    myCommand.Parameters.AddWithValue("@Supplier_Desc", Sup.Supplier_Desc);
                    myCommand.Parameters.AddWithValue("@Bank_Details", Sup.Bank_Details);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Supplier Sup)
        {
            string query = @"
                             update dbo.Supplier 
                              set Supplier_Name = @Supplier_Name,
                                  Supplier_Desc = @Supplier_Desc,
                                  Bank_Details = @Bank_Details
                              where Supplier_Id = @Supplier_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Supplier_Id", Sup.Supplier_Id);
                    myCommand.Parameters.AddWithValue("@Supplier_Name", Sup.Supplier_Name);
                    myCommand.Parameters.AddWithValue("@Supplier_Desc", Sup.Supplier_Desc);
                    myCommand.Parameters.AddWithValue("@Bank_Details", Sup.Bank_Details);
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
                             delete from dbo.Supplier 
                              where Supplier_Id = @Supplier_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Supplier_Id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
