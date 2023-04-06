using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise4JG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        //Method for close button for app to end
        {
            Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
            //Method for calculate button using Try parse, and MessageBox.Show() to validate entry
        {
            bool isValid = decimal.TryParse(txtPurchasePrice.Text, out decimal PurchasePrice);
            if (!isValid)
            {
                MessageBox.Show("Please re-enter the purchase price", "Invalid Data");
                return;
            }

            isValid = decimal.TryParse(txtDownPayment.Text, out decimal DownPayment);
            if (!isValid)
            {
                MessageBox.Show("Please re-enter the down payment", "Invalid Data");
                return;
            }

            isValid = decimal.TryParse(txtInterestRate.Text, out decimal InterestRate);
            if (!isValid)
            {
                MessageBox.Show("Please re-enter the interest rate", "Invalid Data");
                return;
            }

            isValid = decimal.TryParse(txtLoanTerms.Text, out decimal LoanTerms);
            if (!isValid)
            {
                MessageBox.Show("Please re-enter the loan terms", "Invalid Data");
                return;
            }
            //Calculations for amount to finance, interest, and monthly payment

            decimal AmountToFinance = (PurchasePrice - DownPayment);
            decimal InterestRateCalc = (InterestRate / 100);
            decimal InterestRateMonthly = InterestRateCalc / 12;
            //Monthly Payment Calculation using Math.Pow and conversions to decimal within
            decimal MonthlyPayment = InterestRateMonthly * AmountToFinance * (decimal)((Math.Pow(1 + (double)InterestRateMonthly, (double)LoanTerms) / (Math.Pow(1 + (double)InterestRateMonthly, (double)LoanTerms) - 1)));


            //Formatting output as currency and as a string 

            txtAmountToFinance.Text = AmountToFinance.ToString("C");
            txtMonthlyPayment.Text = MonthlyPayment.ToString("C");

        }

    }
}
