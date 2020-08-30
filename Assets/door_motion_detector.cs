using UnityEngine;
using System.Collections;

public class door_motion_detector : MonoBehaviour {

	public GameObject doorToOpen;

	public bool opened;
	public bool doorControllerLock;

	// Use this for initialization
	void Start () {
		opened = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other)
	{
		door_open door = (door_open)doorToOpen.GetComponent (typeof(door_open));
		Debug.Log ("Door Opening");
		door.openDoor ();
	}

	void OnTriggerExit (Collider other)
	{
		door_open door = (door_open)doorToOpen.GetComponent (typeof(door_open));
		Debug.Log ("Door Closing");
		door.closeDoor ();
	}
}
