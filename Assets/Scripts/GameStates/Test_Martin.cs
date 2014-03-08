using UnityEngine;
using System.Collections;

public class Test_Martin : State<GameState>
{
	
	public override void EnterState ()
	{
		Debug.Log ("Enter Test_Martin");

		if (GameStateManager.singleton.previousState is MainMenu)
			SceneManager.singleton.LoadTestMartin ();
	}
	
	public override void UpdateState ()
	{
	}
	
	public override void UpdateStateGUI ()
	{
	}
	
	public override void ExitState ()
	{
		Debug.Log ("Exit Test_Martin");
	}
}
