using System;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private TransactionStatus status;
        private string @from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus status, string @from, string to, double amount)
        {
            Id = id;
            Status = status;
            From = @from;
            To = to;
            Amount = amount;
        }

        public int Id
        {
            get => id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id can't be negative number!");
                }

                id = value;
            }
        }

        public TransactionStatus Status
        {
            get => status;
            set => status = value;
        }

        public string From
        {
            get => @from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("From (Who send Transaction) can't be empty or white space!");
                }

                @from = value;
            }
        }

        public string To
        {
            get => to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("To (who has to receive) transaction can't be empty or white space!");
                }

                to = value;
            }
        }

        public double Amount
        {
            get => amount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Amount to send can't be zero or negative!");
                }

                amount = value;
            }
        }
    }
}