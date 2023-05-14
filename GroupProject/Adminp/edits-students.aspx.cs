using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace GroupProject.Adminp
{
    public partial class edits_students : System.Web.UI.Page
    {
        string connection = (@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecord();
        }
        void LoadRecord()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand comm = new SqlCommand("select * from userTB where  userID=" + "0" + " ", conn);
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

        private void registerUser()
        {
            if (txtuser.Text.Trim() == "" && txtPass.Text.Trim() == "")
            {

                lblmsg.Text = "Enter all empty fields";

            }
            else
            {
                try
                {
                    string salting = HashPass.Saltmethod();
                    string passed = HashPass.hashed(txtPass.Text, salting);



                    // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    SqlConnection conn = new SqlConnection(connection);
                    SqlCommand cmd = new SqlCommand("insert into userTB (userID,Name,IDNumber,Gender,Level,Course,username,password,salting) values (@userID,@Name, @IDNumber,@Gender,@Level,@Course,@username,@password,@salting)", conn);
                    cmd.Parameters.AddWithValue("@userID", "0");
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@IDNumber", txtid.Text);
                    cmd.Parameters.AddWithValue("@Gender", drpGender.Text);
                    cmd.Parameters.AddWithValue("@Level", drplevl.Text);
                    cmd.Parameters.AddWithValue("@Course", drpCours.Text);

                    cmd.Parameters.AddWithValue("@username", txtuser.Text);
                    cmd.Parameters.AddWithValue("@password", passed);
                    cmd.Parameters.AddWithValue("@salting", salting);
                    conn.Open();
                    int endview = cmd.ExecuteNonQuery();
                    lblmsg.Text = "Registration successful";
                    conn.Close();
                }
                catch (Exception)
                {
                    lblmsg.Text = "Something went wrong: ";


                }
            }


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            registerUser();
        }

        protected void btnsearh_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from userTB where IDNumber= '" + Txtsearchk.Text + "'", conn);
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
        void updtQuestion()
        {
            try
            {
                string salting = HashPass.Saltmethod();
                string passed = HashPass.hashed(txtPass.Text, salting);


                SqlConnection conn = new SqlConnection(connection);

                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("update userTB set Name=@Name,IDNumber=@IDNumber,Gender=@Gender,Level=@Level,Course=@Course,username=@username,password=@password,salting=@salting WHERE IDNumber=@IDNumber", conn);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@IDNumber", txtid.Text);
                cmd.Parameters.AddWithValue("@Gender", drpGender.Text);
                cmd.Parameters.AddWithValue("@Level", drplevl.Text);
                cmd.Parameters.AddWithValue("@Course", drpCours.Text);
                cmd.Parameters.AddWithValue("@username", txtuser.Text);
                cmd.Parameters.AddWithValue("@password", passed);
                cmd.Parameters.AddWithValue("@salting", salting);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Successfully updated";
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
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from userTB where IDNumber='" + Txtsearchk.Text + "'", conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    txtname.Text = r.GetValue(1).ToString();
                    txtid.Text = r.GetValue(2).ToString();
                    drpGender.Text = r.GetValue(3).ToString();
                    drplevl.Text = r.GetValue(4).ToString();
                    drpCours.Text = r.GetValue(5).ToString();
                    txtuser.Text = r.GetValue(6).ToString();
                    txtPass.Text = r.GetValue(7).ToString();
                }


                conn.Close();

            }
            catch (Exception ex)
            {
                lblmsg.Text = "Something went wrong: " + ex.ToString();

            }
        }
        void deltStudnet()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("delete userTB  WHERE IDNumber=@id", conn);
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

        protected void btnupdt_Click(object sender, EventArgs e)
        {
            updtQuestion();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {
            deltStudnet();
        }
    }

}
