using UnityEngine;
using System.Collections;

public class PanelOffTrigger : MonoBehaviour {

	public GameObject _2DPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "CUT_SCENE_CAMERA") {
			StartCoroutine("turnOffPanel");
		}
	}

	private IEnumerator turnOffPanel() {
		yield return new WaitForSeconds(4f);

		_2DPanel.SetActive(false);
	} 
}
