using UnityEngine;
using System.Collections;

public class Metal : MonoBehaviour
{

		public Metals type;
	private Object token;

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
			token = Resources.Load ("token"+type.ToString()) as GameObject;
		
		}
	
		void OnGUI ()
		{

		}

		void OnMouseDown ()
		{
				this.mine ();
		}

		public void mine ()
		{
		Instantiate (token);
		}

	void OnTriggerEnter(Collider other)
	{
		mine ();
	}
		
}
