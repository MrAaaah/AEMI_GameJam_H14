using UnityEngine;
using System.Collections;

public class tokenControler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody.AddForce (new Vector3 (Random.Range (-10, 10), Random.Range (50, 200), 0));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(Random.Range(0,20),Random.Range(0,20),0));
	}

	void OnCollisionEnter(Collision other)
	{
		Destroy (this);
	}
}
