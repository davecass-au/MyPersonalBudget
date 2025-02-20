using Microsoft.EntityFrameworkCore;
using Shared.Models.Entities;

namespace API.Data
{
    public class MyBudgetDbContext(DbContextOptions<MyBudgetDbContext> options) : DbContext(options)
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<BalanceCorrectionEntity> BalanceCorrections { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<TransactionSingleInstanceEntity> TransactionSingleInstances { get; set; }
        public DbSet<TransactionRecurringInstanceEntity> TransactionRecurringInstances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountEntity>()
                .HasMany(a => a.TransactionsFrom)
                .WithOne(a => a.FromAccount)
                .HasForeignKey(a => a.FromAccountId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AccountEntity>()
                .HasMany(a => a.TransactionsTo)
                .WithOne(a => a.ToAccount)
                .HasForeignKey(a => a.ToAccountId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
