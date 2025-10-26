using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'lilysHomework' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int lilysHomework(List<int> arr)
    {
         int n = arr.Count;

        List<int> asc = new List<int>(arr);
        asc.Sort();
        List<int> desc = new List<int>(asc);
        desc.Reverse();

        int swapsAsc = CountSwaps(new List<int>(arr), asc);
        int swapsDesc = CountSwaps(new List<int>(arr), desc);

        return Math.Min(swapsAsc, swapsDesc);
    }

    private static int CountSwaps(List<int> source, List<int> target)
    {
        int swaps = 0;
        Dictionary<int, int> indexMap = new Dictionary<int, int>();

        for (int i = 0; i < source.Count; i++)
            indexMap[source[i]] = i;

        for (int i = 0; i < source.Count; i++)
        {
            if (source[i] != target[i])
            {
                swaps++;

                int correctVal = target[i];
                int idx = indexMap[correctVal];

                indexMap[source[i]] = idx;
                source[idx] = source[i];
                source[i] = correctVal;
            }
        }

        return swaps;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.lilysHomework(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
