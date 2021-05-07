using System.Collections.Generic;

namespace PierresBakeryNamespace.Models
{
  public class Bread
  {
    // Code
    private static Dictionary<string, int> _breadMenu = new Dictionary<string, int>()
    {
      {"string", 0}
    };

    public static Dictionary<string, int> GetBreadOrder(string breadType, int breadCount)
    {
      Dictionary<string, int> breadOrder = _breadMenu;
      return breadOrder;
    }
  }
}