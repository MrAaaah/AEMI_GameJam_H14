using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	private GameManager GM;
	GameStateManager GSM;
	

	void Awake () {
		GM = GameManager.Instance;
		GSM = GameStateManager.Instance;
		GSM.OnStateChange += HandleOnStateChange;
	}

	void OnGUI() {
		if (GUI.Button(new Rect(30, 30, 150, 30), "Back : "+GM.namePlayer)) {
			GoToStartScreen();
		}
	}
	
	private void GoToStartScreen() {
		Debug.Log("Go back");
		GSM.SetGameState ( GameState.StartScreen);
	}

	void HandleOnStateChange ()
	{
		Debug.Log("Handling state change to: " + GSM.gameState);
		
		if (GSM.gameState == GameState.StartScreen) {
			Application.LoadLevel("StartScreen");
		}
	}
}

