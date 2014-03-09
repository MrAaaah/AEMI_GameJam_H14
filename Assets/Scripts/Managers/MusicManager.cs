using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Music {
	MainMenuMusicBackGround,
	GameMusicBackground,
}

[AddComponentMenu("Singletons/MusicManager")]
public class MusicManager : SingletonMonoBehaviour<MusicManager> {

	private AudioSource audioSource;

	private Dictionary<Music, AudioClip> sounds;
	
	private bool initialized = false;

	void Awake () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.rolloffMode = AudioRolloffMode.Linear;

		sounds = new Dictionary<Music, AudioClip> ();
	}

	// Use this for initialization
	void Start () {
		if (!initialized)
			LoadSounds ();
	}

	private void LoadSounds () {
		sounds.Add(Music.GameMusicBackground, Resources.Load("Sounds/SFX017") as AudioClip);
		sounds.Add(Music.MainMenuMusicBackGround, Resources.Load("Sounds/SFX018") as AudioClip);
		initialized = true;	
	}
	
	public void PlaySound (Music music) {
		if (!initialized) 
			LoadSounds ();

		if (music == Music.GameMusicBackground) {
			audioSource.loop = true;
			audioSource.volume = 0.2f;
			audioSource.PlayOneShot (sounds[music]);
		}
		else if (music == Music.MainMenuMusicBackGround) {
			audioSource.loop = true;
			audioSource.volume = 0.5f;
			audioSource.PlayOneShot (sounds[music]);
		}
	}
}
