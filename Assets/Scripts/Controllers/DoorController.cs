using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	LevelController levelController;

	public Door[] doors;

	public bool areOpens;

	// Use this for initialization
	void Start () {
		levelController = GetComponent<LevelController> ();		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void InitDoors () {
		StartCoroutine(InitDoorsWhenItCan());
	}

	IEnumerator InitDoorsWhenItCan () {
		do {
			if (levelController == null) {
				levelController = GetComponent<LevelController> ();		
			}
			yield return new WaitForSeconds(0.1f);
		} while (levelController == null);

		GameObject currentLevel = levelController.currentLevel;
//		Debug.Log (currentLevel);
		doors[0] = currentLevel.transform.Find("Doors/LeftDoor").gameObject.GetComponent<Door> ();
		doors[1] = currentLevel.transform.Find("Doors/RightDoor").gameObject.GetComponent<Door> ();
		
		CloseDoors();
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
