using UnityEngine;

public enum GameState {
	StartScreen,
	MainMenu,
}

public delegate void OnStateChangeHandler();

public class GameStateManager {
	protected GameStateManager () {}
	private static GameStateManager instance = null;

	public GameState gameState { get; private set; }
	public event OnStateChangeHandler OnStateChange;

	// Singleton pattern implementation
	public static GameStateManager Instance { 
		get {
			if (GameStateManager.instance == null) {
				GameStateManager.instance = new GameStateManager (); 
			}  
			return GameStateManager.instance;
		} 
	}

	public void SetGameState (GameState gameState) {
		Debug.Log ("Change state to "+gameState);

		this.gameState = gameState;

		if (OnStateChange!=null) {
			OnStateChange();
		}
	}
}