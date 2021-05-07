using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryTestNamespace.Test
{
  [TestClass]
  public class BreadTests : IDisposable
  {
    public void Dispose()
    {
      Bread.ClearAll();
    }

    [TestMethod]
    public void GetBreadOrder_CreatesDictionaryOfBread_Dictionary()
    {
      // Arrange
      string breadChoice = "bread";
      int breadCount = 1;
      // Dictionary<string, int> expectedBreadChoiceData = new Dictionary<string, int>()
      // {
      //   {"unit price", 5},
      //   {"count", 1},
      //   {"subtotal", 5}
      // };
      Dictionary<string, Dictionary<string, int>> expectedBreadOrder = new Dictionary<string, Dictionary<string, int>>()
      {// This dictionary encapsulates the previous one for its value
        {
          "bread",
          new Dictionary<string, int>
          {
            {"unit price", 5},
            {"count", 1},
            {"subtotal", 5}
          }
        }
      };

      // Act
      Dictionary<string, Dictionary<string, int>> returnedBreadOrder = Bread.GetBreadOrder(breadChoice, breadCount);
      // This should create a nested dictionary from only the 'breadChoice' string and the 'breadCount' int

      // Assert
      Assert.AreEqual(expectedBreadOrder["bread"]["unit price"], returnedBreadOrder[breadChoice]["unit price"]);
      Assert.AreEqual(expectedBreadOrder["bread"]["count"], returnedBreadOrder[breadChoice]["count"]);
      Assert.AreEqual(expectedBreadOrder["bread"]["subtotal"], returnedBreadOrder[breadChoice]["subtotal"]);
    }

    [TestMethod]
    public void breadDiscounts_BuyTwoGetOneFree_Five()
    {
      // Arrange
      string breadChoice = "bread";
      int breadCount = 3;
      int expectedDiscount = 5;

      // Act
      Dictionary<string, Dictionary<string, int>> returnedBreadOrder = Bread.GetBreadOrder(breadChoice, breadCount);
      int returnedDiscount = Bread.breadDiscounts();

      // Assert
      Assert.AreEqual(expectedDiscount, returnedDiscount);
    }
  }
}