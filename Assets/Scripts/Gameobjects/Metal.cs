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
//		Debug.Log (token);
		}
	
		void OnGUI ()
		{

		}

		void OnMouseDown ()
		{
		Debug.Log("OnMouseDown argnt");
			this.mine ();
		}

		public void mine ()
		{
		Vector3 newpos = new Vector3(transform.position.x, transform.position.y, 0f);
		GameObject newO = Instantiate (token, newpos, transform.rotation) as GameObject;
			

			if (newO.GetComponent<tokenControler>()) {
				newO.GetComponent<tokenControler>().SetType(type);
			}
		}

		void OnTriggerEnter(Collider other)
		{
		Debug.Log("triggerenter argnt");
			mine ();
		}
}
