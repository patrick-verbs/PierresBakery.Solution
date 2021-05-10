using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryTestNamespace.Test
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Bread.ClearAll();
      Pastry.ClearAll();
      Order.ClearAll();
    }

    [TestMethod]
    public void GetFullOrder_CreatesDictionaryOfBreadAndPastries_Dictionary()
    {
      // Arrange
      string breadChoice = "bread";
      int breadCount = 1;
      string pastryChoice = "pastry";
      int pastryCount = 1;
      Dictionary<string, Dictionary<string, int>> expectedFullOrder = new Dictionary<string, Dictionary<string, int>>()
      {// This dictionary encapsulates the previous one for its value
        {
          "bread",
          new Dictionary<string, int>
          {
            {"unit price", 5},
            {"count", 1},
            {"subtotal", 5}
          }
        },
        {
          "pastry",
          new Dictionary<string, int>
          {
            {"unit price", 2},
            {"count", 1},
            {"subtotal", 2}
          }
        }
      };

      // Act
      Bread.SetBreadOrder(breadChoice, breadCount);
      Pastry.SetPastryOrder(pastryChoice, pastryCount);
      Dictionary<string, Dictionary<string, int>> returnedFullOrder = Order.GetFullOrder();
      // This should create a nested dictionary from only the 'breadChoice' string and the 'breadCount' int

      // Assert
      Assert.AreEqual(expectedFullOrder["bread"]["unit price"], returnedFullOrder[breadChoice]["unit price"]);
      Assert.AreEqual(expectedFullOrder["bread"]["count"], returnedFullOrder[breadChoice]["count"]);
      Assert.AreEqual(expectedFullOrder["bread"]["subtotal"], returnedFullOrder[breadChoice]["subtotal"]);
      Assert.AreEqual(expectedFullOrder["pastry"]["unit price"], returnedFullOrder[pastryChoice]["unit price"]);
      Assert.AreEqual(expectedFullOrder["pastry"]["count"], returnedFullOrder[pastryChoice]["count"]);
      Assert.AreEqual(expectedFullOrder["pastry"]["subtotal"], returnedFullOrder[pastryChoice]["subtotal"]);
    }

    // [TestMethod]
    // public void GetBreadOrder_AccumulateRepeatBreadsToSameDictionaryItem_Twelve()
    // {
    //   // Arrange
    //   string firstBreadChoice = "bread";
    //   string secondBreadChoice = "bread";
    //   int firstBreadCount = 5;
    //   int secondBreadCount = 10;
    //   int expectedCombinedCount = firstBreadCount + secondBreadCount;
    //   int expectedCombinedSubtotal = expectedCombinedCount * 5;

    //   // Act
    //   Dictionary<string, Dictionary<string, int>> returnedFullOrder = Bread.GetBreadOrder(firstBreadChoice, firstBreadCount);
    //   returnedFullOrder = Bread.GetBreadOrder(secondBreadChoice, secondBreadCount);

    //   // Assert
    //   Assert.AreEqual(expectedCombinedCount, returnedFullOrder["bread"]["count"]);
    //   Assert.AreEqual(expectedCombinedSubtotal, returnedFullOrder["bread"]["subtotal"]);
    // }

    // [TestMethod]
    // public void breadDiscounts_BuyTwoGetOneFree_Five()
    // {
    //   // Arrange
    //   string breadChoice = "bread";
    //   int breadCount = 3;
    //   int expectedDiscount = 5;// At $5 each, "buy 2 get 1 free" = $5 discount

    //   // Act
    //   Dictionary<string, Dictionary<string, int>> returnedFullOrder = Bread.GetBreadOrder(breadChoice, breadCount);
    //   int returnedDiscount = Bread.breadDiscounts();

    //   // Assert
    //   Assert.AreEqual(expectedDiscount, returnedDiscount);
    // }
  }
}