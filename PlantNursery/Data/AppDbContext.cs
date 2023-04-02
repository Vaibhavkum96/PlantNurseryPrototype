using Microsoft.EntityFrameworkCore;

namespace PlantNursery.Data
{
    //Not Really Adding the Database but Here I will try to represent the tables
    public class AppDbContext   : DbContext
    {



        
         
         public DbSet<Plant> Plant {get; set;}
         
       //  Order Related Tables

         public DbSet<Order> Orders {get; set;}
         public DbSet<OrderItem> OrderItems {get;set;}
         public DbSet<ShoppingCartItems> ShoppingCartItems {get;set;}

         
         
         
         
         
         
    }
}
