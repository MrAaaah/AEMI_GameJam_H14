using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

		private bool swinging = false;
		private Time startSwing;
		private bool hitted;
		private Animator anim;
		private CircleCollider2D collider;

		// Use this for initialization
		void Start ()
		{
				collider = GetComponent<CircleCollider2D> ();
			
	
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		public void changeSideWeapon (bool right)
		{
				//collider.center = new Vector2 (right ? 0.21f : -0.21f, 0);
		}

		public bool swing ()
		{
				if (!swinging) {
		
						swinging = true;
						return true;
				}
				return false;
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				Debug.Log ("Hit Somehting");
			
				string ownLayer = LayerMask.LayerToName (gameObject.layer);
				string otherLayer = LayerMask.LayerToName (other.gameObject.layer);
				if (otherLayer.StartsWith ("Player")) {
						Character[] characters = FindObjectsOfType<Character> ();
						
						
						int ownnb = ownLayer [ownLayer.Length - 1] - 48;
						int nb = otherLayer [otherLayer.Length - 1] - 48;
						Character.get (nb).InflictDmgOnCharacter (Character.get (ownnb).getCharacterDamage ());
				}

				Debug.Log (ownLayer + " hit " + otherLayer);
				
		}
}
