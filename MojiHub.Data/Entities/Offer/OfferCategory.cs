using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Entities.Offer
{
    public class OfferCategory
    {
        [Key]
        public int OfferCategoryId { get; set; }
       
        public int OfferId { get; set; }
        [ForeignKey("OfferId")]
        public Offer Offer { get; set; }

        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

}
