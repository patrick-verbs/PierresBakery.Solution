using System;
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

    private static Dictionary<string, Dictionary<string, int>> _currentBreadOrder = new Dictionary<string, Dictionary<string, int>>() {};
    // Tracks instances of bread selections the customer has added to their order

    public static Dictionary<string, Dictionary<string, int>> GetBreadOrder(string breadChoice, int breadCount)
    {
      Dictionary<string, int> breadChoiceData = new Dictionary<string, int>() {};
      foreach(var breadOption in _breadMenu)
      {
        if(breadChoice == breadOption.Key)
        {

          int unitPrice = breadOption.Value;
          breadChoiceData.Add("unit price", breadOption.Value);
          breadChoiceData.Add("count", breadCount);
          breadChoiceData.Add("subtotal", breadCount * unitPrice);

          _currentBreadOrder.Add(breadChoice, breadChoiceData);
          break;
        }
      };

      return _currentBreadOrder;
    }
  }
}