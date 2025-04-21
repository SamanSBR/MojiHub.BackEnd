using MojiHub.Data.Entities.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Services.Interfaces
{
    public interface IOfferService
    {
        void AddOffer(Offer offer);
        List<Offer> GetAll();
    }
}
