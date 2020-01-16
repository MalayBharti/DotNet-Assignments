using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookService
    {
        MyDbContext dbContext = new MyDbContext();

        public void BookOptions()
        {
            string more;

            do
            {
                Console.WriteLine("**** Select Your Option: ****");
                Console.WriteLine("1: Get Book Details:");
                Console.WriteLine("2: Add New Book:");
                Console.WriteLine("3: Remove Book:");
                Console.WriteLine("4: Update Book Details:");
                Console.WriteLine("5: Get list of Books.");


                var choiceInput = Convert.ToInt32(Console.ReadLine());

                switch (choiceInput)
                {
                    case 1:
                        BookDetails();
                        break;

                    case 2:
                        AddBook();
                        break;

                    case 3:
                        RemoveBook();
                        break;

                    case 4:
                        UpdateBook();
                        break;

                    case 5:
                        GetAllBookList();
                        break;
                    default:
                        Console.WriteLine("Not a valid choice");
                        break;
                }
                Console.WriteLine("Want to perform other book operation (y/n)");
                more = Console.ReadLine();
            }
            while (more == "y");

        }

        // This Method is to get the details of Book. 

        public void BookDetails()
        {
            Console.WriteLine("Enter Book Id:");
            var bookId = Convert.ToInt32(Console.ReadLine());
            var bookDetails = dbContext.Books.Where(b => b.BookId == bookId);
            foreach (var item in bookDetails)
            {
                Console.WriteLine("Name : " + item.BookName
                    + " \n isAvailable : " + item.IsAvailbale 
                    +"\n Issued to CustomerId : " + item.CustomerId);
            }

        }

        // This Method is to add new Book. 

        public void AddBook()
        {
            Console.WriteLine("Enter New Book Name:");
            string bookName = Console.ReadLine();
            Book book = new Book()
            {
                BookName = bookName,
                IsAvailbale = true
            };

            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        // This Method is to Remove existing Book. 

        public void RemoveBook()
        {
            Console.WriteLine("Enter Book id to remove");
            var bookIdRemove = Convert.ToInt32(Console.ReadLine());
            var bookRemove = dbContext.Books.FirstOrDefault(b => b.BookId == bookIdRemove);

            if(bookRemove.IsAvailbale == false)
            {
                Console.WriteLine("Can't Remove. Book is Issued to Customer.");
            }
            else
            {
                dbContext.Books.Remove(bookRemove);
                dbContext.SaveChanges();
            }
        }

        // This Method is to Update existing Book. 

        public void UpdateBook()
        {
            Console.WriteLine("Enter Book Id to update");
            var bookIdUpdate = Convert.ToInt32(Console.ReadLine());
            var bookUpdate = dbContext.Books.FirstOrDefault(b => b.BookId == bookIdUpdate);

            if(bookUpdate.IsAvailbale == false)
            {
                Console.WriteLine("Can't Update. Book is Issued to Customer. ");
            }
            else
            {
                Book newBook = new Book();
                Console.WriteLine("Enter New BookName: ");
                var newName = Console.ReadLine();
                bookUpdate.BookName = newName;
                dbContext.Entry(bookUpdate).State = EntityState.Modified;

                dbContext.SaveChanges();
            }
        }

        // Method to fetch all the books.

        public void GetAllBookList()
        {
            var booklist = dbContext.Books.Select(s => s);

            Console.WriteLine("List Of Books are - ");
            foreach (var item in booklist)
            {
                Console.WriteLine(item.BookName);
            }
        }
    }
}
