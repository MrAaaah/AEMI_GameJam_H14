using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SoundFX {
	OpenDoors,
	DoorsActivated,

	Hit,

	WeaponSwing,
//	WeaponKnifes,
//	WeaponKunais,
	Spit,
//	Lazor,
//	DoomDevice,

	Die, 
	GetResource,

	HitResource,

	FinPeriodeNonLethale,

	HoverGUI,
	SelectElementGUI,

	TimerBeforeReturnGame,
//	AlarmingTimerBeforeReturnGame,
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
		sounds.Add(SoundFX.Hit, Resources.Load("Sounds/SFX005") as AudioClip);
		sounds.Add(SoundFX.WeaponSwing, Resources.Load("Sounds/SFX004") as AudioClip);
		sounds.Add(SoundFX.Spit, Resources.Load("Sounds/SFX008") as AudioClip);
		
		sounds.Add(SoundFX.Die, Resources.Load("Sounds/SFX011") as AudioClip);
		sounds.Add(SoundFX.GetResource, Resources.Load("Sounds/SFX012") as AudioClip);
		
		sounds.Add(SoundFX.HitResource, Resources.Load("Sounds/SFX013") as AudioClip);
		sounds.Add(SoundFX.FinPeriodeNonLethale, Resources.Load("Sounds/SFX016") as AudioClip);
		sounds.Add(SoundFX.HoverGUI, Resources.Load("Sounds/SFX019") as AudioClip);
		sounds.Add(SoundFX.SelectElementGUI, Resources.Load("Sounds/SFX020") as AudioClip);
		sounds.Add(SoundFX.TimerBeforeReturnGame, Resources.Load("Sounds/SFX021") as AudioClip);

		initialized = true;	
	}
	
	public void PlaySound (SoundFX sound) {
		if (!initialized) 
			LoadSounds ();

		audioSource.volume = 1.0f;

		if (sound == SoundFX.OpenDoors) {
			audioSource.volume = 0.35f;
		}
		if (sound == SoundFX.SelectElementGUI) {
			audioSource.volume = 0.65f;
		}
		if (sound == SoundFX.Die) {
			audioSource.volume = 0.35f;
		}
		audioSource.PlayOneShot (sounds[sound]);

	}
}
