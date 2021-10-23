using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.Models
{
    public class EditProduct
    {        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }  
        [Required]
        public Decimal Price { get; set; }
        public string Company { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSold { get; set; }
    }
}
