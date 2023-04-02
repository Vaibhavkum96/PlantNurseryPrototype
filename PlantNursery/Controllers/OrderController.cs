using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantNursery.Data.Cart;
using PlantNursery.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Net;

namespace PlantNursery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ShoppingCartItems _shoppingCartItems;

        public OrderController(ShoppingCart shoppingCart, ShoppingCartItems shoppingCartItems)
        {
            _shoppingCart = shoppingCart;
            _shoppingCartItems = shoppingCartItems;
        }

        [HttpGet(Name = "GetShoppingCartList")]
        public IEnumerable<ShoppingCart> GetItems()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return (IEnumerable<ShoppingCart>)items.ToList();
        }

        [HttpGet(Name = "GetTotalPrice")]

        public IActionResult GetPrice(Models.Plant plant)
        {
            try
            {

                var price = _shoppingCart.GetShoppingCartTotal(); //Defined in ShoppingCart.cs <---Cart<--Data
                return Ok(new { Status = "ok", Message = price.ToString() });
            }

            catch (Exception ex) 
            {

                logger.Error(ex, "Exception While Processing the Request");
                throw;
            }
            





        }

        [HttpPost(Name ="AddItem")]
        public IActionResult AddToCart(int id)
        { /*
           check for Quantity, getting the selected ID from the database; 

            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

           try
            {
            var item = GetPlantByID(int id);

            bool check = _shoppingCart.QuantityCheck(item); //Defined in ShoppingCart.cs <---Cart<--Data

            
              if(check == false)
              {
                 logger.Debug("Quantity Check");
                return Request.CreateErrorResponse(HttpStatusCode.RequestedRangeNotSatisfiable)
              
              }


              if(item != null)
            {
                _shoppingCart.AddItemtoCart(item); //Defined in ShoppingCart.cs <---Cart<--Data
                 logger.Debug("Add To Cart");
                  
            }
            
            return Request.CreateResponse(HttpStatusCode.OK);

          }
            
            catch (Exception ex)  
        {  
            logger.Error(ex, "Exception While Processing the Request");  
            throw;  
        } 


             */
        }
        

        [HttpDelete(Name = "RemoveItem")]
        public void RemoveFromCart(int id)
        {
            /*
            

            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try 
             {
              
              var item = GetPlantByID(int id); getting the selected ID from the database; 

             
           
                        if(item != null)
                      {
                         _shoppingCart.RemoveItemAtCart(item); //Defined in ShoppingCart.cs <---Cart<--Data
                         return Request.CreateResponse(HttpStatusCode.OK)
                    }

                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest)
             
            
            
             
            
             }

             
            catch (Exception ex)  
             {  
                    logger.Error(ex, "Exception While Processing the Request");  
                     throw;  
             } 

            


            
             */
        }

    }
}
