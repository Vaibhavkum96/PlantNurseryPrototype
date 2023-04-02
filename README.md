# PlantNursery
Planning Process 

1) Deciding the Models Needed to carry out the task, I have created 4 Data tables, 
through which Order Plaing will take place, i.e.,
Order---->OrderItem----->Plant , ShoppingCartItems  

2) Order DataTable is having One TO many Relationship with the OrderItem Table and OrderItem table is having
One to Many Relationship with Plant Table. 

3) So, all the order processing is getting Handled Through ShoopingCart.cs (Present Under
-----> Data---->Cart----->ShoppingCart.cs)

4) All the database CRUD Operations has been written under this  ShoopingCart.cs File.

5) Order Controller Has been Added under Controller Folder to handle the API Request/Response.

This is how the code is kept and the core planning process was on the deciding of the Models and make 
efficent use of it.

------------------------------------------------------------------------------------------------------------
Features 

1) Getting all the list of shopping cart items present in the cart ---> GetShoppingCartItems()

2) Getting the total price of the items present in the cart --------> GetShoppingCartTotal()

3) Added the feature of removing and adding the items present Present in the Cart keeping the count of Quantities
of items left in the inventory. ---> RemoveItemAtCart(), QuantityCheck(), AddItemToCart()

4) Tried to Handle the session of the user by using IServiceProvider Class----> GetShoppingCart(IServiceProvider)

5) All the definition of methods have been implemented using Try <---> Catch Block to handle the exception.

The above features were chosen because these are the necessary things which we can to while ordering an entity
from a ecommerce site. Without these basic functionalities the site cannot function.

------------------------------------------------------------------------------------------------------------
Can be added 

1) Get the list of all the orders already ordered by the User ----> GetOrdersByUserID()

2) Integrated with a payment System when ordering a Item.
------------------------------------------------------------------------------------------------------------
Code Structure 

Controller ----> OrderController 
Main Logic ------> Data-->Cart-->ShoppingCart.cs
Models Declared Under Model Folder
-------------------------------------------------------------------------------------------------------------

Final Comments : This is not a working project, this is just a prototype of how I would think while making
this ecommerce platform, There are some Functionalities which has not been implemented perfectly or it is
incomplete.

Thanks for reading this, Have a Good day !
