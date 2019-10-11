
using LibrarySystem_WebAPI_Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibrarySystem_WebAPI_Store
{
    public class LibrarySystemContext : DbContext
    {
        private string _connectionstring;
        private string _migrationAssemblyName;


        public LibrarySystemContext(string connstring, string migrationAssemblyName)
        {
            _connectionstring = connstring;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            if (!optionbuilder.IsConfigured)
            {
                optionbuilder.UseSqlServer(_connectionstring, m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(optionbuilder);
        }

        public  LibrarySystemContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
           .Property(b => b.FineAmount)
           .HasDefaultValue(0);

            modelBuilder.Entity<IssueBook>()
          .Property(b => b.IssueDate)
          .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ReturnBook>()
          .Property(b => b.ReturnDate)
          .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Book>(b =>
            {
                b.HasIndex(x => x.Barcode).IsUnique(true);
            });
            modelBuilder.Entity<Student>(b =>
            {
                b.HasIndex(x => x.Id).IsUnique(true);
            });

            modelBuilder.Entity<Book>(b =>
            {
                b.HasIndex(x => x.Id).IsUnique(true);
            });

            modelBuilder.Entity<IssueBook>()
                .HasOne(ib => ib.Student)
                .WithMany(i => i.BookIssues)
                .HasForeignKey(ib => ib.StudentId);

            modelBuilder.Entity<ReturnBook>()
                .HasOne(rb => rb.Student)
                .WithMany(rb => rb.BookReturns)
                .HasForeignKey(ib => ib.StudentId);

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<IssueBook> IssueBook { get; set; }
        public DbSet<ReturnBook> ReturnBook { get; set; }

    }
}
