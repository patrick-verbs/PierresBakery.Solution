using Microsoft.VisualStudio.TestTools.UnitTesting;
using PierresBakeryNamespace.Models;

namespace PierresBakeryNamespace.Test
{
  [TestClass]
  public class PierresBakery
  {
    [TestMethod]
    public void PierresBakeryConstructor_CreatesInstanceOfSomething_Result()
    {
      Template newTemplate = new Template();
      Assert.AreEqual(typeof(Template), newTemplate.GetType());
    }
    // Tests
  }
}