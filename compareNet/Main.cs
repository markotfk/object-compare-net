using System;
using System.Diagnostics;

namespace compareNet
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var test1 = new TestClassForCompare (100, "Test1");
			var test2 = new TestClassForCompare (200, "Test2");

			var diff = ObjectComparer.Compare (test1, test2);
			Debug.Assert(!diff);

			diff = ObjectComparer.Compare(test1, test1);
			Debug.Assert(diff);



			Console.ReadLine();
		}
	}
}
