using UnityEngine;
using System.Collections;

public class cube_motion_detector : MonoBehaviour {

	public GameObject cubeToMove;
	private GameObject hero;

	// Use this for initialization
	void Start () {
		hero = GameObject.Find ("RigidBodyFPSController");
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if ("Player" == other.tag) {
			Debug.Log("someoneInTheCubeArea");
			cube_move cube = (cube_move)cubeToMove.GetComponent (typeof(cube_move));
			cube.moveCube ();
		}
	}

	void OnTriggerExit (Collider other) {
		if ("Player" == other.tag) {
			Debug.Log ("someoneExitTheCubeArea");
			cube_move cube = (cube_move)cubeToMove.GetComponent (typeof(cube_move));
			cube.stopCube ();
		}
	}
}
