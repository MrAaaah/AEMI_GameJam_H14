using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SoundFX {
	OpenDoors,
	DoorsActivated,
}

[AddComponentMenu("Singletons/SoundFXManager")]
public class SoundFXManager : SingletonMonoBehaviour<SoundFXManager> {
	
	private AudioSource audioSource;
	
	private Dictionary<SoundFX, AudioClip> sounds;
	
	private bool initialized = false;
	
	void Awake () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.rolloffMode = AudioRolloffMode.Linear;

		sounds = new Dictionary<SoundFX, AudioClip> ();
	}
	
	// Use this for initialization
	void Start () {
		if (!initialized)
			LoadSounds ();
	}
	
	private void LoadSounds () {
		sounds.Add(SoundFX.OpenDoors, Resources.Load("Sounds/SFX015") as AudioClip);
		sounds.Add(SoundFX.DoorsActivated, Resources.Load("Sounds/SFX014") as AudioClip);
		initialized = true;	
	}
	
	public void PlaySound (SoundFX sound) {
		if (!initialized) 
			LoadSounds ();
		audioSource.PlayOneShot (sounds[sound]);
	}
}
