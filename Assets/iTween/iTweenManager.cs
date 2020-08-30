using UnityEngine;
using System.Collections;

public class iTweenManager : MonoBehaviour {

	public Transform[] waypointArray;
	public float percentsPerSecond; // = 0.2f; // %2 of the path moved per second
	public float startPathPercent; // path start percentage
	float currentPathPercent = 0.0f; //min 0, max 1

	public GameObject objectToLookAt; 

	public GameObject titleAlien7Panel;

	public GameObject _2DPanel;
	bool tempFlag = false;

	public bool continueLoop = false;
	public GUIManager guiManager;

	public bool escapeFlag = false;

	// Use this for initialization
	void Start () {
		tempFlag = false;

		// fade out
		//        CameraFade.StartAlphaFade( Color.white, false, 5f, 2f, () => { Application.LoadLevel(1); } );
		//        CameraFade.StartAlphaFade( Color.black, false, 5f, 2f, () => { Application.LoadLevel(1); } );
		// fade in
		//        CameraFade.StartAlphaFade( Color.white, true, 5f, 2f, () => { Application.LoadLevel(1); } );
		CameraFade.StartAlphaFade( Color.black, true, 3f, 5f, () => { } );
//		CameraFade.StartAlphaFade( Color.black, false, 3f, 7f, () => {
//			_2DPanel.SetActive(false);
//			tempFlag = true;
//		} );
//		StartCoroutine (deleteInstanceCameraFade());

		currentPathPercent = startPathPercent;

		guiManager.turnOnSoundSource ("intro_01");
	}

//	private IEnumerator deleteInstanceCameraFade() {
//		yield return new WaitForSeconds(7f);
//
//		//        Destroy (CameraFade.mInstance.gameObject);
//		//        CameraFade.mInstance = null;
//
//		CameraFade.StartAlphaFade( Color.black, false, 5f, 2f, () => { Application.LoadLevel(1); } );
//	
////		StartCoroutine (deleteInstanceCameraFade2());
//	}  

//	private IEnumerator deleteInstanceCameraFade2() {
//		CameraFade.StartAlphaFade( Color.black, false, 5f, 2f, () => { Application.LoadLevel(1); } );
//
//		//        Destroy (CameraFade.mInstance.gameObject);
//		//        CameraFade.mInstance = null;
//
//		titleAlien7Panel.SetActive (false);
//	}  

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape)) {
			escapeFlag = true;
		}

		if (escapeFlag) {
			escapeFlag = false;
			guiManager.turnOnCameraLobby01a ();
			_2DPanel.SetActive (false);
			guiManager.fadeOutCurSoundSource("bgm_01");
			gameObject.SetActive (false);
		}

		if (tempFlag) {
			tempFlag = false;
			CameraFade.StartAlphaFade( Color.black, true, 2f, 2f, () => { } );
		}

		currentPathPercent += percentsPerSecond * Time.deltaTime;

		if (currentPathPercent >= 1.0f) {
			if (continueLoop) {
				currentPathPercent = startPathPercent;

				for (int i = 0; i < waypointArray.Length; i++) {
					Transform curFadeOutTrigger = waypointArray [i].Find ("FadeOutTrigger");
					if (curFadeOutTrigger != null) {
						curFadeOutTrigger.gameObject.SetActive (true);
					}
				}
			}
			else {
				guiManager.turnOnCameraLobby01a ();
				_2DPanel.SetActive (false);
				CameraFade.StartAlphaFade( Color.black, true, 2f, 2f, () => { } );
				guiManager.fadeOutCurSoundSource("bgm_01");
				gameObject.SetActive (false);
			}
		}

		iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
		iTween.PutOnPath(objectToLookAt, waypointArray, currentPathPercent + 0.02f);
		transform.LookAt (objectToLookAt.transform);

		//		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("test"), "time", 20)); 
		//		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("spaceshipPath"), "axis", "z", "time", 20, "orienttopath", true)); 
	
	}
	 
	void OnDrawGizmos()
	{
		//Visual. Not used in movement
		iTween.DrawPath(waypointArray);
	}

	public void fadeIn() {
		CameraFade.StartAlphaFade( Color.black, true, 3f, 5f, () => { Application.LoadLevel(1); } );
	}

	public void fadeOut() {
		CameraFade.StartAlphaFade( Color.black, false, 5f, 2f, () => { Application.LoadLevel(1); } );
	}

	public void fadeOutIn(GameObject _2DPanel, bool turnOn) {
		tempFlag = false;
		this._2DPanel = _2DPanel;

//		StartCoroutine (fadeOutInCoroutine());
//		CameraFade.StartAlphaFade( Color.black, false, 5f, 2f, () => {} );
//		CameraFade.StartAlphaFade( Color.black, false, 3f, 7f, () => {
		CameraFade.StartAlphaFade( Color.black, false, 3f, 0f, () => {
			if (_2DPanel != null) {
				_2DPanel.SetActive(turnOn);
			}
			tempFlag = true;
		} );
	}

//	private IEnumerator fadeOutInCoroutine() {
//		CameraFade.StartAlphaFade( Color.black, false, 5f, 2f, () => { Application.LoadLevel(1); } );
//		yield return new WaitForSeconds(4f);
//	
//		CameraFade.StartAlphaFade( Color.black, true, 2f, 2f, () => { Application.LoadLevel(1); } );
//	}  

}
