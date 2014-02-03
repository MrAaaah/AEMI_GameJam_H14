using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {
	GameManager GM;
	GameStateManager GSM;

	void Awake () {
		GM = GameManager.Instance;
		GSM = GameStateManager.Instance;
		GSM.OnStateChange += HandleOnStateChange;
	}

	void OnGUI() {
		if (GUI.Button(new Rect(30, 30, 150, 30), "Press !")) {
			GoToMainMenu();
		}
	}

	private void GoToMainMenu() {
		Debug.Log("Go to main menu");
		GSM.SetGameState(GameState.MainMenu);
	}

	void HandleOnStateChange ()
	{
		Debug.Log("Handling state change to: " + GSM.gameState);

		if (GSM.gameState == GameState.MainMenu) {
			Application.LoadLevel("MainMenu");
		}
	}
}
