using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

	private bool swigging = false;
	private Time startSwing;
	private bool hitted;
	private Animator anim;

		// Use this for initialization
		void Start ()
		{
		anim = transform.parent.transform.parent.GetComponent<Animator>();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		if (Input.GetButtonDown ("Fire1")) {
			//anim.SetTrigger("Swing");
		}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
			if (swigging) {
				string ownLayer = LayerMask.LayerToName(gameObject.layer);
				string otherLayer = LayerMask.LayerToName(other.gameObject.layer);

				Debug.Log(ownLayer + " hit " + otherLayer);
			}
		}
}
