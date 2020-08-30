using UnityEngine;
using System.Collections;

public class cube_move : MonoBehaviour {

	public bool someoneInTheCubeArea;

	// Use this for initialization
	void Start () {
		someoneInTheCubeArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (someoneInTheCubeArea) {
			transform.position = new Vector3(Random.Range(transform.position.x - 0.01f, transform.position.x + 0.01f), transform.position.y, Random.Range(transform.position.z - 0.01f, transform.position.z + 0.01f));
//			transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
		}
//		if (someoneInTheCubeArea) {
//			transform.position = new Vector3 (transform.position.x, transform.position.y + (float)0.1, transform.position.z);
//		} 
	}

	public void moveCube () {
		someoneInTheCubeArea = true;
	}

	public void stopCube() {
		someoneInTheCubeArea = false;
	}

	public void OnMouseDown () {
		this.gameObject.SetActive (false);
//		GetComponent<Renderer>().enabled = false;
	}
}
