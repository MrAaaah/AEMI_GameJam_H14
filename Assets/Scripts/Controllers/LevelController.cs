using System;
using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject[] levels;
	public GameObject[] tileset;
	private mapManager[] levels_map = new mapManager[5];

	public int currentLevelId;
	public GameObject currentLevel;
	public GameObject nextLevel; 

	public float transitionDuration = 1.0f;
	private float startTransitionTime;

	public bool inTransition {
		get {
			return (inTransitionExit || inTransitionEnter);
		}
	}

	private bool inTransitionExit;
	private bool inTransitionEnter;

	private Vector3 currentLevelPosition = new Vector3(0, 0, 0);
	private Vector3 leftLevelPosition = new Vector3(-48, 0, 0);
	private Vector3 rightLevelPosition = new Vector3(48, 0, 0);

	// Use this for initialization
	void Start () {
		inTransitionExit = false;
		inTransitionEnter = false;

		if (levels.Length % 2 == 0) {
			throw new Exception("Le jeu nécessite un nombre de niveau impair");
		}

		int middleLevelId = (levels.Length-1)/2;
		currentLevelId = middleLevelId;


		for (int i = 0; i < levels.Length; i++) {

			levels_map[i] = new mapManager(Application.streamingAssetsPath + "/Maps/Lvl2/Lvl2_0" + i + ".json",tileset);
			levels[i]=levels_map[i].getLevelObject();

			if (i != currentLevelId) {
				levels[i].SetActive(false);		
			} 
			else {
				levels[i].SetActive(true);
				levels[i].transform.position = Vector3.zero;
			}
		}

		currentLevel = levels[middleLevelId];
		levels_map [currentLevelId].spawnPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool AtLeftestLevel () {
		return currentLevelId == 0;
	}

	public bool AtRightestLevel () {
		return currentLevelId == levels.Length-1;
	}

	public mapManager currentMap{ get { return levels_map [currentLevelId]; } }


//	public void OnGUI ()
//	{
//		if (GUI.Button (new Rect (400, 100, 100, 100), "Go to left Level")) {
//			ChangeToLeftLevel();
//		}
//		if (GUI.Button (new Rect (500, 100, 100, 100), "Go to right Level")) {
//			ChangeToRightLevel();
//		}
//	}

	public void ChangeToLeftLevel () {
		if (currentLevelId > 0 && !(inTransitionEnter || inTransitionExit)) {
			nextLevel = levels[currentLevelId-1];
			StartCoroutine (TransitionToLeftLevel ());
		} else {
			Debug.Log ("We have a winner !");
		}

	}

	public void ChangeToRightLevel () {
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

		levels[currentLevelId-1].SetActive(true);
		
		while (inTransitionExit || inTransitionEnter) {
			ExitToRight(currentLevel);
			EnterFromLeft(nextLevel);
			yield return new WaitForSeconds(1/60.0f);
		}

		levels[currentLevelId].SetActive(false);

		currentLevel = nextLevel;
		levels_map [currentLevelId].destroyPlayer ();
		currentLevelId--;
		levels_map [currentLevelId].spawnPlayer ();
	}

	IEnumerator TransitionToRightLevel () {
		startTransitionTime = Time.time;
		inTransitionExit = true;
		inTransitionEnter = true;

		levels[currentLevelId+1].SetActive(true);
		
		while (inTransitionExit || inTransitionEnter) {
			ExitToLeft(currentLevel);
			EnterFromRight(nextLevel);
			yield return new WaitForSeconds(1/60.0f);
		}

		levels[currentLevelId].SetActive(false);
		
		currentLevel = nextLevel;
		levels_map [currentLevelId].destroyPlayer ();
		currentLevelId++;
		levels_map [currentLevelId].spawnPlayer ();
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
