using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameStateManager GSM;
	public string namePlayer;

	static GameManager _instance;
	
	static public bool isActive { 
		get { 
			return _instance != null; 
		} 
	}
	
	static public GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
				
				if (_instance == null)
				{
					GameObject go = new GameObject("_gamemanager");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<GameManager>();
				}
			}
			return _instance;
		}
	}

	void Awake () {
		GSM = GameStateManager.Instance;
		GSM.OnStateChange += HandleOnStateChange;
		
		Debug.Log ("Current game state when Awakes: " + GSM.gameState);
		
		GSM.SetGameState (GameState.StartScreen);
	}
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log("Current game state when Starts: " + GSM.gameState);
	}
	
	void HandleOnStateChange ()
	{
		Debug.Log("Handling state change to: " + GSM.gameState);
	}

}
