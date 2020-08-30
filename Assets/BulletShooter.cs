using UnityEngine;
using System.Collections;

public class BulletShooter : MonoBehaviour {
	public int damage = 100;
	public float force = 1000.0f;

	Vector3 originalBulletPosition;
	Quaternion originalBulletRotation;

	public GameObject sparkEffect;
//	public GameObject gunPoint;
	public Vector3 hitPoint;

	public GameObject bloodEffect;
	public GameObject bloodDecal;

	// Use this for initialization
	void Start () {
		originalBulletPosition = transform.position;
		originalBulletRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void shoot(Ray ray, GameObject gunPoint) {
		// reset the bullet
		GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
		transform.position = gunPoint.transform.position;
		transform.rotation = gunPoint.transform.rotation;

		RaycastHit hitInfo = new RaycastHit();
		bool hit = Physics.Raycast(ray, out hitInfo);

		// transform.position: bullet's position
		// hitInfo.point: mouse pointer clicked
		hitPoint = hitInfo.point;
		Vector3 direction = (hitPoint - transform.position).normalized;

		// rotate the bullet head toward the mouse pointer clicked
		transform.rotation = Quaternion.LookRotation(direction);

		// for free aim
		GetComponent<Rigidbody> ().AddForce (direction * force);
//		GetComponent<Rigidbody> ().AddForce (direction * force * 0.01f); // slower for testing
//		GetComponent<Rigidbody> ().AddForce (direction * force * 10);

		// for FPS(center aim)
//		GetComponent<Rigidbody>().AddForce(transform.forward * force);

		StartCoroutine (bulletTimer());
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == "TARGET")
		{
			GameObject spark = (GameObject) Instantiate(sparkEffect
//				, transform.position
				, hitPoint
				, Quaternion.identity);
			Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);

			//			Destroy(coll.gameObject);
			gameObject.SetActive(false);
		}
		if (coll.collider.tag == "Zombie")
		{
//			coll.collider.GetComponent<Animator>().SetTrigger ("isHit");

			GameObject blood1 = (GameObject)Instantiate (bloodEffect, hitPoint, Quaternion.identity);
			Destroy (blood1, 2.0f); 

			Vector3 decalPos = coll.collider.transform.position + (Vector3.up * 0.05f);

			Quaternion decalRot = Quaternion.Euler(90, 0, Random.Range(0,360));

			GameObject blood2 = (GameObject) Instantiate(bloodDecal, decalPos, decalRot);

			float scale = Random.Range(1.5f, 3.5f);
			blood2.transform.localScale = Vector3.one * scale;
			blood2.transform.localScale = Vector3.one * 0.75f;

			Destroy(blood2, 5.0f);    

//			GameObject spark = (GameObject) Instantiate(sparkEffect
//				//				, transform.position
//				, hitPoint
//				, Quaternion.identity);
//			Destroy(spark, spark.GetComponent<ParticleSystem>().duration + 0.2f);

			//			Destroy(coll.gameObject);
			gameObject.SetActive(false);
		}
	} 

	private IEnumerator bulletTimer() {
		yield return new WaitForSeconds(2.0f);
		gameObject.SetActive(false);
	} 
}
