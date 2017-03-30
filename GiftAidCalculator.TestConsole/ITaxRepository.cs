using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public interface ITaxRepository
    {
        decimal GetTaxAmount();

        void SetTaxAmount(decimal amount);
    }
}
