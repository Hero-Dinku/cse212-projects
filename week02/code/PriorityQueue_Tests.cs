using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic priority queue functionality with different priorities
    // Expected Result: Highest priority item dequeued first
    // Defect(s) Found: Original loop condition missed last item and >= didn't maintain FIFO
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(\"Low\", 1);
        priorityQueue.Enqueue(\"High\", 3);
        priorityQueue.Enqueue(\"Medium\", 2);
        
        Assert.AreEqual(\"High\", priorityQueue.Dequeue());
        Assert.AreEqual(\"Medium\", priorityQueue.Dequeue());
        Assert.AreEqual(\"Low\", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same priority
    // Expected Result: Should dequeue in FIFO order for same priority
    // Defect(s) Found: Original >= comparison didn't maintain FIFO for same priority
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(\"First\", 2);
        priorityQueue.Enqueue(\"Second\", 2);
        priorityQueue.Enqueue(\"Third\", 2);
        
        Assert.AreEqual(\"First\", priorityQueue.Dequeue());
        Assert.AreEqual(\"Second\", priorityQueue.Dequeue());
        Assert.AreEqual(\"Third\", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with same high priority items
    // Expected Result: Highest priority first, FIFO within same priority
    // Defect(s) Found: Need proper handling of priority comparison and FIFO order
    public void TestPriorityQueue_MixedPrioritiesWithSameHigh()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(\"A\", 1);
        priorityQueue.Enqueue(\"B\", 3);
        priorityQueue.Enqueue(\"C\", 3); // Same priority as B
        priorityQueue.Enqueue(\"D\", 2);
        
        Assert.AreEqual(\"B\", priorityQueue.Dequeue()); // Highest priority, first of same
        Assert.AreEqual(\"C\", priorityQueue.Dequeue()); // Same priority as B, FIFO
        Assert.AreEqual(\"D\", priorityQueue.Dequeue()); // Priority 2
        Assert.AreEqual(\"A\", priorityQueue.Dequeue()); // Priority 1
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message \"The queue is empty.\"
    // Defect(s) Found: Exception type and message should be correct
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail(\"Should throw exception for empty queue\");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual(\"The queue is empty.\", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Single item in queue
    // Expected Result: Should return that item, then throw exception when empty
    // Defect(s) Found: Basic single item functionality
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(\"Single\", 5);
        
        Assert.AreEqual(\"Single\", priorityQueue.Dequeue());
        
        // Should be empty now
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail(\"Should throw exception after dequeuing last item\");
        }
        catch (InvalidOperationException) { }
    }

    [TestMethod]
    // Scenario: Negative and zero priorities
    // Expected Result: Should respect priority ordering with negative values
    // Defect(s) Found: Should handle all integer priority values
    public void TestPriorityQueue_NegativeAndZeroPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(\"Most Negative\", -10);
        priorityQueue.Enqueue(\"Negative\", -5);
        priorityQueue.Enqueue(\"Zero\", 0);
        priorityQueue.Enqueue(\"Positive\", 5);
        
        Assert.AreEqual(\"Positive\", priorityQueue.Dequeue()); // 5 (highest)
        Assert.AreEqual(\"Zero\", priorityQueue.Dequeue());     // 0
        Assert.AreEqual(\"Negative\", priorityQueue.Dequeue()); // -5
        Assert.AreEqual(\"Most Negative\", priorityQueue.Dequeue()); // -10
    }

    [TestMethod]
    // Scenario: Complex mix of priorities
    // Expected Result: Correct priority ordering with FIFO for ties
    // Defect(s) Found: Comprehensive priority handling
    public void TestPriorityQueue_ComplexScenario()
    {
        var priorityQueue = new PriorityQueue();
        // Add in mixed order
        priorityQueue.Enqueue(\"A\", 2);
        priorityQueue.Enqueue(\"B\", 5);
        priorityQueue.Enqueue(\"C\", 2); // Same as A
        priorityQueue.Enqueue(\"D\", 1);
        priorityQueue.Enqueue(\"E\", 5); // Same as B
        priorityQueue.Enqueue(\"F\", 3);
        
        // B and E have priority 5 (highest), B first (FIFO)
        Assert.AreEqual(\"B\", priorityQueue.Dequeue());
        Assert.AreEqual(\"E\", priorityQueue.Dequeue()); // Same priority as B
        Assert.AreEqual(\"F\", priorityQueue.Dequeue()); // Priority 3
        Assert.AreEqual(\"A\", priorityQueue.Dequeue()); // Priority 2, first of same
        Assert.AreEqual(\"C\", priorityQueue.Dequeue()); // Priority 2, same as A
        Assert.AreEqual(\"D\", priorityQueue.Dequeue()); // Priority 1
    }
}
