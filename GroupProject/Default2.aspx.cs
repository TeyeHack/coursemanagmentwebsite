using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GroupProject
{
    public partial class Default2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        DataTable dt = new DataTable();
        string name; string fname;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

            name = (String)(Session["username"]);
            fethrecord();
            //Label1.Text = name;
            // string idn = (String)(Session[""]);

        }
        void fethrecord()
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("select * from userTB where username='" + name + "'", conn);
            SqlDataReader r = comm.ExecuteReader();
            while (r.Read())
            {
                //    Txt1.Text = r.GetValue(0).ToString();
                fname = r.GetValue(1).ToString();

            }
            conn.Close();
        }

        private void saveContent()
        {
            DateTime dt = DateTime.Now;

            string sDate = dt.ToShortDateString();

            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("insert into QuizResultTB (Name,Marks,Date) values (@Name,@Marks,@Date)", conn);

                cmd.Parameters.AddWithValue("@Name", fname);
                cmd.Parameters.AddWithValue("@Marks", lbresult1.Text);
                cmd.Parameters.AddWithValue("@Date", sDate);

                conn.Open();
                cmd.ExecuteNonQuery();
                //lblmsg.Text = "Assignment added successfully";
                conn.Close();

            }
            catch (Exception)
            {
                lbresult1.Text = "Something went wrong: ";

            }



        }
        public void BindGrid()
        {

            try
            {

                SqlDataAdapter adp = new SqlDataAdapter("select * from tblQuestions", ConfigurationManager.ConnectionStrings["con"].ToString());
                adp.Fill(dt);
                grdquestions.DataSource = dt;
                grdquestions.DataBind();
            }
            catch (Exception)
            {
                lbresult1.Text = "Something went wrong: ";

            }

        }
        protected void grdquestions_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList rdlstOptions = (RadioButtonList)e.Row.FindControl("rdlstOptions");
                HiddenField hdnquestionId = (HiddenField)e.Row.FindControl("hdnquestionId");
                if (rdlstOptions != null && hdnquestionId != null)
                {
                    DataRow[] result = dt.Select("questionid=" + (Convert.ToInt32(hdnquestionId.Value)));
                    DataView view = new DataView();
                    view.Table = dt;
                    view.RowFilter = "questionid=" + (Convert.ToInt32(hdnquestionId.Value));
                    if (view.Table.Rows.Count > 0)
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = view.ToTable();
                    }
                }
            }

        }


        protected void btnsubmit(object sender, EventArgs e)
        {
            saveContent();
        }

        protected void btnsubmit1(object sender, EventArgs e)
        {
            saveContent();
        }
    }
}