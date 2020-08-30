using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	public GameObject parent;
	Animator animator;
//	Color startcolor;
	Shader startShader;

	// Use this for initialization
	void Start () {
		animator = parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnMouseDown () {
		animator.SetBool ("open", !animator.GetBool ("open"));
	}

	void OnMouseEnter() {
//		startcolor = GetComponent<Renderer>().material.color;
//		GetComponent<Renderer>().material.color = Color.red;
		startShader = GetComponent<Renderer>().material.shader;
//		GetComponent<Renderer>().material.shader = Shader.Find("FX/Flare");
//		GetComponent<Renderer>().material.shader = Shader.Find("Toon/Lit Outline");
//		GetComponent<Renderer>().material.shader = Shader.Find("Standard");
//		GetComponent<Renderer>().material.color = Color.red;
		GetComponent<Renderer>().material.SetColor("_Color", Color.red);
		Debug.Log("DoorTrigger::OnMouseEnter()");
	}

	void OnMouseExit() {
//		GetComponent<Renderer>().material.color = startcolor;
//		GetComponent<Renderer>().material.shader = startShader;
		Debug.Log("DoorTrigger::OnMouseExit()");
	}
}
