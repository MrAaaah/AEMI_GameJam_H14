using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

	public Material openDoor;
	public Material closedDoor;

	MeshRenderer meshRenderer;

	public enum DoorPosition {
		Left,
		Right,
	}

	public DoorPosition position;

	// Use this for initialization
	void Start ()
	{
		meshRenderer = GetComponent<MeshRenderer>();

		if (meshRenderer != null)
			meshRenderer.material = closedDoor;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnMouseDown () {
		switch (position) {
		case DoorPosition.Left:
			Debug.Log("Click on left door");	
			EventManager.singleton._leftDoorAccessed();
			break;
		case DoorPosition.Right:
			Debug.Log("Click on right door");				
			EventManager.singleton._rightDoorAccessed();
			break;
		default:
			break;
		}
	}

	public void OpenDoor () {
		try {
			meshRenderer.material = openDoor;
		} catch (System.Exception ex) {
			Debug.LogError(ex.ToString());
		}
	}

	public void CloseDoor () {
		try {
			meshRenderer.material = closedDoor;
		} catch (System.Exception ex) {
			Debug.LogError(ex.ToString());
		}
	}
}

