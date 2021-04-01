using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock
{
    public class ChainBlockStructure : IChainblock
    {
        private List<ITransaction> transactions;

        public ChainBlockStructure()
        {
            transactions = new List<ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.Any(t => t.Id == tx.Id))
            {
                throw new ArgumentException("Transaction with this id already exist");
            }

            transactions.Add(tx);
        }

        public bool Contains(ITransaction tx)
        {
            ITransaction transaction = transactions
                .FirstOrDefault(t => t.Id == tx.Id);

            return transaction != null;
        }

        public bool Contains(int id)
        {
            ITransaction transaction = transactions
                .FirstOrDefault(t => t.Id == id);

            return transaction != null;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (transactions.Any(t => t.Id == id) == false)
            {
                throw new InvalidOperationException("Transaction with that id already exist");
            }

            int indexOfTransaction = transactions.FindIndex(t => t.Id == id);

            transactions[indexOfTransaction].Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (transactions.Any(t => t.Id == id) == false)
            {
                throw new InvalidOperationException("Transaction with that id doesn't exist");
            }

            transactions.RemoveAll(t => t.Id == id);
        }

        public ITransaction GetById(int id)
        {
            if (transactions.Any(t => t.Id == id) == false)
            {
                throw new InvalidOperationException("Transaction with that id doesn't exist");
            }

            return transactions.First(t => t.Id == id);
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (transactions.Any(t => t.Status == status) == false)
            {
                throw new InvalidOperationException("Transaction with that status doesn't exist");
            }

            var sortedTransactions = transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount);

            return sortedTransactions;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (transactions.Any(t => t.Status == status) == false)
            {
                throw new InvalidOperationException("Transactions with that status not exist.");
            }

            List<string> senders = transactions
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            return senders;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (transactions.Any(t => t.Status == status) == false)
            {
                throw new InvalidOperationException("Transactions with that status not exist.");
            }


            List<string> receivers = transactions
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            return receivers;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id);
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}