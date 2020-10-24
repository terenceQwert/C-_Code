using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ConsoleApp1
{
#if false
    public class Stock
    {
        public double GainLoss { get; set; }
        public string Ticker { get; set; }
    }
    public class StockPortfoilo : IEnumerable<Stock>
    {
        List<Stock> _stocks;
        public StockPortfoilo()
        {
            _stocks = new List<Stock>();
        }
        public void Add(string ticker, double gainloss)
        {
            _stocks.Add(new Stock() { Ticker = ticker, GainLoss = gainloss });
        }
        public IEnumerable<Stock> GetWorksPerformers(int topNumber) => _stocks.OrderBy((Stock stock) => stock.GainLoss).Take(topNumber);
        public void SellStocks( IEnumerable<Stock> stocks)
        {
            foreach( Stock s in stocks)
            {
                _stocks.Remove(s);
            }
        }

        public void PrintPortfolio( string titles)
        {
            Console.WriteLine(titles);
        }
#region IEnumerable<Stock> Members
        public IEnumerable<Stock> GetEnumerator() => _stocks.GetEnumerator();
#endregion
#region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
#endregion
    }
#endif  // false

    public  struct Data
    {
        public int IntData { get; set; }
        public float FloatData { get; set; }
        public string StrData { get; set; }
        public char CharData { get; set; }
        public bool BoolData { get; set; }
        public Data( int intData, float floatData, string strData, char charData, bool boolData)
        {
            IntData = intData;
            FloatData = floatData;
            StrData = strData;
            CharData = charData;
            BoolData = boolData;
        }
        public Data( int intData , float floatData = 0.7f, string strData="a", char charData='a') : this() 
        {
            IntData = intData;
            FloatData = floatData;
            StrData = strData;
            CharData = charData;
            BoolData = false;
        }
        public override string ToString()
        {
            return (IntData + "::" + FloatData + "::" + StrData + "::" + CharData + "::" + BoolData);
        }
    }

}
