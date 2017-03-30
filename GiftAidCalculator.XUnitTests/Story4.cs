using GiftAidCalculator.TestConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GiftAidCalculator.XUnitTests
{
    public class Story4
    {
        ITaxRepository _taxRepo;
        GiftAidCalculation _sut;
        Events _events;

        public Story4()
        {
            _taxRepo = new TaxRepository();
            _events = new Events();
            _sut = new GiftAidCalculation(_taxRepo, _events);
        }

        [Fact]
        [Trait("Story4", "Events")]
        public void Should_return_Running_SupplementAmount()
        {
            var result = _events.SupplementAmount(EventType.Running);
            Assert.Equal(5m, result);
        }

        [Fact]
        [Trait("Story4", "Events")]
        public void Should_return_Swimming_SupplementAmount()
        {
            var result = _events.SupplementAmount(EventType.Swimming);
            Assert.Equal(3m, result);
        }

        [Fact]
        [Trait("Story4", "Events")]
        public void Should_return_Zero_SupplementAmount()
        {
            var result = _events.SupplementAmount(EventType.Others);
            Assert.Equal(0m, result);
        }

        [Fact]
        [Trait("Story4", "GiftAid")]
        public void Should_calculate_Swimming_SupplementAmount()
        {   
            var result = _sut.CalculateGiftAidAmount(100, EventType.Swimming);
            Assert.Equal(28m, result);
        }

        [Fact]
        [Trait("Story4", "GiftAid")]
        public void Should_calculate_Running_SupplementAmount()
        {
            var result = _sut.CalculateGiftAidAmount(100, EventType.Running);
            Assert.Equal(30m, result);
        }
    }
}
