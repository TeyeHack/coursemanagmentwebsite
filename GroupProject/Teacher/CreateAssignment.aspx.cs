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
    public partial class CreateAssignment : System.Web.UI.Page
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

                SqlCommand comm = new SqlCommand("select * from AssignmentTB", conn);
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
        private void saveContent()
        {


            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("insert into AssignmentTB (AssignmentID,Instructions,Document) values (@AssignmentID,@Instructions,@Document)", conn);

                if (fu1.HasFile)

                {
                    int filesize = fu1.PostedFile.ContentLength / 1024;
                    if (filesize < 3000072)
                    {

                        string fe = System.IO.Path.GetExtension(fu1.FileName);
                        if (fe.ToLower() == ".pdf" || fe.ToLower() == ".docx" || fe.ToLower() == ".pptx" || fe.ToLower() == ".mp4" || fe.ToLower() == ".mov")
                        {
                            fu1.SaveAs(Server.MapPath("~/assignments/" + fu1.FileName));
                            Txtdocs.Text = fu1.FileName;
                            lblmsg.Text = "Upload Succesfull";

                            cmd.Parameters.AddWithValue("@AssignmentID", Txt1.Text);
                            cmd.Parameters.AddWithValue("@Instructions", Txt2.Text);
                            cmd.Parameters.AddWithValue("@Document", Txtdocs.Text);

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
                lblmsg.Text = "Assignment added successfully";
                conn.Close();
                LoadRecord();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Something went wrong " + ex.ToString();

            }



        }
        void updtassignment()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("update AssignmentTB set Instructions=@Instructions,Document=@Document WHERE AssignmentID=@AssignmentID", conn);
                //  cmd.Parameters.AddWithValue("@AssignmentID", Txt1.Text);
                cmd.Parameters.AddWithValue("@Instructions", Txt2.Text);
                cmd.Parameters.AddWithValue("@Document", Txtdocs.Text);

                cmd.Parameters.AddWithValue("@AssignmentID", Txtsearchk.Text);


                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "update successfull";

                conn.Close();
                LoadRecord();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong ";

            }
        }
        void deltAssignment()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("delete AssignmentTB  WHERE AssignmentID=@id", conn);
                cmd.Parameters.AddWithValue("@id", Txtsearchk.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Delete successfull";
                conn.Close();
                LoadRecord();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong ";

            }
        }

        protected void btnsubmit(object sender, EventArgs e)
        {
            saveContent();
        }

        protected void btnupdate(object sender, EventArgs e)
        {
            updtassignment();
        }

        protected void btndelete(object sender, EventArgs e)
        {
            deltAssignment();
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from AssignmentTB where AssignmentID='" + Txtsearchk.Text + "'", conn);
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

        protected void btnedits_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from AssignmentTB where AssignmentID='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    Txt1.Text = r.GetValue(0).ToString();
                    Txtdocs.Text = r.GetValue(2).ToString();
                    Txt2.Text = r.GetValue(1).ToString();

                }
                conn.Close();
            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }
    }
}