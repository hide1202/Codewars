using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodeWars
{
	/*
	Word Patterns
		Write
			WordPattern(string pattern, string str)
			that given a pattern and a string str, find if str follows the same sequence as pattern. 
		For example:
			WordPattern("abab', "truck car truck car") == true
			WordPattern("aaaa", "dog dog dog dog") == true
			WordPattern("abab", "apple banana banana apple") == false
			WordPattern("aaaa', "cat cat dog cat") == false
	*/
	public class WordPatternsProblem
	{
		public static bool WordPattern(string pattern, string str)
		{
			var keys = pattern.ToCharArray ();
			var values = str.Split (' ');

			if (keys.Length != values.Length)
				return false;

			var dict = new Dictionary<char, string> ();

			for (int i = 0; i < keys.Length; i++) {
				var k = keys [i];
				if (dict.ContainsKey (k)) {
					if (dict [k] != values [i])
						return false;
				} else if (dict.ContainsValue (values [i]))
					return false;
				else
					dict.Add (k, values [i]);
			}

			return true;
		}

		public static void Test()
		{
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("abab", "apple banana apple banana"));
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("abba", "car truck truck car"));
			Assert.AreEqual(false, WordPatternsProblem.WordPattern("abab", "apple banana banana apple"));
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("aaaa", "cat cat cat cat"));
			Assert.AreEqual(false, WordPatternsProblem.WordPattern("aaaa", "cat cat dog cat"));
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("bbbabcb", "c# c# c# javascript c# python c#"));
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("abcdef", "apple banana cat donkey elephant flower"));
			Assert.AreEqual(false, WordPatternsProblem.WordPattern("xyzzyx", "apple banana apple banana"));
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("xyzzyx", "1 2 3 3 2 1"));
			Assert.AreEqual(true, WordPatternsProblem.WordPattern("aafggiilp", "cow cow fly pig pig sheep sheep chicken aardvark"));
			Assert.AreEqual(false, WordPatternsProblem.WordPattern("aafggiilp", "cow cow fly rooster pig sheep sheep chicken aardvark"));
			Assert.AreEqual(false, WordPatternsProblem.WordPattern("aaaa", "cat cat cat"));
			Assert.AreEqual(false, WordPatternsProblem.WordPattern("abba", "dog dog dog dog"));
		}
	}
}