using UnityEngine;
using System.Collections;

public class HPBarManager : MonoBehaviour {

	public Camera mainCamera;
	public GameObject hpBar;
	public Vector3 hpBarOriginalLocalScale;
	public GameObject zombie;

	// Use this for initialization
	void Start () {
		hpBarOriginalLocalScale = hpBar.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		if (zombie.gameObject.GetComponent<Renderer>().isVisible) {
			Debug.Log ("Zombie is visible");
			hpBar.SetActive(true);
		}
		else {
			Debug.Log ("Zombie is not visible");
			hpBar.SetActive(false);
		}
		//		hpBar.enabled = (zombie.gameObject.GetComponent<Renderer>().isVisible);

		Vector3 localPos = mainCamera.WorldToViewportPoint(gameObject.transform.position);
		hpBar.transform.localPosition = new Vector3 (localPos.x * (1024f) - 512f, localPos.y * (768f) - 384f, 0f);

		float dist = Vector3.Distance (mainCamera.transform.position, gameObject.transform.position);

		float curScale = 0.0f;
		if (dist >= 1.0f && dist <=20f) {
			curScale = 2.0f / dist;
		}
		else if (dist < 1.0f) {
			curScale = 2.0f;
		}

		hpBar.transform.localScale = new Vector3 (hpBarOriginalLocalScale.x * curScale, hpBarOriginalLocalScale.y * curScale, hpBarOriginalLocalScale.z * curScale);
	}	
}	
