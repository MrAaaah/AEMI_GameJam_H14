using UnityEngine;
using System.Collections;

public class MetalOnLevel : MonoBehaviour
{

		public Metal type;
		public int quantity = 0;

		// Use this for initialization
		void Start ()
		{
				quantity = Random.Range (5, 25);
				type = Helpers.GetRandomEnum<Metal> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		void OnGUI ()
		{

		}

		void die ()
		{
				// @todo: trigger some kind of animation to let the mining stuff disapear
				throw new System.NotImplementedException ();
		}

		public int mine ()
		{
				int mined = Random.Range (1, 2);
				if (quantity > 1) {
						quantity -= mined;
				} else if (quantity == 1) {
						quantity -= 1;
						mined = 1;
				} else {
						mined = 0;
				}
				if (quantity == 0)
						this.die ();
				return mined;
		}
}
