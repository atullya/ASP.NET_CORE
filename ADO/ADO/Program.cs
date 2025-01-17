
using System.Data;
using System.Data.SqlClient;




class Program
{
    static void Main(string[] args)
    {
        CRUDoperation c1 = new CRUDoperation();
        //c1.CreateTable();
        //c1.InsertData();
        //c1.deleteData();
        c1.DisplayData();

    }
}