using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public float timerDuration;
	private float timer;

	DoorController doorsController;
	LevelController levelController;

	// Use this for initialization
	void Start () {
		doorsController = GetComponent<DoorController> ();
		levelController = GetComponent<LevelController> ();
		GameManager.singleton.namePlayer="";

		StartLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimer ();
	}

	void OnEnable () {
		EventManager.leftDoorAccessed += HandleLeftDoorAccessed;
		EventManager.rightDoorAccessed += HandleRightDoorAccessed;
	}
	
	void OnDisable () {
		EventManager.leftDoorAccessed -= HandleLeftDoorAccessed;
		EventManager.rightDoorAccessed -= HandleRightDoorAccessed;
	}

	void HandleLeftDoorAccessed () {
		if (timer == 0) {
			if (levelController.AtLeftestLevel()) {
				Debug.Log("Player 2 win");
			}
			else {
				levelController.ChangeToLeftLevel ();
				StartCoroutine(WaitForAnimationEnd());
				doorsController.CloseDoors();
			}
		}
	}

	void HandleRightDoorAccessed () {
		if (timer == 0) {
			if (levelController.AtRightestLevel()) {
				Debug.Log("Player 1 win");
			}
			else {

				levelController.ChangeToRightLevel ();
				StartCoroutine(WaitForAnimationEnd());
				doorsController.CloseDoors();
			}
		}
	}

	IEnumerator WaitForAnimationEnd () {
		while (levelController.inTransition) {
			yield return new WaitForSeconds(0.1f);
		}

		StartLevel ();
	}

	void StartLevel () {
		timer = timerDuration;
		doorsController.InitDoors();
	}

	void UpdateTimer () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				timer = 0;
				doorsController.OpenDoors ();
			}
		}
	}

	public void OnGUI ()
	{
//		GUI.Label (new Rect (300,500,100,100), timer.ToString ());
//		GUI.Box (new Rect (300,500,100,100), "0");
		GUI.Box(new Rect(400,10,230,30), timer.ToString ("F")+"s vant l'ouverture des portes");
	}
}

