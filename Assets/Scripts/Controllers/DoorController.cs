using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public Door[] doors;

	public bool areOpens;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI ()
	{
		if (GUI.Button (new Rect (100, 100, 100, 100), "Open doors")) {
			OpenDoors ();
		}
		
		if (GUI.Button (new Rect (200, 100, 100, 100), "Close doors")) {
			CloseDoors ();
		}
	}


	public void OpenDoors () {
		foreach (Door door in doors) {
			door.OpenDoor ();	
		}
	}
	
	public void CloseDoors () {
		foreach (Door door in doors) {
			door.CloseDoor ();	
		}
	}
}
