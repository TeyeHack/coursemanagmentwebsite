using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace GroupProject.Student
{
    public partial class StudentMD : System.Web.UI.MasterPage
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["username"]);

            if (name == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("../login.aspx", false);
                //Display the Picture in Image control

            }
            else
            {
                string msgs = "Welcome Back,Role | Student ";
                usrlbl.Text = msgs + name;
            }
            //  usrlbl.Text = name;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //  usrlbl.Text = name;
            Session["username"] = null;
            Session.Abandon();
            Response.BufferOutput = true;
            Response.Redirect("../Login.aspx", false);
        }
    }
    }