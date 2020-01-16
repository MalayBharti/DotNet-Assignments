using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Customer
    {
        public Customer()
        {
            this.Books = new List<Book>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [StringLength(256)]
        public string CustomerName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
