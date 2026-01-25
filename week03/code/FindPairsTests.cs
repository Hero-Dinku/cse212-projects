using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FindPairsTests
{
    [TestMethod]
    public void FindPairs_TwoPairs()
    {
        var actual = SetsAndMaps.FindPairs(["am", "at", "ma", "if", "fi"]);
        var expected = new[] { "ma & am", "fi & if" };

        Assert.AreEqual(expected.Length, actual.Length);
    }

    [TestMethod]
    public void FindPairs_OnePair()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "bc", "cd", "de", "ba"]);
        var expected = new[] { "ba & ab" };

        Assert.AreEqual(expected.Length, actual.Length);
    }

    [TestMethod]
    public void FindPairs_SameChar()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "aa", "ba"]);
        var expected = new[] { "ba & ab" };

        Assert.AreEqual(expected.Length, actual.Length);
    }

    [TestMethod]
    public void FindPairs_ThreePairs()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "ba", "ac", "ad", "da", "ca"]);
        var expected = new[] { "ba & ab", "da & ad", "ca & ac" };

        Assert.AreEqual(expected.Length, actual.Length);
    }

    [TestMethod]
    public void FindPairs_NoPairs()
    {
        var actual = SetsAndMaps.FindPairs(["ab", "ac"]);
        Assert.AreEqual(0, actual.Length);
    }
}
