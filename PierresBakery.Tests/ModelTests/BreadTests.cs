using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PierresBakeryNamespace.Models;

namespace PierresBakeryTestNamespace.Test
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void GetBreadOrder_CreatesDictionaryOfBread_Dictionary()
    {
      // Arrange
      string breadChoice = "bread";
      int breadCount = 1;
      Dictionary<string, int> expectedBreadChoiceData = new Dictionary<string, int>()
      {
        {"unit price", 5},
        {"count", 1},
        {"subtotal", 5}
      };
      Dictionary<string, Dictionary<string, int>> expectedBreadOrder = new Dictionary<string, Dictionary<string, int>>()
      {// This dictionary encapsulates the previous one for its value
        {"bread", expectedBreadChoiceData}
      };

      // Act
      Dictionary<string, int> returnedBreadOrder = Bread.GetBreadOrder(breadChoice, breadCount);
      // This should create a nested dictionary from only the 'breadChoice' string and the 'breadCount' int

      // Assert
      CollectionAssert.AreEqual(expectedBreadChoiceData, returnedBreadOrder);
    }
  }
}