using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				if (GameStateManager.singleton.currentState == null)
						GameStateManager.singleton.SetGameState (GameState.StartScreen);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
				if (GUI.Button (new Rect (30, 30, 150, 30), "Press !")) {	
						GameStateManager.singleton.SetGameState (GameState.MainMenu);
				}
		}
}