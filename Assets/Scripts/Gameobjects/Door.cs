using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

	public Material openDoor;
	public Material closedDoor;

	MeshRenderer meshRenderer;

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

