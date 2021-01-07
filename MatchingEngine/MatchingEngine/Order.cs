using System;
using System.Collections.Generic;
using System.Text;

namespace MatchingEngine
{
    public struct Order
    {
        public double Price;
        public double Volume;
        public int CounterpartyID;
        public long orderID;
        public BidOffer BidOffer;
        public int commodityID;
        public DateTime lastUpdateTime;
    }

    public enum BidOffer
    {
         Bid,
         Offer
    }
}
