using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [StringLength(256)]
        public string BookName { get; set; }

        public Boolean IsAvailbale { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
