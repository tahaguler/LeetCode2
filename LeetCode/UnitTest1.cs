using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public int[] Test1()
        {
            int[] nums = new int[] {3, 2, 4};
            int target = 6;

            List<int> indexList = new List<int>();
            foreach (var num in nums)
            {
                int numSearch = target - num;
                int result = Array.FindIndex(nums, t => t == numSearch && t != num);
                if (result > -1)
                {
                    // 
                    indexList.Add(Array.IndexOf(nums, num));
                    indexList.Add(result);
                    break;
                }
            }

            int[] indexArray = indexList.ToArray();
            return indexArray;
        }

        [Fact]
        public int[] TwoSumSolution_BruteForce()
        {
            int[] nums = new int[] {3, 2, 4};
            int target = 6;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] {i, j};
                    }
                }
            }

            throw new ArgumentException("No two sum solution");
        }

        [Fact]
        public int[] TwoSumSolution_HashTable()
        {
            var nums = new int[] {2, 2, 5, 6};
            const int target = 4;

            var hashTable = new Hashtable();
            for (var i = 0; i < nums.Length; i++)
            {
                hashTable.Add(nums[i], i);
                // It is important to add the number as the key and index as the value because we will be using the indexes at the end.
                /*
                 * [
                 *  2: 0,
                 *  2: 1,
                 *  5: 2,
                 *  6, 3
                 * ]
                 */
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (hashTable.ContainsKey(complement) && (int?) hashTable[complement] != i)
                {
                    return new int[] {i, (int) hashTable[complement]};
                }
            }

            throw new ArgumentException("No two sum solution");
        }

        [Fact]
        public int[] TwoSumSolution_OnePassHash()
        {
            int[] nums = new int[] {2, 5, 6};
            int target = 8;

            Hashtable hashTable = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (hashTable.ContainsKey(complement))
                {
                    return new int[] {i, (int) hashTable[complement]};
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
            char[] cArr = new char[] {'a', 'b'};
            cArr = new char[] { };
            _testOutputHelper.WriteLine(cArr.Length.ToString());
        }

        [Fact]
        public void MaxOperator()
        {
            Math.Max(5, 6);
        }

        [Fact]
        public void CanIAddSameCharIntoHashSet() // I can't. it wont crash but it only keeps one.
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
        public ListNode AddTwoNumbers()
        {
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));

            ListNode dummyHead = new ListNode();
            ListNode p = l1, q = l2, curr = dummyHead; // I need a dummy head to keep track of the start, otherwise I would lose the start. 
            var carry = 0;

            while (p != null || q != null)
            {
                var x = (p != null) ? p.val : 0;
                var y = (q != null) ? q.val : 0;

                int sum = x + y + carry;

                carry = sum / 10;

                curr.next = new ListNode( sum % 10); // 0 -> x   modulus operator called mod.
                curr = curr.next; // x -> null
                
                if( p != null) p = p.next;
                if (q != null) q = q.next;
            }
            
            if (carry > 0){
                curr.next = new ListNode(carry);
            }

            return dummyHead.next;
        }

        [Fact]
        public string LongestPali()
        {
            string s = "babad";
            if (s == null || s.Length < 1) return "";
           
            int start = 0, end = 0, realLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = paliLength(s, i, i);
                int len2 = paliLength(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > realLen)
                {
                    start = i - (len - 1) / 2;
                    realLen = len;
                }
            } 

            return s.Substring(start, realLen);
        }

        [Fact]
        public int CountPrimes()
        {
            int n = 10;
            
            
            bool[] primes = new bool[n];
        
            for(int i = 0; i < primes.Length; i++){
                primes[i] = true;
            }
        
            for(int i = 2; i * i < primes.Length; i++){
                if(primes[i]){
                    for(int j = i; i * j < primes.Length; j++){
                        primes[i*j] = false;
                    }
                }
            }
        
            int primeCount = 0;
            for(int i = 2; i < primes.Length; i++){
                if(primes[i]) primeCount++;
            }
        
            return primeCount;
        }
        
        private int paliLength(string s, int left, int right){
            int L = left, R = right;
            while(L >= 0 && R < s.Length && s[L] == s[R]){
                L--;
                R++; 
            }
            return R - L - 1 ;// rwcecdb 3 2 4 lentgh 3 
        } 
    }


    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}