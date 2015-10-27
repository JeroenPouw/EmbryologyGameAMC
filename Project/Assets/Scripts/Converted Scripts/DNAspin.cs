using UnityEngine;
using System.Collections;

public class DNAspin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down * Time.deltaTime * 100);
	}
}
