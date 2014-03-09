using UnityEngine;
using System.Collections;

public class Game : State<GameState>
{
	
	public override void EnterState ()
	{
		Debug.Log ("Enter Game");

		if (GameStateManager.singleton.previousState is StartScreen ||
		    GameStateManager.singleton.previousState is EndGameScreen)
			SceneManager.singleton.LoadGame ();
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit Game");
	}
}
