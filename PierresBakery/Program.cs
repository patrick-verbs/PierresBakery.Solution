using System;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryNamespace 
{
  public class Program
  {
    public static void Main()
    {
      // UI Stuff
      Console.WriteLine("hi I'm a console log" + "\n");

      Bread.SetBreadOrder("bread", 25);
      Pastry.SetPastryOrder("pastry", 10);

      Dictionary<string, Dictionary<string, int>> fullOrder = Order.GetFullOrder();
      int runningTotal = 0;

      foreach(var kvp in fullOrder)
      {
        runningTotal += fullOrder[kvp.Key]["subtotal"];

        Console.WriteLine(kvp.Key.ToUpper());
        Console.WriteLine("-----");
        foreach (var nestedKvp in fullOrder[kvp.Key])
        {
          string padding = "";
          foreach (char letter in nestedKvp.Key)
          {
            padding = "               ";
            int difference = padding.Length - nestedKvp.Key.Length;
            padding = padding.Substring(0, difference);
          }
          Console.WriteLine("   " + nestedKvp.Key + ":" + padding + nestedKvp.Value);
        }
        if (kvp.Key == "bread")
        {
          int discounts = Bread.breadDiscounts();
          Console.WriteLine("   discounts:     -" + discounts);
          Console.WriteLine("");
          runningTotal -= discounts;
        }
        else if (kvp.Key == "pastry")
        {
          int discounts = Pastry.pastryDiscounts();
          Console.WriteLine("   discounts:     -" + discounts);
          Console.WriteLine("");
          runningTotal -= discounts;
        }
      }

      Console.WriteLine("TOTAL: " + runningTotal);
    }
  }
}