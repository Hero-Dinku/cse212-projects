using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class SummarizeDegreesTests
{
    [TestMethod]
    public void SummarizeCensusDegrees()
    {
        var result = SetsAndMaps.SummarizeDegrees("census.txt");
        
        // Check that we got results
        Assert.IsTrue(result.Count > 0, "Should find at least one degree");
        
        // Check that all counts are positive
        foreach (var kvp in result)
        {
            Assert.IsTrue(kvp.Value > 0, $"Degree '{kvp.Key}' should have positive count");
        }
        
        // Verify specific degrees we know should exist
        string[] expectedDegrees = { "Bachelors", "HS-grad", "11th", "Masters", "9th" };
        
        foreach (string degree in expectedDegrees)
        {
            Assert.IsTrue(result.ContainsKey(degree), 
                $"Should contain degree: {degree}");
        }
        
        // Print the actual counts for verification (optional)
        Console.WriteLine("Degree counts from census.txt:");
        foreach (var kvp in result.OrderBy(x => x.Key))
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
        }
    }
}
