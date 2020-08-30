using UnityEngine;
using System.Collections;

public class ZombieManager : MonoBehaviour {

	public bool turn;

	// Use this for initialization
	void Start () {
//		gameObject.GetComponent<Animation> ().Play ("zombie_idle");
		turn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (turn) {
			transform.rotation = transform.rotation * Quaternion.Euler(0.0f, 90.0f * Time.deltaTime, 0.0f); 
		}
	}

	public void hitByBullet () {
		StartCoroutine (hitByBulletAnimation());
	}

	private IEnumerator hitByBulletAnimation() {
//		gameObject.GetComponent<Animation> ().CrossFade ("zombie_reaction_hit");
//
		turn = true;
		yield return new WaitForSeconds(1.5f);
//
//		gameObject.GetComponent<Animation> ().CrossFade ("zombie_idle", 0.5f);
	} 

	void OnTriggerEnter (Collider other) {
//		gameObject.GetComponent<Animator> ().enabled = false;
		turn = true;
		StartCoroutine ("zombieTurnStop");
	}

	private IEnumerator zombieTurnStop() {
		yield return new WaitForSeconds(2.0f);

		turn = false;
	}
}
