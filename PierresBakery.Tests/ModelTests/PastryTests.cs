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
      Pastry.ClearAll();
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

    [TestMethod]
    public void GetPastryOrder_AccumulateRepeatPastriesToSameDictionaryItem_Twelve()
    {
      // Arrange
      string firstPastryChoice = "pastry";
      string secondPastryChoice = "pastry";
      int firstPastryCount = 4;
      int secondPastryCount = 8;
      int expectedPastryTotal = firstPastryCount + secondPastryCount;

      // Act
      Dictionary<string, Dictionary<string, int>> returnedPastryOrder = Pastry.GetPastryOrder(firstPastryChoice, firstPastryCount);
      returnedPastryOrder = Pastry.GetPastryOrder(secondPastryChoice, secondPastryCount);

      // Assert
      Assert.AreEqual(expectedPastryTotal, returnedPastryOrder["pastry"]["count"]);
    }

    [TestMethod]
    public void pastryDiscounts_ThreeFiveDollars_One()
    {
      // Arrange
      string pastryChoice = "pastry";
      int pastryCount = 3;
      int expectedDiscount = 1;// At $2 each, 3 pastries for $5 = $1 discount

      // Act
      Dictionary<string, Dictionary<string, int>> returnedPastryOrder = Pastry.GetPastryOrder(pastryChoice, pastryCount);
      int returnedDiscount = Pastry.pastryDiscounts();

      // Assert
      Assert.AreEqual(expectedDiscount, returnedDiscount);
    }
  }
}