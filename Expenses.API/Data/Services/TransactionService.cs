using Expenses.API.Dtos;
using Expenses.API.Models;

namespace Expenses.API.Data.Services
{
    public interface ITransactionsService
    {
        List<Transaction> GetAll(int UserId);
        Transaction? GetById(int id);
        Transaction Add(PostTransactionDto transaction, int UserId);
        Transaction? Update(int id, PutTransactionDto transaction);
        void Delete(int id);
    }

    public class TransactionsService(AppDbContext context) : ITransactionsService
    {
        public Transaction Add(PostTransactionDto transaction, int UserId)
        {
            var newTransaction = new Transaction()
            {
                UserId = UserId,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Category = transaction.Category,
                CreateAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            context.Transactions.Add(newTransaction);
            context.SaveChanges();

            return newTransaction;
        }

        public void Delete(int id)
        {
            var transactionDb = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transactionDb != null)
            {
                context.Transactions.Remove(transactionDb);
                context.SaveChanges();
            }
        }

        public List<Transaction> GetAll(int UserId)
        {
            var allTransactions = context.Transactions.Where(n => n.UserId == UserId ).ToList();
            return allTransactions;
        }

        public Transaction? GetById(int id)
        {
            var transactionDb = context.Transactions.FirstOrDefault(n => n.Id == id);
            return transactionDb;

        }

        public Transaction? Update(int id, PutTransactionDto transaction)
        {
            var transactionDb = context.Transactions.FirstOrDefault(n => n.Id == id);
            if (transactionDb != null)
            {
                transactionDb.Type = transaction.Type;
                transactionDb.Amount = transaction.Amount;
                transactionDb.Category = transaction.Category;
                transactionDb.UpdatedAt = DateTime.UtcNow;

                context.Transactions.Update(transactionDb);
                context.SaveChanges();
            }

            return transactionDb;
        }
    }
}