using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace GroupProject
{
    public partial class CourseObjectivesPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();

            }

        }
        void delteRecord()
        {
            try
            {


                SqlCommand cmd = new SqlCommand("delete courseOBJTB  WHERE courseCode=@id", conn);
                cmd.Parameters.AddWithValue("@id", Txtsearchk.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Delete successfull";
                LoadRecord();
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong";

            }
        }
        void LoadRecord() { 
            try{
      
        
            SqlCommand comm = new SqlCommand("select * from courseOBJTB", conn);
        SqlDataAdapter d = new SqlDataAdapter(comm);
        DataTable dt = new DataTable();
        d.Fill(dt);
            GridView.DataSource = dt;
            GridView.DataBind();
              }

            catch (Exception)
            {
                lblmsg.Text = "Something went wrong:try again/invalid input ";
            }
        }
        void updtCOBJ()
        {
            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                SqlCommand cmd = new SqlCommand("update courseOBJTB set CourseTitle=@CourseTitle,Objectives=@Objectives,CDescription=@CDescription WHERE courseCode='" + Txtsearchk.Text + "'", conn);
                cmd.Parameters.AddWithValue("@CourseTitle", txtCourse.Text);
                cmd.Parameters.AddWithValue("@courseCode", txtCode.Text);

                cmd.Parameters.AddWithValue("@Objectives", txtab.Text);

                cmd.Parameters.AddWithValue("@CDescription", TxtDescrip.Text);
                
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Successfuly updated";
                LoadRecord();
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }
        void saveRecods()
        {
            try
            {



                SqlCommand cmd = new SqlCommand("insert into courseOBJTB (courseCode,CourseTitle,Objectives,CDescription) values (@courseCode,@CourseTitle,@Objectives,@CDescription)", conn);
                cmd.Parameters.AddWithValue("@courseCode", txtCode.Text);
                cmd.Parameters.AddWithValue("@CourseTitle", txtCourse.Text);
                cmd.Parameters.AddWithValue("@Objectives", txtab.Text);

                cmd.Parameters.AddWithValue("@CDescription", TxtDescrip.Text);


                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Successfuly added";
                LoadRecord();
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }

        protected void btnsubmit(object sender, EventArgs e)
        {
            saveRecods();
        }

        protected void btnupdate(object sender, EventArgs e)
        {
            updtCOBJ();
        }

        protected void btndelete(object sender, EventArgs e)
        {
            delteRecord();
        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            //Searching Contents
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from courseOBJTB where courseCode= '" + Txtsearchk.Text + "'", conn);
                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView.DataSource = dt;
                GridView.DataBind();
                conn.Close();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong:try again/invalid input ";

            }
        }

        protected void btnedits_Click(object sender, EventArgs e)
        {
            try
            {


                //retrieving contents 
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from courseOBJTB where courseCode='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    txtCourse.Text = r.GetValue(2).ToString();
                    txtCode.Text = r.GetValue(1).ToString();
                    txtab.Text = r.GetValue(3).ToString();

                    TxtDescrip.Text = r.GetValue(4).ToString();

                }
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong:try again/invalid input ";

            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {


                //retrieving contents 
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from courseOBJTB where courseCode='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    txtCourse.Text = r.GetValue(2).ToString();
                    txtCode.Text = r.GetValue(1).ToString();
                    txtab.Text = r.GetValue(3).ToString();

                    TxtDescrip.Text = r.GetValue(4).ToString();

                }
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong:try again/invalid input ";

            }
        }
    }

}
