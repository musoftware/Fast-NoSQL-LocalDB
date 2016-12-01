using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fast_NoSQL_LocalDB
{
    public class Customer
    {
        public Customer()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public bool IsActive { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // Basic example

            // Open database (or create if not exits)
            using (var db = new LiteDatabase(@"MyData.db"))
            {
                // Get customer collection
                var customers = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "John Doe",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                customers.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                customers.Update(customer);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);

                // Use Linq to query documents
                var results = customers.Find(x => x.Name.StartsWith("Jo"));

                foreach (var item in results)
                {
                    
                }

            }

        }

    }
}
