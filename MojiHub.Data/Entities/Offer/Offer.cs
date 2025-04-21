using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Entities.Offer
{
    public class Offer
    {
        public Offer()
        {
                
        }
        [Key]
        public int OfferId { get; set; }  // Unique identifier for the offer

        [Required]
        [StringLength(100)]  // Title of the offer
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]  // Description of the offer
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]  // Price of the offer (positive)
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Timestamp when offer was created

        #region Relationships

        // Foreign key to User (the creator of the offer)
        public int UserId { get; set; }

        // Navigation property to the User
        [ForeignKey("UserId")]
        public User.User User { get; set; }

        // Navigation property to OfferCategory
        public ICollection<OfferCategory> OfferCategories { get; set; }

        #endregion
    }

}
