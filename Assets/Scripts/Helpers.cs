using UnityEngine;
using System.IO;
using System;

public class Helpers
{
		public static T GetRandomEnum<T> ()
		{
				System.Array A = System.Enum.GetValues (typeof(T));
				T V = (T)A.GetValue (UnityEngine.Random.Range (0, A.Length));
				return V;
		}

		public static float Multiply (float a, float b)
		{
				return a * b;
		}

		public static string fileToString (string mapPath)
		{

				if (File.Exists (mapPath)) {
						return File.ReadAllText (mapPath);
				} else {
						Debug.LogError (mapPath);
						throw new Exception ("fileToString: File not found! ");
				}
		}
}