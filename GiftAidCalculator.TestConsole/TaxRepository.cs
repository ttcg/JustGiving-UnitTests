using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public class TaxRepository : ITaxRepository
    {
        // default value is 20%
        private decimal _TaxAmount { get; set; } = 20m;

        public decimal GetTaxAmount()
        {
            return _TaxAmount;
        }

        public void SetTaxAmount(decimal amount)
        {
            // the tax amount must be between 0 and 100
            if (amount <= 0 || amount >= 100)
                throw new ArgumentException("Tax Amount is not valid.  It must be between 0 and 100.");

            _TaxAmount = amount;
        }
    }
}
