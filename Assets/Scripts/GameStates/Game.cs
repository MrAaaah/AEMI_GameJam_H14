using UnityEngine;
using System.Collections;

public class Game : State<GameState>
{
	
	public override void EnterState ()
	{
		Debug.Log ("Enter Game");

		if (GameStateManager.singleton.previousState is MainMenu)
			SceneManager.singleton.LoadGame ();
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
		if (GUI.Button(new Rect(30, 130, 150, 30), "Prees to kill the dwarf")) {
			GameStateManager.singleton.SetGameState (GameState.CraftScreen);
		}
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit Game");
	}
}
