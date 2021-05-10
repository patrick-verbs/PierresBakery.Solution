using System;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryNamespace 
{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Hi! Welcome to Pierre's Bakery!" + "\n");

      Shop:
      Console.WriteLine("Would you like to see our selection of bread, or pastries? " + "(Bread/Pastries/Checkout)" + "\n");
      string userChoice = (Console.ReadLine()).ToLower();
      if (userChoice[0] == 'b')
      {
        goto Bread;
      }
      else if (userChoice[0] == 'p')
      {
        goto Pastry;
      }
      else if (userChoice[0] == 'c')
      {
        goto Checkout;
      }

      Bread:
      Console.WriteLine("How many loaves of bread would you like?");
      int breadCount = Int32.Parse(Console.ReadLine());
      Bread.SetBreadOrder("bread", breadCount);
      if (breadCount > 1)
      {
        Console.WriteLine(breadCount + "loaves of bread! That's a lot of bread!");
      }
      else if (breadCount == 1)
      {
        Console.WriteLine("One loaf of bread for ya? Coming right up!");
      }
      goto Shop;

      Pastry:
      Console.WriteLine("How many pastries would you like?");
      int pastryCount = Int32.Parse(Console.ReadLine());
      Pastry.SetPastryOrder("pastry", pastryCount);
      if (pastryCount > 1)
      {
        Console.WriteLine(pastryCount + "pastries! That's a lot of sugar!");
      }
      else if (pastryCount == 1)
      {
        Console.WriteLine("One tasty pastry for ya? Coming right up!");
      }
      goto Shop;

      // welcome message
      // view bread or pastry selections
      // add bread
      // - choose bread
      // - exit
      // add pastry
      // - choose pastry
      // - exit
      // print order

      Checkout:
      PrintOrder();
    }

    public static void PrintOrder()
    {
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

      Console.WriteLine("TOTAL: $" + runningTotal);
    }
  }
}