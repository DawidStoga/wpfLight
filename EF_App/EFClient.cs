using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF_App
{
     public partial class EFClient
    { 
        private static void ViewDataRec2()
        {
            using (var ctx = new EFRecipesEntities())
            {
                foreach (var item in ctx.Poems)
                {
                    Console.WriteLine(item.Title + "   " + item.Poet.FirstName);
                }
            }
        }
        private static void AddDatatoModel()
        {
            using (var ctx = new EFRecipesEntities())
            {
                var poem = new Poem { Title = "LOT2" };
                var poet = new Poet { FirstName = "John", LastName = "Milton" };
                var meter = new Meter { MeterName = "meterName" };
                poem.Meter = meter;
                poem.Poet = poet;
                ctx.Poems.Add(poem);

                poet = new Poet { FirstName = "Lewis", LastName = "Carroll" };
                poem = new Poem { Title = "TheHunt" };
                meter = new Meter { MeterName = "Anape" };
                poem.Meter = meter;
                poem.Poet = poet;
                ctx.Poems.Add(poem);
                // ctx.SaveChanges();
                try
                {
                    ctx.SaveChanges();
                }

                catch (Exception gex)
                {
                    if (gex is DbEntityValidationException)
                    {
                        var ex = gex as DbEntityValidationException;
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Console.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                    else
                    {
                        var excep = gex as DbUpdateException;

                        var e = gex.InnerException;
                        Console.WriteLine(e.InnerException.Message);
                        Console.WriteLine(excep.Source.ToString());

                    }
                }

            }
        }
        private static async void AddDataAsync()
        {

            using (var ctx = new EF6RecipesContext())
            {

                if (ctx.PersonSet.Count() == 0)  //add only once - for test purpose
                {
                    var person = new Person { FirstName = "Dawid", MiddleName = "-", LastName = "Stoga", PhoneNumber = "3154545" };
                    ctx.PersonSet.Add(person);
                    person = new Person { FirstName = "Magda", MiddleName = "Malgorzata", LastName = "Gaworska", PhoneNumber = "7145789" };
                    ctx.PersonSet.Add(person);
                    person = new Person { FirstName = "Jakub", MiddleName = "Dawid", LastName = "Stoga ", PhoneNumber = "brak" };
                    ctx.PersonSet.Add(person);
                    int x = await ctx.SaveChangesAsync();
                    Console.WriteLine($"Added {x} rows");
                }
            }
        }
        private static void ViewData()
        {
            Console.WriteLine("View Data");
            using (var ctx = new EF6RecipesContext())
            {
                foreach (var person in ctx.PersonSet)
                {
                    Console.WriteLine($"name: {person.FirstName}  surname: {person.LastName}  ");
                }
            }
        }


        /*CH2 Recipe3*/

        private static void AddDataRec3()
        {
            using (var context = new EFRecipesEntities1())
            {
                // add an artist with two albums
                var artist = new Artist { FirstName = "Alan", LastName = "Jackson" };
                var album1 = new Album { AlbumName = "Drive" };
                var album2 = new Album { AlbumName = "Live at Texas Stadium" };
                artist.Albums.Add(album1);
                artist.Albums.Add(album2);
                context.Artists.Add(artist);
                // add an album for two artists
                var artist1 = new Artist { FirstName = "Tobby", LastName = "Keith" };
                var artist2 = new Artist { FirstName = "Merle", LastName = "Haggard" };
                var album = new Album { AlbumName = "Honkytonk University" };

                //  artist1.Albums.Add(album);
                //artist2.Albums.Add(album);

                album.Artists.Add(artist1);
                album.Artists.Add(artist2);

                context.Albums.Add(album);
                context.SaveChanges();
            }
        }

        private static void ViewData3()
        {
            using (var context = new EFRecipesEntities1())
            {
                Console.WriteLine("Artists and their albums...");
                var artists = context.Artists;
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0} {1}", artist.FirstName, artist.LastName);
                    foreach (var album in artist.Albums)
                    {
                        Console.WriteLine("\t{0}", album.AlbumName);
                    }
                }
                Console.WriteLine("\nAlbums and their artists...");
                var albums = context.Albums;
                foreach (var album in albums)
                {
                    Console.WriteLine("{0}", album.AlbumName);
                    foreach (var artist in album.Artists)
                    {
                        Console.WriteLine("\t{0} {1}", artist.FirstName, artist.LastName);
                    }
                }

            }
        }
        private static void AddDataRec4()
        {
            using (var context = new EFRecipesEntities2())
            {


                var order = new Order() { OrderId = 2, OrderDate = new DateTime(2010, 1, 18) };
                var item = new Item
                {
                    SKU = 1229,
                    Description = "Backpack",
                    Price = 29.97M
                };
                var oi = new OrderItem { Order = order, Item = item, Count = 1 };
                context.OrderItems.Add(oi);
                item = new Item
                {
                    SKU = 2229,
                    Description = "Water Filter",
                    Price = 13.97M
                };
                oi = new OrderItem { Order = order, Item = item, Count = 3 };

                context.OrderItems.Add(oi);
                context.SaveChanges();
            }

        }
        private static void ViewData4()
        {
            using (var context = new EFRecipesEntities2())
            {

                foreach (var order in context.Orders)
                {
                    Console.WriteLine("Order # {0}, ordered on {1}",
                    order.OrderId.ToString(),
                    order.OrderDate.ToShortDateString());
                    Console.WriteLine("SKU\tDescription\tQty\tPrice");
                    Console.WriteLine("---\t-----------\t---\t-----");
                    foreach (var oi in order.OrderItems)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", oi.Item.SKU,
                        oi.Item.Description, oi.Count.ToString(),
                        oi.Item.Price.ToString("C"));
                    }
                }

            }
        }
        private static void AddData5()
        {
            using (var ctx = new EFRecipesEntities5())
            {

                var louvre = new PictureCategory { Name = "Louvre" };
                var child = new PictureCategory { Name = "Egyptian Antiquites" };
                louvre.Subcategories.Add(child);
                child = new PictureCategory { Name = "Sculptures" };
                louvre.Subcategories.Add(child);
                child = new PictureCategory { Name = "Paintings" };
                louvre.Subcategories.Add(child);
                var paris = new PictureCategory { Name = "Paris" };
                paris.Subcategories.Add(louvre);
                var vacation = new PictureCategory { Name = "Summer Vacation" };
                vacation.Subcategories.Add(paris);
                ctx.PictureCategories.Add(paris);
                ctx.SaveChanges();
                /*
                PictureCategory pc1 = new PictureCategory() { Name = "L1a" };
                PictureCategory pc2 = new PictureCategory() { Name = "L1b" };
                PictureCategory pc3 = new PictureCategory() { Name = "L1c" };
                PictureCategory pc4 = new PictureCategory() { Name = "L1d" };
                pc4.Subcategories.Add(new PictureCategory { Name = "L2a" });
                pc4.Subcategories.Add(new PictureCategory { Name = "L2b" });
                PictureCategory pc = new PictureCategory() { Name = "L" };// Subcategories = new List<PictureCategory> { pc1, pc2, pc3, pc4 } };
                pc.Subcategories.Add(pc1);
                pc.Subcategories.Add(pc2);
                pc.Subcategories.Add(pc3);
                ctx.PictureCategories.Add(pc);
               ctx.SaveChanges();*/
            }

        }
        private static void ViewData5()
        {
            using (var ctx = new EFRecipesEntities5())
            {
               

               var all = ctx.PictureCategories.ToList();
               var roots = all.Where(x => x.ParentCategory == null).ToList();
               // var rootBoost = ctx.PictureCategories.AsNoTracking().ToList();
                roots.ForEach(root => Print(root, 0));

                var entry = ctx.Entry(all.FirstOrDefault());
                var cv = entry.CurrentValues["Name"];
            }

        }
        static void Print(PictureCategory cat, int level)
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("{0}{1}", sb.Append(' ', level).ToString(), cat.Name);

            cat.Subcategories.ForEach(child => Print(child, level + 1));
        }
        static void AddData6()
        {
            using (var ctx = new EF6RecipesEntity6())
            {
                Product prod = new Product();
                prod.Description = "First product";
                prod.Price = 100M;
                prod.ImageURL = "www.onet.pl";
                ctx.Products.Add(prod);
                ctx.SaveChanges();


            }
        }
        static void AddData7()
        {

            OtherProduct op = new OtherProduct { Description = "descr", ImageURL = "picx", Price = 20 };

            using (var ctx = new EF6RecipesEntity7())
            {
                ctx.OtherProducts.Add(op);
                ctx.SaveChanges();
                var items = from itm in ctx.OtherProducts select itm;
                foreach(var item in  items)
                    Console.WriteLine(item.Description);
            }
        }
        static void AppDataEng()
        {
            using (var ctx = new NoRecipesEntity())
            {
                Electronic el = new Electronic { Company = "Diehl", Description = "avionic", Fuse = 10, Power = 3000, Speed = 56, Voltage = 230 };
                ctx.Electronics.Add(el);
            }
        }
    }
}
