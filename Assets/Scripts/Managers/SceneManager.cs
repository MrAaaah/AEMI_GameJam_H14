using UnityEngine;
using System.Collections;

public enum Level {
	StartScreen,
	MainMenu,
	Test_Martin,
	Game,
}

[AddComponentMenu("Singletons/SceneManager")]
public class SceneManager : SingletonMonoBehaviour<SceneManager> {

	public Level previousLevel;
	public Level currentLevel;

	private void LoadLevel (Level level) {
		Debug.Log ("Load level: "+level.ToString());
		previousLevel = currentLevel;
		currentLevel = level;
		Application.LoadLevel (level.ToString());
	}

	public void LoadStartScreen () {
		LoadLevel (Level.StartScreen);
	}

	public void LoadMainMenu () {
		LoadLevel (Level.MainMenu);
	}

	public void LoadTestMartin () {
		LoadLevel (Level.Test_Martin);
	}

	public void LoadGame () {
		LoadLevel (Level.Game);
	}
}
