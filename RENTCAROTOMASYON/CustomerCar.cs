using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENTCAROTOMASYON
{
    [Table("Table_customercar")]
    public class CustomerCar
    {
        [Key]
        public int rental_ıd { get; set; }

        [ForeignKey("Customer")]
        public int customer_ıd { get; set; }

        [ForeignKey("Car")]
        public int car_ıd { get; set; }

        [Required]
        public DateTime rent_date { get; set; }

        [Required]
        public DateTime return_date { get; set; }

        [Required]
        public decimal total_price { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual Car Car { get; set; }
    }
}
