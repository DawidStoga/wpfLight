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
    [Table("Engines",Schema = "dawid")]
    public class Engines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnId { get; set; }
        public string  Description { get; set; }
        public int Power { get; set; }
        public string Company  { get; set; }

    }
    [Table("Electro", Schema = "dawid")]
    public class Electronic:Engines
    {
        public int Voltage { get; set; }
        public int Fuse { get; set; }
        public int Speed { get; set; }
    }
    public class OtherProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
    public class NoRecipesEntity : DbContext
    {
        public NoRecipesEntity() : base("name=EFRecipesEntities5")
        {

        }
        public DbSet<Electronic> Electronics { get; set; }
    }
   
    public class EF6RecipesEntity7:DbContext
    {
        public EF6RecipesEntity7():base("name=EFRecipesEntities5")
        {
            
        }
        public DbSet<OtherProduct> OtherProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OtherProduct>()
                .Map(m =>
                        {
                            m.Properties(p => new { p.SKU, p.Description, p.Price });
                            m.ToTable("OtherProduct", "Chapter2");
                        })
                 .Map(m =>
                 {
                     m.Properties(p => new { p.SKU, p.ImageURL });
                     m.ToTable("OtherProductImg", "Chapter2");

                 });
        }

    }
}
