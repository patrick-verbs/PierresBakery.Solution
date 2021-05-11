using System;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryNamespace 
{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("\n" + "Hi! Welcome to Pierre's Bakery!");
      string contextBread = "";
      string contextPastry = "";
      bool isInt;

      Shop:
      Console.Write("\n" + "Would you like to see our selection of bread, or pastries? " + "(");
      Console.BackgroundColor = ConsoleColor.DarkMagenta;
      Console.Write("B");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.Write("read");
      Console.ResetColor();
      Console.Write("/");
      Console.BackgroundColor = ConsoleColor.Cyan;
      Console.Write("P");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("astries");
      Console.ResetColor();
      Console.Write("/");
      Console.BackgroundColor = ConsoleColor.DarkGreen;
      Console.Write("C");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.Write("heckout");
      Console.ResetColor();
      Console.Write(")");

      string userChoice = "";
      userChoice = (Console.ReadLine()).ToLower();

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
      Console.WriteLine("\n" + contextBread + "How many loaves of bread would you like?");
      int breadCount = 0;
      string breadInput = Console.ReadLine();
      isInt = int.TryParse(breadInput, out breadCount);
      if (!isInt)
      {
        contextBread = "I'm afraid I didn't quite catch that number! ";
        goto Bread;
      }

      Bread.SetBreadOrder("bread", breadCount);
      if (breadCount > 1)
      {
        Console.WriteLine("\n" + breadCount + " loaves of bread! That's a lot of bread!");
      }
      else if (breadCount == 1)
      {
        Console.WriteLine("\n" + "One loaf of bread for ya? Coming right up!");
      }
      else if (breadCount == 0)
      {
        Console.WriteLine("\n" + "Nothing catching your eye? It is pretty dark and abstract in this command-line bakery...");
        Console.Write("(OK)");
        Console.ReadLine();
      }
      else if (breadCount < 0)
      {
        Console.WriteLine("\n" + "Oh, sorry, we're not buying! We actually bake all our goods fresh in our CSharp oven!");
        Console.Write("(OK)");
        Console.ReadLine();
      }
      else
      {
        contextBread = "I'm afraid I didn't quite catch that number!";
        goto Bread;
      }
      goto Shop;

      Pastry:
      Console.WriteLine("\n" + contextPastry + "How many pastries would you like?");
      int pastryCount = 0;
      string pastryInput = Console.ReadLine();
      isInt = int.TryParse(pastryInput, out pastryCount);
      if (!isInt)
      {
        contextPastry = "I'm afraid I didn't quite catch that number! ";
        goto Pastry;
      }

      Pastry.SetPastryOrder("pastry", pastryCount);
      if (pastryCount > 1)
      {
        Console.WriteLine("\n" + pastryCount + " pastries! That's a lot of sugar!");
      }
      else if (pastryCount == 1)
      {
        Console.WriteLine("\n" + "Just the one pastry for ya? Coming right up!");
      }
      else if (pastryCount == 0)
      {
        Console.WriteLine("\n" + "Nothing catching your eye? It is pretty dark and abstract in this command-line bakery...");
        Console.Write("(OK)");
        Console.ReadLine();
      }
      else if (pastryCount < 0)
      {
        Console.WriteLine("\n" + "Oh, sorry, we're not buying! We actually bake all our goods fresh in our CSharp oven!");
        Console.Write("(OK)");
        Console.ReadLine();
      }
      else
      {
        contextPastry = "I'm afraid I didn't quite catch that number!";
        goto Pastry;
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