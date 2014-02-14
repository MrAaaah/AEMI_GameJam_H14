using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameStateManager.singleton.currentState == null)
			GameStateManager.singleton.SetGameState (GameState.MainMenu);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
	}
}
