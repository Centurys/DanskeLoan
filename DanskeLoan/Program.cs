using System;

namespace DanskeLoan
{
    public class Program
    {
        private const double InterestRate = 0.05;

        private static void Main(string[] args)
        {
            if (args is null || args.Length != 2)
            {
                Console.WriteLine($"Usage: [program name '{nameof(DanskeLoan)}'] [argument 1 loan amount] [argument 2 loan duration in years']");
                Console.WriteLine($"Example: {nameof(DanskeLoan)} 500000 10");
                return;
            }

            if (!double.TryParse(args[0], out var loanAmount))
            {
                Console.WriteLine("Wrong argument [1] 'LoanAmount' format");
                return;
            }

            if (!int.TryParse(args[1], out var loanYears))
            {
                Console.WriteLine("Wrong argument [2] 'LoanDurationYears' format");
                return;
            }

            var program = new Program();
            var loanMonths = loanYears * 12;

            var apr = program.AnnualPercentageRate(loanAmount, loanYears);

            var paymentAmount = program.PaymentAmount(loanAmount, loanMonths);

            var administrationFee = program.AdministrationFee(loanAmount);

            Console.WriteLine($"Loan amount: {loanAmount}");
            Console.WriteLine($"For: {loanYears} years");
            Console.WriteLine();

            Console.WriteLine($"Interest rate: {Math.Round(InterestRate * 100, 2)}%");
            Console.WriteLine($"'AOP', annual percentage rate: {Math.Round(apr * 100, 2)}%");
            Console.WriteLine($"Monthly cost: {Math.Round(paymentAmount, 2)}");
            Console.WriteLine($"Total amount in interest rate : {Math.Round(paymentAmount * loanMonths - loanAmount, 2)}");
            Console.WriteLine($"Total amount in administrative fees : {Math.Round(administrationFee, 2)}");
        }

        public double PaymentAmount(double loanAmount, int loanMonths)
        {
            var interstRatePerMonth = InterestRate / 12;
            var interstRatePerMonthAll = Math.Pow(1 + interstRatePerMonth, loanMonths);

            return loanAmount * ((interstRatePerMonth * interstRatePerMonthAll) / (interstRatePerMonthAll - 1));
        }

        public double AdministrationFee(double loanAmount)
        {
            return Math.Min(loanAmount * 0.01, 10_000);
        }

        public double AnnualPercentageRate(double loanAmount, int loanYears)
        {
            var loanMonths = loanYears * 12;
            var administrationFee = AdministrationFee(loanAmount);
            var totalInterestRate = PaymentAmount(loanAmount, loanMonths) * loanMonths - loanAmount;

            return (administrationFee + totalInterestRate) / loanAmount / loanYears;
        }
    }
}