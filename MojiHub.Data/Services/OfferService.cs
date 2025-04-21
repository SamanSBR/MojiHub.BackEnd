using MojiHub.Data.Context;
using MojiHub.Data.Entities.Offer;
using MojiHub.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Services
{
    public class OfferService : IOfferService
    {
        private MojiHubContext _context;
        public OfferService(MojiHubContext context)
        {
            _context = context;
        }
        public void AddOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        public List<Offer> GetAll()
        {
            return _context.Offers.ToList();
        }
    }
}
