using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

		LevelController levelController;
		public Door[] doors;
		public bool areOpens;
		bool correctedDoorPositions = false;

		// Use this for initialization
		void Start ()
		{
				levelController = GetComponent<LevelController> ();		
		}
	
		// Update is called once per frame
		void Update ()
		{
		}

		public void InitDoors ()
		{
				StartCoroutine (InitDoorsWhenItCan ());
		}

		IEnumerator InitDoorsWhenItCan ()
		{
				do {
						if (levelController == null) {
								levelController = GetComponent<LevelController> ();		
						}
						yield return new WaitForSeconds (0.1f);
				} while (levelController == null);

				GameObject currentLevel = levelController.currentLevel;

				doors = currentLevel.transform.Find ("Doors").GetComponentsInChildren<Door> ();
				int correction = 1;
				if (doors [0].transform.position.x < doors [1].transform.position.x) {
						correction = 0;
				}

				if (!doors [0].positionnedCorrectly) {
						doors [0].transform.Translate (0.0f, -0.5f, 0.0f);
						doors [0].positionnedCorrectly = true;
				}

				if (!doors [1].positionnedCorrectly) {

						doors [1].transform.Rotate (0, 180.0f, 0f); // fix door rotation :)
						doors [1].transform.Translate (0.0f, -0.5f, 0.0f);
						doors [1].positionnedCorrectly = true;
				}
				doors [correction].position = Door.DoorPosition.Left;
				doors [correction].trigger = doors [correction].GetComponentsInChildren<BoxCollider2D> () [2];
				doors [(correction + 1) % 2].position = Door.DoorPosition.Right;
				doors [(correction + 1) % 2].trigger = doors [correction].GetComponentsInChildren<BoxCollider2D> () [0];
		
		
				CloseDoors ();
		}

		public void OpenDoors ()
		{
				foreach (Door door in doors) {
						door.OpenDoor ();	
				}
		}
	
		public void CloseDoors ()
		{
				foreach (Door door in doors) {
						door.CloseDoor ();	
				}
		}
}
