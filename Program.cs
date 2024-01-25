using System;
using System.Data.SqlClient;

namespace AdoNetConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CreateTable();
            program.InsertRecord(1, "Pavan Ratnakar", "pavanratnakar124@gmail.com", DateTime.Now);
            program.DisplayRecords();
            program.UpdateRecord(1, "Updated Pavan Ratnakar", "updatedRatnakar@example.com");
            program.DisplayRecords();
            program.DeleteRecord(1);
            program.DisplayRecords();
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
              
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
               
                SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);
                
                con.Open();
             
                cm.ExecuteNonQuery();
              
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
          
            finally
            {
                con?.Close();
            }
        }

        public void InsertRecord(int id, string name, string email, DateTime joinDate)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO student(id, name, email, join_date) VALUES(@id, @name, @email, @joinDate)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@joinDate", joinDate);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Record inserted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inserting record: " + e);
            }
            finally
            {
                con?.Close();
            }
        }

        public void UpdateRecord(int id, string name, string email)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE student SET name = @name, email = @email WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Record updated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error updating record: " + e);
            }
            finally
            {
                con?.Close();
            }
        }

        public void DeleteRecord(int id)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Record deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting record: " + e);
            }
            finally
            {
                con?.Close();
            }
        }

        public void DisplayRecords()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM student", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Email: {reader["email"]}, Join Date: {reader["join_date"]}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error displaying records: " + e);
            }
            finally
            {
                con?.Close();
            }
        }
    }
}
