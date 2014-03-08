using UnityEngine;
using System.Collections;

public class GrowingHatCommands : MonoBehaviour
{	
		
		public AnimationCurve curve;
		public bool growing;
		private float baseY = 0;
		private float initialY;

		float currentTime {
				get;
				set;
		}
	
		void Start ()
		{
				initialY = transform.localScale.y;
		}

		void Update ()
		{
				if (growing) {
						transform.localScale = new Vector3 (transform.localScale.x, curve.Evaluate (Time.time - currentTime) + baseY - initialY, transform.localScale.z);
						if (Time.time - currentTime >= curve.length) {
								growing = false;
						}
			
				}
		}

		void OnMouseDown ()
		{
				grow ();
		}

		void grow ()
		{
				if (!growing) {
						baseY = transform.localScale.y;
						currentTime = Time.time;
						growing = true;
				}
		}
}
