using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace DividendReinvestmentCalculatorApp
{
    public partial class Program : Form
    {
        private TextBox sharesBox;
        private TextBox sharePriceBox;
        private TextBox yieldBox;
        private Label label3;
        private Label label4;
        private TextBox yearsBox;
        private Label label5;
        private ComboBox dividendPaymentsCombo;
        private Label label6;
        private TextBox extraInvestmentBox;
        private Label label1;

        static double sharePrice = 0;
        static double shares = 0;
        static double yield = 0;
        static double yieldPercentage = 0;
        static double extraInvestment = 0;
        static int paymentsPerYear = 0;
        static int investmentFrequency = 0;

        static double totalDividend = 0;
        static double periodDividend = 0;
        private RichTextBox compoundingTextBox;
        private Button clearButton;
        private Label label8;
        private Label label9;
        private TextBox symbolBox;
        private Label label10;
        private TextBox costBox;
        private Label label2;
        private Button addStockButton;
        private RichTextBox allStocksBox;
        static double totalValue = 0;
        private Button clearStocksButton;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label totalPortfolioValueLabel;
        private Label totalPortfolioYieldLabel;
        private Label totalYieldPercentageLabel;
        private Button removeStockButton;
        private Label label14;
        private Label label15;
        private Button calculateCompoundingButton;
        static List<Stock> portfolio = new List<Stock>();
        private Label label7;
        private TextBox dividendGrowthBox;
        private Label label16;
        private TextBox annualAppreciationBox;
        private Portfolio _portfolioCompounding = new Portfolio();
        private Portfolio _portfolio = new Portfolio();

        public Program()
        {
            InitializeComponent();
        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
            
        }

        private void InitializeComponent()
        {
            this.sharesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sharePriceBox = new System.Windows.Forms.TextBox();
            this.yieldBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yearsBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dividendPaymentsCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.extraInvestmentBox = new System.Windows.Forms.TextBox();
            this.compoundingTextBox = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.symbolBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.costBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addStockButton = new System.Windows.Forms.Button();
            this.allStocksBox = new System.Windows.Forms.RichTextBox();
            this.clearStocksButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.totalPortfolioValueLabel = new System.Windows.Forms.Label();
            this.totalPortfolioYieldLabel = new System.Windows.Forms.Label();
            this.totalYieldPercentageLabel = new System.Windows.Forms.Label();
            this.removeStockButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.calculateCompoundingButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dividendGrowthBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.annualAppreciationBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sharesBox
            // 
            this.sharesBox.Location = new System.Drawing.Point(16, 120);
            this.sharesBox.Name = "sharesBox";
            this.sharesBox.Size = new System.Drawing.Size(100, 26);
            this.sharesBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shares:";
            // 
            // sharePriceBox
            // 
            this.sharePriceBox.Location = new System.Drawing.Point(170, 66);
            this.sharePriceBox.Name = "sharePriceBox";
            this.sharePriceBox.Size = new System.Drawing.Size(100, 26);
            this.sharePriceBox.TabIndex = 3;
            // 
            // yieldBox
            // 
            this.yieldBox.Location = new System.Drawing.Point(170, 120);
            this.yieldBox.Name = "yieldBox";
            this.yieldBox.Size = new System.Drawing.Size(100, 26);
            this.yieldBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Yield (in dollars):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Years:";
            // 
            // yearsBox
            // 
            this.yearsBox.Location = new System.Drawing.Point(432, 205);
            this.yearsBox.Name = "yearsBox";
            this.yearsBox.Size = new System.Drawing.Size(100, 26);
            this.yearsBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dividend Payments:";
            // 
            // dividendPaymentsCombo
            // 
            this.dividendPaymentsCombo.AutoCompleteCustomSource.AddRange(new string[] {
            "Annually",
            "Quarterly",
            "Monthly"});
            this.dividendPaymentsCombo.FormattingEnabled = true;
            this.dividendPaymentsCombo.Items.AddRange(new object[] {
            "Annually",
            "Quarterly",
            "Monthly"});
            this.dividendPaymentsCombo.Location = new System.Drawing.Point(170, 180);
            this.dividendPaymentsCombo.Name = "dividendPaymentsCombo";
            this.dividendPaymentsCombo.Size = new System.Drawing.Size(121, 28);
            this.dividendPaymentsCombo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Monthly Investment";
            // 
            // extraInvestmentBox
            // 
            this.extraInvestmentBox.Location = new System.Drawing.Point(432, 138);
            this.extraInvestmentBox.Name = "extraInvestmentBox";
            this.extraInvestmentBox.Size = new System.Drawing.Size(100, 26);
            this.extraInvestmentBox.TabIndex = 11;
            // 
            // compoundingTextBox
            // 
            this.compoundingTextBox.Location = new System.Drawing.Point(431, 324);
            this.compoundingTextBox.Name = "compoundingTextBox";
            this.compoundingTextBox.ReadOnly = true;
            this.compoundingTextBox.Size = new System.Drawing.Size(360, 319);
            this.compoundingTextBox.TabIndex = 15;
            this.compoundingTextBox.Text = "";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(574, 275);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(62, 23);
            this.clearButton.TabIndex = 16;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(374, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Enter in your stocks to calculate your portfolio\'s yield";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Stock Symbol";
            // 
            // symbolBox
            // 
            this.symbolBox.Location = new System.Drawing.Point(16, 65);
            this.symbolBox.Name = "symbolBox";
            this.symbolBox.Size = new System.Drawing.Size(100, 26);
            this.symbolBox.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(167, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Share Price ($)";
            // 
            // costBox
            // 
            this.costBox.Location = new System.Drawing.Point(16, 180);
            this.costBox.Name = "costBox";
            this.costBox.Size = new System.Drawing.Size(100, 26);
            this.costBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Total Cost";
            // 
            // addStockButton
            // 
            this.addStockButton.Location = new System.Drawing.Point(16, 215);
            this.addStockButton.Name = "addStockButton";
            this.addStockButton.Size = new System.Drawing.Size(75, 23);
            this.addStockButton.TabIndex = 6;
            this.addStockButton.Text = "Add Stock";
            this.addStockButton.UseVisualStyleBackColor = true;
            this.addStockButton.Click += new System.EventHandler(this.addStockButton_Click);
            // 
            // allStocksBox
            // 
            this.allStocksBox.Location = new System.Drawing.Point(12, 326);
            this.allStocksBox.Name = "allStocksBox";
            this.allStocksBox.ReadOnly = true;
            this.allStocksBox.Size = new System.Drawing.Size(360, 319);
            this.allStocksBox.TabIndex = 24;
            this.allStocksBox.Text = "";
            // 
            // clearStocksButton
            // 
            this.clearStocksButton.Location = new System.Drawing.Point(109, 215);
            this.clearStocksButton.Name = "clearStocksButton";
            this.clearStocksButton.Size = new System.Drawing.Size(75, 23);
            this.clearStocksButton.TabIndex = 8;
            this.clearStocksButton.Text = "New Stock";
            this.clearStocksButton.UseVisualStyleBackColor = true;
            this.clearStocksButton.Click += new System.EventHandler(this.clearStocksButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Total Portfolio Value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(146, 258);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Total Portfolio Yield";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(274, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(124, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Portfolio Yield %";
            // 
            // totalPortfolioValueLabel
            // 
            this.totalPortfolioValueLabel.AutoSize = true;
            this.totalPortfolioValueLabel.Location = new System.Drawing.Point(30, 275);
            this.totalPortfolioValueLabel.Name = "totalPortfolioValueLabel";
            this.totalPortfolioValueLabel.Size = new System.Drawing.Size(0, 20);
            this.totalPortfolioValueLabel.TabIndex = 28;
            // 
            // totalPortfolioYieldLabel
            // 
            this.totalPortfolioYieldLabel.AutoSize = true;
            this.totalPortfolioYieldLabel.Location = new System.Drawing.Point(158, 275);
            this.totalPortfolioYieldLabel.Name = "totalPortfolioYieldLabel";
            this.totalPortfolioYieldLabel.Size = new System.Drawing.Size(0, 20);
            this.totalPortfolioYieldLabel.TabIndex = 29;
            // 
            // totalYieldPercentageLabel
            // 
            this.totalYieldPercentageLabel.AutoSize = true;
            this.totalYieldPercentageLabel.Location = new System.Drawing.Point(289, 275);
            this.totalYieldPercentageLabel.Name = "totalYieldPercentageLabel";
            this.totalYieldPercentageLabel.Size = new System.Drawing.Size(0, 20);
            this.totalYieldPercentageLabel.TabIndex = 30;
            // 
            // removeStockButton
            // 
            this.removeStockButton.Location = new System.Drawing.Point(200, 215);
            this.removeStockButton.Name = "removeStockButton";
            this.removeStockButton.Size = new System.Drawing.Size(91, 23);
            this.removeStockButton.TabIndex = 31;
            this.removeStockButton.Text = "Remove Stock";
            this.removeStockButton.UseVisualStyleBackColor = true;
            this.removeStockButton.Click += new System.EventHandler(this.removeStockButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(428, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(432, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Calculate your portfolio\'s growth and compounding over time";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(442, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(568, 20);
            this.label15.TabIndex = 33;
            this.label15.Text = "Enter in how much you invest, how often, and for how long you plan on investing";
            // 
            // calculateCompoundingButton
            // 
            this.calculateCompoundingButton.Location = new System.Drawing.Point(445, 275);
            this.calculateCompoundingButton.Name = "calculateCompoundingButton";
            this.calculateCompoundingButton.Size = new System.Drawing.Size(75, 23);
            this.calculateCompoundingButton.TabIndex = 34;
            this.calculateCompoundingButton.Text = "Calculate";
            this.calculateCompoundingButton.UseVisualStyleBackColor = true;
            this.calculateCompoundingButton.Click += new System.EventHandler(this.calculateCompoundingButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(315, 20);
            this.label7.TabIndex = 36;
            this.label7.Text = "Average Annual Dividend Growth (decimal):";
            // 
            // dividendGrowthBox
            // 
            this.dividendGrowthBox.Location = new System.Drawing.Point(598, 138);
            this.dividendGrowthBox.Name = "dividendGrowthBox";
            this.dividendGrowthBox.Size = new System.Drawing.Size(100, 26);
            this.dividendGrowthBox.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(598, 182);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(287, 20);
            this.label16.TabIndex = 38;
            this.label16.Text = "Average Annual Appreciation (decimal):";
            // 
            // annualAppreciationBox
            // 
            this.annualAppreciationBox.Location = new System.Drawing.Point(598, 205);
            this.annualAppreciationBox.Name = "annualAppreciationBox";
            this.annualAppreciationBox.Size = new System.Drawing.Size(100, 26);
            this.annualAppreciationBox.TabIndex = 14;
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(838, 655);
            this.Controls.Add(this.annualAppreciationBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dividendGrowthBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.calculateCompoundingButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.removeStockButton);
            this.Controls.Add(this.totalYieldPercentageLabel);
            this.Controls.Add(this.totalPortfolioYieldLabel);
            this.Controls.Add(this.totalPortfolioValueLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.clearStocksButton);
            this.Controls.Add(this.allStocksBox);
            this.Controls.Add(this.addStockButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.costBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.symbolBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.compoundingTextBox);
            this.Controls.Add(this.extraInvestmentBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dividendPaymentsCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yearsBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yieldBox);
            this.Controls.Add(this.sharePriceBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sharesBox);
            this.Name = "Program";
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Program_Load(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            
            extraInvestmentBox.Clear();
            yearsBox.Clear();
            annualAppreciationBox.Clear();
            dividendGrowthBox.Clear();
            compoundingTextBox.Clear();
        }

        private void addStockButton_Click(object sender, EventArgs e)
        {
            Stock tempStock = new Stock();
            tempStock.Symbol = symbolBox.Text;
            tempStock.SharePrice = Double.Parse(sharePriceBox.Text);
            tempStock.Shares = Double.Parse(sharesBox.Text);
            tempStock.Yield = Double.Parse(yieldBox.Text);
            tempStock.Cost = Double.Parse(costBox.Text);
            tempStock.DividendPayments = ParseDividentPayments();
            tempStock.Value = Utilities.CalculateValue(tempStock.Shares, tempStock.SharePrice);
            tempStock.YieldPercentage = Utilities.CalculateYieldPercentage(tempStock.SharePrice, tempStock.Yield);
            tempStock.CostPerShare = Utilities.CalculateCostPerShare(tempStock.Shares, tempStock.Cost);
            tempStock.ReturnPercentage = Utilities.CalculateReturnPercentage(tempStock.Cost, tempStock.Value);
            tempStock.TotalYield = Utilities.CalculateTotalYield(tempStock.Shares, tempStock.Yield);
            _portfolio.Stocks.Add(tempStock);

            //add stock to list to be displayed
            DisplayStock();

            //calculate portfolio yield
            CalculatePortfolioYield();
        }

        private void CalculatePortfolioYield()
        {
            double totalPortfolioYield = 0;
            double totalYieldPercentage = 0;
            double totalPortfolioValue = 0;

            foreach(Stock stock in _portfolio.Stocks)
            {
                totalPortfolioValue += stock.Value;
                totalPortfolioYield += stock.TotalYield;
            }
            totalYieldPercentage = totalPortfolioYield / totalPortfolioValue;
            totalYieldPercentage *= 100;
            totalPortfolioValueLabel.Text = totalPortfolioValue.ToString("C", CultureInfo.CurrentCulture);
            totalPortfolioYieldLabel.Text = totalPortfolioYield.ToString("C", CultureInfo.CurrentCulture);
            totalYieldPercentageLabel.Text = totalYieldPercentage.ToString("0.####");
        }

        private void DisplayStock()
        {
            StringBuilder sb = new StringBuilder();
            double portfolioValue = 0;
            //calculate the total value for the portfolio for use in next step
            foreach(Stock stock in _portfolio.Stocks)
            {
                portfolioValue += stock.Value;
            }

            foreach(Stock stock in _portfolio.Stocks)
            {
                sb.Append(stock.Symbol + " - Share Price: " + stock.SharePrice.ToString("C", CultureInfo.CurrentCulture));
                sb.Append("\nShares: " + stock.Shares + "   Cost: " + stock.Cost.ToString("C", CultureInfo.CurrentCulture));
                sb.Append("\nYield: " + stock.Yield.ToString("C4", CultureInfo.CurrentCulture) + "    Yield %: " + stock.YieldPercentage.ToString("0.####"));
                sb.Append("\nValue: " + stock.Value.ToString("C", CultureInfo.CurrentCulture) + "    Return %: " + stock.ReturnPercentage.ToString("0.####"));
                sb.Append("\nPortfolio %: " + ((stock.Value / portfolioValue) * 100).ToString("0.####") + "    Total Annual Yield: " + stock.TotalYield.ToString("C", CultureInfo.CurrentCulture));
                sb.Append("\n\n");
            }
            allStocksBox.Text = sb.ToString();
        }

        private int ParseDividentPayments()
        {
            int dividendPayments = 0;
            switch(dividendPaymentsCombo.SelectedItem.ToString())
            {
                case "Monthly":
                    dividendPayments = 12;
                    break;
                case "Quarterly":
                    dividendPayments = 4;
                    break;
                case "Annually":
                    dividendPayments = 1;
                    break;
                default:
                    dividendPayments = 4;
                    break;
            }
            return dividendPayments;
        }

        private void clearStocksButton_Click(object sender, EventArgs e)
        {
            sharesBox.Clear();
            symbolBox.Clear();
            sharePriceBox.Clear();
            yieldBox.Clear();
            costBox.Clear();
            dividendPaymentsCombo.Text = "";
            symbolBox.Focus();
        }

        private void removeStockButton_Click(object sender, EventArgs e)
        {
            string symbol = symbolBox.Text;
            int index = portfolio.FindIndex(a => a.Symbol == symbol);
            portfolio.RemoveAt(index);
            DisplayStock();
            symbolBox.Focus();
        }

        private void calculateCompoundingButton_Click(object sender, EventArgs e)
        {
            //reset variables
            compoundingTextBox.Clear();
            _portfolioCompounding.Stocks.Clear();
            
            //transfer stocks to portfolioCompounding, this will ensure that portfolio remains intact regardless of what happens with the compounding
            foreach(Stock stock in _portfolio.Stocks)
            {
                _portfolioCompounding.Stocks.Add(stock);
            }

            //output starting portfolio value before compounding
            compoundingTextBox.Text += "Starting Portfolio:\n";
            OutputMonth();

            //take input
            double extraInvestment = 0;
            extraInvestment = Double.Parse(extraInvestmentBox.Text);
            int years = 0;
            years = Int32.Parse(yearsBox.Text);
            double dividendGrowth = 0;
            double annualAppreciation = 0;
            dividendGrowth = Double.Parse(dividendGrowthBox.Text);
            annualAppreciation = Double.Parse(annualAppreciationBox.Text);
            dividendGrowth += 1; // set up for calculations later on, will multiply by 1.05 for example
            annualAppreciation += 1;
            
            //outer loop will loop once for each year
            for(int x = 0; x < years; x++)
            {
                if(x>0)
                {
                    //include dividend growth and stock appreciation for every year except the first year
                    CalculateDividendGrowth(dividendGrowth);
                    CalculateAnnualAppreciation(annualAppreciation);
                }
                
                //inner loop will run 12 times, one interation per month
                for(int y = 0; y < 12; y++)
                {
                    //call method to loop over the portfolio for the current month
                    //passing in the iteration of the loop to determine if it will pay a dividend for the current month
                    AddMonth(extraInvestment, y+1);
                    OutputMonth(x + 1, y + 1);
                }
            }
        }

        private void CalculateAnnualAppreciation(double annualAppreciation)
        {
            foreach(Stock stock in _portfolioCompounding.Stocks)
            {
                stock.SharePrice = stock.SharePrice * annualAppreciation;
                stock.Value = Utilities.CalculateValue(stock.Shares, stock.SharePrice);
                stock.ReturnPercentage = Utilities.CalculateReturnPercentage(stock.Cost, stock.Value);
            }
        }

        private void CalculateDividendGrowth(double dividendGrowth)
        {
            foreach(Stock stock in _portfolioCompounding.Stocks)
            {
                
                stock.Yield = stock.Yield * dividendGrowth;
                //2.8 = 2.8 * 1.05  -> 2.94
                stock.TotalYield = Utilities.CalculateTotalYield(stock.Shares, stock.Yield);
                stock.YieldPercentage = Utilities.CalculateYieldPercentage(stock.SharePrice, stock.Yield);
            }
        }

        private void AddMonth(double extraInvestment, int month)
        {
           
            //divide the extra investment evenly accross the portfolio
            double investmentPerStock = extraInvestment / _portfolioCompounding.Stocks.Count;
            foreach(Stock stock in _portfolioCompounding.Stocks)
            {
                bool payDividend = false;
                payDividend = ShouldPayDividend(month, stock.DividendPayments);
                double totalInvestment = 0;
                totalInvestment = investmentPerStock;
                if(payDividend)
                {
                    totalInvestment += ((stock.Yield / stock.DividendPayments) * stock.Shares);
                }

                //calculate how many shares to buy
                double buyShares = totalInvestment / stock.SharePrice;
                stock.Shares += buyShares;
                stock.Cost += totalInvestment;
                stock.Value += totalInvestment;
                stock.TotalYield = Utilities.CalculateTotalYield(stock.Shares, stock.Yield);
            }
        }

        private void OutputMonth()
        {
            OutputMonth(0, 0);
        }

        private void OutputMonth(int year, int month)
        {
            StringBuilder sb = new StringBuilder();

            double totalPortfolioYield = 0;
            double totalYieldPercentage = 0;
            double totalPortfolioValue = 0;

            foreach (Stock stock in _portfolioCompounding.Stocks)
            {
                totalPortfolioValue += stock.Value;
                totalPortfolioYield += stock.TotalYield;
            }
            totalYieldPercentage = totalPortfolioYield / totalPortfolioValue;
            totalYieldPercentage *= 100;

            if(year == 0 && month == 0)
            {
                sb.Append("Starting Portfolio Value");
            } else
            {
                sb.Append($"Year {year}, Month {month}:");
            }
            sb.Append("\nPortfolio Value: " + totalPortfolioValue.ToString("C", CultureInfo.CurrentCulture));
            sb.Append("\nAnnual Yield: " + totalPortfolioYield.ToString("C", CultureInfo.CurrentCulture));
            sb.Append("\nMonthly Yield: " + (totalPortfolioYield / 12).ToString("C", CultureInfo.CurrentCulture));
            sb.Append("\n\n");

            compoundingTextBox.Text += sb.ToString();
        }

        private bool ShouldPayDividend(int month, int dividendPayments)
        {
            bool payDividend = false;
            if(dividendPayments == 12)
            {
                payDividend = true;
            } else if(dividendPayments == 4)
            {
                if(month == 3 || month == 6 || month == 9 || month == 12)
                {
                    payDividend = true;
                }
            } else if(dividendPayments == 1)
            {
                if(month == 12)
                {
                    payDividend = true;
                }
            }
            return payDividend;
        }

       
    }
}
