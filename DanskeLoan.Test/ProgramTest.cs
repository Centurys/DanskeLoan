using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DanskeLoan.Test
{
    [TestClass]
    public class ProgramTest
    {
        private Program _program = new Program();

        [TestMethod]
        public void PaymentAmoun_Test()
        {
            var actualPaymentAmount = Math.Round(_program.PaymentAmount(500_000, 10 * 12), 2);
            var expectedPaymentAmount = 5303.28D;

            Assert.AreEqual(expectedPaymentAmount, actualPaymentAmount);
        }

        [TestMethod]
        public void AdministrationFee_Test()
        {
            var actualAdministrationFee = Math.Round(_program.AdministrationFee(500_000), 2);
            var expectedAdministrationFee = 5000D;

            Assert.AreEqual(expectedAdministrationFee, actualAdministrationFee);
        }

        [TestMethod]
        public void AnnualPercentageRate_Test()
        {
            var actualApr = Math.Round(_program.AnnualPercentageRate(500_000, 10) * 100, 2);
            var expectedApr = 2.83D;

            Assert.AreEqual(expectedApr, actualApr);
        }
    }
}