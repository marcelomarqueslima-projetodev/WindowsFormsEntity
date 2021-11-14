using System.Data.Entity;

namespace WindowsFormsEntity.Data
{
    public partial class DBModels : DbContext
    {
        public DBModels()
            : base("name=DBModels")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Sobrenome)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Endereco)
                .IsUnicode(false);
        }
    }
}
