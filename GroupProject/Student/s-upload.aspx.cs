using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace GroupProject.Student
{
    public partial class s_upload : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string name; string fname;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRecord();
            }
            name = (String)(Session["username"]);
            Label1.Text = name;
            // string idn = (String)(Session[""]);
            fethrecord();
        }
        void LoadRecord()
        {
            try
            {

                SqlCommand comm = new SqlCommand("select * from StAssignmentTB", conn);
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
            DateTime dt = DateTime.Now;

            string sDate = dt.ToShortDateString();

            try
            {


                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("insert into StAssignmentTB (AssignmentID,Name,Document,SubmissionDate) values (@AssignmentID,@Name,@Document,@SubmissionDate)", conn);

                if (fu1.HasFile)

                {
                    int filesize = fu1.PostedFile.ContentLength / 1024;
                    if (filesize < 300072)
                    {

                        string fe = System.IO.Path.GetExtension(fu1.FileName);
                        if (fe.ToLower() == ".pdf" || fe.ToLower() == ".docx" || fe.ToLower() == ".pptx" || fe.ToLower() == ".mp4" || fe.ToLower() == ".mov")
                        {
                            fu1.SaveAs(Server.MapPath("~/assignments/" + fu1.FileName));
                            Txtdocs.Text = fu1.FileName;
                            lblmsg.Text = "Upload Succesfull";

                            cmd.Parameters.AddWithValue("@AssignmentID", Txt1.Text);

                            cmd.Parameters.AddWithValue("@Name", fname);
                            cmd.Parameters.AddWithValue("@Document", Txtdocs.Text);
                            cmd.Parameters.AddWithValue("@SubmissionDate", sDate);

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
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";


            }



        }
        //void updtassignment()
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("update StAssignmentTB set Document=@Document WHERE AssignmentID=@AssignmentID", conn);
        //        //  cmd.Parameters.AddWithValue("@AssignmentID", Txt1.Text);

        //        cmd.Parameters.AddWithValue("@Document", Txtdocs.Text);

        //        cmd.Parameters.AddWithValue("@AssignmentID", Txtsearchk.Text);


        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        lblmsg.Text = "update successfull";

        //        conn.Close();
        //        LoadRecord();
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg.Text = "Something went wrong: " + ex.ToString();

        //    }
        //}
        void deltAssignment()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("delete StAssignmentTB  WHERE AssignmentID=@id", conn);
                cmd.Parameters.AddWithValue("@id", Txtsearchk.Text);

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
        void fethrecord()
        {
            try
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
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }

        protected void btnsubmit(object sender, EventArgs e)
        {
            saveContent();
        }

        protected void btndelete(object sender, EventArgs e)
        {
            deltAssignment();
        }


        protected void btnedits_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from StAssignmentTB where AssignmentID='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    Txt1.Text = r.GetValue(0).ToString();
                    Txtdocs.Text = r.GetValue(1).ToString();

                }
                conn.Close();

            }
            catch (Exception)
            {
                lblmsg.Text = "Something went wrong: ";

            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from StAssignmentTB where AssignmentID='" + Txtsearchk.Text + "'", conn);
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
    }

}