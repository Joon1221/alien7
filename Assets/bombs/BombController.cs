using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {
	public GameObject expEffect;
	private Transform transform;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision coll){
		Debug.Log ("BombCotroller::OnCollisionEnter()");
		if (coll.collider.tag == "BULLET"){
			//            Destroy(coll.gameObject);

			ExpBarrel();
		}
	}

	void ExpBarrel(){
		Instantiate(expEffect, transform.position, Quaternion.identity);

		Collider[] colls = Physics.OverlapSphere(transform.position, 10.0f);
		//collects all objects inside the sphere of radius 10.0f

		foreach (Collider coll in colls){
			Rigidbody rbody = coll.GetComponent<Rigidbody>();
			if (rbody != null){
				//                rbody.mass = 1.0f;
				rbody.AddExplosionForce(500.0f, transform.position, 10.0f, 300.0f);
			}
		}

		        Destroy(gameObject, 5.0f);
		Destroy(gameObject, 0.2f);
	}
}
