using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCFramework.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Image")
        {
        }

        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .Property(e => e.imagePath)
                .IsUnicode(false);
        }
    }
}
