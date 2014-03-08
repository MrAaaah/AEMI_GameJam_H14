using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public float timerDuration;
	private float timer;

	DoorController doorsController;

	// Use this for initialization
	void Start () {
		doorsController = GetComponent<DoorController> ();
		GameManager.singleton.namePlayer="";
		timer = timerDuration;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTimer ();
	}

	void UpdateTimer () {
		if (timer > 0) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				timer = 0;
				doorsController.OpenDoors ();
			}
		}
	}

	public void OnGUI ()
	{
//		GUI.Label (new Rect (300,500,100,100), timer.ToString ());
//		GUI.Box (new Rect (300,500,100,100), "0");
		GUI.Box(new Rect(400,10,230,30), timer.ToString ("F")+"s vant l'ouverture des portes");
	}
}

