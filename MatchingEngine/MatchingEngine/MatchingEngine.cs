using System;
using System.Collections.Generic;
using System.Text;

namespace MatchingEngine
{
    public class MatchingEngine
    {
        public LinkedList<Order> bids;
        public LinkedList<Order> offers;

        public List<Trade> trades;

        public MatchingEngine()
        {
            bids = new LinkedList<Order>();
            offers = new LinkedList<Order>();
            trades = new List<Trade>();
        }


        public void AddOrder(Order o)
        {
            if (o.BidOffer == BidOffer.Bid)
            {
                if (bids.Count == 0)
                {
                    bids.AddFirst(o);
                }
                else if (bids.Last.Value.Price >= o.Price)
                {
                    bids.AddLast(o);
                }
                else
                {
                    var bid = bids.First;
                    while (bid.Value.Price > o.Price)
                    {
                        bid = bid.Next;
                    }
                    bids.AddBefore(bid, o);
                }

            }
            else
            {
                if (offers.Count == 0)
                {
                    offers.AddFirst(o);
                }
                else if (offers.Last.Value.Price <= o.Price)
                {
                    offers.AddLast(o);
                }
                else
                {
                    var offer = offers.First;
                    while (offer.Value.Price < o.Price)
                    {
                        offer = offer.Next;
                    }
                    offers.AddBefore(offer, o);
                }
            }

            if (bids.Count > 0 && offers.Count > 0)
                MatchOrders();
        }

        public void MatchOrders()
        {
            var bid = bids.First;
            var offer = offers.First;

            while (bid != null && offer != null)
            {
                if (bid.Value.CounterpartyID == offer.Value.CounterpartyID)
                {
                    if (bid.Value.lastUpdateTime >= offer.Value.lastUpdateTime)
                    {
                        offer = offer.Next;
                    }
                    else
                    {
                        bid = bid.Next;
                    }    
                }
                else
                {
                    var price = bid.Value.lastUpdateTime >= offer.Value.lastUpdateTime ? bid.Value.Price : offer.Value.Price;
                    if (bid.Value.Price >= offer.Value.Price)
                    {
                        var bidVol = bid.Value.Volume;
                        var offerVol = offer.Value.Volume;

                        if (bidVol > offerVol)
                        {
                            trades.Add(new Trade() { Price = price, Volume = offerVol, tradeTime = DateTime.UtcNow });
                            //Console.WriteLine($"*** Trade Executed at {bid.Value.Price} for {bidVol - offerVol} Volume");
                            var nextOffer = offer.Next;
                            var newBid = new LinkedListNode<Order>(new Order { Price = bid.Value.Price, Volume = bidVol - offerVol, BidOffer = BidOffer.Bid, lastUpdateTime = DateTime.Now });
                            bid.Replace(newBid);
                            bid = newBid;

                            offers.Remove(offer);
                            offer = nextOffer;
                        }
                        else if (offerVol > bidVol)
                        {
                            trades.Add(new Trade() { Price = price, Volume = bidVol, tradeTime = DateTime.UtcNow });
                            //Console.WriteLine($"*** Trade Executed at {offer.Value.Price} for {offerVol - bidVol} Volume");
                            var nextBid = bid.Next;
                            var newOffer = new LinkedListNode<Order>(new Order { Price = offer.Value.Price, Volume = offerVol - bidVol, BidOffer = BidOffer.Offer, lastUpdateTime = DateTime.Now });
                            offer.Replace(newOffer);
                            offer = newOffer;

                            bids.Remove(bid);
                            bid = nextBid;
                        }
                        else if (offerVol == bidVol)
                        {
                            trades.Add(new Trade() { Price = price, Volume = offerVol, tradeTime = DateTime.UtcNow });
                            //Console.WriteLine($"*** Trade Executed at {bid.Value.Price} for full Volume");
                            var newBid = bid.Next;
                            var newOffer = offer.Next;
                            bids.Remove(bid);
                            offers.Remove(offer);
                            bid = newBid;
                            offer = newOffer;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void PrintOrders()
        {
            Console.Out.WriteLine("***Bids***");
            foreach(var bid in bids)
            {
                Console.Out.WriteLine($"Bid - t: {bid.lastUpdateTime} - p: {bid.Price} - v: {bid.Volume}");
            }
            Console.Out.WriteLine("***Offers***");
            foreach (var offer in offers)
            {
                Console.Out.WriteLine($"Offer - t: {offer.lastUpdateTime} - p: {offer.Price} - v: {offer.Volume}");
            }
        }

        public void PrintTrades()
        {
            Console.Out.WriteLine("***Trades***");
            var newvol = 0.0;
            foreach (var trade in trades)
            {
                Console.Out.WriteLine($"Trade - t: {trade.tradeTime} - p: {trade.Price} - v: {trade.Volume}");
                newvol += trade.Volume;
            }
        }
    }
}
