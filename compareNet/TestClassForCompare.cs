using System;

namespace compareNet
{
	public class TestClassForCompare
	{
		public int count;
		public string name;

		public TestClassForCompare (int count, string name)
		{
			this.count = count;
			this.name = name;
			IntProperty = 0;
			StrProperty = "";
		}

		public int IntProperty { get; set; }

		public string StrProperty { get; set; }

	}
}

