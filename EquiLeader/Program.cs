using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public static void Main(string[] args)
    {
        int[] intArray = new int[args.Length];
        for(int i = 0; i < args.Length; i++)
        {
            intArray[i] = int.Parse(args[i]);
        }
        solution(intArray);
    }
    public static int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        //A leader is a value that takes up over n/2 elements in the array
        //As per help, add A to a stack. If the top two elements of the stack differ, then remove them.  Due to the definition of a leader, we will end up with the leader left.

        Stack<int> leaderTestStack = new Stack<int>();
        foreach(var item in A)
        {
            if(leaderTestStack.Count > 0 && leaderTestStack.Peek() != item)
            {
                leaderTestStack.Pop();
            }
            else
            {
                leaderTestStack.Push(item);
            }
        }

        //Leader will be only value left in stack.
        if (leaderTestStack.Count > 0)
        {
            int leaderOfFullArray = leaderTestStack.Peek();

            //Check that each way of splitting the array in half still has the leader as leader (count > n/2).
            //Using prefixSum
            int[] prefixSumOfLeader = new int[A.Length];
            prefixSumOfLeader[0] = A[0] == leaderOfFullArray ? 1 : 0;
            for (int i = 1; i < A.Length; i++)
            {
                prefixSumOfLeader[i] = prefixSumOfLeader[i - 1] + (A[i] == leaderOfFullArray ? 1 : 0);
            }

            //Loop along indexes to split the array and check sum of leader val for each side is greater than size / 2
            int totalEquiLeaders = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int sumLeft = prefixSumOfLeader[i];
                int sumRight = prefixSumOfLeader[A.Length - 1] - sumLeft;
                if (sumLeft > (i + 1) / 2 && sumRight > (A.Length - (i + 1)) / 2)
                {
                    totalEquiLeaders++;
                }
            }
            return totalEquiLeaders;
        }
        return 0;
    }
}