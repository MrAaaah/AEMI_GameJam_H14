using UnityEngine;
using System.Collections;

public enum Level {
	StartScreen,
	MainMenu,
	Test_Martin,
	Game,
	Game_without_level,
	EndingCredits,
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

	public void LoadGame () {
		LoadLevel (Level.Game_without_level);
	}

	public void LoadEndingCredits () {
		LoadLevel (Level.EndingCredits);
	}
}
