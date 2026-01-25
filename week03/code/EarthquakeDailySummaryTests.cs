using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class EarthquakeDailySummaryTests
{
    [TestMethod]
    public void EarthquakeDailySummary_Basic()
    {
        var result = SetsAndMaps.EarthquakeDailySummary();
        
        // This test requires internet connection
        // Just check that it returns an array (might be empty if no earthquakes)
        Assert.IsNotNull(result);
        
        // If we got results, check format
        if (result.Length > 0)
        {
            foreach (string s in result)
            {
                Assert.IsTrue(s.Contains(" - Mag "), 
                    $"String must contain magnitude: {s}");
            }
        }
    }
}
