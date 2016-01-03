using System;
using NUnit.Framework;

namespace CodeWars
{
	/*
		Lucas numbers are numbers in a sequence defined like this:
			L(n) = 2 if n = 0
			L(n) = 1 if n = 1
			otherwise
			L(n) = L(n - 1) + L(n - 2)
		Your mission is to define a function lucasnum(n) that returns the nth term of this sequence.
		Note: It should work for negative numbers as well (how you do this is you flip the equation around, so for negative numbers: 
			L(n) = L(n + 2) - L(n + 1))

		Examples:
			lucasnum(-10) -> 123
			lucasnum(-5) -> -11
			lucasnum(-1) -> -1
			lucasnum(0) -> 2
			lucasnum(1) -> 1
			lucasnum(5) -> 11
			lucasnum(10) -> 123
	*/
	public class Lucas
	{
		public static long lucasnum(int n)
		{
			if(n == 0) return 2;
			if (n == 1) return 1;

			long left = 1, right = 1;
			long sum = n > 0 ? 3L : 2L;
			int count = n > 0 ? n - 2 : -n;
			Func<long> summation;
			if(n > 0)
				summation = () => sum + right;
			else
				summation = () => right - sum;

			for (int i = 0; i < count; i++) {
				left = sum;
				sum = summation ();
				right = left;
			}
			return sum;
		}

		public static void Test()
		{
			Assert.AreEqual(11, Lucas.lucasnum(5));
			Assert.AreEqual(123, Lucas.lucasnum(-10));
			Assert.AreEqual(-11, Lucas.lucasnum(-5));
			Assert.AreEqual(-1, Lucas.lucasnum(-1));
			Assert.AreEqual(2, Lucas.lucasnum(0));
			Assert.AreEqual(1, Lucas.lucasnum(1));
			Assert.AreEqual(123, Lucas.lucasnum(10));
		}
	}
}
