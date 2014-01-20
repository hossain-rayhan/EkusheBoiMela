using System.Data.Entity;
using EkusheBoiMela.Model.Entity;

namespace EkusheBoiMela.Model
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Db")
        {
            //Database.SetInitializer<DataContext>(null);
        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>().HasKey(e => e.Id);
            modelBuilder.Entity<Author>().HasKey(e => e.Id);
            modelBuilder.Entity<Publisher>().HasKey(e => e.Id);
            modelBuilder.Entity<Book>().HasKey(e => e.Isbn).HasRequired(r => r.Catagory).WithMany().HasForeignKey(f => f.CatagoryId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Book>().HasKey(e => e.Isbn).HasRequired(r => r.Author).WithMany().HasForeignKey(f => f.AuthorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Book>().HasKey(e => e.Isbn).HasRequired(r => r.Publisher).WithMany().HasForeignKey(f => f.PublisherId).WillCascadeOnDelete(false);
            modelBuilder.Entity<User>().HasKey(e => e.Id);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}

