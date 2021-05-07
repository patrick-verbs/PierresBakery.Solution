using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateNameSpace.Models;

namespace TemplateNameSpace.Test
{
  [TestClass]
  public class Template
  {
    [TestMethod]
    public void TemplateConstructor_CreatesInstanceOfTemplate_Template()
    {
      Template newTemplate = new Template();
      Assert.AreEqual(typeof(Template), newTemplate.GetType());
    }
    // Tests
  }
}