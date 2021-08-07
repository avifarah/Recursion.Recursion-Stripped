#nullable enable
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace Recursion_Stripped
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            *  Palindrome n:
            *		n = 1:	Palindrome(n) = 1 1
            *		n = 2:	Palindrome(n) = 2 1 1 2
            *		n = 3:	Palindrome(n) = 3 2 1 1 2 3
            *		etc...
            *  Write a recursive program that will take n as input and produce the list:
            *		n (n - 1) (n - 2) . . 2 1 1 2 . . (n - 2) (n - 1) n
            */
            //try
            //{
            //	int test = 5;
            //	var pal = Palindrome.GetPalindrome(test);
            //	Console.WriteLine($"Palindrome.GetPalindrome({test})");
            //	Console.WriteLine(string.Join(" ", pal));
            //}
            //catch (Exception ex)
            //{
            //	Console.WriteLine($"Error while processing Archimedis' row 2.  Internal message: {ex.Message}");
            //}

            /*
            *  Power:
            *  x ^ y find result in a recursive manner
            */
            //Console.WriteLine();
            //Console.WriteLine("Power:");
            //var baseValue = 5;
            //for (var n = -5; n <= 5; ++n)
            //{
            //	var p = PowerOf.Power(baseValue, n);
            //	var trust = Math.Pow(baseValue, n);
            //	var check = (trust - p) / trust;
            //	Console.WriteLine($"PowerOf.Power({baseValue}, {n,2}): {p}{(check > 1e-15 ? $"  Check detected an error.  {trust} vs {p}" : string.Empty)}");
            //}

            /*
            *  Pascal's triangle (https://en.wikipedia.org/wiki/Pascal%27s_triangle):
            *  n = 0               1
            *  n = 1             1   1
            *  n = 2           1   2   1
            *  n = 3         1   3   3   1
            *  n = 4       1   4   6   4   1
            *  n = 5      1  5  10  10   5   1
            *
            *  Note that:
            *  	(a + b)^0 = 1
            *		(a + b)^1 = 1*a + 1*b
            *		(a + b)^2 = 1*a^2 + 2*a*b + 1*b^2
            *		(a + b)^3 = 1*a^3 + 3*a^2*b + 3*a*b^2 + 1*b^3
            *  Write a recursive program that return the n'th row of Archimedis triangle
            */
            //var row = 5;
            //try
            //{
            //	Console.WriteLine();
            //	Console.WriteLine($"Pascal's triangle.  Row {row}:");
            //	var row2 = PascalsTriangle.PascalsRow(row);
            //	Console.WriteLine(string.Join(" ", row2));
            //}
            //catch (Exception ex)
            //{
            //	Console.WriteLine($"Error while processing Pascal's row {row}.  Internal message: {ex.Message}");
            //}

            /*
            *	Fibonacci:
            *		Fibonacci(0) = 0
            *		Fibonacci(1) = 1
            *		Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2)
            */
            //var fibValue = 40;
            //try
            //{
            //	Console.WriteLine();
            //	Console.WriteLine("Fibonacci number value");
            //	var sw = Stopwatch.StartNew();
            //
            //	var fib = Fibonacci.Fib(fibValue);
            //
            //	sw.Stop();
            //	Console.WriteLine($"Fibonacci({fibValue}):  {fib:#,##0}.  (Calculated in {sw.ElapsedMilliseconds:#,##0} milliseconds)");
            //}
            //catch (Exception ex)
            //{
            //	Console.WriteLine($"Error while processing Fibonacci({fibValue}).  Internal message: {ex.Message}");
            //}

            /*
            * We have n disks stacked in size order where the smallest is at the top.
            * We have 3 pegs A, B and C
            * The disks are stacked on Peg A
            *
            * Our task is to move the disks from Peg A to Peg C by using Peg B, such that:
            * 		1	We move one disk at a time
            *		2	No larger disk is ever placed on top of a smaller disk
            *
            * If diskCount == 1
            *		MoveDisk:	A -> C		(no sweat)
            * if diskCount == 2
            *		MoveDisk:	A -> B		(Peg B is empty and is the place holder peg.  The disk moved is the smaller disk)
            *		MoveDisk:	A -> C		(Move the larger disk to the destination Peg, C)
            *		MoveDisk:	B -> C		(Move the smaller disk from B on top of the larger disk on C)
            */
            var diskCount = 3;
            try
            {
                Console.WriteLine();
                Console.WriteLine($"Tower of Hanoi with {diskCount} disks:");
                TowerOfHanoi.Peg fromPeg = TowerOfHanoi.Peg.A;
                TowerOfHanoi.Peg toPeg = TowerOfHanoi.Peg.C;
                TowerOfHanoi.Peg usingPeg = TowerOfHanoi.Peg.B;
                TowerOfHanoi.MoveTower(diskCount, fromPeg, usingPeg, toPeg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing TowerOfHanoi({diskCount}).  Internal message: {ex.Message}");
            }
        }
    }

    class Palindrome
    {
        public static List<int> GetPalindrome(int n)
        {
            if (n < 1)
                throw new ArgumentException($"intput given {n} is not allowed.  It is expected to be positive", nameof(n));
            
            // A place holder
            return new List<int>();
        }
    }

    class PowerOf
    {
        public static double Power(int baseValue, int expValue)
        {
            // Place holder
            return 0.0;
        }
    }

    class PascalsTriangle
    {
        // Hint
        public static IEnumerable<int> PascalsRow(int n)
        {
            if (n < 0)
                throw new ArgumentException($"input value of {n} is illegal.  Expected value of 0 or more", nameof(n));
            
            // Place holder		
            return new List<int>();
        }
    }

    class Fibonacci
    {
        public static BigInteger Fib(int n)
        {
            if (n < 0)
                throw new ArgumentException($"intput ({n}) may not be negative", nameof(n));

            // Place holder
            return 0;
        }
    }

    class TowerOfHanoi
    {
        public enum Peg { A, B, C }

        /*
        *	Tower of Hanoi.
        *	We have 3 pegs, A, B, C
        *	We also have N disks on peg A stacked in order largest at the bottom smallest at the top.
        *  No 2 disks are of the same size.
        *  We need to move the disks from peg A to peg C (using B) such that we:
        *		A.	move 1 disk at a time and 
        *		B.	No bigger disk sits on top of a smaller disk.
        */
        /// <summary>
        /// Originally we need to move the Tower from A (p1) to C (p3)
        /// </summary>
        public static void MoveTower(int diskCount, Peg p1, Peg p2, Peg p3)
        {
        }
    }
}
