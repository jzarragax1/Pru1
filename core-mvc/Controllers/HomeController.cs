using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using core_mvc.Models;


using System.Collections;

using System.Data;
using System.Web;
using System.Data.SqlClient;

using System.IO;
using System.Configuration;

using System.Xml;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;




namespace core_mvc.Controllers
{
  
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {

         



            List<IndexModel> listMeals = new List<IndexModel>();
            using (SqlConnection sqlConnection = new SqlConnection("Data Source = 188.121.44.217; Initial Catalog = clinicampus; User Id = User_clinicampus; Password = Napoleonx2;"))
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_SearchedComments", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SearchTerm", "");
                    sqlConnection.Open();
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        listMeals.Add(new IndexModel
                        {
                            dni = Convert.ToString(sqlReader[1]),
                            plantaDesc = Convert.ToString(sqlReader[0]),
                            //Comments = Convert.ToString(sqlReader[2]),
                            //ImageUrl = Convert.ToString(sqlReader[3]),
                            //Price = Convert.ToString(sqlReader[4])
                        });
                    }
                }
            }


            return View(listMeals);

         
        }



        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }




        public List<IndexModel> prueba()
        {



            List<IndexModel> listMeals = new List<IndexModel>();
            using (SqlConnection sqlConnection = new SqlConnection("Data Source = 188.121.44.217; Initial Catalog = clinicampus; User Id = User_clinicampus; Password = Napoleonx2;"))
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_SearchedComments", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SearchTerm", "");
                    sqlConnection.Open();
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        listMeals.Add(new IndexModel
                        {
                            dni = Convert.ToString(sqlReader[1]),
                            plantaDesc = Convert.ToString(sqlReader[0]),
                            //Comments = Convert.ToString(sqlReader[2]),
                            //ImageUrl = Convert.ToString(sqlReader[3]),
                            //Price = Convert.ToString(sqlReader[4])
                        });
                    }
                }
            }
            return (listMeals);


        }

        public List<Index2Model> prueba2()
        {

            //RECOGER DATOS DEL FORMULARIO

            //String donaldduck;

            //donaldduck = Request.Form["donaldduck"];
            //accion = Request.Form["accion"];
            List<Index2Model> listMeals = new List<Index2Model>();
            listMeals.Add(new Index2Model
            {
                accion = HttpContext.Request.QueryString.Value,

            });



            return (listMeals);
        }


        public IActionResult Index2()
        {

            //RECOGER DATOS DEL FORMULARIO

            //String donaldduck;

            //donaldduck = Request.Form["donaldduck"];
            //accion = Request.Form["accion"];
            List<Index2Model> listMeals = new List<Index2Model>();
            listMeals.Add(new Index2Model
            {
                accion = HttpContext.Request.QueryString.Value,
                
            });


  

            return View(listMeals);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
