/************************************************** *******
* Author: Justin Williamson
* CubeScript for simple pass through script.
* Create your character two emptygameObjects and tag them ("TopTrigger")("BottomTrigger")
* getComponent these emptygameObjects box colliders
* check the isTrigger box for both box colliders
* TopTrigger Should be the length of the gameObject "player" and the BottomTrigger
* should be small and at the bottom of the gameObject.
* getComponent your ground blocks rigidbodies and uncheck useGravity
* drop this script into your ground blocks and poof, jump through blocks.
* only error, hits his head on second jump first time. Small Glitch.
* ************************************************** ******/

using UnityEngine;
using System.Collections;

public class CubeTriggerScript : MonoBehaviour {
	
	void OnTriggerStay(Collider hit){
		if(hit.gameObject.tag == "TopTrigger"){
			rigidbody2D.collider2D.isTrigger = true;
			rigidbody2D.isKinematic = true;
			Debug.Log("Top hit");
		}
	}
	void OnTriggerExit(Collider hit){
		if(hit.gameObject.tag == "BottomTrigger"){
			rigidbody2D.collider2D.isTrigger = false;
			Debug.Log("Bottom hit");
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
} 