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

	public BoxCollider2D trigger;



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
            //meshRenderer.material = openDoor;
            GameObject g = transform.FindChild("gate_close").gameObject;
            g.SetActive(false);
            GameObject d = transform.FindChild("gate_open").gameObject;
            d.SetActive(true);
		} catch (System.Exception ex) {
			Debug.LogError(ex.ToString());
		}
	}

	public void CloseDoor () {
        if (position == DoorPosition.Left)
            this.transform.Rotate(0, 180f, 0f);
        this.transform.Translate(0.0f, -0.5f, 0.0f);
		try {
            GameObject g = transform.FindChild("gate_close").gameObject;
            g.SetActive(true);
            GameObject d = transform.FindChild("gate_open").gameObject;
            d.SetActive(false);
			meshRenderer.material = closedDoor;
		} catch (System.Exception ex) {
			Debug.LogError(ex.ToString());
		}
	}
}

