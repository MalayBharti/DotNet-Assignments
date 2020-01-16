using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service
{
    public class BookIssueService
    {
        MyDbContext dbContext = new MyDbContext();

        public void BookIssueOperation()
        {
            string more;

            do
            {
                Console.WriteLine("**** Select Your Option. ****");
                Console.WriteLine("1: Issue Book to Customer.");
                Console.WriteLine("2: Return Book back to Library. :");
                Console.WriteLine("3: Get all customer who issued particular book. :");
                Console.WriteLine("4: Get all books issued particular Customer. :");
                Console.WriteLine("5: Get list of all issued book with customer name. :");

                var choiceInput = Convert.ToInt32(Console.ReadLine());

                switch (choiceInput)
                {
                    case 1:
                        IssueBook();
                        break;

                    case 2:
                        TakeReturnBook();
                        break;

                    case 3:
                        GetAllCustomer();
                        break;

                    case 4:
                        GetAllBooks();
                        break;

                    case 5:
                        IssuedBookWithCustomer();
                        break;

                    default:
                        Console.WriteLine("Not a valid choice");
                        break;
                }
                Console.WriteLine("Want to perform other BookIssue operation (y/n)");
                more = Console.ReadLine();
            }
            while (more == "y");

        }

        // Method to Issue Book to cutsomer.

        public void IssueBook()
        {
            Console.WriteLine("Enter CustomerId: ");
            var customerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n Enter BookId: ");
            var bookId = Convert.ToInt32(Console.ReadLine());

            var check = dbContext.Books.FirstOrDefault(b => b.BookId == bookId);

            if (check.IsAvailbale == false)
            {
                Console.WriteLine("Book is Already Issued to other Customer.");
            }
            else
            {
                BookIssue bookIssue = new BookIssue()
                {
                    BookId = bookId,
                    CustomerId = customerId
                };

                var bookUpdate = dbContext.Books.FirstOrDefault(b => b.BookId == bookId);
                Book newBook = new Book();
                bookUpdate.IsAvailbale = false;
                bookUpdate.CustomerId = customerId;
                dbContext.Entry(bookUpdate).State = EntityState.Modified;

                dbContext.BookIssues.Add(bookIssue);
                dbContext.SaveChanges();
            }

        }

        // Method to Return Book to Library.

        public void TakeReturnBook()
        {
            Console.WriteLine("Enter BookId to return");
            var bookId = Convert.ToInt32(Console.ReadLine());

            var check = dbContext.Books.FirstOrDefault(b => b.BookId == bookId);

            if (check.IsAvailbale == true)
            {
                Console.WriteLine("\n Book is not issued yet.");
            }
            else
            {
                var bookUpdate = dbContext.Books.FirstOrDefault(b => b.BookId == bookId);
                Book newBook = new Book();
                bookUpdate.IsAvailbale = true;
                bookUpdate.CustomerId = null;
                dbContext.Entry(bookUpdate).State = EntityState.Modified;

                dbContext.SaveChanges();
            }
        }

        // Method to get all the customer issued with particular book.

        public void GetAllCustomer()
        {
            Console.WriteLine("\n Enter BookId: ");
            var bookId = Convert.ToInt32(Console.ReadLine());

            var customerList = dbContext.Books
                .Where(b => b.BookId == bookId && b.CustomerId != null)
                .Include(c => c.Customer);

            if (customerList.Count() == 0)
            {
                Console.WriteLine("No Book with this bookId Issued.");
            }
            else
            {
                Console.WriteLine("Customers issued with this book are :");

                foreach (var item in customerList)
                {
                    Console.WriteLine(item.Customer.CustomerName);
                }
            }
        }

        // Method to get all the books issued to particular customer.

        public void GetAllBooks()
        {
            Console.WriteLine("\n Enter CustomerId: ");
            var customerId = Convert.ToInt32(Console.ReadLine());

            var customerList = dbContext.Books
                .Where(b => b.CustomerId == customerId)
                .Include(c => c.Customer);

            if (customerList.Count() == 0)
            {
                Console.WriteLine("No such customer exist.");
            }
            else
            {
                Console.WriteLine("Books issued are - ");
                foreach (var item in customerList)
                {
                    Console.WriteLine(item.BookName);
                }
            }
        }

        public void IssuedBookWithCustomer()
        {
            var issuedBookList = dbContext.Books
                .Where(b => b.IsAvailbale == false)
                .Include(c => c.Customer).ToList();

            foreach (var item in issuedBookList)
            {
                Console.WriteLine(item.BookName + " is issued to "
                    + item.Customer.CustomerName);
            }
        }
    }
}