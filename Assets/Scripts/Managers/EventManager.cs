using UnityEngine;
using System.Collections;

[AddComponentMenu("Singletons/EventManager")]
public class EventManager : SingletonMonoBehaviour<EventManager> {

// http://answers.unity3d.com/questions/559269/event-manager-and-event-listener.html
	
	public delegate void LeftDoorAccessed ();
	public static event LeftDoorAccessed leftDoorAccessed;

	public delegate void RightDoorAccessed ();
	public static event RightDoorAccessed rightDoorAccessed;

	public void _leftDoorAccessed () {
		if (leftDoorAccessed != null) {
			leftDoorAccessed ();
		}
	}

	public void _rightDoorAccessed () {
		if (rightDoorAccessed != null) {
			rightDoorAccessed ();
		}
	}
}

