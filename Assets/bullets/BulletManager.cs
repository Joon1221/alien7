using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {
	public const int MAX_NUM_BULLETS = 50;

	public int maxNumBullets = MAX_NUM_BULLETS;
	public GameObject[] bullets;

	// Use this for initialization
	void Start () {
		UnityEngine.Object bulletPrefab = Resources.Load("Bullet"); // note: not .prefab!
		Debug.Log("BulletManager::Start(): bulletPrefab = " + bulletPrefab);
		if (bulletPrefab == null) {
			Application.Quit ();
		}

		bullets = new GameObject[maxNumBullets];
		for (int i = 0; i < bullets.Length; i++) {
			bullets[i] = (GameObject)GameObject.Instantiate(bulletPrefab, new Vector3(0, 0, 0), Quaternion.identity);
			bullets[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject getAvailableBullet() {
		for (int i = 0; i < bullets.Length; i++) {
			if (!bullets[i].activeSelf) {
				return bullets[i];
			}
		}
		return null;
	}
}
