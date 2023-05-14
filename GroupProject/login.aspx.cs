using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using System.Data;
namespace GroupProject
{
    public partial class login : System.Web.UI.Page
    {
        string connection = (@"Data Source=EMMAS-INSPIRON\SQLEXPRESS;Initial Catalog=grp8DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void userLogin(object sender, EventArgs e)
        {
            verifyUser();



        }
        private void verifyUser()
        {

            try
            {


                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Select count(*) from userTB where username=@username ", conn);
                cmd.Parameters.AddWithValue("@username", txtuser.Text);

                conn.Open();




                int endview = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                conn.Close();
                if (endview == 1)
                {
                    conn.Open();
                    SqlCommand mycmd = new SqlCommand("select  password,salting,userID from userTB where username=@username ", conn);
                    mycmd.Parameters.AddWithValue("@username", txtuser.Text);

                    SqlDataReader inforeadear;
                    inforeadear = mycmd.ExecuteReader();
                    inforeadear.Read();
                    string userpass = inforeadear[0].ToString();

                    string usersalt = inforeadear[1].ToString();
                    string uid = inforeadear[2].ToString();

                    string passed = HashPass.hashed(txtpass.Text, usersalt);
                    //conn.Close();
                    if (uid == "0")
                    {
                        if (passed == userpass)

                        {
                            lblmsg.Text = "Login Successfull";

                            Response.Redirect("Student/StudentDashboard.aspx", false);

                            Session["username"] = txtuser.Text;



                        }
                        else
                        {
                            lblmsg.Text = "Incorrect username or password";
                        }

                    }

                    else if (uid == "1")
                    {
                        if (passed == userpass)

                        {


                            lblmsg.Text = "Login Successfull";


                            Response.Redirect("Teacher/Home.aspx", false);

                            Session["username"] = txtuser.Text;



                        }
                        else
                        {
                            lblmsg.Text = "Incorrect username or password";
                        }

                    }
                    else if (uid == "2")
                    {
                        if (passed == userpass)

                        {


                            lblmsg.Text = "Login Successfull";

                            Response.Redirect("Adminp/Home.aspx", false);

                            Session["username"] = txtuser.Text;



                        }
                        else
                        {
                            lblmsg.Text = "Incorrect username or password";
                        }

                    }

                    else
                    {
                        lblmsg.Text = "Incorrect username or password";
                    }



                }
                else
                {
                    lblmsg.Text = "Incorrect username or password";
                }
            }
            catch (Exception ex)
            {

                lblmsg.Text = "Incorrect username/password/Invalid inputs" + ex.ToString();
            }
        }



    }
}
