using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_log(object sender, EventArgs e)
        {
            string username = uname.Text;
            string password = pass.Text;
            try
            {
                string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string disQuery = "Select * from tbl_reg WHERE username=@username AND password=@password";

                SqlCommand sc = new SqlCommand(disQuery, conn);
                sc.Parameters.AddWithValue("username", username);

                sc.Parameters.AddWithValue("password", password);
                //execute query
                SqlDataReader sd=sc.ExecuteReader();
                if (sd.Read() == true)
                {
                    res.Text = "Record Found Welcome";
                }
                else
                {
                    res.Text = "username or password Incorrect";
                }

            }
            catch(SqlException msg)
            {
                Console.WriteLine(msg);
            }
        }
    }
}