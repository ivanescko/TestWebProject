using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebProject.Models.Entities;

namespace TestWebProject.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }


        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost; Database=testorder_db; Uid=god; Pwd=12345; Character Set=utf8; ConvertZeroDatetime=True;",
            new MySqlServerVersion(new Version(8, 0, 18))
                );
        }



    }
}
