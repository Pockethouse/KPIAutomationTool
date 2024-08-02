using EXCELGRAPHING.Models;

namespace EXCELGRAPHING;

using Microsoft.EntityFrameworkCore;
using EXCELGRAPHING.Models;

 public class DBContext : DbContext
    {
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<PolicyHolder> Policyholders { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PayablePayment> PayablePayments { get; set; }
        public DbSet<ReceivablePayment> ReceivablePayments { get; set; }


        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<InsuranceCompany>().ToTable("InsuranceCompanies");
            modelBuilder.Entity<Provider>().ToTable("Providers");
            modelBuilder.Entity<PolicyHolder>().ToTable("Policyholders");
            modelBuilder.Entity<Policy>().ToTable("Policies");
            modelBuilder.Entity<Claim>().ToTable("Claims");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Distribution>().ToTable("Distribution");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Bank>().ToTable("Banks");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            modelBuilder.Entity<PayablePayment>().ToTable("PayablePayments");
            modelBuilder.Entity<ReceivablePayment>().ToTable("ReceivablePayments");
            

            // Seed PaymentMethods
           /* modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { PaymentMethodID = 1, Method = "Check" },
                new PaymentMethod { PaymentMethodID = 2, Method = "Credit Card" },
                new PaymentMethod { PaymentMethodID = 3, Method = "Direct Deposit" }
            ); */
        }
    }
