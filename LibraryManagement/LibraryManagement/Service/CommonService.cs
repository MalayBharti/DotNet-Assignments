using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service
{
    public class CommonService
    {
        public void Service()
        {
            string more;

            do
            {
                Console.WriteLine("Enter 1 for Customer Service Option");
                Console.WriteLine("Enter 2 for Book Service Option");

                var choiceInput = Convert.ToInt32(Console.ReadLine());

                switch (choiceInput)
                {
                    case 1:
                        CustomerService customerService = new CustomerService();
                        customerService.CustomerOptions();
                        break;

                    case 2:
                        BookService bookService = new BookService();
                        bookService.BookOptions();
                        break;

                    default:
                        Console.WriteLine("Enter valid choice");
                        break;
                }

                Console.WriteLine("Want to perform other service (y/n)");
                more = Console.ReadLine();
            }
            while (more == "y");
        }
    }
}
