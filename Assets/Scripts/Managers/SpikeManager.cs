using UnityEngine;
using System.Collections;

public class SpikeManager : MonoBehaviour
{

		void OnTriggerEnter2D (Collider2D other)
		{
				Destroy (other.gameObject);
				Debug.Log ("COLLISION");
		}
}
