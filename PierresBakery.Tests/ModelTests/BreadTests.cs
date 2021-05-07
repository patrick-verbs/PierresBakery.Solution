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
      Dictionary<string, int> expectedBreadOrder = new Dictionary<string, int>()
      {
        {"bread", 1}
      };

      // Act
      Dictionary<string, int> returnedBreadOrder = Bread.GetBreadOrder(breadChoice, breadCount);

      // Assert
      CollectionAssert.AreEqual(expectedBreadOrder, returnedBreadOrder);
    }
  }
}