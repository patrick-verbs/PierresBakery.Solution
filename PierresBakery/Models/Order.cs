using System;
using System.Collections.Generic;

namespace PierresBakeryNamespace.Models
{
  public class Order
  {
    private static Dictionary<string, Dictionary<string, int>> _currentOrder = new Dictionary<string, Dictionary<string, int>>() {};

    public static Dictionary<string, Dictionary<string, int>> GetFullOrder()
    {
      _currentOrder.Clear();

      Dictionary<string, Dictionary<string, int>> breadOrder = Bread.GetBreadOrder();
      foreach(var kvp in breadOrder)
      {
        _currentOrder.Add(kvp.Key, kvp.Value);
      }

      Dictionary<string, Dictionary<string, int>> pastryOrder = Pastry.GetPastryOrder();
      foreach(var kvp in pastryOrder)
      {
        _currentOrder.Add(kvp.Key, kvp.Value);
      }

      return _currentOrder;
    }

    public static void ClearAll()
    {
      _currentOrder.Clear();
    }
  }
}