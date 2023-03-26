using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;

namespace console_to_db_connection
{
    class Employee
    {
        int Id;
        string Name;
        string Email;


        //Collect The Details....
        public void GetEmployee()
        {
            Console.Write("Enter The Below Details");
            Console.WriteLine("Enter Id ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Email ");
            Email = Console.ReadLine();
            string connectionstring = "Data Source=Mohamedyaheeya;Initial Catalog=LearnigConnection;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionstring);
            string insertCommand = $"INSERT INTO Employetbl VALUES ({Id}, '{Name}', '{Email}')";
            SqlCommand cmmd = new SqlCommand(insertCommand, cnn);
            cnn.Open();
            cmmd.ExecuteNonQuery();
        }
        public void showData()
        {
            string connectionstring = "Data Source=Mohamedyaheeya;Initial Catalog=LearnigConnection;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionstring);
            cnn.Open();
            string query = "select * from Employetbl";
            SqlCommand cmd;
            cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0} \t | {1} \t | {2}", reader[0], reader[1], reader[2]));
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Employee emp = new Employee();
                emp.GetEmployee();
                emp.showData();

            }
        }
    }
}