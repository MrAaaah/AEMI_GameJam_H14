using UnityEngine;
using System.Collections;

public class StartScreen : State<GameState>
{
	
		public override void EnterState ()
		{
				Debug.Log ("Enter startstate");

				if (GameStateManager.singleton.previousState is MainMenu)
						SceneManager.singleton.LoadStartScreen ();

		MusicManager.singleton.PlaySound(Music.MainMenuMusicBackGround);
		
		}
	
		public override void UpdateState ()
		{
		}
	
		public override void UpdateStateGUI ()
		{
		}

		public override void ExitState ()
		{
				Debug.Log ("Exit startstate");
		}
}
