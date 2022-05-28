using Microsoft.EntityFrameworkCore;
using DB.Models;
using DB;
namespace DB.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.IO;

    public class ApplicationContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiscountTransConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTransConfiguration());
            modelBuilder.Entity<Trans>()
                        .HasOne(p => p.Customer)
                        .WithMany(p => p.Trans);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            List<StreamReader> procedures = new List<StreamReader>();
            List<StreamReader> triggers = new List<StreamReader>();
            /*procedures.Add(new StreamReader(@"Procedures/Procedure_change_price.txt"));
            procedures.Add(new StreamReader(@"Procedures/Procedure_all_delete.txt"));*/
            /*triggers.Add(new StreamReader(@"Triggers/Trigger_set_discount.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_set_prise.txt"));*/
            /*triggers.Add(new StreamReader(@"Triggers/Trigger_price_count_ins_upd.txt"));
            triggers.Add(new StreamReader(@"Triggers/Trigger_price_count_del.txt"));*/

            foreach (StreamReader reader in procedures)
            {
                try
                {
                    Database.ExecuteSqlRaw(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом обращении
                }
            }
            foreach (StreamReader reader in triggers)
            {
                try
                {
                    Database.ExecuteSqlRaw(reader.ReadToEnd());
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 2714)
                {
                    reader.Close();
                }
                catch (SqlException e) when (e.Number == 4060)
                {
                    Database.EnsureCreated();   // создаем базу данных при первом обращении
                }
            }
        }
        public DbSet<DB.Models.Customer> Customer { get; set; }
        public DbSet<DB.Models.Discount> Discount { get; set; }
        public DbSet<DB.Models.DiscountTrans> DiscountTrans { get; set; }
        public DbSet<DB.Models.Product> Product { get; set; }
        public DbSet<DB.Models.ProductTrans> ProductTrans { get; set; }
        public DbSet<DB.Models.Trans> Trans { get; set; }
    }
}