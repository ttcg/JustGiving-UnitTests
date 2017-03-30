using GiftAidCalculator.TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiftAidCalculator.XUnitTests
{
    public class Story2
    {
        ITaxRepository _taxRepo;
        GiftAidCalculation _sut;
        Events _events;

        public Story2()
        {
            _taxRepo = new TaxRepository();
            _events = new Events();
            _sut = new GiftAidCalculation(_taxRepo, _events);
        }

        [Fact]
        [Trait("Story2", "Tax")]
        public void Should_able_to_set_TaxAmount()
        {
            _taxRepo.SetTaxAmount(10);
            var result = _taxRepo.GetTaxAmount();
            Assert.Equal(10, result);
        }

        [Fact]
        [Trait("Story2", "Tax")]
        public void Should_able_to_calculate_with_CustomTaxAmount()
        {
            _taxRepo.SetTaxAmount(10);

            var result = _sut.CalculateGiftAidAmount(100);
            Assert.Equal(11.11m, result, 2);
        }

        [Fact]
        [Trait("Story2", "Exception")]
        public void Should_throw_TaxAmountInvalidError_for_less_than_ZERO()
        {            
            Exception ex = Assert.Throws<ArgumentException>(() => _taxRepo.SetTaxAmount(-5));
            Assert.Equal(typeof(ArgumentException), ex.GetType());
        }

        [Fact]
        [Trait("Story2", "Exception")]
        public void Should_throw_TaxAmountInvalidError_for_HUNDRED()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => _taxRepo.SetTaxAmount(100));
            Assert.Equal(typeof(ArgumentException), ex.GetType());
        }
    }
}
