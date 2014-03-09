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
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit Ending Credits");
	}
}
