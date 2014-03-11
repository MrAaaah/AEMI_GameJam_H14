using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
		private bool didNotFlipYet = true;
		MeshRenderer meshRenderer;

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

		void OnMouseDown ()
		{
				switch (position) {
				case DoorPosition.Left:
						Debug.Log ("Click on left door");	
						EventManager.singleton._leftDoorAccessed ();
						break;
				case DoorPosition.Right:
						Debug.Log ("Click on right door");				
						EventManager.singleton._rightDoorAccessed ();
						break;
				default:
						break;
				}
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
				if (didNotFlipYet) {
						if (position == DoorPosition.Left) {
								this.transform.Rotate (0, 180f, 0f);
								this.didNotFlipYet = false;
						}
						this.transform.Translate (0.0f, -0.5f, 0.0f);
				}

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

