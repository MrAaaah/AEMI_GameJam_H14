using UnityEngine;
using System.Collections;

public class CraftScreen : State<GameState>
{
	private float savedTimeScale;

	public override void EnterState ()
	{
		Debug.Log ("Enter CraftScreen");
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
		if (GUI.Button (new Rect (100, 100, 100, 100), "Go back to game")) {
			GameStateManager.singleton.SetGameState (GameState.Game);
		}
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit CraftScreen");
		Time.timeScale = savedTimeScale;
		
	}
}
