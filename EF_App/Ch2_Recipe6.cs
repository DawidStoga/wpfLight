using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_App
{
   public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }

    public class EF6RecipesEntity6:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public EF6RecipesEntity6():base("name=EFRecipesEntities5")
        {
         
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Map((m) =>
                       {
                           m.Properties(p => new { p.SKU, p.Description, p.Price });
                           m.ToTable("Product");
                       }
                    )
                    .Map(m =>
                    {
                        m.Properties(p => new { p.SKU, p.ImageURL });
                        m.ToTable("ProductWebInfo");
                    });
        
        }
    }
}
