using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMappingDemo
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }

        [StringLength(256)]
        public string CityName { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public State State { get; set; }
    }
}
