using UnityEngine;
using System.Collections;

public class tokenControler : MonoBehaviour {

	public Metals type;

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (new Vector3 (Random.Range (-10, 10), Random.Range (50, 200), 0));
		Debug.Log (gameObject.GetComponent<MeshFilter>().mesh.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Rotate(new Vector3(Random.Range(0,20),Random.Range(0,20),0));
	}

	public void SetType (Metals t) {
		type = t;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			int idPlayer = other.gameObject.GetComponent<PlayerControl>().PlayerNumber;
			Character[] players = GameObject.FindObjectsOfType<Character>();
			Character player = null;

			if (players[0].mPlayerNb == idPlayer) {
				player = players[0];
			}
			else {
				player = players[1];
			}

			if (type == Metals.argent) {
				player.addAPieceOfSilver();
				Destroy (gameObject);
			} else if (type == Metals.cuivre) {
				player.addAPieceOfCopper();
				Destroy (gameObject);
			} else if  (type == Metals.or) {
				player.addAPieceOfGold();
				Destroy (gameObject);
			} 
					

		}
	}
}
