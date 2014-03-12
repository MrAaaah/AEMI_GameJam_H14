using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
		MeshRenderer meshRenderer;
		public bool positionnedCorrectly = false;

		public enum DoorPosition
		{
				Left,
				Right,
		}

		public DoorPosition position;
		public BoxCollider2D trigger;



		// Use this for initialization
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{

		}

		public void OpenDoor ()
		{
				try {
						GameObject g = transform.FindChild ("gate_close").gameObject;
						g.SetActive (false);
						GameObject d = transform.FindChild ("gate_open").gameObject;
						d.SetActive (true);
				} catch (System.Exception ex) {
						Debug.LogError (ex.ToString ());
				}
		}

		public void CloseDoor ()
		{

				try {
						GameObject g = transform.FindChild ("gate_close").gameObject;
						g.SetActive (true);
						GameObject d = transform.FindChild ("gate_open").gameObject;
						d.SetActive (false);
				} catch (System.Exception ex) {
						Debug.LogError (ex.ToString ());
				}
		}
}

