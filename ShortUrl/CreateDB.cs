using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl
{
    public class CreateDB
    {
        public void CreateDBandTable(string connectionString,string name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand($"CREATE DATABASE IF NOT EXISTS `{name}`; USE `{name}`;" +
                        "CREATE TABLE IF NOT EXISTS `links` (" +
                        "`id` int(11) NOT NULL AUTO_INCREMENT," +
                        "`longURL` varchar(300) DEFAULT NULL," +
                        "`shortURL` varchar(100) NOT NULL," +
                        "`createdData` varchar(100) DEFAULT NULL," +
                        "`count` int(11) DEFAULT NULL," +
                        "PRIMARY KEY (`id`)," +
                        "UNIQUE KEY `shortURL_UNIQUE` (`shortURL`)" +
                        ") ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci"
                        , conn);
                    command.ExecuteNonQuery();                    
                    conn.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            
        }
    }
}
