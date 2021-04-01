using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chainblock.Contracts;
using Moq;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockStructureTests
    {
        private Mock<ITransaction> trancation;
        private ChainBlockStructure chainBlock;
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
            amount = 10;

            trancation = new Mock<ITransaction>();
            chainBlock = new ChainBlockStructure();

            trancation.Setup(i => i.Id).Returns(id);
            trancation.Setup(s => s.Status).Returns(status);
            trancation.Setup(f => f.From).Returns(@from);
            trancation.Setup(t => t.To).Returns(to);
            trancation.Setup(a => a.Amount).Returns(amount);
        }

        public List<ITransaction> GetInSideListOfChainBlock()
        {
            var insideTransaction = chainBlock
                .GetType()
                .GetFields((BindingFlags)60)
                .FirstOrDefault(f => f.Name == "transactions")
                .GetValue(chainBlock);

            return (List<ITransaction>)insideTransaction;
        }

        [Test]
        public void When_AddTransaction_ShouldBeAdded()
        {
            chainBlock.Add(trancation.Object);

            List<ITransaction> transactions = GetInSideListOfChainBlock();

            Assert.AreEqual(1, transactions.Count);
        }

        [Test]
        public void When_AddTransactionWithExistingId_ShouldThrowException()
        {
            chainBlock.Add(trancation.Object);

            Assert.Throws<ArgumentException>(
                () => chainBlock.Add(trancation.Object),
                "Transaction with this id already exist");
        }

        [Test]
        public void When_AddTransaction_CountShouldBeIncrease()
        {
            chainBlock.Add(trancation.Object);

            Assert.AreEqual(1, chainBlock.Count);
        }

        [Test]
        public void When_TryContainsByTransaction_ShouldReturnTrue()
        {
            chainBlock.Add(trancation.Object);

            Assert.IsTrue(chainBlock.Contains(trancation.Object));
        }

        [Test]
        public void When_TryContainsByTransaction_AndDoNotHaveThatTransaction_ShouldReturnFalse()
        {
            Assert.IsFalse(chainBlock.Contains(trancation.Object));
        }

        [Test]
        public void When_TryContainsById_ShouldReturnTrue()
        {
            chainBlock.Add(trancation.Object);

            Assert.IsTrue(chainBlock.Contains(trancation.Object.Id));
        }

        [Test]
        public void When_TryContainsById_AndDoNotHaveThatTransaction_ShouldReturnFalse()
        {
            Assert.IsFalse(chainBlock.Contains(trancation.Object.Id));
        }

        [Test]
        public void When_ChangeTransactionStatusById_TransactionStatus_ShouldBeChange()
        {
            ITransaction currentTransaction = new Transaction(id, status, @from, to, amount);

            chainBlock.Add(currentTransaction);

            chainBlock.ChangeTransactionStatus(1, TransactionStatus.Failed);

            List<ITransaction> transactions = GetInSideListOfChainBlock();
            ITransaction changeTransaction = transactions.FirstOrDefault(t => t.Id == trancation.Object.Id);

            Assert.AreEqual(TransactionStatus.Failed, changeTransaction.Status);
        }

        [Test]
        public void When_ChangeTransactionStatusById_AndTransactionNoExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainBlock.ChangeTransactionStatus(1, TransactionStatus.Successfull),
                "Transaction with that id already exist");
        }

        [Test]
        public void When_RemoveById_ShouldBeRemoved()
        {
            chainBlock.Add(trancation.Object);
            chainBlock.RemoveTransactionById(trancation.Object.Id);

            List<ITransaction> insideTransactions = GetInSideListOfChainBlock();

            Assert.AreEqual(0, insideTransactions.Count);
        }

        [Test]
        public void When_RemoveById_AndNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainBlock.RemoveTransactionById(1),
                "Transaction with that id doesn't exist");
        }

        [Test]
        public void When_GetById_ShouldReturnTransactionWithThatId()
        {
            chainBlock.Add(trancation.Object);

            ITransaction getTransaction = chainBlock.GetById(trancation.Object.Id);

            Assert.AreEqual(trancation.Object.Id, getTransaction.Id);
        }

        [Test]
        public void When_GetById_AndDoNotExist_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(
                () => chainBlock.GetById(1),
                "Transaction with that id doesn't exist");
        }

        [Test]
        public void When_GetByStatus_AndDoNotExistsTransactions_ShouldThrowException()
        {
            ITransaction secondTransaction = new Transaction(12, TransactionStatus.Aborted, @from, to, amount);
            chainBlock.Add(trancation.Object);
            chainBlock.Add(secondTransaction);

            Assert.Throws<InvalidOperationException>(
                () => chainBlock.GetByTransactionStatus(TransactionStatus.Failed),
                "Transaction with that status doesn't exist");
        }

        [Test]
        public void When_GetByStatus_ShouldReturnAndSortDescendingOrderByAmount()
        {
            ITransaction secondTransaction = new Transaction(12, TransactionStatus.Successfull, @from, to, 12);
            chainBlock.Add(trancation.Object);
            chainBlock.Add(secondTransaction);

            List<ITransaction> sortDescendingByAmount = chainBlock
                .GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            Assert.AreEqual(12, sortDescendingByAmount[0].Amount);
            Assert.AreEqual(2, sortDescendingByAmount.Count);
        }

        [Test]
        public void When_GetAllSenderWithTransactionStatus_AndNotExist_ShouldThrowException()
        {
            chainBlock.Add(trancation.Object);

            Assert.Throws<InvalidOperationException>(
                () => chainBlock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed),
                "Transactions with that status not exist.");
        }

        [Test]
        public void When_GetAllSenderWithTransactionStatus_ShouldReturnCollectionOfTransactionWithThatStatusAndOrderByAmount()
        {
            ITransaction secondTransaction = new Transaction(12, status, "Gosho", "Pesho", 12);
            chainBlock.Add(trancation.Object);
            chainBlock.Add(secondTransaction);

            List<string> senders = chainBlock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            Assert.AreEqual(2, senders.Count);
            Assert.AreEqual(@from, senders[0]);
        }

        [Test]
        public void When_GetAllReceiverWithTransactionStatus_AndNotExist_ShouldThrowException()
        {
            chainBlock.Add(trancation.Object);

            Assert.Throws<InvalidOperationException>(
                () => chainBlock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed),
                "Transactions with that status not exist.");
        }

        [Test]
        public void When_GetAllReceiverWithTransactionStatus_ShouldReturnCollectionOfTransactionWithThatStatusAndOrderByAmount()
        {
            ITransaction secondTransaction = new Transaction(12, status, "Gosho", "Pesho", 12);
            chainBlock.Add(trancation.Object);
            chainBlock.Add(secondTransaction);

            List<string> senders = chainBlock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            Assert.AreEqual(2, senders.Count);
            Assert.AreEqual(to, senders[0]);
        }

        [Test]
        public void When_GetAllOrderedByAmountDescendingThenById_ShouldReturnSortCollection()
        {
            ITransaction secondTransaction = new Transaction(2, status, @from, to, 12); // first
            ITransaction thirdTransaction = new Transaction(3, status, @from, to, 11); //second
            ITransaction fourthTransaction = new Transaction(4, status, @from, to, 11); // third

            chainBlock.Add(trancation.Object); //id = 1 amount = 10 / fourth
            chainBlock.Add(fourthTransaction);
            chainBlock.Add(thirdTransaction);
            chainBlock.Add(secondTransaction);

            List<ITransaction> sortedTransactions = chainBlock.GetAllOrderedByAmountDescendingThenById()
                .ToList();

            Assert.AreEqual(12, sortedTransactions[0].Amount);
            Assert.AreEqual(3, sortedTransactions[1].Id);
            Assert.AreEqual(4, sortedTransactions[2].Id);
            Assert.AreEqual(10, sortedTransactions[3].Amount);
        }
    }
}