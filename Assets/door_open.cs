using UnityEngine;
using System.Collections;

public class door_open : MonoBehaviour {

	public bool automaticDoor;

	public double originalPosY;
	public bool doorOpening;

	public bool someoneInTheDoorArea;

	// Use this for initialization
	void Start () {
		originalPosY = transform.position.y;
		doorOpening = false;
		someoneInTheDoorArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (automaticDoor) {
			if (doorOpening) {
				if (transform.position.y < originalPosY + 3.5) {
					transform.position = new Vector3 (transform.position.x, transform.position.y + (float)0.1, transform.position.z);
				} 
				else {
					doorOpening = false;
				}
			} else if (!someoneInTheDoorArea) {
				if (transform.position.y >= originalPosY + 0.05) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - (float)0.05, transform.position.z);
				} 
			}
		} 
		else {
			if (doorOpening) {
				if (transform.position.y < 3.5) {
					transform.position = new Vector3 (transform.position.x, transform.position.y + (float)0.1, transform.position.z);
				}
			}
			else {
				if (transform.position.y >= originalPosY + 0.05) {
					transform.position = new Vector3 (transform.position.x, transform.position.y - (float)0.05, transform.position.z);
				} 
			}
		}
	}

	void OnMouseDown () {
//		if (Input.GetMouseButtonDown (0)) {
//			doorOpen = !doorOpen;
//		}
	}

	public void openDoor () {
		if (!automaticDoor) {
			return;
		}

		someoneInTheDoorArea = true;
		if (!doorOpening) { 
			doorOpening = true;
		}

	}

	public void closeDoor() {
		if (!automaticDoor) {
			return;
		}

		someoneInTheDoorArea = false;
	}

	public void toggleDoor() {
		if (automaticDoor) {
			return;
		}
		doorOpening = !doorOpening;
	}
}
