using UnityEngine;
using System.Collections;

public class move_sphere : MonoBehaviour {

	bool bounce;
	float dirX;
	float dirZ;

	// Use this for initialization
	void Start () {
		bounce = false;
		dirX = 0.1f;
		dirZ = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (bounce) {
			bounce = false;
			dirX *= -1.0f;
			dirZ *= -1.0f;
		}
		transform.position = new Vector3 (transform.position.x + dirX, transform.position.y, transform.position.z + dirZ);
	}

	void OnCollisionEnter (Collision col)
	{
		if (!col.gameObject.name.Contains("floor") && col.gameObject.name != "Sphere") {
			bounce = true;
//			Destroy(col.gameObject);
		}
	}
}
