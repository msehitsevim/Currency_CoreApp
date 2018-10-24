using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using testCurr.Models;

namespace testCurr.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {            
            DateTime dtime = DateTime.Now;
            List<DovizKuru> currlist = null;
            ViewData["Message"] = "Your application description page.";
            WebClient client = new WebClient();
            var json = client.DownloadString("https://www.doviz.com/api/v1/currencies/all/latest");
            currlist = JsonConvert.DeserializeObject<List<DovizKuru>>(json);

            string baglanti = "Server = BTSTAJYER\\STAJYER; Initial Catalog = Currency; Integrated Security = True";
            SqlConnection con = new SqlConnection(baglanti);
            foreach (var i in currlist)
            {      
              
                SqlCommand sorgu = new SqlCommand("dbo.oldData", con);
                con.Open();
                sorgu.CommandType = CommandType.StoredProcedure;
                SqlParameter pr_Code = new SqlParameter("@pCode",i.Code);
                sorgu.Parameters.Add(pr_Code);
                SqlParameter pr_Buying = new SqlParameter("@pBuying",i.Buying);
                sorgu.Parameters.Add(pr_Buying);
                SqlParameter pr_Selling = new SqlParameter("@pSelling", i.Selling);
                sorgu.Parameters.Add(pr_Selling);
                SqlParameter pr_Dtime = new SqlParameter("@pDtime",dtime);
                sorgu.Parameters.Add(pr_Dtime);
                sorgu.ExecuteNonQuery();
                
                con.Close();
            }
        
            if (currlist == null)
                return null;
            return View(currlist.Take(60).ToList());
  
        }
                     /* SqlCommand sorgu2 = new SqlCommand("dbo.spDoviz_tipi", con);
                    sorgu2.CommandType = CommandType.StoredProcedure;
                    SqlParameter pr_Code = new SqlParameter("@pCode", i.Code);
                    sorgu2.Parameters.Add(pr_Code);
                    SqlParameter pr_Name = new SqlParameter("@pName", i.Name);
                    sorgu2.Parameters.Add(pr_Name);   
                    sorgu2.ExecuteNonQuery();    DovizTipini db ye kayıt için tek sefer çalıştır. con içine yaz.  
                    */


    }
}
