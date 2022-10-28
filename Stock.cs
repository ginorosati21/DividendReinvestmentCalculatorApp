using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DividendReinvestmentCalculatorApp
{
    class Stock
    {
        private string symbol = "";
        private double sharePrice = 0;
        private double yield = 0;
        private double yieldPercentage = 0;
        private double totalYield = 0;
        private int dividendPayments = 0;
        private double shares = 0;
        private double cost = 0;
        private double costPerShare = 0;
        private double value = 0;
        private double returnPercentage = 0;
        private double portfolioPercntage = 0;

        public Stock()
        { }

        public Stock(string symbol, double sharePrice, double shares, double yield, double cost, int dividendPayments)
        {
            this.symbol = symbol;
            this.sharePrice = sharePrice;
            this.shares = shares;
            this.yield = yield;
            this.cost = cost;
            this.dividendPayments = dividendPayments;
            //this.yieldPercentage = CalculateYieldPercentage(this.sharePrice, this.yield);
            //this.costPerShare = CalculateCostPerShare(this.shares, this.cost);
            //this.value = CalculateValue(this.shares, this.sharePrice);
            //this.returnPercentage = CalculateReturnPercentage(this.cost, this.value);

        }

    

        public string Symbol { get; set; }
        public double SharePrice { get; set; }
        public double Yield { get; set; }
        public double YieldPercentage { get; set; }
        public int DividendPayments { get; set; }
        public double Shares { get; set; }
        public double Cost { get; set; }
        public double CostPerShare { get; set; }
        public double Value { get; set; }
        public double ReturnPercentage { get; set; }
        public double PortfolioPercentage { get; set; }
        public double TotalYield { get; set; }
    }

    
}
