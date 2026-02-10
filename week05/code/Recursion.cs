using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace cse212;

public class Recursion
{
    // Problem 1: Recursive Squares Sum
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;
        
        // Recursive case: n² + sum of squares from 1 to n-1
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations Choose - NOTE: Different parameter order!
    public static void PermutationsChoose(List<string> results, string letters, int size, 
                                          string current = """", bool[]? used = null)
    {
        // Initialize used array on first call
        if (used == null)
            used = new bool[letters.Length];
        
        // Base case: if current permutation reaches desired size
        if (current.Length == size)
        {
            results.Add(current);
            return;
        }
        
        // Recursive case: try each unused letter
        for (int i = 0; i < letters.Length; i++)
        {
            if (!used[i])
            {
                // Choose letter i
                used[i] = true;
                
                // Recursively build permutations
                PermutationsChoose(results, letters, size, current + letters[i], used);
                
                // Backtrack
                used[i] = false;
            }
        }
    }

    // Problem 3: Climbing Stairs - NOTE: Returns decimal for large numbers!
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary
        if (remember == null)
            remember = new Dictionary<int, decimal>();
        
        // Check if we already computed this value
        if (remember.ContainsKey(s))
            return remember[s];
        
        // Base cases
        if (s == 0) 
            return 1;  // One way to be at the start
        if (s < 0) 
            return 0;  // Invalid step
        
        // Recursive case with memoization
        decimal ways = CountWaysToClimb(s - 1, remember) + 
                       CountWaysToClimb(s - 2, remember) + 
                       CountWaysToClimb(s - 3, remember);
        
        // Store in memoization dictionary
        remember[s] = ways;
        
        return ways;
    }

    // Problem 4: Wildcard Binary Patterns
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the first wildcard
        int wildcardIndex = pattern.IndexOf('*');
        
        // Base case: no wildcards left
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }
        
        // Recursive case: replace '*' with '0' and '1'
        // Replace with '0'
        string pattern0 = pattern.Substring(0, wildcardIndex) + ""0"" + 
                         pattern.Substring(wildcardIndex + 1);
        WildcardBinary(pattern0, results);
        
        // Replace with '1'
        string pattern1 = pattern.Substring(0, wildcardIndex) + ""1"" + 
                         pattern.Substring(wildcardIndex + 1);
        WildcardBinary(pattern1, results);
    }

    // Problem 5: Maze Solver
    public static void SolveMaze(List<string> results, Maze maze)
    {
        // Start from position (0, 0)
        List<(int, int)> currentPath = new List<(int, int)> { (0, 0) };
        
        // Call the recursive helper
        SolveMazeHelper(currentPath, results, maze);
    }

    private static void SolveMazeHelper(List<(int, int)> currentPath, List<string> results, Maze maze)
    {
        // Get current position
        var (currentX, currentY) = currentPath[^1];
        
        // Base case: reached the end
        if (maze.IsEnd(currentX, currentY))
        {
            results.Add(currentPath.AsString());
            return;
        }
        
        // Try all possible moves: Right, Down, Left, Up
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };
        
        for (int i = 0; i < 4; i++)
        {
            int newX = currentX + dx[i];
            int newY = currentY + dy[i];
            
            if (maze.IsValidMove(newX, newY, currentPath))
            {
                // Add new position to path
                currentPath.Add((newX, newY));
                
                // Recursively explore
                SolveMazeHelper(currentPath, results, maze);
                
                // Backtrack
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
}
