using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Entities.Offer
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Navigation property for the many-to-many relationship
        public ICollection<OfferCategory> OfferCategories { get; set; }
    }

}
