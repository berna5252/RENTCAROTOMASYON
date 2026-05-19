using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RENTCAROTOMASYON
{
    [Table("Table_category")]
    public class Category
    {

        [Key]
            public int category_ıd { get; set; }

            [Required, MaxLength(50)]
            public string category_name { get; set; }

            public virtual ICollection<Car> Cars { get; set; }
        }

    }

