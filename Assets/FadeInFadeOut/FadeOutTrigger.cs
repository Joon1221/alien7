using UnityEngine;
using System.Collections;

public class FadeOutTrigger : MonoBehaviour {

	public GameObject _2DPanel;
	public bool turnOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// when isTriiger of the collider is off
//	void OnCollisionEnter(Collision coll)
//	{
//		Debug.Log ("FadeOutTrigger::OnCollisionEnter(): hello1");
//		if (coll.collider.tag == "CUT_SCENE_CAMERA") {
//			//coll.collider.gameObject.SetActive (false);
//			iTweenManager iTweenManagerObj = (iTweenManager)coll.collider.gameObject.GetComponent (typeof(iTweenManager));
//			iTweenManagerObj.fadeOutIn ();
//		}
//	}

	// when isTriiger of the collider is on
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "CUT_SCENE_CAMERA") {
			Debug.Log ("FadeOutTrigger::OnCollisionEnter(): turnOn = " + turnOn);
			//coll.collider.gameObject.SetActive (false);
			iTweenManager iTweenManagerObj = (iTweenManager)other.gameObject.GetComponent (typeof(iTweenManager));
			iTweenManagerObj.fadeOutIn (_2DPanel, turnOn);
			gameObject.SetActive (false);
		}
	}
}
