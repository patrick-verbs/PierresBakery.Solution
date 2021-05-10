using System;
using System.Collections.Generic;

namespace PierresBakeryNamespace.Models
{
  public class Order
  {
    private static Dictionary<string, Dictionary<string, int>> _currentOrder = new Dictionary<string, Dictionary<string, int>>() {};

    public static Dictionary<string, Dictionary<string, int>> GetFullOrder()
    {
      // Dictionary<string, Dictionary<string, int>> breadOrder = 
      // _currentOrder.Add()//
      return _currentOrder;
    }

    public static void ClearAll()
    {
      _currentOrder.Clear();
    }
  }
}