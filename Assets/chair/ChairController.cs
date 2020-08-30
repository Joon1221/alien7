using UnityEngine;
using System.Collections;

public class ChairController : MonoBehaviour {

	public Material[] mats;

	// Use this for initialization
	void Start () {
		int idx = Random.Range (0, mats.Length);
		GetComponentInChildren<MeshRenderer> ().material = mats[idx];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
