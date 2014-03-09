using UnityEngine;
using System.Collections;

public class SpikeManager : MonoBehaviour
{

		void OnTriggerEnter2D (Collider2D other)
		{
				string layer = LayerMask.LayerToName (other.gameObject.layer);
				if (layer.StartsWith ("Player")) {
						Character[] characters = FindObjectsOfType<Character> ();

						int nb = layer [layer.Length - 1] - 48;
						foreach (Character c in characters) {
								if (c.getPlayerNb () == nb) {
										c.InflictDmgOnCharacter (99999);
										break;
								}
						}
				}
				Debug.Log ("COLLISION");
		}
}
