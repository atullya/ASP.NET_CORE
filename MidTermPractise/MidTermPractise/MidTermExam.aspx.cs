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
                CreateTableIfNotExists(); // Ensure table exists
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

                // Database connection
                string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=true";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    CreateTableIfNotExists(); // Ensure table exists before inserting data

                    string query = "INSERT INTO tbl_reg1  (UserID, Username, Password, Gender, Faculty, Country) VALUES (@UserID, @Username, @Password, @Gender, @Faculty, @Country)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", id);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Faculty", faculty);
                        cmd.Parameters.AddWithValue("@Country", country);

                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            lblMessage.Text = "Data Inserted Successfully!";
                            LoadData();
                        }
                        else
                        {
                            lblMessage.Text = "Data not Inserted.";
                        }
                    }
                }
            }
            catch (SqlException s)
            {
                lblMessage.Text = "Database Error: " + s.Message;
            }
        }

        public void LoadData()
        {
            string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=true";
            SqlConnection conn = new SqlConnection(cs);
            
                conn.Open();
                string query = "SELECT UserID, Username, Gender, Faculty, Country FROM tbl_reg1";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                gridView.DataSource = reader;
                gridView.DataBind();
            
        }

        private void CreateTableIfNotExists()
        {
            string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                string query = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tbl_reg1')
                    BEGIN
                        CREATE TABLE tbl_reg1 (
                            UserID NVARCHAR(50) PRIMARY KEY,
                            Username NVARCHAR(100) NOT NULL,
                            Password NVARCHAR(100) NOT NULL,
                            Gender NVARCHAR(10) NOT NULL,
                            Faculty NVARCHAR(100) NOT NULL,
                            Country NVARCHAR(255) NOT NULL
                        )
                    END";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
