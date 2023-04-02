using Microsoft.EntityFrameworkCore;
using NLog.Web;
using PlantNursery.Models;
using System.Linq;

namespace PlantNursery.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        private readonly Plant _plant;

        public string ShoppingCartID{ get; set; }
        public List<ShoppingCartItems> ShoppingCartItems{ get; set; }

        public ShoppingCart (AppDbContext context)
        {
            _context = context;
            
        }

        var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        //To Handle the Session Part

        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<AppDbContext>();
            string cartID = session.GetString("cartID");
            return new ShoppingCart(context) { ShoppingCartID = cartID };

        }

        
        //Quantity Check
        public bool QuantityCheck(Plant plant)
        {
            try
            {
                var data = _context.Plant.Where(n => n.PlantID == plant.ID).Select(n => n.Quantity).ToString();

                int isAvailable;
                bool isParse = Int32.TryParse(data, out isAvailable);

                if (isAvailable > 0)
                {
                    return true;
                }

                return false;
            }

            catch (Exception ex)
            {
                logger.Error(ex, "Exception While Processing the Request");
                throw;
            }




        }


        //Function to Remove Items to ShoppingCart
        public void RemoveItemAtCart(Plant plant)
        {
            try
            { 
              var shoppingCartItems = _context.ShoppingCartItems.FirstOrDefault(n => n.PlantID == plant.ID && n.ShoppingCartID == ShoppingCartID);
              var plantAvailable = _context.Plant.FirstOrDefault(n => n.PlantID == plant.ID);


              if (shoppingCartItems != null)
              {
                if (shoppingCartItems.Amount > 1)
                {
                    shoppingCartItems.Amount--;
                    plantAvailable.Quantity++;
                }
                else
                {
                    //Remove Part;
                }


              }
            //Save Changes;
              plantAvailable.Quantity++;

               }

            catch (Exception ex)
            {
                logger.Error(ex, "Exception While Processing the Request");
                throw;
            }
        }


        //Function to Add Items to ShoppingCart
        public void AddItemtoCart(Plant plant)
        {
            try
            {
                var shoppingCartItems = _context.ShoppingCartItems.FirstOrDefault(n => n.PlantID == plant.ID && n.ShoppingCartID == ShoppingCartID);
                var plantAvailable = _context.Plant.FirstOrDefault(n => n.PlantID == plant.ID);

                if (shoppingCartItems == null)
                {
                    shoppingCartItems = new ShoppingCartItems()
                    {
                        ShoppingCartID = ShoppingCartID,
                        Plant = plant,
                        Amount = 1,

                    };
                    //Add the data to DB, ShoppingCartItems
                }
                //For adding the same item again
                else
                {
                    shoppingCartItems.Amount++;
                    plantAvailable.Quantity--;
                }

                plantAvailable.Quantity++;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception While Processing the Request");
                throw;
            }



        }

        //Function To Return Shopping Cart items

        public List<ShoppingCartItems> GetShoppingCartItems()
        {
            try
            {
                if (ShoppingCartItems != null)
                {

                    return ShoppingCartItems.ToList();
                }

                else
                {
                    return ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).Include(n => n.Plant).ToList();
                }
            }
            //If shopping Cart Already have value

            catch (Exception ex)
            {
                logger.Error(ex, "Exception While Processing the Request");
                throw;
            }


        }

        public double GetShoppingCartTotal()
        {
            try
            {
                var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartID == ShoppingCartID).Select(n => n.Plant.Price * n.Amount).Sum();
                return total;
            }

            catch (Exception ex)
            {
                logger.Error(ex, "Exception While Processing the Request");
                throw;
            }

        }

        public List<Order> GetOrdersByUserID(string UserID)
        {
            try
            {
                var orders = _context.Orders.Include(n => n.OrderItem).ThenInclude(n => n.Plant).Where(n => n.UserID == UserID).ToList();
                return orders;
            }
            
            catch (Exception ex)
            { 
               logger.Error(ex, "Exception While Processing the Request");
               throw;
            }


    }
}
