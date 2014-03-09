using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	StartScreen,
	MainMenu,
	PauseMenu,
	Game,
	CraftScreen,
	EndGameScreen,
	EndingCredits,
}

[AddComponentMenu("Singletons/GameStateManager")]
public class GameStateManager : SingletonMonoBehaviour<GameStateManager> {
	
	public GameState state { get; private set; }

	public State<GameState> previousState;
	public State<GameState> currentState;

	private Dictionary<GameState, State<GameState>> states;

	public int test;

	public void Start () {
		CreateStates ();
	}

	public void Update () {
		if (currentState != null)
			currentState.UpdateState ();
	}

	public void OnGUI () {
		if (currentState != null)
			currentState.UpdateStateGUI ();
	}

	private void CreateStates () {
		if (states == null) {
			states = new Dictionary<GameState, State<GameState>> ();
			
			states.Add (GameState.StartScreen, new StartScreen ());
			states.Add (GameState.MainMenu, new MainMenu ());
			states.Add (GameState.PauseMenu, new PauseMenu ());
			states.Add (GameState.Game, new Game ());
			states.Add (GameState.CraftScreen, new CraftScreen ());
			states.Add (GameState.EndGameScreen, new EndGameScreen ());
			states.Add (GameState.EndingCredits, new EndingCredits ());
			Debug.Log ("Create states");
		}
	}

	public void SetGameState (GameState nextGameState) {
		if (currentState != null) {
			previousState = currentState;
			previousState.ExitState ();
			Debug.Log("-- "+currentState.ToString() + " --");
		} else { CreateStates (); }

		currentState = states[nextGameState];
		
		Debug.Log (currentState);
		
		currentState.EnterState ();
	}
	

}
