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
      Dictionary<string, int> expectedBreadOrder = new Dictionary<char, int>()
      {
        {"bread", 5}
      };

      // Act
      Dictionary<string, int> returnedBreadOrder = Bread.GetBreadOrder(breadChoice);

      // Assert
      CollectionAssert.AreEqual(expectedBreadOrder, returnedBreadOrder);
    }
  }
}