using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms
{
    internal class ClimbStair
    {
        //递归代码
        public int climbStairs(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            return climbStairs(n - 1) + climbStairs(n - 2);
        }
        //记忆化递归
        Dictionary<int,int> memo =new Dictionary<int, int>() ;
        public int climbStairs1(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            if (memo.ContainsKey(n)) return memo[n];
            memo.Add(n, climbStairs(n - 1) + climbStairs(n - 2));
            return memo[n];
        }
        //DP
        public int climbStairsDP(int n)
        {
            if (n == 1) return 1;
            int[] dp = new int[10];
            dp[0] = 1;
            dp[1] = 2;

            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[dp.Length - 1];
        }
        //DP滚动数组优化
        public int climbStairsDP2(int n)
        {
            if (n == 1) return 1;
            int a = 1;
            int b= 2;
            int temp = 0;

            for (int i = 2; i < n; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }
            return temp;
        }

    }
}
