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
    public partial class edits_Teacher : System.Web.UI.Page
    {
        string connection = (@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecord();
        }
        void updtUsr() //Teachers update not Completed
        {
            try
            {
                string salting = HashPass.Saltmethod();
                string passed = HashPass.hashed(txtPass.Text, salting);


                SqlConnection conn = new SqlConnection(connection);

                // string connection = @"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                SqlCommand cmd = new SqlCommand("update userTB set Name=@Name,IDNumber=@IDNumber,Gender=@Gender,username=@username,password=@password,salting=@salting WHERE IDNumber=@IDNumber", conn);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@IDNumber", txtid.Text);
                cmd.Parameters.AddWithValue("@Gender", drpgender.Text);

                cmd.Parameters.AddWithValue("@username", txtuser.Text);
                cmd.Parameters.AddWithValue("@password", passed);
                cmd.Parameters.AddWithValue("@salting", salting);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Successfully updated";

                conn.Close();
                LoadRecord();

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
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand comm = new SqlCommand("select Name,IDNUmber,Gender,username,password from userTB where userID=" + "1" + "", conn);
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
                    SqlCommand cmd = new SqlCommand("insert into userTB (userID,Name,IDNumber,Gender,username,password,salting) values (@userID,@Name,@IDNumber,@Gender,@username,@password,@salting)", conn);
                    //userID 1 Represent Teachers
                    cmd.Parameters.AddWithValue("@userID", "1");
                    cmd.Parameters.AddWithValue("@Name", txtname.Text);
                    cmd.Parameters.AddWithValue("@IDNumber", txtid.Text);
                    cmd.Parameters.AddWithValue("@Gender", drpgender.Text);


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
                    // lblmsg.Text = "Something went wrong:" + ex.ToString();

                    lblmsg.Text = "Something went wrong:";
                }
            }


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            registerUser();
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
                    drpgender.Text = r.GetValue(3).ToString();

                    txtuser.Text = r.GetValue(6).ToString();
                    txtPass.Text = r.GetValue(6).ToString();
                }


                conn.Close();
            }
            catch (Exception)

            {
                lblmsg.Text = "Something went wrong: ";

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            updtUsr();
        }
        void deltTeacher()
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
        protected void btndelete_Click(object sender, EventArgs e)
        {
            deltTeacher();
        }
    }

}
