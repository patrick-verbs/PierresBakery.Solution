using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryTestNamespace.Test
{
  [TestClass]
  public class PastryTests : IDisposable
  {
    public void Dispose()
    {
      Bread.ClearAll();
    }

    [TestMethod]
    public void GetPastryOrder_CreatesDictionaryOfPastry_Dictionary()
    {
      // Arrange
      string pastryChoice = "pastry";
      int pastryCount = 1;
      Dictionary<string, Dictionary<string, int>> expectedPastryOrder = new Dictionary<string, Dictionary<string, int>>()
      {// This dictionary encapsulates the previous one for its value
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
      Dictionary<string, Dictionary<string, int>> returnedPastryOrder = Pastry.GetPastryOrder(pastryChoice, pastryCount);
      // This should create a nested dictionary from only the 'pastryChoice' string and the 'pastryCount' int

      // Assert
      Assert.AreEqual(expectedPastryOrder["pastry"]["unit price"], returnedPastryOrder[pastryChoice]["unit price"]);
      Assert.AreEqual(expectedPastryOrder["pastry"]["count"], returnedPastryOrder[pastryChoice]["count"]);
      Assert.AreEqual(expectedPastryOrder["pastry"]["subtotal"], returnedPastryOrder[pastryChoice]["subtotal"]);
    }

    // [TestMethod]
    // public void breadDiscounts_BuyTwoGetOneFree_Five()
    // {
    //   // Arrange
    //   string breadChoice = "bread";
    //   int breadCount = 3;
    //   int expectedDiscount = 5;

    //   // Act
    //   Dictionary<string, Dictionary<string, int>> returnedBreadOrder = Bread.GetBreadOrder(breadChoice, breadCount);
    //   int returnedDiscount = Bread.breadDiscounts();

    //   // Assert
    //   Assert.AreEqual(expectedDiscount, returnedDiscount);
    // }
  }
}