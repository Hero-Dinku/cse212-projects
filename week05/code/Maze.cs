using System;
using System.Collections.Generic;
using System.Linq;

namespace cse212;

public class Maze
{
    private readonly int[] _maze;
    private readonly int _size;
    
    // Constructor with 3 parameters as shown in tests
    public Maze(int rows, int cols, int[] maze)
    {
        _maze = maze;
        _size = rows;  // Assuming square maze (rows == cols)
    }

    // Helper method to check if we're at the end
    public bool IsEnd(int x, int y)
    {
        return GetCell(x, y) == 2;
    }

    // Helper method to get cell value
    public int GetCell(int x, int y)
    {
        return _maze[y * _size + x];
    }

    // Helper method to check if a move is valid
    public bool IsValidMove(int x, int y, List<(int, int)> currentPath)
    {
        // Check bounds
        if (x < 0 || x >= _size || y < 0 || y >= _size)
            return false;
        
        // Check if it's a wall (0 means wall)
        if (GetCell(x, y) == 0)
            return false;
        
        // Check if we've already been here (no circles)
        if (currentPath.Contains((x, y)))
            return false;
        
        return true;
    }
}
