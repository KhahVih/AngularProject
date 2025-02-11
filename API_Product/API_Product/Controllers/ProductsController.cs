using API_Product.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetProduct")]
        public JsonResult GetProduct()
        {
            //string query = "select p.ProductId, p.ProductName, p.ProductPrice, p.ProductImage, p.ProductDescription, c.CategoryName from Products p, Categories c where p.CategoryId = c.CategoryId";
            string query = "select * from Products";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con)) 
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("GetProductById/{id}")]
        public JsonResult GetProductById(int id)
        {
            string query = "select * from Products where ProductId = '"+id+"'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost("AddProduct")]
        public JsonResult AddProduct(Product p)
        {
            string query = @"Insert into Products values (N'"+p.ProductName+ "', '"+p.ProductPrice+ "', N'"+p.ProductDescription+"', " +
                "'"+p.ProductImage+ "', '"+p.CategoryId+"')";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(" Add Product Success");
        }

        [HttpPut("UpdateProduct")]
        public JsonResult UpdateProduct(Product p)
        {
            string query = @"Update Products set ProductName = N'" + p.ProductName + "', ProductPrice = '" + p.ProductPrice + "', ProductDescription = N'" + p.ProductDescription + "', " +
                "ProductImage = '" + p.ProductImage + "', CategoryId = '" + p.CategoryId + "' where ProductId = '"+p.ProductId+"'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Update Product Success");
        }


        [HttpDelete("DeleteProduct/{id}")]
        public JsonResult DeleteProduct( int id)
        {
            string query = @"Delete from Products where ProductId = '" + id + "'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Delete Product Success");
        }

        //------------------CATEGORY--------------------

        [HttpGet("GetCategory")]
        public JsonResult GetCategory()
        {
            string query = "select * from Categories";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("GetCategoryById/{id}")]
        public JsonResult GetCategoryById(int id)
        {
            string query = "select * from Categories where CategoryId = '" + id + "'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost("AddCategory")]
        public JsonResult AddCategory(Category c)
        {
            string query = @"Insert into Categories values (N'" + c.CategoryName + "')";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(" Add Category Success");
        }

        [HttpPut("UpdateCategory")]
        public JsonResult UpdateCategory(Category c)
        {
            string query = @"Update Categories set CategoryName = N'" + c.CategoryName + "' where CategoryId = '" + c.CategoryId + "'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Update Category Success");
        }

        [HttpDelete("DeleteCategory/{id}")]
        public JsonResult DeleteCategory( int id)
        {
            string query = @"Delete from Categories where CategoryId = '" + id + "'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Delete Category Success");
        }

        // --------------USER------------------------------
        //get user
        [HttpGet("GetUser")]
        public JsonResult GetUser() {
            string query = "select * from Users";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("GetUserById/{id}")]
        public JsonResult GetUserById(int id)
        {
            string query = "select * from Users where Id = '" + id + "'";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost("AddUser")]
        public JsonResult AddUser(User user)
        {
            string query = @"Insert into Users values ('" + user.UserName + "', '" + user.Password + "', '" + user.Phone + "', N'" + user.DiaChi + "')";
            DataTable table = new DataTable();
            String sql = _configuration.GetConnectionString("Product");
            SqlDataReader reader;
            using (SqlConnection con = new SqlConnection(sql))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    reader = cmd.ExecuteReader();
                    table.Load(reader);
                    reader.Close();
                    con.Close();
                }
            }
            return new JsonResult("Add User Succes");
        }

    }
}
