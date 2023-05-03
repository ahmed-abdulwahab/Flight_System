using FinalV4.ViewModel;

namespace FinalV4.Data
{
    public class StaticMenus
    {
        public static List<HandBaggage> handBaggages=new List<HandBaggage>()
         {
              new HandBaggage { ItemName = "No Hand Baggage", Price = 0m },
              new HandBaggage { ItemName = "Hand Baggage Less 20 K.G", Price = 60m },
              new HandBaggage { ItemName = "Hand Baggage More 20 K.G", Price = 120m },
         };

        public static List<FoodMenuViewModel> foodMenuViewModels= new List<FoodMenuViewModel>()
            {
              new FoodMenuViewModel { ItemName = "Hamburger", Price = 5.99m },
              new FoodMenuViewModel { ItemName = "Cheeseburger", Price = 6.99m },
              new FoodMenuViewModel { ItemName = "Chicken Sandwich", Price = 7.99m },
              new FoodMenuViewModel { ItemName = "Grilled Cheese", Price = 4.99m },
            };
        }
    }