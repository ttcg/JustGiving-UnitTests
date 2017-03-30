using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public class GiftAidCalculation
    {
        private ITaxRepository _TaxRepo;
        private Events _Events;

        public GiftAidCalculation(ITaxRepository taxRepo, Events events)
        {
            _TaxRepo = taxRepo;
            _Events = events;
        }

        public decimal CalculateGiftAidAmount(decimal donationAmount)
        {
            return CalculateGiftAidAmount(donationAmount, EventType.Others);
        }

        public decimal CalculateGiftAidAmount(decimal donationAmount, EventType eventType)
        {
            // the tax amount must be between 0 and 100
            if (donationAmount <= 0)
                throw new ArgumentException("Donation Amount is not valid.  It must be greater than zero.");
            
            var gaRatio = _TaxRepo.GetTaxAmount() / (100 - _TaxRepo.GetTaxAmount());

            // add supplement amount
            gaRatio += _Events.SupplementAmount(eventType) / 100;

            return Math.Round(donationAmount * gaRatio, 2);
        }
    }
}
