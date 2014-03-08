using UnityEngine;
using System.Collections;

[AddComponentMenu("Singletons/EventManager")]
public class EventManager : SingletonMonoBehaviour<EventManager> {

// http://answers.unity3d.com/questions/559269/event-manager-and-event-listener.html
	
	public delegate void DoorTimerEnd ();
	public static event DoorTimerEnd doorTimerEnd;

	public void _doorTimerEnd () {
		if (doorTimerEnd != null) {
			doorTimerEnd ();
		}
	}
}

