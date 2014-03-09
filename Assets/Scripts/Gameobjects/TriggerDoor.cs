using UnityEngine;
using System.Collections;

public class TriggerDoor : MonoBehaviour
{
	public Door door;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D (Collider2D other) {
//		if (door.position == Door.DoorPosition.Left && other.) {
		PlayerControl pC = other.gameObject.GetComponent<PlayerControl>();
		if (pC != null) {
			if (door.position == Door.DoorPosition.Left && pC.PlayerNumber == 2) {
				EventManager.singleton._leftDoorAccessed();
			}
			else if (door.position == Door.DoorPosition.Right && pC.PlayerNumber == 1) {
				EventManager.singleton._rightDoorAccessed();
			}
		}
	}

}

