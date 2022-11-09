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
    public class DepartmentController : ControllerBase
    {

        private readonly IConfiguration _configurration;

        public DepartmentController(IConfiguration configuration)
        {
            _configurration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             select Department_Id, Department_Name from dbo.Department
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
        public JsonResult Post(Department dep)
        {
            string query = @"
                             insert into dbo.Department values (@Department_Name)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Department_Name", dep.Department_Name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            string query = @"
                             update dbo.Department 
                              set Department_Name = @Department_Name
                              where Department_Id = @Department_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Department_Id", dep.Department_Id);
                    myCommand.Parameters.AddWithValue("@Department_Name", dep.Department_Name);
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
                             delete from dbo.Department 
                              where Department_Id = @Department_Id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configurration.GetConnectionString("Platinum_Life_DB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Department_Id", id);
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
