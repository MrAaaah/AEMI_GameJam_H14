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

		void OnTriggerEnter2D (Collider2D other)
		{
//		if (door.position == Door.DoorPosition.Left && other.) {
				PlayerControl pC = other.gameObject.GetComponent<PlayerControl> ();
				if (pC != null) {
						// Left Door and Player 2
						if (door.position == Door.DoorPosition.Left && pC.PlayerNumber == 2) {
								GetComponent<BoxCollider2D> ().enabled = false;
								EventManager.singleton._leftDoorAccessed ();
								SoundFXManager.singleton.PlaySound (SoundFX.DoorsActivated);
						// Right Door and Player 1
						} else if (door.position == Door.DoorPosition.Right && pC.PlayerNumber == 1) {
								GetComponent<BoxCollider2D> ().enabled = false;
								EventManager.singleton._rightDoorAccessed ();
								SoundFXManager.singleton.PlaySound (SoundFX.DoorsActivated);
						}
				} else {
						Debug.LogError ("wtf, shouldn't happen");
				}
		}

}

