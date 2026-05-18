using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RENTCAROTOMASYON
{
    [Table("Table_customer")]
    internal class Customer
    {
        [Key]
        public int customer_ıd { get; set; }

        [Required]
        [MaxLength(50)]
        public string customer_name { get; set; }

        [Required]
        [MaxLength(50)]
        public string customer_surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string customer_email { get; set; }

        [Required]
        [MaxLength(50)]
        public string customer_telephone { get; set; }

        public virtual ICollection<CustomerProduct> CustomerProducts { get; set; }

    }
}
