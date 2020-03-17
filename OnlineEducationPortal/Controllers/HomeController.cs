using OnlineEducationPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineEducationPortal.Controllers
{
    public class HomeController : Controller
    {

        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=LAPTOP-FKPBSUHI;Initial Catalog=EducationPortal;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;

        //this method is used to execute the sql query like insert delete update in the database tables
        public void SqlQuery(String query)
        {
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
            sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
        }


        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable srchRecord(String qry)
        {
            DataTable tbl = new DataTable();

            sqlCon = new SqlConnection(conStr);

            sqlCon.Open();
            sqlcmd = new SqlCommand(qry, sqlCon);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlCon.Close();

            return tbl;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult SendMsg(ContactData data)
        {
            
            String query = "insert into Contact_Data(Name,Email,Phone,Message) values('" + data.txtName.ToString() + "','" + data.txtEmail.ToString() + "','" + data.txtContact.ToString() + "','" + data.txtMsg.ToString() + "')";
            SqlQuery(query);
            return View("Redirect");

        }

        public ActionResult Login(LoginData data)
        {
            String query = "select * from Login_Data where Name='"+data.txtEmail.ToString()+"' and Password='"+data.txtPassword.ToString()+"'";
            DataTable tbl = new DataTable();
            tbl=srchRecord(query);
            if (tbl.Rows.Count > 0)
            {
                return View("Correct");
            }
            else {
                return View("WrongName");
            }


        }


        public ActionResult Correct() {
            return View();
        }
        public ActionResult WrongName() {

            return View();
        }

        public ActionResult Redirect()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminLogin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}