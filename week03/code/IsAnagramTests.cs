using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class IsAnagramTests
{
    [TestMethod]
    public void IsAnagram_BasicCases()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("CAT", "ACT"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("DOG", "GOOD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("AABBCCDD", "ABCD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("ABCCD", "ABBCD"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("BC", "AD"));
    }

    [TestMethod]
    public void IsAnagram_IgnoresCases()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("Ab", "Ba"));
    }

    [TestMethod]
    public void IsAnagram_IgnoresSpaces()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("tom marvolo riddle", "i am lord voldemort"));
    }

    [TestMethod]
    public void IsAnagram_IgnoresSpacesAndCases()
    {
        Assert.IsTrue(SetsAndMaps.IsAnagram("A Decimal Point", "Im a Dot in Place"));
        Assert.IsTrue(SetsAndMaps.IsAnagram("Eleven plus Two", "Twelve Plus One"));
        Assert.IsFalse(SetsAndMaps.IsAnagram("Eleven plus One", "Twelve Plus One"));
    }
}
