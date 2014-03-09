using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour
{
	public Texture2D background;
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
		// @todo: show after animation
		int textureWidth = 256;
		int textureHeight = 128;
		int top = 30;
		if (GUI.Button(new Rect(Screen.width / 2 - (textureWidth / 2), top, textureWidth, textureHeight), background, GUIStyle.none))
		{
			GameStateManager.singleton.SetGameState (GameState.Game);
		}
	}
}