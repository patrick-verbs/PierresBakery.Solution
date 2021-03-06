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

    public static void SetBreadOrder(string breadChoice, int breadCount)
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

          bool repeatBreadChoice = _currentBreadOrder.ContainsKey(breadChoice);
          if(repeatBreadChoice)
          {
            _currentBreadOrder[breadChoice]["count"] += breadCount;
            _currentBreadOrder[breadChoice]["subtotal"] += breadCount * unitPrice;
          }
          else {
            _currentBreadOrder.Add(breadChoice, breadChoiceData);
          }
          break;
        }
      };
    }

    public static Dictionary<string, Dictionary<string, int>> GetBreadOrder()
    {
      return _currentBreadOrder;
    }

    public static int breadDiscounts()
    {
      int totalDiscount = 0;
      int totalBreadItems = 0;

      foreach(var breadType in _currentBreadOrder)
      {
        totalBreadItems += breadType.Value["count"];
      }

      // At $5 each, "buy 2 get 1 free" is simply a $5 discount for every trio of bread loaves/items
      int totalBreadItemTrios = totalBreadItems / 3;// Rounds down per integer division specs
      totalDiscount += 5 * totalBreadItemTrios;

      return totalDiscount;
    }

    public static void ClearAll()
    {
      _currentBreadOrder.Clear();
    }
  }
}