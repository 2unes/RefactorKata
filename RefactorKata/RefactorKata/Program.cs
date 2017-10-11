using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Product> products = GetProducts();

            foreach (var Products in products)
            {
                Console.WriteLine(Products.name);
            }
        }

        private static List<Product> GetProducts()
        {
            List<Product> products;
            using (var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();
                products = new List<Product>();

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
            }
            return products;
        }
    }
}
