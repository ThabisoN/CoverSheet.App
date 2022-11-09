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
    public class ManagerController : ControllerBase
    {
        private readonly IConfiguration _configurration;
        private readonly IWebHostEnvironment _env;

        public ManagerController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configurration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             select Manager_Id, Firstname, Lastname, Department, Manager_Signature from dbo.Manager
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
        public JsonResult Post(Manager man)
        {
            string query = @"
                             insert into dbo.Manager 
                             (Firstname,Lastname,Department,Manager_Signature)
                      values (@FirstName,@Lastname,@Department,@Manager_Signature)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Firstname", man.Firstname);
                    myCommand.Parameters.AddWithValue("@Lastname", man.Lastname);
                    myCommand.Parameters.AddWithValue("@Department", man.Department);
                    myCommand.Parameters.AddWithValue("@Manager_Signature", man.Manager_Signature);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Manager man)
        {
            string query = @"
                             update dbo.Manager 
                             set Firstname = @Firstname,
                                 Lastname = @Lastname,
                                 Department = @Department,
                                 Manager_Signature = @Manager_Signature
                                 where Manager_Id = @Manager_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Manager_Id", man.Manager_Id);
                    myCommand.Parameters.AddWithValue("@Firstname", man.Firstname);
                    myCommand.Parameters.AddWithValue("@Lastname", man.Lastname);
                    myCommand.Parameters.AddWithValue("@Department", man.Department);
                    myCommand.Parameters.AddWithValue("@Manager_Signature", man.Manager_Signature);
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
                             delete from dbo.Manager 
                              where Manager_Id = @Manager_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Manager_Id", id);
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
