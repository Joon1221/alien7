using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GUIManager : MonoBehaviour {

	public Light myLight;
	public Light myFlashLight;

	public bool map_01_on;
	public GameObject map_01;

	public UISlider hpBar;

	public GameObject WorldObject;
//	public Camera worldCamera;
	public Camera uiCamera;
	public UIRoot uiRoot;

	// for OnLoginBtnClick()
	public UIInput uiInputID;
	public UIInput uiInputPwd;

	public GameObject loginArea;

//	public GameObject unityChan;
	public Camera[] worldCamera;

	public AudioSource[] audioSources;
	public string curSoundSourceName;
	public string nextSoundSourceName;

	// Use this for initialization
//	void Start() {
	void Awake()
	{
//		myLight = GetComponent<Light>();
		myLight.enabled = false;
		myFlashLight.enabled = false;

		map_01_on = false;
		map_01.SetActive(map_01_on);

		hpBar.sliderValue = 1.0F; // min: 0.0F - max: 1.0F

//		turnOnCameraUnityChan();
//		turnOnCameraLobby01a();
		turnOnCameraRoom01a ();

		audioSources = gameObject.GetComponents<AudioSource> ();
		curSoundSourceName = null;
		nextSoundSourceName = null;
		turnOffAllSoundSources ();
//		turnOnSoundSource ("bgm_01");
//		turnOnSoundSource ("intro_01");

//		Debug.Log (Application.loadedLevel);
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.F)) {
			OnFlashLightBtnClick();
		}
		if (Input.GetKeyDown(KeyCode.M)) {
			OnMapBtnClick();
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			hpBar.sliderValue += 0.1F;
		
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			hpBar.sliderValue -= 0.1F;
		}

		//this is your object that you want to have the UI element hovering over
//		GameObject WorldObject;

		//this is the ui element
//		RectTransform UI_Element;
		//first you need the RectTransform component of your canvas
//		RectTransform CanvasRect=Canvas.GetComponent<RectTransform>();

		//then you calculate the position of the UI element
		//0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

		Vector3 ViewportPosition=worldCamera[0].WorldToViewportPoint(WorldObject.transform.position);
//		Vector2 WorldObject_ScreenPosition=new Vector2(
//			((ViewportPosition.x*CanvasRect.sizeDelta.x)-(CanvasRect.sizeDelta.x*0.5f)),
//			((ViewportPosition.y*CanvasRect.sizeDelta.y)-(CanvasRect.sizeDelta.y*0.5f)));

		//now you can set the position of the ui element
		//UI_Element.anchoredPosition=WorldObject_ScreenPosition;
		hpBar.transform.position = new Vector3 (ViewportPosition.x * (1024.0F / 768.0F), ViewportPosition.y, 0);
//		hpBar.transform.position = uiCamera.ScreenToWorldPoint(ViewportPosition);
//		hpBar.transform.position = ViewportPosition;

//		hpBar.transform.position = new Vector3 (0.0F, 0.0F, hpBar.transform.position.z);

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Mouse is down");

			RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
//				hitInfo.transform.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("FX/Flare");
				hitInfo.transform.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

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
		}
	}

	void OnMapBtnClick() {
		Debug.Log("Map");
		map_01_on = !map_01_on;
		map_01.SetActive(map_01_on);
	}

	void OnFlashLightBtnClick() {
		Debug.Log("Flash Light");
		myFlashLight.enabled = !myFlashLight.enabled;
	}

	void OnLoginBtnClick() {
		Debug.Log("ID       : " + uiInputID.text);
		Debug.Log("Password : " + uiInputPwd.text);
		StartCoroutine(RequestURL());
	}

	IEnumerator RequestURL() {
		Debug.Log("hello1");
		string postScoreURL = "http://localhost:8080/space_invaders_server/SpaceInvadersServer";
		//string postScoreURL = "http://localhost:8080/test/Test1";
		string jsonString = "{\"operation\":\"login\",\"id\":\"" + uiInputID.text + "\",\"pwd\":\"" + uiInputPwd.text + "\",\"message\":\"\"}";
		//string jsonString = "";

		UTF8Encoding encoding = new UTF8Encoding();
		Dictionary<string, string> postHeader = new Dictionary<string, string>();

		postHeader.Add("Content-type", "text/json; charset=utf-8");
		//postHeader.Add("Content-type", "application/json; charset=utf-8");
		postHeader.Add("Content-Length", (string)(""+jsonString.Length));

		Debug.Log("jsonString: " + jsonString);

		WWW request = new WWW(postScoreURL, encoding.GetBytes(jsonString), postHeader);
		//WWW request = new WWW(postScoreURL);

		yield return request;

		// Print the error to the console
		if (request.error != null)
		{
			Debug.Log("request error: " + request.error);
		}
		else
		{
			Debug.Log("request success");
			Debug.Log("returned data" + request.text);
			loginArea.SetActive(false);
		}

		Debug.Log("hello2");
	}

