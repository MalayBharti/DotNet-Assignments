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
                Console.WriteLine("**** Select Your Option: ****");
                Console.WriteLine("1: Issue Book to Customer:");
                Console.WriteLine("2: Return Book back to Library :");

                var choiceInput = Convert.ToInt32(Console.ReadLine());

                switch (choiceInput)
                {
                    case 1:
                        IssueBook();
                        break;

                    case 2:
                        TakeReturnBook();
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

            if(check.IsAvailbale == true)
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

    }
}
