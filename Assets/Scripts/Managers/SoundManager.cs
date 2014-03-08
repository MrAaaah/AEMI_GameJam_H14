using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Sound {
	GameMusicBackground,
}

[AddComponentMenu("Singletons/SoundManager")]
public class SoundManager : SingletonMonoBehaviour<SoundManager> {

	private AudioSource audioSource;

	private Dictionary<Sound, AudioClip> sounds;
	
	private bool initialized = false;

	void Awake () {
		audioSource = GetComponent<AudioSource> ();
		sounds = new Dictionary<Sound, AudioClip> ();
	}

	// Use this for initialization
	void Start () {
		if (!initialized)
			LoadSounds ();
	}

	private void LoadSounds () {
		sounds.Add(Sound.GameMusicBackground, Resources.Load("Sounds/SFX017") as AudioClip);
		initialized = true;	
	}
	
	public void PlaySound (Sound sound) {
		if (!initialized) 
			LoadSounds ();

		if (sound == Sound.GameMusicBackground) {
			audioSource.loop = true;
			audioSource.volume = 0.2f;
			audioSource.PlayOneShot (sounds[sound]);
					
		}
	}
}
