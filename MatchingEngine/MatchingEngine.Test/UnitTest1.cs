using NUnit.Framework;
using System;
using System.Linq;

namespace MatchingEngine.Test
{
    [TestFixture]
    public class Tests
    {
        private MatchingEngine matchingEngine;
        [SetUp]
        public void Setup()
        {
            matchingEngine = new MatchingEngine();
        }

        [Test]
        public void ConsumeAllBids()
        {

            Random r = new Random();
            var vol = 0;
            for (int i = 0; i < 100; i++)
            {
                var newVol = r.Next(1, 20);
                vol += newVol;
                matchingEngine.AddOrder(new Order() { BidOffer = BidOffer.Bid, Price = r.Next(50, 100), Volume = newVol, lastUpdateTime = DateTime.UtcNow, CounterpartyID = 1 });
            }

            matchingEngine.AddOrder(new Order() { BidOffer = BidOffer.Offer, Price = 49, Volume = vol, lastUpdateTime = DateTime.UtcNow, CounterpartyID = 2 });

            Assert.AreEqual(0, matchingEngine.bids.Count + matchingEngine.offers.Count);
            Assert.AreEqual(matchingEngine.trades.Sum(x => x.Volume), vol);
        }

        [Test]
        public void ConsumeAllOrders()
        {

            Random r = new Random();
            var vol = 0;
            for (int i = 0; i < 100; i++)
            {
                var newVol = r.Next(1, 20);
                vol += newVol;
                matchingEngine.AddOrder(new Order() { BidOffer = BidOffer.Offer, Price = r.Next(1, 49), Volume = newVol, lastUpdateTime = DateTime.UtcNow, CounterpartyID = 1 });
            }

            matchingEngine.AddOrder(new Order() { BidOffer = BidOffer.Bid, Price = 51, Volume = vol, lastUpdateTime = DateTime.UtcNow, CounterpartyID = 2 });

            Assert.AreEqual(0, matchingEngine.bids.Count + matchingEngine.offers.Count);
            Assert.AreEqual(matchingEngine.trades.Sum(x => x.Volume), vol);
        }
    }
}