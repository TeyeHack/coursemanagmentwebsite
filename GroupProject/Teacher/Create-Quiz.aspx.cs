using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace GroupProject.Teacher
{
    public partial class Create_Quiz : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();
            }
        }
        void LoadRecord()
        {
            try
            {
                SqlCommand comm = new SqlCommand("select * from tblQuestions", conn);
                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong ";

            }

        }
     
        void updtQuestion()
        {
            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("update tblQuestions set Question=@Question,Option1=@Option1,Option2=@Option2,Option3=@Option3,Option4=@Option4,QuestionAnswer=@Answer WHERE QuestionId=@id", conn);
                cmd.Parameters.AddWithValue("@id", Txtsearchk.Text);
                cmd.Parameters.AddWithValue("@Question", Txtq.Text);
                cmd.Parameters.AddWithValue("@Option1", txtopt1.Text);
                cmd.Parameters.AddWithValue("@Option2", txtopt2.Text);
                cmd.Parameters.AddWithValue("@Option3", txtopt3.Text);
                cmd.Parameters.AddWithValue("@Option4", txtopt4.Text);
                cmd.Parameters.AddWithValue("@Answer", txtanswer.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "update successfull";
                LoadRecord();
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong ";

            }
        }
        void delteQuestion()
        {
            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("delete tblQuestions  WHERE QuestionId=@id", conn);
                cmd.Parameters.AddWithValue("@id", Txtsearchk.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Delete successfull";
                LoadRecord();
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong ";

            }
        }
        private void addQuestion()
        {
            if (Txtq.Text.Trim() == "")
            {

                lblmsg.Text = "Question field can't be null";

            }
            else if (txtopt1.Text.Trim() == "")
            {

                lblmsg.Text = "Option1 field can't be null";

            }
            else if (txtopt2.Text.Trim() == "")
            {

                lblmsg.Text = "Option2 field can't be null";

            }
            else if (txtopt3.Text.Trim() == "")
            {

                lblmsg.Text = "Option3 field can't be null";

            }
            else if (txtopt4.Text.Trim() == "")
            {

                lblmsg.Text = "Option4 field can't be null";

            }
            else if (txtanswer.Text.Trim() == "")
            {

                lblmsg.Text = "Answer field can't be null";

            }
            else
            {

                try
                {


                    // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    SqlCommand cmd = new SqlCommand("insert into tblQuestions (Question,Option1,Option2,Option3,Option4,QuestionAnswer) values (@Question,@Option1,@Option2,@Option3,@Option4,@QuestionAnswer)", conn);
                    cmd.Parameters.AddWithValue("@Question", Txtq.Text);
                    cmd.Parameters.AddWithValue("@Option1", txtopt1.Text);
                    cmd.Parameters.AddWithValue("@Option2", txtopt2.Text);
                    cmd.Parameters.AddWithValue("@Option3", txtopt3.Text);
                    cmd.Parameters.AddWithValue("@Option4", txtopt4.Text);
                    cmd.Parameters.AddWithValue("@QuestionAnswer", txtanswer.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblmsg.Text = "Question added successful";
                    LoadRecord();
                    conn.Close();

                }
                catch (Exception)
                {
                    lblmsg.Text = "Something went wrong ";

                }
            }


        }

     
    

        protected void btnsearch3(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from tblQuestions where QuestionId= '" + Txtsearchk.Text + "'", conn);
                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                conn.Close();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }

        protected void btnedits2(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from tblQuestions where QuestionId='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    Txtq.Text = r.GetValue(1).ToString();
                    txtopt1.Text = r.GetValue(2).ToString();
                    txtopt2.Text = r.GetValue(3).ToString();
                    txtopt3.Text = r.GetValue(4).ToString();
                    txtopt4.Text = r.GetValue(5).ToString();
                    txtanswer.Text = r.GetValue(6).ToString();
                }


                conn.Close();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong";

            }
        }

        protected void btnsubmit(object sender, EventArgs e)
        {
            addQuestion();
        }

        protected void btnupdate(object sender, EventArgs e)
        {
            updtQuestion();
        }

        protected void btndelete(object sender, EventArgs e)
        {
            delteQuestion();
        }
    }
}