using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENTCAROTOMASYON
{
    [Table("Table_car")]

    public class Car
    {
        [Key]
        public int car_ıd { get; set; }

        [Required, MaxLength(50)]
        public string car_name { get; set; }

        [Required]
        public decimal car_dailyprice { get; set; }

        [ForeignKey("Category")]
        public int category_ıd { get; set; }

        [Required, MaxLength(20)]
        public string car_plate { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<CustomerCar> CustomerCars { get; set; }
    }
}
