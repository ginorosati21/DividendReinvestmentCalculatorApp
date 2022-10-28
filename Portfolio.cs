using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DividendReinvestmentCalculatorApp
{
    class Portfolio
    {
        public List<Stock> Stocks { get; set; } = new List<Stock>();

        private double TotalDividend { get; set; } = 0;

            
    }
}