//	void turnOnCameraUnityChan() {
//		turnOffAllCameras();
//		unityChan.SetActive(true);
//	}

	public void turnOnCameraLobby01a() {
//		unityChan.SetActive(false);
		turnOnCamera(0);
	}

	public void turnOnCameraRoom01a() {
//		unityChan.SetActive(false);
		turnOnCamera(1);
	}

	public void turnOnCamera(int index) {
		turnOffAllCameras();
		worldCamera[index].enabled = true;
	}

	public void turnOffAllCameras() {
		for (int i = 0; i < worldCamera.Length; i++) {
			worldCamera [i].enabled = false;
		}
	}

	public void turnOnSoundSource(string soundSourceName) {
		for (int i = 0; i < audioSources.Length; i++) {
//			Debug.Log( audioSources[i].clip.name );
			if (audioSources[i].clip.name == soundSourceName) {
				audioSources [i].enabled = true;
				curSoundSourceName = soundSourceName;
			}
		}
	}

	public void turnOffSoundSource(string soundSourceName) {
		for (int i = 0; i < audioSources.Length; i++) {
			//			Debug.Log( audioSources[i].clip.name );
			if (audioSources[i].clip.name == soundSourceName) {
				audioSources [i].enabled = false;
			}
		}
	}

	public void turnOffAllSoundSources() {
		for (int i = 0; i < audioSources.Length; i++) {
			//			Debug.Log( audioSources[i].clip.name );
			audioSources [i].enabled = false;
		}
	}

	public void fadeOutCurSoundSource(string nextSoundSourceName) {
		this.nextSoundSourceName = nextSoundSourceName;
		if (curSoundSourceName != null) {
			IEnumerator fadeSound1 = FadeOutSoundSource (curSoundSourceName, 4.0f);
			StartCoroutine (fadeSound1);
		}
	}

	public IEnumerator FadeOutSoundSource (string soundSourceName, float FadeTime) {
		AudioSource audioSource = null;
		for (int i = 0; i < audioSources.Length; i++) {
			//			Debug.Log( audioSources[i].clip.name );
			if (audioSources[i].clip.name == soundSourceName) {
				audioSource = audioSources[i];
				break;
			}
		}

		if (audioSource == null) {
			Debug.Log ("GUIManager::FadeOutSoundSource: error: no such clip name: " + soundSourceName);
			Application.Quit();
		}

		float startVolume = audioSource.volume;

		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

			yield return null;
		}

		audioSource.Stop ();
		audioSource.volume = startVolume;

		if (nextSoundSourceName != null && nextSoundSourceName != "") {
			AudioSource nextAudioSource = null;

			for (int i = 0; i < audioSources.Length; i++) {
				if (audioSources[i].clip.name == nextSoundSourceName) {
					nextAudioSource = audioSources[i];
					break;
				}
			}

			if (nextAudioSource == null) {
				Debug.Log ("GUIManager::FadeOutSoundSource: error: no such next clip name: " + nextSoundSourceName);
				Application.Quit();
			}

			nextAudioSource.enabled = true;

			curSoundSourceName = nextSoundSourceName;
			nextSoundSourceName = null;
		}
	}

	public void nextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
