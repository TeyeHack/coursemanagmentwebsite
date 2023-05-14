using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace GroupProject.Student
{
    public partial class s_Download : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            // fetchdata();
            LoadRecord();
        }
        void LoadRecord()
        {
            try
            {
                SqlCommand comm = new SqlCommand("select * from AssignmentTB", conn);
                SqlDataAdapter d = new SqlDataAdapter(comm);

                DataTable dt = new DataTable();
                d.Fill(dt);

                GridView.DataSource = dt;
                GridView.DataBind();
            }
            catch (Exception)
            {

            }
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Document")
                {
                    Response.Clear();
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename =" + e.CommandArgument);
                    Response.TransmitFile(Server.MapPath("assignments/") + e.CommandArgument);
                    Response.End();

                }
            }
            catch (Exception)
            {

            }
        }
    }
}