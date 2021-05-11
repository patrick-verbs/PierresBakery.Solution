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
      string contextShop = "";
      string contextBread = "";
      string contextPastry = "";
      bool isInt;

      Shop:
      Console.WriteLine("\n" + contextShop + "Would you like to see our selection of bread, or pastries?");
      Console.Write("(");
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
      Console.Write(") ");

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
      else
      {
        contextShop = "I have no idea what you just said... ";
        goto Shop;
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
        Console.Write("(*nom nom*)");
        Console.ReadLine();
      }
      else if (breadCount == 1)
      {
        Console.WriteLine("\n" + "One loaf of bread for ya? Coming right up!");
        Console.Write("(Thanks!)");
        Console.ReadLine();
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
        contextBread = "Huh? ";
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
        Console.Write("(Yeah...)");
        Console.ReadLine();
      }
      else if (pastryCount == 1)
      {
        Console.WriteLine("\n" + "Just the one pastry for ya? Coming right up!");
        Console.Write("(Thanks!)");
        Console.ReadLine();
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
        contextPastry = "Huh? ";
        goto Pastry;
      }
      goto Shop;

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

        Console.WriteLine("\n" + kvp.Key.ToUpper());
        string underline = "---------------";
        underline = underline.Substring(0, kvp.Key.Length);
        Console.WriteLine(underline);
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
          runningTotal -= discounts;
        }
        else if (kvp.Key == "pastry")
        {
          int discounts = Pastry.pastryDiscounts();
          Console.WriteLine("   discounts:     -" + discounts);
          runningTotal -= discounts;
        }
      }

      Console.WriteLine("\n" + "TOTAL: $" + runningTotal);
      Console.Write("\n" + "Have a good day!");
      Console.ReadLine();
    }
  }
}