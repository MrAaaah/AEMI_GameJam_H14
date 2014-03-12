using UnityEngine;
using System.Collections;

public class EndingCredits : State<GameState> {
	
	
	public override void EnterState ()
	{
		Debug.Log ("Enter EndingCredit");
		if (GameStateManager.singleton.previousState is Game)
			SceneManager.singleton.LoadEndingCredits ();
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
		if (GUI.Button(new Rect(200, 400, 150, 130), "Restart !")) {
			GameStateManager.singleton.SetGameState (GameState.Game);
		}
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit Ending Credits");
	}
}
