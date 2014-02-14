using UnityEngine;
using System.Collections;

public class CubeRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(10,10,5) * Time.deltaTime);
	}
}
