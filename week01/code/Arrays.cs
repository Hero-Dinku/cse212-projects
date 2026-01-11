using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of size 'length' to store the multiples
        // Step 2: Use a for loop to iterate from 0 to length-1
        // Step 3: For each iteration, calculate the multiple: number * (i + 1)
        // Step 4: Store the result in the array at index i
        // Step 5: Return the completed array
        
        double[] result = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Check for invalid inputs (null list, empty list, or amount out of range)
        // Step 2: Calculate the split index = data.Count - amount
        // Step 3: Get the right part (elements from split index to end) using GetRange
        // Step 4: Get the left part (elements from start to split index-1) using GetRange
        // Step 5: Clear the original list
        // Step 6: Add the right part first, then the left part to achieve rotation
        
        if (data == null || data.Count == 0 || amount <= 0 || amount > data.Count)
            return;
            
        int splitIndex = data.Count - amount;
        
        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);
        
        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
