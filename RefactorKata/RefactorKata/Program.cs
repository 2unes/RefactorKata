﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
            /*
             * cmd.CommandText = "Select * from Invoices";
             */
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();

            //TODO: Replace with Dapper
            while (reader.Read())
            {
                var prod = new Product
                {
                    name = reader["Name"].ToString()
                };
                products.Add(prod);
            }
            Console.WriteLine("Products Loaded!");
            conn.Dispose();

            foreach (var t in products)
            {
                Console.WriteLine(t.name);
            }
        }
    }
    public class Product
    {
        public string name { get; set; }
        
    }
}
