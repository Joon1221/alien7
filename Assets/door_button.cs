using UnityEngine;
using System.Collections;

public class door_button : MonoBehaviour {

	public GameObject doorToOpen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		door_open other = (door_open)doorToOpen.GetComponent (typeof(door_open));
		other.toggleDoor ();
	}
}
