using UnityEngine;
using System.Collections;

public class door_pivot : MonoBehaviour {
	private bool open;
	Animator animator;
//	private bool animationDone;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
//		animationDone = false;
	}
	
	// Update is called once per frame
	void Update () {
//		if (!animationDone) {
//			animator.SetBool ("open", true);
//
//			animationDone = true;
//		}
	}
}
