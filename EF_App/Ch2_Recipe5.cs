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
   public class PictureCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; private set; }
        public string Name  { get; set; }
        public int? ParentCategoryId { get; private set; }

        [ForeignKey("ParentCategoryId")]
        public PictureCategory ParentCategory { get; set; }

        public List<PictureCategory> Subcategories { get; set; }
        public PictureCategory()
        {
            Subcategories = new List<PictureCategory>();
        }
    }

  public  class EFRecipesEntities5:DbContext
    {
    public DbSet<PictureCategory> PictureCategories { get; set; }
        
        public EFRecipesEntities5():base("EFRecipesEntities5")
        {
         
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PictureCategory>()
                .HasMany(cat => cat.Subcategories)
                .WithOptional(cat => cat.ParentCategory);
        }

    }
}
