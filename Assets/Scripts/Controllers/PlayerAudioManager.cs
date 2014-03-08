using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour {

	public AudioClip marche;
	public AudioClip saut;
	public AudioClip atterissage;
	public AudioClip recoitCoup;
	public AudioClip armePrincipale;
	public AudioClip armeCouteaux;
	public AudioClip armeKounais;
	public AudioClip armeSphereDeBave;
	public AudioClip mothaFuckinLaZor;
	public AudioClip doomDevice;
	public AudioClip mort;
	public AudioClip recupereRessource;

	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound (AudioClip clip) {
		audioSource.clip = clip;
		Debug.Log("Play "+clip);
//		audioSource.audio = clip;
		audioSource.Play();
	}
}
