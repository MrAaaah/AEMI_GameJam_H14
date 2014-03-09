using UnityEngine;
using System.Collections;

public class SpikeManager : MonoBehaviour
{

		void OnTriggerEnter2D (Collider2D other)
		{
			Debug.Log(other.transform.gameObject.name);	
			int nb;
			if (other.transform.gameObject.GetComponent<PlayerControl> () != null) {
						nb = other.transform.gameObject.GetComponent<PlayerControl> ().PlayerNumber;
						Character[] characters = FindObjectsOfType<Character> ();
						foreach (Character c in characters) {
								if (c.getPlayerNb () == nb) {
										c.InflictDmgOnCharacter (99999);
										break;
								}
						}
						Debug.Log ("COLLISION SUCESS");
				} else {
					Debug.Log ("COLLISION FAILED");		
				}
				/*string layer = LayerMask.LayerToName (other.gameObject.layer);
				if (layer.StartsWith ("Player")) {
				PlayerControl pc = other.GetComponent<PlayerControl>();

						int nb = layer [layer.Length - 1] - 48;
						if(pc != null)
							nb = pc.PlayerNumber;*/
						//Debug.Log ("Bob va `a la ferme avec le Numéro... "+ nb);
						
				//}
				
		}
}
