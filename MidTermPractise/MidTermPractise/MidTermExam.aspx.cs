using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace MidTermPractise
{
    public partial class MidTermExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();  // Load data when the page loads initially
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = uid.Text;
                string username = uname.Text;
                string password = pass.Text;
                string gender = rb1.Checked ? "Male" : "Female";
                string country = "";

                if (chkNepal.Checked) country += "Nepal ";
                if (chkIndia.Checked) country += "India ";
                if (chkOther.Checked) country += "Other ";
                string faculty = "";
                if (coun.SelectedValue != "")
                {
                    faculty = coun.SelectedValue;
                }
                //database connection
                string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=true";
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string query = "INSERT INTO tbl_reg1  (UserID, Username, Password, Gender, Faculty, Country) VALUES (@UserID, @Username, @Password, @Gender, @Faculty, @Country)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Faculty", faculty);
                cmd.Parameters.AddWithValue("@Country", country);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    lblMessage.Text = "Data Inserted";
                    LoadData();
                }
                else
                {
                    lblMessage.Text = "Data not Inserted";
                }
                conn.Close();
              
            }
            catch (SqlException s)
            {
                Console.WriteLine(s);
            }
       
        }
        public void LoadData()
        {
            string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=true";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string query = "SELECT UserID, Username, Gender, Faculty, Country FROM tbl_reg1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridView.DataSource = dt;
            gridView.DataBind();
        }
    }
}