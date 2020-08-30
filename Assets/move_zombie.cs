using UnityEngine;
using System.Collections;

public class move_zombie : MonoBehaviour {

	Random random;
	bool bounce;
	int rotation;
	double xSpeed;
	double zSpeed;

	// Use this for initialization
	void Start () {
		random = new Random();
		bounce = false;
		rotation = 0;
		xSpeed = 0;
		zSpeed = 0;
	}

	// Update is called once per frame
//	void Update () {
//		if (bounce) {
//			bounce = false;
//			rotation = Random.Range (0, 90);
//			transform.rotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z); 
//		}
//		xSpeed = Mathf.Cos (rotation) * 1.0;
//
//		zSpeed = Mathf.Sin (rotation) * 1.0;
//
//		if (Input.GetMouseButtonDown (0)) {
//			
//			transform.position = new Vector3 ((int)(transform.position.x + xSpeed), transform.position.y * transform.rotation.y, (int)(transform.position.z + zSpeed));
//		}
//		Debug.Log ("Rotation" + rotation + "xSpeed" + xSpeed);
//	}

	void OnCollisionEnter (Collision col)
	{
		bounce = true;
		//			Destroy(col.gameObject);
	}
}
