using System;
using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject[] levels;

	public int currentLevelId;
	GameObject currentLevel;
	GameObject nextLevel; 

	public float transitionDuration = 1.0f;
	private float startTransitionTime;

	private bool inTransitionExit;
	private bool inTransitionEnter;

	private Vector3 currentLevelPosition = new Vector3(0, 0, 0);
	private Vector3 leftLevelPosition = new Vector3(-100, 0, 0);
	private Vector3 rightLevelPosition = new Vector3(100, 0, 0);

	// Use this for initialization
	void Start () {
		inTransitionExit = false;
		inTransitionEnter = false;

		if (levels.Length % 2 == 0) {
			throw new Exception("Le jeu nécessite un nombre de niveau impair");
		}

		int middleLevelId = (levels.Length-1)/2;
		currentLevelId = middleLevelId;
		currentLevel = levels[middleLevelId];
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnEnable () {
		EventManager.leftDoorAccessed += ChangeToLeftLevel;
		EventManager.rightDoorAccessed += ChangeToRightLevel;
	}

	void OnDisable () {
		EventManager.leftDoorAccessed -= ChangeToLeftLevel;
		EventManager.rightDoorAccessed -= ChangeToRightLevel;
	}

	public void OnGUI ()
	{
		if (GUI.Button (new Rect (400, 100, 100, 100), "Go to left Level")) {
			ChangeToLeftLevel();
		}
		if (GUI.Button (new Rect (500, 100, 100, 100), "Go to right Level")) {
			ChangeToRightLevel();
		}
	}

	void ChangeToLeftLevel () {
		if (currentLevelId > 0 && !(inTransitionEnter || inTransitionExit)) {
			nextLevel = levels[currentLevelId-1];
			StartCoroutine (TransitionToLeftLevel ());
		} else {
			Debug.Log ("We have a winner !");
		}

	}

	void ChangeToRightLevel () {
		if (currentLevelId < levels.Length - 1  && !(inTransitionEnter || inTransitionExit)) {
			nextLevel = levels[currentLevelId+1];
			StartCoroutine (TransitionToRightLevel ());
		} else {
			Debug.Log ("We have a winner !");
		}
		
	}

	IEnumerator TransitionToLeftLevel () {
		startTransitionTime = Time.time;
		inTransitionExit = true;
		inTransitionEnter = true;

		while (inTransitionExit || inTransitionEnter) {
			ExitToRight(currentLevel);
			EnterFromLeft(nextLevel);
			yield return new WaitForSeconds(1/60.0f);
		}

		currentLevel = nextLevel;
		currentLevelId--;
	}

	IEnumerator TransitionToRightLevel () {
		startTransitionTime = Time.time;
		inTransitionExit = true;
		inTransitionEnter = true;
		
		while (inTransitionExit || inTransitionEnter) {
			ExitToLeft(currentLevel);
			EnterFromRight(nextLevel);
			yield return new WaitForSeconds(1/60.0f);
		}
		
		currentLevel = nextLevel;
		currentLevelId++;
	}

//	void QuitLevel (GameObject level) {
////			currentLevel.SetActive(false);
//		Vector3 pos = level.transform.position;
//		pos.x -= 100;
//		level.transform.position = pos;
//	}
//
//	void LoadLevel (GameObject level) {
//		level.transform.position = new Vector3(100, 0, 0);
//		level.transform.position = new Vector3(0, 0, 0);
//	}

	void ExitToLeft (GameObject level) {
		level.transform.position = Vector3.Lerp(currentLevelPosition, leftLevelPosition, (Time.time - startTransitionTime) / transitionDuration);
		if (level.transform.position == leftLevelPosition)
			inTransitionExit = false;
	}

	void ExitToRight (GameObject level) {
		level.transform.position = Vector3.Lerp(currentLevelPosition, rightLevelPosition, (Time.time - startTransitionTime) / transitionDuration);
		if (level.transform.position == rightLevelPosition)
			inTransitionExit = false;
	}

	void EnterFromLeft (GameObject level) {
		level.transform.position = Vector3.Lerp(leftLevelPosition, currentLevelPosition, (Time.time - startTransitionTime) / transitionDuration);
		if (level.transform.position == currentLevelPosition)
			inTransitionEnter = false;
	}

	void EnterFromRight (GameObject level) {
		level.transform.position = Vector3.Lerp(rightLevelPosition, currentLevelPosition, (Time.time - startTransitionTime) / transitionDuration);
		if (level.transform.position == currentLevelPosition)
			inTransitionEnter = false;
	}
}
