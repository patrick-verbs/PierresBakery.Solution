using System.Collections.Generic;

namespace PierresBakeryNamespace.Models
{
  public class Bread
  {
    private static Dictionary<string, int> _breadMenu = new Dictionary<string, int>()
    // Lists choices of bread & their corresponding base-price
    {
      {"bread", 5}
    };

    private static Dictionary<string, int> _currentBreadOrder = new Dictionary<string, int>() {};
    // Tracks instances of bread selections the customer has added to their order

    public static Dictionary<string, object> GetBreadOrder(string breadChoice, int breadCount)
    {
      foreach(var breadOption in _breadMenu)
      {
        if(breadChoice == breadOption.Key)
        {
          Dictionary<string, int> breadChoiceData = new Dictionary<string, int>() {};

          int unitPrice = breadOption.Value;
          breadChoiceData.Add("unit price", unitPrice);
          breadChoiceData.Add("count", breadCount);
          breadChoiceData.Add("subtotal", breadCount * unitPrice);

          _currentBreadOrder.Add(breadChoice, breadChoiceData);
          break;
        }
      }


      int totalPrice = 0;

      // for(int i; i <= breadCount; i++)
      // {
      //   // stuff
      //   totalPrice += breadOrder.
      // }

      Dictionary<string, object> thisBreadItem = new Dictionary<string, object>() {};
      return _currentBreadOrder;
    }
  }
}