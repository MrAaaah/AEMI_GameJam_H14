using UnityEngine;
using System.Collections;

public class EndGameScreen : State<GameState> {

	private float savedTimeScale;
	
	public override void EnterState ()
	{
		Debug.Log ("Enter EndGameScreen");
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}

	public override void UpdateState ()
	{
	}

	public override void UpdateStateGUI ()
	{
		if (GUI.Button (new Rect (200, 200, 300, 300), "Start a new game")) {
			GameStateManager.singleton.SetGameState (GameState.Game);
		}

		if (GUI.Button (new Rect (600, 200, 300, 300), "Nope")) {
			GameStateManager.singleton.SetGameState (GameState.EndingCredits);
		}
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit EndGameScreen");
		Time.timeScale = savedTimeScale;	
	}
}
