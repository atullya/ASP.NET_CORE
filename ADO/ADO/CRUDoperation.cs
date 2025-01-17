using System;
using Microsoft.Data.SqlClient;

class CRUDoperation
{
    string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=True;TrustServerCertificate=True";

    public void CreateTable()
    {
        try
        {
            SqlConnection sc = new SqlConnection(cs);
            sc.Open();
            string createTableQuery = "CREATE TABLE std_table1 (id INT PRIMARY KEY, name VARCHAR(50), gender VARCHAR(50), faculty VARCHAR(50))";
            SqlCommand cmd = new SqlCommand(createTableQuery, sc);
            int res= cmd.ExecuteNonQuery();
           
                Console.WriteLine("Database crated successfully!!");
           

        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Error: " + ex.Message);
        }
    }

    public void InsertData()
    {
        try
        {
            // Insert a new student record

            Console.WriteLine("Enter Student Name:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter Faculty:");
            string faculty = Console.ReadLine();


            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            string insQuery = "Insert into std_table (id,name,gender,faculty) VALUES (@id,@name,@gender,@faculty) ";
            SqlCommand cmd = new SqlCommand(insQuery, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@faculty", faculty);

            int res=cmd.ExecuteNonQuery();
            if (res > 0)
            {
                Console.WriteLine("Data inserted successfully.");
            }
            else
            {
                Console.WriteLine("No new records were inserted. Record may already exist.");
            }


        }
        catch(SqlException s)
        {
            Console.WriteLine(s);
        }
    }
    public void DisplayData()
    {
        try
        {
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();
            string disQuery = "Select * from std_table";
            SqlCommand cmd = new SqlCommand(disQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id is " + reader["id"]);
                Console.WriteLine("Username is " + reader["name"]);
         
                Console.WriteLine("Gender is " + reader["gender"]);
                Console.WriteLine("Faculty is " + reader["faculty"]);
            }

        }
        catch (SqlException s)
        {
            Console.WriteLine(s);
        }
    }

    public void deleteData()
    {
        SqlConnection conn = new SqlConnection(cs);
        conn.Open();
        string delQuery = "Delete from std_table where name='atullya' and faculty='csit' ";
        SqlCommand sc = new SqlCommand(delQuery, conn);
        int res = sc.ExecuteNonQuery();
        if (res > 0)
        {
            Console.WriteLine(res + "Data Deleted Suceessfull");
        }
    }
}
