using UnityEngine;
using System.Collections;

public class StickyBombGunScript : MonoBehaviour 
{
	LineRenderer line;

	public GameObject gunPoint;
	public float hitForce = 100f;
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	private AudioSource Gunshot;

	public GameObject point1;
	public GameObject point2;
	public GameObject point3;
	public Material lineMaterial;

	public GameObject bullet;

//	public MeshRenderer muzzleFlash;

	public Camera gunCamera;

//	public GameObject sphere;

	RaycastHit hitInfoZombie;

	void Start () 
	{
//		muzzleFlash.enabled = false;

		Gunshot = GetComponent<AudioSource>();
		line = gameObject.AddComponent<LineRenderer>();
//		line.enabled = false;
		line.enabled = true;

		line.sortingLayerName = "OnTop";
		line.sortingOrder = 5;
		line.SetVertexCount(2);
//		line.SetPosition(0, point1.transform.position);
//		line.SetPosition(1, point2.transform.position);
//		line.SetPosition(2, point3.transform.position);
		line.SetWidth(0.5f, 0.5f);
		line.useWorldSpace = true;
		line.material = lineMaterial;

	}
	void Update () 
	{
//		if(Input.GetButtonDown("Fire1"))
//		{
//			StopCoroutine("FireLaser");
//			StartCoroutine("FireLaser");
//		}
//	}
//
//	IEnumerator FireLaser()
//	{
		if (Input.GetMouseButtonDown(0))
		{
			bullet.SetActive(true);

			//create new thread 
			StartCoroutine (ShotEffect());
//			StartCoroutine (showMuzzleFlash());

//			line.enabled = true;

			Debug.Log("Mouse is down");
//			Ray ray = new Ray(transform.position, transform.forward);
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//create line from camera position to mouse click position
			Ray ray = gunCamera.ScreenPointToRay(Input.mousePosition);

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(ray, out hitInfo);
//			sphere.transform.position = hitInfo.point;

			StickyBombShooter stickyBombShooter = (StickyBombShooter)bullet.GetComponent (typeof(StickyBombShooter));
			stickyBombShooter.shoot (ray);
			if (hit) 
			{
				if (hitInfo.transform.gameObject.tag == "Zombie")
				{
					hitInfoZombie = hitInfo;
					StartCoroutine ("zombieReactionHitTrigger");

//					ZombieManager zombieManager = (ZombieManager)hitInfo.transform.gameObject.GetComponent (typeof(ZombieManager));
//					zombieManager.hitByBullet ();
				} else {
					Debug.Log ("nopz");
				}
//				line.SetPosition(0, gunPoint.transform.position);
////				line.SetPosition(1, hitInfo.transform.gameObject.transform.position);
//				line.SetPosition(1, hitInfo.point);
//				line.SetWidth(0.2f, 0.2f);
//				line.material = lineMaterial;

//				if(Physics.Raycast(ray, out hitInfo, 100))
//				{
//					Debug.Log("hello2");
//
//					line.SetPosition(1, hitInfo.point);
//					if(hitInfo.rigidbody)
//					{
//						hitInfo.rigidbody.AddForceAtPosition(transform.forward * 10, hitInfo.point);
//					}
//				}
//				else
//					line.SetPosition(1, ray.GetPoint(100));

//				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				//				hitInfo.transform.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("FX/Flare");
				hitInfo.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
				if (hitInfo.rigidbody != null) {
					// Add force to the rigidbody we hit, in the direction from which it was hit
//					hitInfo.rigidbody.AddForce (-hitInfo.normal * hitForce);
					// shoot bullet
//					BulletShooter bulletShooter = (BulletShooter)bullet.GetComponent (typeof(BulletShooter));
//					bulletShooter.shoot (ray);
				} else {
					// shoot bullet
//					BulletShooter bulletShooter = (BulletShooter)bullet.GetComponent (typeof(BulletShooter));
//					bulletShooter.shoot (ray);
				}
				if (hitInfo.transform.gameObject.tag == "Construction")
				{
					Debug.Log ("It's working!");
				} else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}

			Debug.Log("Mouse is down");
//		    yield return null;
		}

//		while(Input.GetButton("Fire1"))
//		{
//			Debug.Log("hello");
//			Ray ray = new Ray(transform.position, transform.forward);
//			RaycastHit hit;
//
//			line.SetPosition(0, ray.origin);
//
//			if(Physics.Raycast(ray, out hit, 100))
//			{
//				Debug.Log("hello2");
//
//				line.SetPosition(1, hit.point);
//				if(hit.rigidbody)
//				{
//					hit.rigidbody.AddForceAtPosition(transform.forward * 10, hit.point);
//				}
//			}
//			else
//				line.SetPosition(1, ray.GetPoint(100));
//
//			yield return null;
//		}
//		line.enabled = false;
	}

	private IEnumerator ShotEffect()
	{
		// Play the shooting sound effect
		Gunshot.Play ();

		// Turn on our line renderer
		line.enabled = true;

		//Wait for .07 seconds
		//same as sleep
		yield return shotDuration;

		// Deactivate our line renderer after waiting
		line.enabled = false;
	}

//	private IEnumerator showMuzzleFlash() {
//		muzzleFlash.transform.position = gunPoint.transform.position;
//		float scale = Random.Range (1.0f, 2.0f);
//		muzzleFlash.transform.localScale = Vector3.one * scale;
//
//		Quaternion rot = Quaternion.Euler (0, 0, Random.Range (0, 360));
//		muzzleFlash.transform.localRotation = rot;
//
//		muzzleFlash.enabled = true;
//
//		yield return new WaitForSeconds(Random.Range(0.01f, 0.05f));
//
//		muzzleFlash.enabled = false;
//	} 
//
//	private IEnumerator zombieReactionHitTrigger() {
//		yield return new WaitForSeconds(0.25f);
//
//		hitInfoZombie.transform.gameObject.GetComponent<Animator>().SetTrigger ("isHit");
//	} 
}
