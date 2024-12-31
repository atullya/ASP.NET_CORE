namespace EFCoreNCCSB.Models
    // Entity framework is used to perform database operation in asp.net core.
    //It uses object relational mapper (ORM) means that all the database operation
    //like create, insert, update and delete are done by creating classes and 
    //object. To use EF core two package are required. EntityFrameWorkCore.SqlServer
    // and EnityFrameworkCore.Tools
{
    public class Student
        //this class ise used to create neccessary parameter for creating 
        //table and it's column i.e. properties of the class will be used
        //to create column of database table 
    {
        public Guid Id { get; set; } //creates auto id
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Faculty { get; set; }   
        public string Fee { get; set; }
    }
}
