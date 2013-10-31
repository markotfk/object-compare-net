using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

namespace compareNet
{
	public class ObjectComparer
	{
		public static bool Compare (object object1, object object2)
		{
			Console.WriteLine ("Compare enter");
			if (!object1.GetType ().Equals (object2.GetType ())) {
				Console.WriteLine ("Compare: Object types do not match");
				return false;
			}
			var fields1 = object1.GetType ().GetFields ();
			var fields2 = object2.GetType ().GetFields ();

			var diffValuesFields = new List<Tuple<string, object, object>> ();
			foreach (var field1 in fields1) {
				foreach (var field2 in fields2) {
					if (field2.Name == field1.Name) {
						Console.WriteLine ("field name match:" + field2.Name);
						var value1 = field1.GetValue (object1);
						var value2 = field2.GetValue (object2);
						if (!value1.Equals (value2)) {
							diffValuesFields.Add (new Tuple<string, object, object> (field1.Name, value1, value2));
						}
					}
				}
			}

			if (diffValuesFields.Count > 0) {
				Console.WriteLine("Object fieds are not equal. Diff:");
			}
			foreach (var diff in diffValuesFields) {
				Console.WriteLine ("* " + diff.Item1 + ": " + diff.Item2 + " != " + diff.Item3);
			}

			var props1 = object1.GetType ().GetProperties ();
			var props2 = object2.GetType ().GetProperties ();

			var diffValuesProps = new List<Tuple<string, object, object>> ();
			foreach (PropertyInfo prop1 in props1) {
				foreach (PropertyInfo prop2 in props2) {
					if (prop1.Name == prop2.Name) {
						var value1 = prop1.GetValue (object1, null);
						var value2 = prop2.GetValue (object2, null);
						if (!value1.Equals (value2)) {
							diffValuesProps.Add (new Tuple<string, object, object> (prop1.Name, value1, value2));
						}
					}
				}
			}
			if (diffValuesProps.Count > 0) {
				Console.WriteLine("Object properties are not equal. Diff:");
			}
			foreach (var diff in diffValuesProps) {
				Console.WriteLine ("* " + diff.Item1 + ": " + diff.Item2 + " != " + diff.Item3);
			}
			var retVal = diffValuesFields.Count == 0 && diffValuesProps.Count == 0;
			if (retVal) {
				Console.WriteLine ("Objects are equal!");
			}
			return retVal;
		}
	}
}

