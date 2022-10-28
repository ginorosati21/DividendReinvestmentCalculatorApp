using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DividendReinvestmentCalculatorApp
{
    public class Utilities
    {
        

        public static double CalculateReturnPercentage(double cost, double value)
        {
            double returnPercentage = 0;
            returnPercentage = value / cost;
            returnPercentage -= 1;
            returnPercentage *= 100;
            return returnPercentage;
        }

        public static double CalculateValue(double shares, double sharePrice)
        {
            double value = 0;
            value = shares * sharePrice;
            return value;
        }

        public static double CalculateCostPerShare(double shares, double cost)
        {
            double costPerShare = 0;
            costPerShare = cost / shares;
            return costPerShare;
        }

        public static double CalculateYieldPercentage(double sharePrice, double yield)
        {
            double yieldPercentage = 0;
            yieldPercentage = yield / sharePrice;
            yieldPercentage *= 100;
            return yieldPercentage;
        }

        public static double CalculateTotalYield(double shares, double yield)
        {
            double totalYield = 0;
            totalYield = shares * yield;
            return totalYield;
        }

        
    }
}
