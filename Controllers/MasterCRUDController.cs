using coretask2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace coretask2.Controllers
{
    public class MasterCRUDController : Controller
    {
        string connection;
        SqlConnection con;
        public MasterCRUDController()
        {
            var dbconfig = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            connection = dbconfig["ConnectionString:defaultconn"];
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Login obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (con = new SqlConnection(connection))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("sp_Login_master_Task2", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@email", obj.email);
                        cmd.Parameters.AddWithValue("@password", obj.password);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            HttpContext.Session.SetString("Name", dr["Name"].ToString());
                            HttpContext.Session.SetString("LogTime", System.DateTime.Now.ToShortTimeString());
                            return RedirectToAction("ShowMaster", "MasterCRUD");
                        }
                        else
                        {
                            ViewBag.res = "Invalid user";
                            return View();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register obj)
        {
            try
            {
                using (con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_Insert_master_Task2", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Maste_ID", Convert.ToInt32(obj.Maste_ID));
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@email", obj.email);
                    cmd.Parameters.AddWithValue("@password", obj.password);
                    cmd.Parameters.AddWithValue("@mobile", obj.mobile);
                    cmd.Parameters.AddWithValue("@gender", obj.gender);
                    cmd.Parameters.AddWithValue("@age", Convert.ToByte(obj.age));
                    cmd.Parameters.AddWithValue("@department", obj.department);
                    cmd.Parameters.AddWithValue("@nationality", obj.nationality);
                    cmd.Parameters.AddWithValue("@status", Convert.ToBoolean(obj.status));
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return RedirectToAction("Login", "MasterCRUD");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Retry");
                        return View();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return View(obj);
        }

        [HttpGet]
        [SetAccessGlobally]
        public ActionResult ShowMaster() 
        {
            List<DisplayModel> obj = GetAllData();
            return View(obj);
        }

        public List<DisplayModel> GetAllData()
        {
            List<DisplayModel> obj = new List<DisplayModel> ();
            try
            {
                using(con = new SqlConnection(connection))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from master_Task2", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        obj.Add(
                            
                            new DisplayModel
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Maste_ID = Convert.ToInt32(dr["Maste_ID"]),
                                Name = dr["Name"].ToString(),
                                email = dr["email"].ToString(),
                                password = dr["password"].ToString(),
                                mobile = dr["mobile"].ToString(),
                                gender = dr["gender"].ToString(),
                                age =  Convert.ToByte(dr["age"].ToString()),
                                department = dr["department"].ToString(),
                                nationality = dr["nationality"].ToString(),
                                status = Convert.ToBoolean(dr["status"].ToString())

                            }
                            
                            );
                    }
                    return obj;
                }
            }
            catch
            {
                throw;
            }
        }

        public IActionResult Detial()
        {
            return View();
        }
        public IActionResult Edit() 
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            try
            {
                using (con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from master_Task2 where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    int x = cmd.ExecuteNonQuery();
                    if(x > 0)
                    {
                        return RedirectToAction("ShowMaster", "MasterCRUD");
                    }
                    else
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}




















