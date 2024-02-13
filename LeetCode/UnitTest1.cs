using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Xunit;
using Xunit.Abstractions;

namespace LeetCode
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;

            List<int> indexList = new List<int>();
            foreach (var num in nums)
            {
                int numSearch = target - num;
                int result = Array.FindIndex(nums, t => t == numSearch && t != num);
                if (result > -1)
                {

                    indexList.Add(Array.IndexOf(nums, num));
                    indexList.Add(result);
                    break;
                }
            }

            int[] indexArray = indexList.ToArray();
            Console.WriteLine(indexArray);
        }

        [Fact]
        public void TwoSumSolution_BruteForce()
        {
            int[] nums = new int[] { 3, 2, 4 };
            int target = 6;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        Console.WriteLine(new int[] { i, j }); ;
                    }
                }
            }

            throw new ArgumentException("No two sum solution");
        }

        [Fact]
        public void TwoSumSolution_OnePassHash()
        {
            int[] nums = new int[] { 2, 5, 6 };
            int target = 8;

            Hashtable hashTable = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (hashTable.ContainsKey(complement))
                {
                    var result = new int[] { i, (int)hashTable[complement] };
                    foreach (var t in result)
                    {
                        _testOutputHelper.WriteLine(t.ToString());
                    }

                    Console.WriteLine(result);
                }

                hashTable.Add(nums[i], i);
            }

            throw new ArgumentException("No two sum solution");
        }

        [Fact]
        public void PercentOperatorTest()
        {
            float percent = 14f / 10f;
            _testOutputHelper.WriteLine(percent.ToString());
        }

        [Fact]
        public void LengthResultTest()
        {
            string str = "Taha";
            _testOutputHelper.WriteLine(str.Length.ToString());
        }

        [Fact]
        public void CanIEmptyAnArray()
        {
            char[] cArr = new char[] { 'a', 'b' };
            cArr = new char[] { };
            _testOutputHelper.WriteLine(cArr.Length.ToString());
        }

        [Fact]
        public void LongestSubStreing()
        {
            Math.Max(5, 6);
        }

        [Fact]
        public void CanIAddSameCharIntoHashSet()
        {
            HashSet<char> set = new HashSet<char>();
            set.Add('a');
            set.Add('a');
            foreach (var c in set)
            {
                _testOutputHelper.WriteLine(c.ToString());
            }
        }

        [Fact]
        public void LongestSubstringWithoutRepeatingCharacters()
        {
            string s = "Taha";
            int ans = 0, i = 0, j = 0;
            HashSet<char> set = new HashSet<char>();

            while (j < s.Length)
            {
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j]);
                    ans = Math.Max(set.Count, ans);
                    j++;
                }
                else
                {
                    set.Remove(s[i]);
                    i++;
                }
            }

            _testOutputHelper.WriteLine(ans.ToString());
        }

        [Fact]
        public void FindLongestPalindrome()
        { // O(n)
            string s = "aaaabbbcddd";
            int[] count = new int[128]; // why 256
            for (int i = 0; i < s.Length; i++)
            {
                count[s[i]]++;
            }

            // Any palindromic string consists of three parts. Beg mid end
            // if even number then no mid.
            string beg = "", mid = "", end = "";

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                //if the current character freq is odd. 
                if (count[ch] % 2 == 1 && mid == "")
                {
                    mid = ch.ToString();

                    count[ch--]--;
                }
                else
                {
                    for (int i = 0; i < count[ch] / 2; i++)
                    {
                        beg += ch;
                        end = ch + end;
                    }
                }
            }

            string result = beg + mid + end;
        }
    }
}