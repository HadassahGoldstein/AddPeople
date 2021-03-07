using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HWMultipleRows.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleDB
    {
        private readonly string _connectionString;
        public PeopleDB(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM People";
            connection.Open();
            List<Person> people = new List<Person>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["age"]
                });               
            }
            return people;
        }
        public void AddPeson(Person p)
        {            
            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO People(firstName,lastName,Age)
                                    VALUES (@firstName,@lastName,@age)";
            command.Parameters.AddWithValue("@firstName", p.FirstName);
            command.Parameters.AddWithValue("@lastName", p.LastName);
            command.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
