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
