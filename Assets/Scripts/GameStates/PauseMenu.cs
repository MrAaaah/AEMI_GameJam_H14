using UnityEngine;
using System.Collections;

public class PauseMenu : State<GameState>
{
	private float savedTimeScale;

	public override void EnterState ()
	{
		Debug.Log ("Enter pause menu");
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
		if (GUI.Button (new Rect (100, 100, 100, 100), "Return")) {
			GameStateManager.singleton.SetGameState (GameState.MainMenu);
		}
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit pause menu");
		Time.timeScale = savedTimeScale;
	}
}
