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

    private static Dictionary<string, int> _currentOrder = new Dictionary<string, int>() {};
    // Tracks instances of bread selections the customer has added to their order

    public Bread(string breadType)
    {
      foreach(var kvp in _breadMenu)
      {
        _currentOrder.Add(kvp.Key, kvp.Value);
      }
    }

    public static Dictionary<string, int> GetBreadOrder(string breadChoice, int breadCount)
    {
      // Dictionary<string, int> breadOrder = _currentOrder.AddBread(breadChoice);
      _currentOrder = Bread(breadChoice);
      // int totalPrice = 0;

      // for(int i; i <= breadCount; i++)
      // {
      //   // stuff
      //   totalPrice += breadOrder.
      // }

      return _currentOrder;
    }
  }
}