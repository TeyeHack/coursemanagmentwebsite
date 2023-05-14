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
    public partial class TeacherAddResources : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
           
                LoadRecord();
          
        }
      

        private void saveContent()
        {


            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("insert into contentTB (Week,Topic,Documents,Description) values (@Week,@Topic,@Documents,@Description)", conn);

                if (fu1.HasFile)

                {
                    int filesize = fu1.PostedFile.ContentLength / 1024;
                    if (filesize < 300072)
                    {

                        string fe = System.IO.Path.GetExtension(fu1.FileName);
                        if (fe.ToLower() == ".pdf" || fe.ToLower() == ".docx" || fe.ToLower() == ".pptx" || fe.ToLower() == ".mp4" || fe.ToLower() == ".mov")
                        {
                            fu1.SaveAs(Server.MapPath("~/documents/" + fu1.FileName));
                            Txtdocs.Text = fu1.FileName;
                            lblmsg.Text = "Upload Succesfull";

                            cmd.Parameters.AddWithValue("@Week", Txtweek.Text);
                            cmd.Parameters.AddWithValue("@Topic", TxtTopic.Text);
                            cmd.Parameters.AddWithValue("@Documents", Txtdocs.Text);
                            cmd.Parameters.AddWithValue("@Description", TxtDescrip.Text);

                        }
                        else
                        {
                            lblmsg.Text = " file format is not supported use pdf,docx,mp4,mov,pptx extension ";
                        }

                    }
                    else
                    {
                        lblmsg.Text = " file is too Big to be uploaded ";
                    }

                }
                else
                {
                    lblmsg.Text = "Upload Unsuccesfull";
                }






                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Content add successful";
                conn.Close();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }



        }

    

        void LoadRecord()
        {
            try
            {

                SqlCommand comm = new SqlCommand("select * from contentTB", conn);
                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }
        void delteQuestion()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("delete contentTB  WHERE Week=@week", conn);
                cmd.Parameters.AddWithValue("@week", Txtsearchk.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Delete successfull";
                conn.Close();
                LoadRecord();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }


        void updtQuestion()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update contentTB set Topic=@Topic,Documents=@Documents,Description=@Description WHERE Week=@Week", conn);
                cmd.Parameters.AddWithValue("@Week", Txtsearchk.Text);
                cmd.Parameters.AddWithValue("@Topic", TxtTopic.Text);
                cmd.Parameters.AddWithValue("@Documents", Txtdocs.Text);
                cmd.Parameters.AddWithValue("@Description", TxtDescrip.Text);
             

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "update successfull";
                LoadRecord();
                conn.Close();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }
   


    
   
        protected void btnedits_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from contentTB where Week='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    Txtweek.Text = r.GetValue(1).ToString();
                    Txtdocs.Text = r.GetValue(3).ToString();
                    TxtTopic.Text = r.GetValue(2).ToString();

                    TxtDescrip.Text = r.GetValue(4).ToString();

                }
                conn.Close();
            }
            catch (Exception)

            {
                lblmsg.Text = "Something went wrong: ";

            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from contentTB where Week= '" + Txtsearchk.Text + "'", conn);
                SqlDataAdapter d = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                d.Fill(dt);
                GridView.DataSource = dt;
                GridView.DataBind();
                conn.Close();
            }
            catch (Exception)

            {
                lblmsg.Text = "Something went wrong: ";

            }

        }

        protected void btnupdate(object sender, EventArgs e)
        {
            updtQuestion();
        }

        protected void btndelete(object sender, EventArgs e)
        {
            delteQuestion();
        }

        protected void btnsubmit(object sender, EventArgs e)
        {
            saveContent();
        }
    }
}