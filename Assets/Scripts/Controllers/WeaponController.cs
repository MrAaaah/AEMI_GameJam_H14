using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
		
		public AnimationCurve curve;
		public float range;
		private bool swinging = false;
		private Time startSwing;
		private bool hit;
		private PlayerControl playerControl;
		private GameObject Weapon;
		

		// Use this for initialization
		void Start ()
		{
			playerControl = GetComponent<PlayerControl> ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (swinging) {
						transform.rotation.eulerAngles = new Vector3 (0, 0, curve.Evaluate (Time.time - startSwing));
						
						if(!hit)
			{
				Vector3 fwd = Transform.TransformDirection(playerControl.transform.forward);
				playerControl.transform.rotation * fwd;
			}
						// if custom deltatime is bigger than curve's last key, stop growing
						if (Time.time - startSwing >= curve.keys [curve.keys.Length - 1].time) {
								swinging = false;
						}
				
				}

		}

		public void swing ()
		{
				if (!swinging) {
		
						swinging = true;
			hit = false;
				}
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
