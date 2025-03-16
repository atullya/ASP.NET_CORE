using System;
using Micrsoft.Data.SqlClient;

class CRUDOPEation{

    string cs = "Data Source=DESKTOP-AHSLSJ6;Initial Catalog=db_nccsb;Integrated Security=True;TrustServerCertificate=True";
   public void InsertData(){
        try{
            Console.WriteLine("Enter ID:");
            int =Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter Name:");
            string name=Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter Gender:");
            string gender=Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter Faculty:");
            string faculty=Int32.Parse(Console.ReadLine());

            SqlConnection conn=new SqlConnection(cs);
            conn.Open();

            string insQuery="insert into tbl_std (id,name,gender,faculty) values(@id,@name,@gender,@faculty)";
            SqlCommand cmd=new SqlCommand(insQuery,conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@faculty", faculty);

            int res=cmd.ExecuteNonQuery();

            if(res>0){
                Console.WriteLine("Insertion successfully");
            }else{
                   Console.WriteLine("Insertion failed");
            }



        }catch(SqlException e){
            Console.WriteLine(e.Message);
        }finally{
            conn.Close();
        }

   }

public void DeleteData(){
    try{
           Console.WriteLine("Enter Name:");
            string name=Int32.Parse(Console.ReadLine());
        SqlConnection conn=new SqlConnection(cs);
        conn.Open();

        string delQuery="delete from tbl_std where name=@name";
            SqlCommand cmd=new SqlCommand(delQuery,conn);
              sc.Parameters.AddWithValue("@name", name);
                int res=cmd.ExecuteNonQuery();
            if(res>0){
  Console.WriteLine("Deletion successfully");
            }else{
                  Console.WriteLine("Deletion unsucessfly");
            }

    }catch(SqlException e){
            Console.WriteLine(e.Message);
        }finally{
            conn.Close();
        }
}

public void displayRecord(){
    try{
            SqlConnection conn=new SqlConnection(cs);
            conn.Open();

            string displayQuery="select * from tbl_reg";
            SqlCommand cmd=new SqlCommand(displayQuery,conn);


            SqlDataReader row= cmd.ExecuteReader();
      while (row.Read())
            {
                Console.WriteLine("Id is " + row["id"]);
                Console.WriteLine("Name is " + row["name"]);
                Console.WriteLine("Faulty is " + row["faulty"]);

                Console.WriteLine("Gender is " + row["gender"]);
            }

 }catch(SqlException e){
            Console.WriteLine(e.Message);
        }finally{
            conn.Close();
        }
}


 public void dynamicUpdate()
    {
        try
        {
           
                SqlConnection conn = new SqlConnection(cs)
                conn.Open();

                // Collecting user input
                Console.WriteLine("Enter Id to update:");
                string id = Console.ReadLine();

                Console.WriteLine("Enter Your Username:");
                string uname = Console.ReadLine();


                Console.WriteLine("Enter Your Gender:");
                string gen = Console.ReadLine();

                Console.WriteLine("Enter Your Faculty:");
                string fac = Console.ReadLine();

                string updQuery = "UPDATE tbl_std SET id = @name,  gender = @gender, faculty = @faculty WHERE id = @id";
            SqlCommand cmd = new SqlCommand(updQuery, conn);
                    int res = cmd.ExecuteNonQuery();
        
                    // Adding parameters
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gen);
                    cmd.Parameters.AddWithValue("@faculty", fac);


                    if (res > 0)
                    {
                        Console.WriteLine(" record(s) updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with the provided Id.");
                    }
                
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("SQL Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }


    class Program{
        static void Main(string[] args){
            CRUDOPEation c1=new CRUDOPEation();
            c1.InsertData();
            c1.DeleteData();
            c1.DisplayData();
            c1.dynamicUpdate();

        }
    }

