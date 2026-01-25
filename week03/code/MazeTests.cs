using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

[TestClass]
public class MazeTests
{
    [TestMethod]
    public void Maze_Basic()
    {
        Dictionary<(int, int), bool[]> map = new()
        {
            { (1, 1), new[] { false, true, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (2, 1), new[] { true, false, false, true } },
            { (2, 2), new[] { true, false, true, false } }
        };
        
        var maze = new Maze(map);
        Assert.AreEqual("Current location (x=1, y=1)", maze.GetStatus());
        
        // Test valid movements
        maze.MoveRight();
        Assert.AreEqual("Current location (x=2, y=1)", maze.GetStatus());
        
        maze.MoveDown();
        Assert.AreEqual("Current location (x=2, y=2)", maze.GetStatus());
        
        // Test invalid movement (should throw exception)
        Assert.ThrowsException<InvalidOperationException>(() => maze.MoveRight());
    }
    
    [TestMethod]
    public void Maze_ComplexMovement()
    {
        Dictionary<(int, int), bool[]> map = new()
        {
            { (1, 1), new[] { false, true, false, true } },
            { (2, 1), new[] { true, false, false, true } },
            { (1, 2), new[] { false, true, true, false } },
            { (2, 2), new[] { true, false, true, false } }
        };
        
        var maze = new Maze(map);
        
        // Move in a square
        maze.MoveRight();  // (2,1)
        maze.MoveDown();   // (2,2)
        maze.MoveLeft();   // (1,2)
        maze.MoveUp();     // (1,1)
        
        Assert.AreEqual("Current location (x=1, y=1)", maze.GetStatus());
    }
}
