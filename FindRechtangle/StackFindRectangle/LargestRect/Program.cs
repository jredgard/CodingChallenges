using System;
using System.Collections.Generic;
public class Solution
{
    static public int LargestRectangleArea(int[] heights)
    {
        var stack = new Stack<int>();               //going to build a stack and pop it as we pass a value to the right that is smaller

        int n = heights.Length;             //max count
        int maxA = 0;

        for (int i = 0; i <= n; i++)        
        {
            var height = 0;
            if (i < n)
            {
                height = heights[i];        
            }
            else
            {
                height = 0;
            }

            if (stack.Count != 0)
            {
                var checkstack = stack.Peek(); //get the current peek of the stack
                Console.WriteLine(checkstack);
            }
            while (stack.Count != 0 && heights[stack.Peek()] > height)  //if the peek is bigger, we pop it off since it goes down to the right
            {
                var cHeight = heights[stack.Pop()];
                var prevIndex = -1;

                if (stack.Count != 0)
                {
                    prevIndex = stack.Peek();               //caclulate the previous index to get the lenght of the rectangle
                }

                maxA = Math.Max(maxA, cHeight * (i - 1 - prevIndex));
            }
            stack.Push(i);          //add it to the stack
        }

        return maxA;
    }

    static void Main(string[] args)
    {
        var test1 = new int[] { 2, 1, 5, 6, 2, 3 };
        var result = LargestRectangleArea(test1);
        Console.WriteLine(result); 
    }




}


//This challenges seems to be a stack chellenge
//The grapgh can go up and down to the right and add to stack
//Start the 0 index and check if the next element is bigger. If it is we continue. If its not we pop it, and calculate the max area for the prev index that is left
//Calculte the remaining indexes in the stack's area.
