using System;
using System.Collections.Generic;

namespace PierresBakeryNamespace.Models
{
  public class Pastry
  {
    private static Dictionary<string, int> _pastryMenu = new Dictionary<string, int>()
    // Lists choices of pastry & their corresponding base-price
    {
      {"pastry", 2}
    };

    private static Dictionary<string, Dictionary<string, int>> _currentPastryOrder = new Dictionary<string, Dictionary<string, int>>() {};
    // Tracks instances of pastry selections the customer has added to their order

    public static Dictionary<string, Dictionary<string, int>> GetPastryOrder(string pastryChoice, int pastryCount)
    {
      Dictionary<string, int> pastryChoiceData = new Dictionary<string, int>() {};
      foreach(var pastryOption in _pastryMenu)
      {
        if(pastryChoice == pastryOption.Key)
        {

          int unitPrice = pastryOption.Value;
          pastryChoiceData.Add("unit price", pastryOption.Value);
          pastryChoiceData.Add("count", pastryCount);
          pastryChoiceData.Add("subtotal", pastryCount * unitPrice);

          _currentPastryOrder.Add(pastryChoice, pastryChoiceData);
          break;
        }
      };

      return _currentPastryOrder;
    }

    public static int pastryDiscounts()
    {
      int totalDiscount = 0;
      int totalPastryItems = 0;

      // foreach(var pastryType in _currentPastryOrder)
      // {
      //   totalPastryItems += pastryType.Value["count"];
      // }

      // double oneThirdPastryItems = totalPastryItems / 3;
      // totalDiscount += 5 * Convert.ToInt32(Math.Floor(oneThirdPastryItems));

      return totalDiscount;
    }

    public static void ClearAll()
    {
      _currentPastryOrder.Clear();
    }
  }
}