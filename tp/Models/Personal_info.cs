using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;

namespace tp.Models
{
    public class Personal_info
    {
        public List<Person> Person_list = new List<Person>();
        public List<Person> GetAllPerson()
        {
            SQLiteConnection sql = new SQLiteConnection("Data Source=./db/data1.db;Version=3;New=True;Compress=True");

            try
            {
                sql.Open();
                String req = "SELECT * FROM personal_info";
                SQLiteCommand com = sql.CreateCommand();
                com.CommandText = req;
                com.ExecuteNonQuery();
                SQLiteDataReader exec = com.ExecuteReader();
                while (exec.Read())
                {
                    Int32 id = exec.GetInt32(0);
                    String first_name = exec.GetString(1);
                    String last_name = exec.GetString(2);
                    String email = exec.GetString(3);
                    String date_birth = exec.GetString(4).ToString();
                    String image = exec.GetString(5).ToString();
                    String country = exec.GetString(6);
                    Person p = new Person(id, first_name, last_name, email, date_birth, image, country);
                    Person_list.Add(p);

                }


            }
            finally
            {
                sql.Close();
            }
            return Person_list;

        }
        public Person GetPerson(Int32 id) {
            SQLiteConnection sql = new SQLiteConnection("Data Source=./db/data1.db;Version=3;New=True;Compress=True");

            try
            {
                sql.Open();
                String req = "SELECT * FROM personal_info";
                SQLiteCommand com = sql.CreateCommand();
                com.CommandText = req;
                com.ExecuteNonQuery();
                SQLiteDataReader exec = com.ExecuteReader();
                while (exec.Read())
                {
                    Int32 id_ = exec.GetInt32(0);
                    if (id_ == id)
                    {
                        String first_name = exec.GetString(1);
                        String last_name = exec.GetString(2);
                        String email = exec.GetString(3);
                        String date_birth = exec.GetString(4).ToString();
                        String image = exec.GetString(5).ToString();
                        String country = exec.GetString(6);
                         return new Person(id_, first_name, last_name, email, date_birth, image, country);

                    }
                    
                   

                }


            }
            finally
            {
                sql.Close();
            }
            return null;
        }
        public int GetPersonByNameCountry(String name,String country_)
        {
            SQLiteConnection sql = new SQLiteConnection("Data Source=./db/data1.db;Version=3;New=True;Compress=True");

            try
            {
                sql.Open();
                String req = "SELECT * FROM personal_info";
                SQLiteCommand com = sql.CreateCommand();
                com.CommandText = req;
                com.ExecuteNonQuery();
                SQLiteDataReader exec = com.ExecuteReader();
                while (exec.Read())
                {
                    String first_name = exec.GetString(1);
                    String country = exec.GetString(6);
                    if ((first_name==name)&&(country==country_))
                    {
                        Int32 id = exec.GetInt32(0);
                        return id;

                    }
                    
                   

                }


            }
            finally
            {
                sql.Close();
            }
            return -1;
        }
    }
}
