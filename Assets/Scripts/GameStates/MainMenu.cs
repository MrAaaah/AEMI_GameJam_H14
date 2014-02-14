using UnityEngine;
using System.Collections;

public class MainMenu : State<GameState>
{

	public override void EnterState ()
	{
		if (GameStateManager.singleton.previousState is StartScreen)
			SceneManager.singleton.LoadMainMenu ();
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
		if (GUI.Button(new Rect(30, 30, 150, 30), "Back : "+GameManager.singleton.namePlayer)) {
			GameStateManager.singleton.SetGameState (GameState.StartScreen);
		}

		if (GUI.Button(new Rect(30, 130, 150, 30), "Pause")) {
			GameStateManager.singleton.SetGameState (GameState.PauseMenu);
		}
	}

	public override void ExitState ()
	{
		Debug.Log ("Exit menustate");
	}
}

