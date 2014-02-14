// From/Inspired by http://wiki.unity3d.com/index.php?title=SingletonLauncher
using UnityEngine;
using System.Collections;

[AddComponentMenu("Singletons/ExempleSingleton")]
public class ExempleSingleton : SingletonMonoBehaviour<ExempleSingleton> {
	
	public int myVar;
	
	public static void Add(int n) { 
		singleton.myVar += n;
	}
}
