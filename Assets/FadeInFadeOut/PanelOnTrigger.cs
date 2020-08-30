using UnityEngine;
using System.Collections;

public class PanelOnTrigger : MonoBehaviour {

	public GameObject _2DPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "CUT_SCENE_CAMERA") {
			StartCoroutine("turnOnPanel");
		}
	}

	private IEnumerator turnOnPanel() {
		yield return new WaitForSeconds(6f);

		_2DPanel.SetActive(true);
	} 
}
