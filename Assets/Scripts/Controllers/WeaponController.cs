using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
		
		public AnimationCurve curve;
		public float range;
		private bool swinging = false;
		private float startSwing;
		private bool hit;
		private PlayerControl playerControl;
		private Transform Weapon;
		

		// Use this for initialization
		void Start ()
		{
				playerControl = GetComponent<PlayerControl> ();
				Weapon = playerControl.gameObject.transform.FindChild ("Weapon");
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (swinging) {

                    Quaternion angle = Quaternion.Euler(new Vector3(0, 0, ((playerControl.facingRight) ? 1 : -1) * curve.Evaluate(Time.time - startSwing)));
						Weapon.rotation = angle;
						
						if (!hit) {
								Vector3 fwd = Weapon.TransformDirection (Weapon.right);
								int enemy = playerControl.PlayerNumber % 2;
								hit = Physics.Raycast (playerControl.transform.position, fwd, range, 1 << (enemy + LayerMask.NameToLayer ("Player1")));
								Debug.DrawLine (Weapon.position, Weapon.position + range * fwd, hit ? Color.blue : Color.green, 1);

							if(hit)
				{
					Character.get(enemy+1).InflictDmgOnCharacter(Character.get (playerControl.PlayerNumber).getCharacterDamage());
				}
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
						startSwing = Time.time;
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
