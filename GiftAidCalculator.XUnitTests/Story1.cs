using GiftAidCalculator.TestConsole;
using System;
using Xunit;

namespace GiftAidCalculator.XUnitTests
{
    
    public class Story1
    {
        ITaxRepository _taxRepo;
        GiftAidCalculation _sut;
        Events _events;

        public Story1()
        {            
            _taxRepo = new TaxRepository();
            _events = new Events();
            _sut = new GiftAidCalculation(_taxRepo, _events);
        }

        [Fact]
        [Trait("Story1", "GiftAid")]
        public void Should_return_Default_GiftAidAmount()
        {            
            var result = _sut.CalculateGiftAidAmount(100);
            Assert.Equal(25, result);
        }

        [Fact]
        [Trait("Story1", "GiftAid")]
        public void Should_return_ZERO_GiftAidAmount()
        {
            var result = _sut.CalculateGiftAidAmount(200);
            Assert.Equal(50, result);
        }

        [Fact]
        [Trait("Story1", "Exception")]
        public void Should_throw_Exception_for_amount_ZERO()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => _sut.CalculateGiftAidAmount(0));
            Assert.Equal(typeof(ArgumentException), ex.GetType());
        }

    }
}
