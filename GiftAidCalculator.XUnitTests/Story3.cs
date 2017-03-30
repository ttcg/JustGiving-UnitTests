using GiftAidCalculator.TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiftAidCalculator.XUnitTests
{
    public class Story3
    {
        ITaxRepository _taxRepo;
        GiftAidCalculation _sut;
        Events _events;

        public Story3()
        {
            _taxRepo = new TaxRepository();
            _events = new Events();
            _sut = new GiftAidCalculation(_taxRepo, _events);
        }

        [Fact]
        [Trait("Story3", "GiftAid")]
        public void Should_able_to_return_rounded_GiftAid()
        {
            _taxRepo.SetTaxAmount(10);
            var result = _sut.CalculateGiftAidAmount(100);
            Assert.Equal(11.11m, result);
        }

        [Fact]
        [Trait("Story3", "GiftAid")]
        public void Should_able_to_return_rounded_GiftAid2()
        {            
            var result = _sut.CalculateGiftAidAmount(50);
            Assert.Equal(12.5m, result);
        }
    }
}
