using System.Collections;
using System.Collections.Generic;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();
        
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;
        
        if (remember.ContainsKey(s))
            return remember[s];
        
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                      CountWaysToClimb(s - 2, remember) + 
                      CountWaysToClimb(s - 3, remember);
        
        remember[s] = ways;
        return ways;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int starIndex = pattern.IndexOf('*');
        
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }
        
        string prefix = pattern.Substring(0, starIndex);
        string suffix = pattern.Substring(starIndex + 1);
        
        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        currPath.Add((x, y));
        
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };
        
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];
            
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }
        
        currPath.RemoveAt(currPath.Count - 1);
    }
}
