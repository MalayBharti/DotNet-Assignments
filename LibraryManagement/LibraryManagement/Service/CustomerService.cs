using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class CustomerService
    {
        MyDbContext dbContext = new MyDbContext();

        public void CustomerOptions()
        {
            string more;

            do
            {
                Console.WriteLine("**** Select Your Option: ****");
                Console.WriteLine("1: Get Customer Details:");
                Console.WriteLine("2: Add New Customer:");
                Console.WriteLine("3: Remove Customer:");
                Console.WriteLine("4: Update Customer Details:");

                var choiceInput = Convert.ToInt32(Console.ReadLine());

                switch (choiceInput)
                {
                    case 1:
                        CustomerDetails();
                        break;

                    case 2:
                        AddCustomer();
                        break;

                    case 3:
                        RemoveCustomer();
                        break;

                    case 4:
                        UpdateCustomer();
                        break;
                }
                Console.WriteLine("Want to perform other Customer operation (y/n)");
                more = Console.ReadLine();
            }
            while (more == "y");
        }

        // This Method is to get the details of Customer. 

        public void CustomerDetails()
        {
            Console.WriteLine("Enter Customer Id:");
            var customerId = Convert.ToInt32(Console.ReadLine());
            var customerDetails = dbContext.Customers.Where(c => c.CustomerId == customerId);
            foreach (var item in customerDetails)
            {
                Console.WriteLine("Name = " + item.CustomerName);
            }

        }

        // This Method is to add new Customer. 

        public void AddCustomer()
        {
            Console.WriteLine("Enter New Customer Name:");
            string customerName = Console.ReadLine();
            Customer customer = new Customer()
            {
                CustomerName = customerName
            };

            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        // This Method is to Remove existing Customer. 

        public void RemoveCustomer()
        {
            Console.WriteLine("Enter Customer id to remove");
            var customerIdRemove = Convert.ToInt32(Console.ReadLine());
            var customerRemove = dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerIdRemove);
            dbContext.Customers.Remove(customerRemove);
            dbContext.SaveChanges();
        }

        // This Method is to Update existing Customer. 

        public void UpdateCustomer()
        {
            Console.WriteLine("Enter Customer Id to update");
            var customerIdUpdate = Convert.ToInt32(Console.ReadLine());
            var customerUpdate = dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerIdUpdate);
            Customer newCustomer = new Customer();
            Console.WriteLine("Enter New Name: ");
            var newName = Console.ReadLine();
            customerUpdate.CustomerName = newName;
            dbContext.Entry(customerUpdate).State = EntityState.Modified;

            dbContext.SaveChanges();

        }
    }
}
