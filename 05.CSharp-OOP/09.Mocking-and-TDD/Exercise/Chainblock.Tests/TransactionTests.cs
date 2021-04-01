using System;
using System.Transactions;
using Chainblock.Contracts;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class TransactionTests
    {
        private ITransaction transaction;
        private int id;
        private TransactionStatus status;
        private string @from;
        private string to;
        private double amount;

        [SetUp]
        public void SetUp()
        {
            id = 1;
            status = TransactionStatus.Successfull;
            @from = "Pesho";
            to = "Gosho";
            amount = 2.3;
            transaction = new Transaction(id, status, @from, to, amount);
        }

        [Test]
        [TestCase(1)]
        [TestCase(100)]
        [TestCase(100)]
        public void When_ProvideId_ShouldBeSet(int positiveId)
        {
            transaction = new Transaction(positiveId, status, @from, to, amount);

            Assert.AreEqual(positiveId, transaction.Id);
        }

        [Test]
        [TestCase(42)]
        [TestCase(101)]
        [TestCase(202)]
        public void When_ChangeId_ShouldBeChange(int changeId)
        {
            transaction.Id = changeId;

            Assert.AreEqual(changeId, transaction.Id);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-42)]
        [TestCase(-100)]
        public void When_ProvideNegativeId_ShouldThrowException(int negativeId)
        {
            Assert.Throws<ArgumentException>(
                () => transaction = new Transaction(negativeId, status, @from, to, amount),
                "Id can't be negative number!");
        }

        [Test]
        public void When_ProvideTransactionStatus_ShouldBeSet()
        {
            Assert.AreEqual(status, transaction.Status);
        }

        [Test]
        public void When_ChangeTransactionStatus_ShouldBeChange()
        {
            transaction.Status = TransactionStatus.Aborted;

            Assert.AreEqual(TransactionStatus.Aborted, transaction.Status);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("                ")]
        public void When_ProvideEmptyOrWhiteSpaceWhoSendTransaction_ShouldThrowException(string emptyFrom)
        {
            Assert.Throws<ArgumentException>(
                () => transaction = new Transaction(id, status, emptyFrom, to, amount),
                "From (Who send Transaction) can't be empty or white space!");
        }

        [Test]
        public void When_ProvideWhoSendTransaction_ShouldBeSet()
        {
            Assert.AreEqual(@from, transaction.From);
        }

        [Test]
        public void When_ChangeWhoSendTransaction_ShouldBeChange()
        {
            string sendBy = "Mitko";

            transaction.From = sendBy;

            Assert.AreEqual(sendBy, transaction.From);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("              ")]
        public void When_ProvideEmptyOrWhiteSpaceWhoHasToReceiveTransaction_ShouldThrowException(string emptyTo)
        {
            Assert.Throws<ArgumentException>(
                () => transaction = new Transaction(id, status, @from, emptyTo, amount),
                "To (who has to receive) transaction can't be empty or white space!");
        }

        [Test]
        public void When_ProvideWhoHaveToReceiveTransaction_ShouldBeSet()
        {
            Assert.AreEqual(to, transaction.To);
        }

        [Test]
        public void When_ChangeWhoHasToReceiveTransaction_ShouldBeChange()
        {
            string sendTo = "Mitko";

            transaction.To = sendTo;

            Assert.AreEqual(sendTo, transaction.To);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-42)]
        public void When_ProvideZeroOrNegativeAmount_ShouldThrowException(double negativeAmount)
        {
            Assert.Throws<ArgumentException>(
                () => transaction = new Transaction(id, status, @from, to, negativeAmount),
                "Amount to send can't be zero or negative!");
        }

        [Test]
        public void When_ProvideAmount_ShouldBeSet()
        {
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        public void When_ChangeAmount_ShouldBeChange()
        {
            double newAmount = 10.3;

            transaction.Amount = newAmount;

            Assert.AreEqual(newAmount, transaction.Amount);
        }
    }
}
