using System;
using NUnit.Framework;

namespace CodeWars
{
	public class ProdFib
	{
		/*
			The Fibonacci numbers are the numbers in the following integer sequence (Fn):

			0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ...
			such as

			F(n) = F(n-1) + F(n-2) with F(0) = 0 and F(1) = 1.
			Given a number, say prod (for product), we search two Fibonacci numbers F(n) and F(n+1) verifying

			F(n) * F(n+1) = prod.
			Your function productFib takes an integer (prod) and returns an array:

			{F(n), F(n+1), 1}
			if F(n) * F(n+1) = prod or returns

			{F(n), F(n+1), 0}
			if you don't find two consecutive F(m) verifying F(m) * F(m+1) = prod. F(m) will be the smallest one such as F(m) * F(m+1) > prod.

			Examples

			productFib(714) # should return {21, 34, 1}, 
			                # since F(8) = 21, F(9) = 34 and 714 = 21 * 34

			productFib(800) # should return {34, 55, 0}, 
			                # since F(8) = 21, F(9) = 34, F(10) = 55 and 21 * 34 < 800 < 34 * 55
			Note: Not useful here but we can tell how to choose the number n up to which to go: 
			we can use the "golden ratio" phi which is (1 + sqrt(5))/2 knowing that F(n) is asymptotic to: phi^n / sqrt(5). 
			That gives a possible upper bound to n.

			References

			http://en.wikipedia.org/wiki/Fibonacci_number

			http://oeis.org/A000045
		*/
		public static ulong[] productFib(ulong prod) {
			ulong fib1 = 0, fib2 = 1;
			ulong fib3 = 0;
			while (fib3 < prod) {
				fib3 = fib1 + fib2;
				var tmp = fib2;
				fib2 = fib3;
				fib1 = tmp;
			}

			return new ulong[]{fib3};
		}

		public static void Test() {
			ulong[] r = new ulong[] { 55, 89, 1 };
			Assert.AreEqual(r, ProdFib.productFib(4895));
		}
	}
}

